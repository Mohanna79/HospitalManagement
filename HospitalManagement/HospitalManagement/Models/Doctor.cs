using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace HospitalManagement.Models
{
    [Table("Doctor")]
    public  class Doctor
    {
        public Doctor()
        {
            Receptions = new HashSet<Reception>();
        }

        public int DoctorId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public long MedicalSystemCode { get; set; }

        public virtual ICollection<Reception> Receptions { get; set; }
    }
}
