using HospitalManagement.Context;
using HospitalManagement.Models;
using HospitalManagement.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HospitalManagement.Services
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly MedicalManageMentContext _dbcontext;

        public DoctorRepository(MedicalManageMentContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public void Create(Doctor account)
        {
            _dbcontext.Doctors.Add(account);
        }

        public void Delete(int id)
        {
            Doctor doctor= _dbcontext.Doctors.Find(id);
            _dbcontext.Doctors.Remove(doctor);
        }

        public List<Doctor> GetAll()
        {
            return _dbcontext.Doctors.ToList();
        }

        public Doctor GetById(int id)
        {
            return _dbcontext.Doctors.Find(id);
        }
        public void Update(Doctor doctor)
        {
            _dbcontext.Entry(doctor).State = EntityState.Modified;
        }
    }
}
