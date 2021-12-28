using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagement.Models
{
    [Table("ReceptionExamination")]
    public partial class ReceptionExamination
    {
        public int ReceptionExaminationId { get; set; }
        public int ReceptionId { get; set; }
        public int ExaminationId { get; set; }
        public virtual Examination Examination { get; set; }
        public virtual Reception Reception { get; set; }
    }
}
