using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using BusinessLogic.Entities;
using BusinessLogic;
using AutoMapper;

namespace WebAPI.MappingConfig
{
    public class MappConfiguration
    {
        public MappConfiguration()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<DepartmentBL, Department>());
            var mapper = new Mapper(config);
        }
    }
}
