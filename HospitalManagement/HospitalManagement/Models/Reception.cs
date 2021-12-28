using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagement.Models
{

    [Table("Reception")]
    public class Reception
    {
        public Reception()
        {
            ReceptionExaminations = new HashSet<ReceptionExamination>();
        }

        public int ReceptionId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int ReceptionExaminationId { get; set; }
        public int ExaminationId { get; set; }
        public long Price { get; set; }
        public DateTime DateTime { get; set; }
        public int ReceptionNumber { get; set; }
        public virtual Doctor Doctor { get; set; }        
        public virtual Patient Patient { get; set; }
        public virtual ICollection<ReceptionExamination> ReceptionExaminations { get; set; }
    }
}
