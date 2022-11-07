using AutoMapper;
using ChallengeFS.Models;
using ChallengeFS.Models.DTOs;

namespace ChallengeFS.API.Utils
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ToDoCreateDto, ToDo>();
            CreateMap<ToDoUpdateDto, ToDo>();
        }
    }
}
