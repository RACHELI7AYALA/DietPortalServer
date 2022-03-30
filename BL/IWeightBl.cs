using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IWeightBl
    {
        public  Task<int> AddWeight(Weight w);
        public Task<KeyValuePair<List<int>, double?>> GetWeeklyWinnerGroup();

        public Task<KeyValuePair<List<int>, double?>> GetWeeklyWinner();

        public Task<KeyValuePair<List<int>, double?>> GetWeeklyGroupWinner(int id);


        public Task<List<Weight>> GetProgress(int userId);


    }
}