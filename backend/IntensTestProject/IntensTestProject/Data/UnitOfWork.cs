using IntensTestProject.Data.Repo;
using IntensTestProject.Interfaces;
using System.Threading.Tasks;

namespace IntensTestProject.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext dc;

        public UnitOfWork(DataContext dc)
        {
            this.dc = dc;
        }

        public IJobCandidateRepository JobCandidateRepository =>
            new JobCandidateRepository(dc);

        public ISkillRepository SkillRepository =>
            new SkillRepository(dc);

        public ICandidateSkillsRepository CandidateSkillsRepository =>
            new CandidateSkillsRepository(dc);

        public async Task<bool> SaveAsync()
        {
            return await dc.SaveChangesAsync() > 0;
        }
    }
}
