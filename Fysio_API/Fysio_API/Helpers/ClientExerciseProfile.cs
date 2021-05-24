using AutoMapper;
using Fysio_API.Dto;
using Fysio_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fysio_API.AutoMappers
{
    public class ClientExerciseProfile : Profile
    {
        public ClientExerciseProfile()
        {
            CreateMap<ClientExerciseDto_In, ClientExercise>();
        }
    }
}
