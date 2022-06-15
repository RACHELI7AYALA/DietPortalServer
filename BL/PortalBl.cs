using AutoMapper;
using DL;
using DTO;
using Entities;
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
        IMapper mapper;
        public PortalBl(IPortalDl pdl, IUserBl ubl,IUserInGroupBl uigbl, IWeightBl wbl,IMapper mapper)
        {
            this.pdl = pdl;
            this.ubl = ubl;
            this.uigbl = uigbl;
            this.wbl = wbl;
            this.mapper = mapper;
        }

        public async Task<GroupDetails> getGroupDetails(int groupId)
        {
         //mapper.Map<UserWithKg>(ubl.GetAllUsers(groupId).Result);

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
                                    WeeklyGroupWinner = await wbl.GetWeeklyGroupWinner(groupId)
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
