using HospitalManagement.Models;
using System.Collections.Generic;

namespace HospitalManagement.Repositories
{
    public interface IDoctorRepository
    {
        List<Doctor> GetAll();
        Doctor GetById(int id);
        void Create(Doctor account);
        void Delete(int id);
        void Update(Doctor doctor);
    }
}
 