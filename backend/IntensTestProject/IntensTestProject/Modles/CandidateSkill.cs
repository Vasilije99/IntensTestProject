using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntensTestProject.Modles
{
    public class CandidateSkill
    {
        public int CandidateId { get; set; }
        public JobCandidate Candidate { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}
