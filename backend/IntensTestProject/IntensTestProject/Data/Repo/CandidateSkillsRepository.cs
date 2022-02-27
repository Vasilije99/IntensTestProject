using IntensTestProject.Interfaces;
using IntensTestProject.Modles;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntensTestProject.Data.Repo
{
    public class CandidateSkillsRepository : ICandidateSkillsRepository
    {
        private readonly DataContext dc;

        public CandidateSkillsRepository(DataContext dc)
        {
            this.dc = dc;
        }

        public void AddNewCandidateSkill(int candidateId, int skillId)
        {
            CandidateSkill candidateSkill = new CandidateSkill();
            candidateSkill.CandidateId = candidateId;
            candidateSkill.SkillId = skillId;

            dc.CandidateSkills.Add(candidateSkill);
        }

        public async Task<List<CandidateSkill>> GetCandidateIdBySkillId(int skillId)
        {
            return await dc.CandidateSkills
                .Where(x => x.SkillId == skillId)
                .ToListAsync();
        }

        public async Task<bool> FindSkillByCandidateId(int candidateId, int skillId)
        {
            return await dc.CandidateSkills
                .Where(x => x.SkillId == skillId)
                .Where(x => x.CandidateId == candidateId)
                .AnyAsync();
        }

        public async Task<List<int>> GetSkillIdsAsync(int candidateId)
        {
            return await dc.CandidateSkills
                .Where(x => x.CandidateId == candidateId)
                .Select(x => x.SkillId)
                .ToListAsync();
        }

        public void RemoveCandidateSkill(int candidateId, int skillId)
        {
            var candidateSkill = dc.CandidateSkills
                                    .FirstOrDefault(x => x.CandidateId == candidateId && x.SkillId == skillId);
            dc.Remove(candidateSkill);
        }
    }
}
