using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YearFive.Data;
using YearFive.Models;

namespace YearFive.Mappings
{
   public class Maps : Profile
        {
            public Maps()
            {
                CreateMap<YearFiveType, YearFiveTypeVM>().ReverseMap();
            }

        }
   
}
