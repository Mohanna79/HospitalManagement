using AutoMapper;
using HospitalManagement.Dto;
using HospitalManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HospitalManagement.Controllers
{
    [Route("api/Patient")]
    [ApiController]
    public class PatientControllers : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PatientControllers(IMapper mapper, IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult Create(CreatePatientDto patientDto)
        {
            var patientEntity = _mapper.Map<Patient>(patientDto);
            _unitOfWork.PatientRepository.Create(patientEntity);
            _unitOfWork.Commit();
            return Ok();
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var patients = _unitOfWork.PatientRepository.GetAll();
            if (patients == null)
                return NotFound();
            var dtos = _mapper.Map<List<GetpatientDto>>(patients);
            return Ok(dtos);
        }
        [HttpGet("{nationalCode}")]
        public IActionResult GetByNationalCode(string nationalCode)
        {
            var count = _unitOfWork.PatientRepository.GetCountByNationalCode(nationalCode);
            _unitOfWork.Commit();
            if (count == 0)
            {
                return NotFound();
            }
            return Ok(count);
        }
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            var result = _unitOfWork.PatientRepository.GetById(Id);
            if (result == null)
            {
                return NotFound();
            }
            var dtos = _mapper.Map<List<GetpatientDto>>(result);
            return Ok(result);
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _unitOfWork.PatientRepository.Delete(id);
            _unitOfWork.Commit();
            return Ok();
        }
        [HttpPut]
        public ActionResult Update( Patient patient)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.PatientRepository.Update(patient);
                _unitOfWork.Commit();
                return Ok();
            }
            return BadRequest();
        }
    }
}
