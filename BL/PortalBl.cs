using AutoMapper;
using DL;
using DTO;
using Entities;
using LazyCache;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BL
{
    public class PortalBl:IPortalBl
    {
        IUserBl ubl;
        IPortalDl pdl;
        IUserInGroupBl uigbl;
        IWeightBl wbl;
        private readonly IAppCache _lazyCache = new CachingService();
        IMapper mapper;
        public PortalBl(IPortalDl pdl, IUserBl ubl,IUserInGroupBl uigbl, IWeightBl wbl,IMapper mapper, IAppCache cache)
        {
            this.pdl = pdl;
            this.ubl = ubl;
            this.uigbl = uigbl;
            this.wbl = wbl;
            this.mapper = mapper;
            _lazyCache = cache;
        }

        public string a(int a)
        {
            return "";
        }

        public async Task<GroupDetails> getGroupDetails(int groupId)
        {
            //mapper.Map<UserWithKg>(ubl.GetAllUsers(groupId).Result);
            KeyValuePair<List<int>, double?> WeeklyGroupWinner;
            if (DateTime.Now.DayOfWeek != DayOfWeek.Sunday)
            {
                WeeklyGroupWinner = await _lazyCache.GetOrAddAsync("WeeklyGroupWinner",
                    async () =>
                {
                    return await wbl.GetWeeklyGroupWinner(groupId);
                }, DateTimeOffset.Now.AddDays(7));

            }
            else
            {

                WeeklyGroupWinner = await wbl.GetWeeklyGroupWinner(groupId);
                _lazyCache.Add("WeeklyGroupWinner", WeeklyGroupWinner, DateTimeOffset.Now.AddDays(7));
            }
            List<UserWithKg> USERS =await ubl.GetUsersWithKg(groupId);
            if (USERS == null)
                USERS = uigbl.GetAllUsers(groupId).Result.
                   Select(u => new UserWithKg
                   {
                       Name = u.FirstName,
                       Id = u.Id,
                       Kg = null
                   }).ToList();
            else
            {
                 return new GroupDetails
                                {
                                    Userswithkg = USERS,
                                    Sentedmesseges = await pdl.getMesseges(groupId),
                                    WeeklyGroupWinner = WeeklyGroupWinner
                 };
            }
               
            return new GroupDetails();
        }


        public async Task<int> AddMessege(SentedMessege m)
        {
            return await pdl.AddMessege(m);
        }
    }
}
