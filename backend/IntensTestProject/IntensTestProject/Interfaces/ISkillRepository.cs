using IntensTestProject.Modles;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntensTestProject.Interfaces
{
    public interface ISkillRepository
    {
        Task<bool> SkillAlreadyExists(string name);
        void AddNewSkill(string name);
        Task<List<Skill>> GetSkillsAsync();
        Task<Skill> FindSkill(int id);
        Task<Skill> FindSkillId(string name);
    }
}
