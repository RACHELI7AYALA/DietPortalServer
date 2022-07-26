using DTO;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{

    public class WeightDl : IWeightDl
    {
        ProjectDBContext dbContext;
        IUserDl udl;
        public WeightDl(ProjectDBContext dbContext, IUserDl udl)
        {
            this.dbContext = dbContext;
            this.udl = udl;
        }
        public async Task<int> AddWeight(Weight w)
        {
            await dbContext.Weights.AddAsync(w);
            return await dbContext.SaveChangesAsync();

        }
        public async Task<Dictionary<int, double?>> GetWeeklyWinnerGroup()
        {
            DateTime today = DateTime.Today;
            return await dbContext.Weights/*.Where(w => w.Date.AddDays(7) >= today)*/
                       .GroupBy(w => w.GroupId).Select(g => new { id = g.Key, s = g.Sum(u => u.Kg) }).ToDictionaryAsync(g => g.id, g => g.s);

        }
        public async Task<Dictionary<int, double?>> GetWeeklyWinner()
        {
            DateTime today = DateTime.Today;
            return await dbContext.Weights.Where(w => w.Date.AddDays(7) >= today)
                 .Select(u => new { id = u.UserId, w = u.Kg }).ToDictionaryAsync(u => u.id, u => u.w);

        }
        public async Task<Dictionary<int, double?>> GetWeeklyGroupWinner(int id)
        {
            DateTime today = DateTime.Today;
            return await dbContext.Weights.Where(w => /*w.Date.AddDays(7) >= today &&*/ w.GroupId == id)
                .Select(u => new { id = u.UserId, w = u.Kg }).ToDictionaryAsync(u => u.id, u => u.w);

        }
        public async Task<List<Weight>> GetProgress(int userId, int groupId)
        {

            return await dbContext.Weights.Where(w => w.UserId == userId && w.GroupId == groupId)
                .OrderBy(w => w.Date).ToListAsync();

        }
        public async Task<KeyValuePair<List<int>, double?>> GetGroupWinner(int id)
        {

            //List<UserWithKg> users = await udl.GetAllUsersWithKg(id);

            //var winner = users.GroupBy(item => item.Name)
            //.Select(group => new { user = group.Key, weight = group.Sum(item => item.Kg) })
            //.ToList();

            //KeyValuePair<List<int>, double?> l = users.Where(u => u.Name == winner.Max(u1 => u1.weight).);

             KeyValuePair<List<int>, double?> l= new KeyValuePair<List<int>, double?>();
             return l;

        }


    }
}