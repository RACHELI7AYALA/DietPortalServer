using AutoMapper;
using DTO;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BL
{
    public class AutoMapping: Profile
    {
        public AutoMapping()
        {
           
            CreateMap<Weight, UserWithKg>();

        }
    }
}
