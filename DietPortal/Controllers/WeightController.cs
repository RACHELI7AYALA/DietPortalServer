using BL;
using Entities;
using LazyCache;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietPortal.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class WeightController : Controller
    {
        IWeightBl wbl;
        private readonly IAppCache _lazyCache = new CachingService();
        public WeightController(IWeightBl wbl, IAppCache cache)
        {
            _lazyCache = cache;
            this.wbl = wbl;
        }

        [HttpPost]
        public async Task<int> AddWeight([FromBody] Weight w)
        {

            return await wbl.AddWeight(w);



        }
        [HttpGet("WeeklyWinnerGroup")]

        public async Task<KeyValuePair<List<int>, double?>> GetWeeklyWinnerGroup()
        {
            if (DateTime.Now.DayOfWeek != DayOfWeek.Sunday)
            {
                var data = await _lazyCache.GetOrAddAsync("GetWeeklyWinnerGroup", wbl.GetWeeklyWinnerGroup, DateTimeOffset.Now.AddDays(7));
                return data;
            }

            KeyValuePair<List<int>, double?> WeeklyWinnerGroup = await wbl.GetWeeklyWinnerGroup();
            _lazyCache.Add("GetWeeklyWinnerGroup", WeeklyWinnerGroup, DateTimeOffset.Now.AddDays(7));
            return WeeklyWinnerGroup;

        }
        [HttpGet("WeeklyWinner")]

        public async Task<KeyValuePair<List<int>, double?>> GetWeeklyWinner()
        {
            //if (DateTime.Now.DayOfWeek != DayOfWeek.Sunday)
            //{
            //    var data = await _lazyCache.GetOrAddAsync("WeeklyWinner", wbl.GetWeeklyWinner, DateTimeOffset.Now.AddDays(7));
            //    return data;
            //}

            KeyValuePair<List<int>, double?> WeeklyWinner = await wbl.GetWeeklyWinner();
            //_lazyCache.Add("WeeklyWinner", wbl.GetWeeklyWinner(), DateTimeOffset.Now.AddDays(7));
            return WeeklyWinner;

        }
        [HttpGet("User/{userId}")]

        public async Task<List<Weight>> GetProgress(int userId)
        {
            List<Weight> w = await wbl.GetProgress(userId);
            return w;

        }
        //[HttpGet]
        //public async Task<KeyValuePair<List<int>, double?>> getCash()
        //{
        //    if (DateTime.Now.DayOfWeek != DayOfWeek.Sunday)
        //    {
        //        var data = await _lazyCache.GetOrAddAsync("GetWeeklyWinnerGroup", GetWeeklyWinnerGroup, DateTimeOffset.Now.AddDays(7));
        //        return data;
        //    }

        //        KeyValuePair<List<int>, double?> WeeklyWinnerGroup = await GetWeeklyWinnerGroup();
        //        _lazyCache.Add("GetWeeklyWinnerGroup", WeeklyWinnerGroup, DateTimeOffset.Now.AddDays(7));
        //        return WeeklyWinnerGroup;

        //}

    } 
}
