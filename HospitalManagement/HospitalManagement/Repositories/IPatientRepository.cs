using HospitalManagement.Models;
using System.Collections.Generic;

namespace HospitalManagement.Repositories
{
    public interface IPatientRepository
    {
        void Create(Patient account);
        void Delete(int id);
        List<Patient> GetAll();
        Patient GetById(int id);
        int GetCountByNationalCode(string nationalcode);
        void Update(Patient patient);

    }
}
