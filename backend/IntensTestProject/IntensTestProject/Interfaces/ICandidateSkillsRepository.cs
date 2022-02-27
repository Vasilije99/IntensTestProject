using IntensTestProject.Modles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntensTestProject.Interfaces
{
    public interface ICandidateSkillsRepository
    {
        Task<List<int>> GetSkillIdsAsync(int candidateId);
        Task<bool> FindSkillByCandidateId(int candidateId, int skillId);
        Task<List<CandidateSkill>> GetCandidateIdBySkillId(int skillId);
        void RemoveCandidateSkill(int candidateId, int skillId);
        void AddNewCandidateSkill(int candidateId, int skillId);
    }
}
