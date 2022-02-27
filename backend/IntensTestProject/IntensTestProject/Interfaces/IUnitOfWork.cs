using System.Threading.Tasks;

namespace IntensTestProject.Interfaces
{
    public interface IUnitOfWork
    {
        IJobCandidateRepository JobCandidateRepository { get; }
        ISkillRepository SkillRepository { get; }
        ICandidateSkillsRepository CandidateSkillsRepository { get; }
        Task<bool> SaveAsync();
    }
}
