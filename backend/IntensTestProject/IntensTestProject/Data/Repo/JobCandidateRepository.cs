using IntensTestProject.Interfaces;
using IntensTestProject.Modles;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntensTestProject.Data.Repo
{
    public class JobCandidateRepository : IJobCandidateRepository
    {
        private readonly DataContext dc;

        public JobCandidateRepository(DataContext dc)
        {
            this.dc = dc;
        }

        public async Task<bool> CandidateAlreadyExists(string email)
        {
            return await dc.Candidates.AnyAsync(x => x.Email == email);
        }

        public async Task<JobCandidate> FindCandidate(int id)
        {
            return await dc.Candidates.FindAsync(id);
        }

        public async Task<List<JobCandidate>> GetCandidatesAsync()
        {
            return await dc.Candidates.ToListAsync();
        }
        
        public void AddJobCandidate(string fullname, string email, string contactNumber, DateTime dateOfBirth)
        {
           JobCandidate jobCandidate = new JobCandidate();
           jobCandidate.FullName = fullname;
           jobCandidate.Email = email;
           jobCandidate.ContactNumber = contactNumber;
           jobCandidate.DateOfBirth = dateOfBirth.Date;

           dc.Candidates.Add(jobCandidate);
        }

        public void RemoveCandidate(int id)
        {
            var candidate = dc.Candidates.Find(id);
            dc.Remove(candidate);
        }

        public async Task<List<JobCandidate>> SearchCandidate(string text)
        {
            return await dc.Candidates.Where(x => x.FullName == text).ToListAsync();
        }
    }
}
