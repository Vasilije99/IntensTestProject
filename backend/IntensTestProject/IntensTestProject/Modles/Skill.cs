using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntensTestProject.Modles
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<CandidateSkill> CandidateSkills { get; set; }
    }
}
