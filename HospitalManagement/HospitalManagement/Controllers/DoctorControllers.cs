using AutoMapper;
using HospitalManagement.Context;
using HospitalManagement.Dto;
using HospitalManagement.Dto.Doctor;
using HospitalManagement.Models;
using HospitalManagement.Repositories;
using HospitalManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HospitalManagement.Controllers
{
    [Route("api/Doctor")]
    [ApiController]
    public class DoctorControllers : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DoctorControllers(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult Create(CreateDoctorDto accountDto)
        {
            var entity = _mapper.Map<Doctor>(accountDto);
            _unitOfWork.DoctorRepository.Create(entity);
            _unitOfWork.Commit();
            return Ok();
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var doctors = _unitOfWork.DoctorRepository.GetAll();
            if (doctors == null)
                return NotFound();
            var dtos = _mapper.Map<List<GetDoctorDto>>(doctors);
            return Ok(dtos);
        }
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {

            var result = _unitOfWork.DoctorRepository.GetById(Id);
            if (result == null)
            {
                return NotFound();
            }
            var dtos = _mapper.Map<List<GetDoctorDto>>(result);
            return Ok(result);
        }
        [HttpDelete]
        public ActionResult DeletePatient(int id)
        {
            _unitOfWork.DoctorRepository.Delete(id);
            _unitOfWork.Commit();
            return Ok();
        }
        [HttpPut]
        public ActionResult Update(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.DoctorRepository.Update(doctor);
                _unitOfWork.Commit();
                return Ok();
            }
            return BadRequest();
        }
    }
}

