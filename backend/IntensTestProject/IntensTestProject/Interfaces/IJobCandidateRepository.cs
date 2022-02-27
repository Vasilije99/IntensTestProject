using IntensTestProject.Modles;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntensTestProject.Interfaces
{
    public interface IJobCandidateRepository
    {
        Task<List<JobCandidate>> GetCandidatesAsync();
        Task<List<JobCandidate>> SearchCandidate(string text);
        Task<bool> CandidateAlreadyExists(string email);
        void AddJobCandidate(string fullname, string email, string contactNumber, DateTime dateOfBirth);
        void RemoveCandidate(int id);
        Task<JobCandidate> FindCandidate(int id);
    }
}
