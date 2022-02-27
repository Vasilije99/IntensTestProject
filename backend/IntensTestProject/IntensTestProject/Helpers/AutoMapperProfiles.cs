using AutoMapper;
using IntensTestProject.Dtos;
using IntensTestProject.Modles;
using System.Collections.Generic;

namespace IntensTestProject.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<JobCandidate, CandidatesDto>().ReverseMap();
            CreateMap<JobCandidate, CandidateDto>().ReverseMap();
            CreateMap<Skill, SkillDto>().ReverseMap();
            CreateMap<SkillDto, List<string>>();
        }
    }
}
