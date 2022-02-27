using AutoMapper;
using IntensTestProject.Dtos;
using IntensTestProject.Interfaces;
using IntensTestProject.Modles;
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
    public class CandidateSkillsController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public CandidateSkillsController(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        [HttpGet("getCandidateSkills/{id}")]
        public async Task<IActionResult> GetCandidateSkills(int id)
        {
            try
            {
                var skillIds = await uow.CandidateSkillsRepository.GetSkillIdsAsync(id);
                var skills = new List<Skill>();
                for(int i = 0; i < skillIds.Count; i++)
                {
                    skills.Add(await uow.SkillRepository.FindSkill(skillIds[i]));
                }

                var skillsDto = mapper.Map<List<SkillDto>>(skills);

                return Ok(skillsDto);
            }
            catch
            {
                return BadRequest("Candidate with this ID does not exists");
            }
        }

        [HttpDelete("removeSkill/{candidateId}/{skillId}")]
        public async Task<IActionResult> RemoveCandidateSkill(int candidateId, int skillId)
        {
            uow.CandidateSkillsRepository.RemoveCandidateSkill(candidateId, skillId);
            await uow.SaveAsync();

            return Ok(skillId);
        }

        [HttpPost("addCandidateSkill/{candidateId}")]
        public async Task<IActionResult> AddCandidateSkill(int skillId, int candidateId)
        {
            if(await uow.CandidateSkillsRepository.FindSkillByCandidateId(candidateId, skillId))
                return BadRequest("Candidate already has this skill");

            uow.CandidateSkillsRepository.AddNewCandidateSkill(candidateId, skillId);
            await uow.SaveAsync();
            return StatusCode(200);
        }
    }
}
