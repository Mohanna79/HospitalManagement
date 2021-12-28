using HospitalManagement.Context;
using HospitalManagement.Repositories;
using HospitalManagement.Services;

namespace HospitalManagement
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MedicalManageMentContext _context;
        public IPatientRepository PatientRepository { get; private set; }
        public IDoctorRepository DoctorRepository { get; private set; }
        public IExaminationRepository ExaminationRepository { get; private set; }
        public IReceptionRepository ReceptionRepository { get; private set; }
        public IReceptionExaminationRepository ReceptionExaminationRepository { get; private set; }
        public UnitOfWork(MedicalManageMentContext context)
        {
            _context = context;
            PatientRepository = new PatientRepository(_context);
            DoctorRepository = new DoctorRepository(_context);
            ExaminationRepository = new ExaminationRepository(_context);
            ReceptionRepository = new ReceptionRepository(_context);
            ReceptionExaminationRepository = new ReceptionExaminationRepository(_context);
        }
        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
