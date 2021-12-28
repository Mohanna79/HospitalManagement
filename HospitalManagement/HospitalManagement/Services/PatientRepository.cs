using AutoMapper;
using HospitalManagement.Context;
using HospitalManagement.Models;
using HospitalManagement.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HospitalManagement.Services
{
    public class PatientRepository : IPatientRepository
    {
        private readonly MedicalManageMentContext _dbcontext;

        public PatientRepository(MedicalManageMentContext dbcontext)
        {
            _dbcontext = dbcontext;

        }
        public void Create(Patient account)
        {
            _dbcontext.Patients.Add(account);
        }

        public void Delete(int id)
        {
            Patient patient = _dbcontext.Patients.Find(id);
            _dbcontext.Patients.Remove(patient);

        }
        public List<Patient> GetAll()
        {
            return _dbcontext.Patients.ToList();
        }
        public Patient GetById(int id)
        {
            return _dbcontext.Patients.Find(id);
        }
        public int GetCountByNationalCode(string nationalcode)
        {
            int count = 0;
            if (_dbcontext.Patients.Any(x => x.NationalCode == nationalcode))
            {
                var PatientId = _dbcontext.Patients.Where(x => x.NationalCode == nationalcode).FirstOrDefault().PatientId;
                count = _dbcontext.Receptions.Where(x => x.PatientId == PatientId).Count();
            }
            return count;
        }
        public void Update(Patient patient)
        {
            _dbcontext.Entry(patient).State = EntityState.Modified;
        }
    }
}