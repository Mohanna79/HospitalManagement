namespace HospitalManagement.Dto.Doctor
{
    public class GetDoctorDto
    {
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public long MedicalSystemCode { get; set; }
    }
}
