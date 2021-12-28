using HospitalManagement.Models;
using System.Collections.Generic;

namespace HospitalManagement.Repositories
{
    public interface IExaminationRepository
    {
        List<Examination> GetAll();
        Examination GetById(int id);
        void Create(Examination account);
        void Delete(int id);
        void Update(Examination examination);
    }
}
