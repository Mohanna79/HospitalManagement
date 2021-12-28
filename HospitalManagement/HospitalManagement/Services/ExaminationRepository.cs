using HospitalManagement.Context;
using HospitalManagement.Models;
using HospitalManagement.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HospitalManagement.Services
{
    public class ExaminationRepository : IExaminationRepository
    {
        private readonly MedicalManageMentContext _dbcontext;

        public ExaminationRepository(MedicalManageMentContext dbcontext)
        {
            _dbcontext = dbcontext;

        }
        public void Create(Examination account)
        {
            _dbcontext.Examinations.Add(account);
        }

        public void Delete(int id)
        {
            Examination examination= _dbcontext.Examinations.Find(id);
            _dbcontext.Examinations.Remove(examination);
        }
        public List<Examination> GetAll()
        {
            return _dbcontext.Examinations.ToList();
        }

        public Examination GetById(int id)
        {
            return _dbcontext.Examinations.Find(id);
        }
        public void Update(Examination examination)
        {
            _dbcontext.Entry(examination).State = EntityState.Modified;
        }
    }
}
