using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace HospitalManagement.Models
{

    [Table("Examination")]
    public  class Examination
    {
        public Examination()
        {
            ReceptionExaminations = new HashSet<ReceptionExamination>();
        }

        public int ExaminationId { get; set; }
        public string Name { get; set; }
        public long Price { get; set; }
        public int ExamineCode { get; set; }

        public virtual ICollection<ReceptionExamination> ReceptionExaminations { get; set; }
    }
}
