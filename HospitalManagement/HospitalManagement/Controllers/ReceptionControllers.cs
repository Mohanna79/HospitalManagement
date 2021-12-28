using AutoMapper;
using HospitalManagement.Dto;
using HospitalManagement.Models;
using HospitalManagement.Repositories;
using HospitalManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceptionControllers : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ReceptionControllers(IMapper mapper, IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var entity = _unitOfWork.ReceptionRepository.GetAll();
            if (entity == null)
                return NotFound();
            var dtos = _mapper.Map<List<GetpatientDto>>(entity);
            return Ok(dtos);
        }
    }
}
