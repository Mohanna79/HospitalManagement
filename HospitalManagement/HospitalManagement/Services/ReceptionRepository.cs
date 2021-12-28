using HospitalManagement.Context;
using HospitalManagement.Models;
using HospitalManagement.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace HospitalManagement.Services
{
    public class ReceptionRepository : IReceptionRepository
    {
        private readonly MedicalManageMentContext _dbcontext;

        public ReceptionRepository(MedicalManageMentContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public List<Reception> GetAll()
        {
            var result = _dbcontext.Receptions.ToList();
            return result;
        }

    }
}
