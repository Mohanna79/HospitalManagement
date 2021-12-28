using HospitalManagement.Repositories;

namespace HospitalManagement
{
    public interface IUnitOfWork
    {
        void Commit();
        IPatientRepository PatientRepository { get; }
        IDoctorRepository DoctorRepository { get; }
        IExaminationRepository ExaminationRepository { get; }
        IReceptionRepository ReceptionRepository { get; }
        IReceptionExaminationRepository ReceptionExaminationRepository { get; }
    }
}
