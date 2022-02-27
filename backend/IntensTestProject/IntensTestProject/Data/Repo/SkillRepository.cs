using IntensTestProject.Interfaces;
using IntensTestProject.Modles;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntensTestProject.Data.Repo
{
    public class SkillRepository : ISkillRepository
    {
        private readonly DataContext dc;

        public SkillRepository(DataContext dc)
        {
            this.dc = dc;
        }

        public void AddNewSkill(string name)
        {
            Skill skill = new Skill();
            skill.Name = name;

            dc.Skills.Add(skill);
        }

        public async Task<Skill> FindSkill(int id)
        {
            return await dc.Skills.FindAsync(id);
        }

        public async Task<Skill> FindSkillId(string name)
        {
            return await dc.Skills.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<List<Skill>> GetSkillsAsync()
        {
            return await dc.Skills.Distinct().ToListAsync();
        }

        public async Task<bool> SkillAlreadyExists(string name)
        {
            return await dc.Skills.AnyAsync(x => x.Name == name);
        }
    }
}
