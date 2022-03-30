using AutoMapper;
using DTO;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DL
{
    public class AutoMapping: Profile
    {
        public AutoMapping()
        {

            CreateMap<Weight, UserWithKg>().
                ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.User.Id)).
                  ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.User.FirstName + " " + src.User.LastName)).
                    ForMember(dest => dest.Kg, opts => opts.MapFrom(src => src.Kg));
        }
      
    }
}
