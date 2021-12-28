using AutoMapper;
using HospitalManagement.Dto;
using HospitalManagement.Dto.Examination;
using HospitalManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace HospitalManagement.Controllers
{
    [Route("api/ ExaminationGroup")]
    [ApiController]
    public class ExaminationControllers : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ExaminationControllers(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult Create(CreateExaminationDto accountDto)
        {
            var entity = _mapper.Map<Examination>(accountDto);
            _unitOfWork.ExaminationRepository.Create(entity);
            _unitOfWork.Commit();
            return Ok();
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var entity = _unitOfWork.ExaminationRepository.GetAll();
            if (entity == null)
                return NotFound();
            var dtos = _mapper.Map<List<GetExaminationDto>>(entity);
            return Ok(dtos);
        }
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {

            var result = _unitOfWork.ExaminationRepository.GetById(Id);
            if (result == null)
            {
                return NotFound();
            }
            var dtos = _mapper.Map<List<GetExaminationDto>>(result);
            return Ok(result);
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _unitOfWork.ExaminationRepository.Delete(id);
            _unitOfWork.Commit();
            return Ok();
        }
        [HttpPut]
        public ActionResult Update(Examination examination)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ExaminationRepository.Update(examination);
                _unitOfWork.Commit();
                return Ok();
            }
            return BadRequest();
        }
    }
}

