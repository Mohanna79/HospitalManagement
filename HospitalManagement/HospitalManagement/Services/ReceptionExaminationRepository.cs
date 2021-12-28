using HospitalManagement.Context;
using HospitalManagement.Models;
using HospitalManagement.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace HospitalManagement.Services
{
    public class ReceptionExaminationRepository: IReceptionExaminationRepository
    {
        private readonly MedicalManageMentContext _dbcontext;

        public ReceptionExaminationRepository(MedicalManageMentContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public long SaveReceptions(string PatientId, string DoctorId, string ExaminationIds)
        {
            Doctor doctor = _dbcontext.Doctors.Where(x => x.DoctorId == int.Parse(DoctorId)).FirstOrDefault();
            Patient patient = _dbcontext.Patients.Where(x => x.PatientId == int.Parse(PatientId)).FirstOrDefault();

            int[] ExaminationId_int = ExaminationIds.Split(',').Select(int.Parse).ToArray();

            List<Examination> examination = _dbcontext.Examinations.Where(x => ExaminationId_int.Contains(x.ExaminationId)).ToList();

            Reception reception = new Reception();
            reception.PatientId = patient.PatientId;
            reception.DoctorId = doctor.DoctorId;
            reception.DateTime = System.DateTime.Now;
            _dbcontext.Receptions.Add(reception); 
            _dbcontext.SaveChanges(); 
            long priceTotal = 0;
            ReceptionExamination receptionExamination;
            foreach (var item in examination)
            {
                receptionExamination = new ReceptionExamination();
                receptionExamination.ReceptionId = reception.ReceptionId;
                receptionExamination.ExaminationId = item.ExaminationId;
                _dbcontext.ReceptionExaminations.Add(receptionExamination);
                priceTotal += item.Price;
            }
            _dbcontext.SaveChanges();
            if (_dbcontext.Receptions.Where(x => x.PatientId == int.Parse(PatientId)).Count() >= 10)
            {
                priceTotal = (long)(0.8 * priceTotal);
            }
            return priceTotal;
        }
    }
}

