using AutoMapper;
using IntensTestProject.Dtos;
using IntensTestProject.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntensTestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public SkillController(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
        
        [HttpPost("addSkill")]
        public async Task<IActionResult> AddNewSkill(AddSkillDto addSkillDto)
        {
            if (await uow.SkillRepository.SkillAlreadyExists(addSkillDto.Name))
                return BadRequest("Skill already exists");
            if (addSkillDto.Name.Length == 0)
                return BadRequest("Name field are empty");

            uow.SkillRepository.AddNewSkill(addSkillDto.Name);
            
            await uow.SaveAsync();
            return StatusCode(201);
        }
        
        
        [HttpGet("getSkills")]
        public async Task<IActionResult> GetSkills()
        {
            var skills = await uow.SkillRepository.GetSkillsAsync();
            var skillsDto = mapper.Map<List<SkillDto>>(skills);
            return Ok(skillsDto);
        }
    }
}