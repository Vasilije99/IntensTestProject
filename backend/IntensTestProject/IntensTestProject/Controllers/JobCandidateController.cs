using AutoMapper;
using IntensTestProject.Dtos;
using IntensTestProject.Interfaces;
using IntensTestProject.Modles;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntensTestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobCandidateController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public JobCandidateController(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var candidates = await uow.JobCandidateRepository.GetCandidatesAsync();
            var candidatesDto = mapper.Map<List<CandidatesDto>>(candidates);
            return Ok(candidatesDto);
        }

        [HttpGet("getCandidate/{id}")]
        public async Task<IActionResult> GetCandidate(int id)
        {
            var candidate = await uow.JobCandidateRepository.FindCandidate(id);
            var candidateDto = mapper.Map<CandidateDto>(candidate);
            return Ok(candidateDto);
        }
        
        [HttpPost("addCandidate")]
        public async Task<IActionResult> AddCandidate(CandidateDto candidateDto)
        {
            if (await uow.JobCandidateRepository.CandidateAlreadyExists(candidateDto.Email))
                return BadRequest("Candidate already exists");
            if (CheckFieldsAreEmpty(candidateDto.FullName, candidateDto.Email, candidateDto.DateOfBirth, candidateDto.ContactNumber))
                return BadRequest("Some fields are empty");

            uow.JobCandidateRepository.AddJobCandidate(candidateDto.FullName, candidateDto.Email, candidateDto.ContactNumber, candidateDto.DateOfBirth);
            
            await uow.SaveAsync();
            return StatusCode(201);
        }
        
        [HttpPut("updateCandidate/{id}")]
        public async Task<IActionResult> UpdateCandidate(int id, CandidateDto candidateDto)
        {
            try
            {
                var candidate = await uow.JobCandidateRepository.FindCandidate(id);

                if (CheckFieldsAreEmpty(candidateDto.FullName, candidateDto.Email, candidateDto.DateOfBirth, candidateDto.ContactNumber))
                    return BadRequest("Some fields are empty");
                mapper.Map(candidateDto, candidate);

                await uow.SaveAsync();
                return StatusCode(200);
            }
            catch
            {
                return BadRequest("Candidate with this ID does not exist");
            }
        }
        
        [HttpDelete("removeCandidate/{id}")]
        public async Task<IActionResult> RemoveCandidate(int id)
        {
            uow.JobCandidateRepository.RemoveCandidate(id);
            await uow.SaveAsync();
            return Ok(id);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchCandidate(string text)
        {
            List<JobCandidate> candidates = await uow.JobCandidateRepository.SearchCandidate(text);
            List<CandidatesDto> candidatesDto = new List<CandidatesDto>();
            if (candidates.Count == 0)
            {
                var skill = await uow.SkillRepository.FindSkillId(text);
                if(skill != null)
                {
                    var candidateSkills = await uow.CandidateSkillsRepository.GetCandidateIdBySkillId(skill.Id);
                    if(candidateSkills.Count > 0)
                    {
                        for(int i = 0; i < candidateSkills.Count; i++)
                        {
                            var candidate = await uow.JobCandidateRepository.FindCandidate(candidateSkills[i].CandidateId);

                            candidates.Add(candidate);
                        }

                        candidatesDto = mapper.Map<List<CandidatesDto>>(candidates);
                        return Ok(candidatesDto);
                    }
                    return Ok();
                }
                return Ok();
            }
            candidatesDto = mapper.Map<List<CandidatesDto>>(candidates);
            return Ok(candidatesDto);
        }

        private bool CheckFieldsAreEmpty(string name, string email, DateTime date, string contact)
        {
            return name.Length == 0 ||
                   email.Length == 0 ||
                   date.ToString().Length == 0 ||
                   contact.Length == 0;
        }
    }
}
