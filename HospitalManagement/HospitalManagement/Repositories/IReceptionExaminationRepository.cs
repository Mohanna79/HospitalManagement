namespace HospitalManagement.Repositories
{
    public interface IReceptionExaminationRepository
    {
        long SaveReceptions(string PatientId, string DoctorId, string ExaminationIds);

    }
}
