using AutoMapper;
using HospitalManagement.Dto;
using HospitalManagement.Dto.Doctor;
using HospitalManagement.Dto.Examination;
using HospitalManagement.Models;
using Microsoft.Graph;
using System.Collections.Generic;

namespace HospitalManagement.Mapping
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<CreatePatientDto, Patient>();
            CreateMap<CreateDoctorDto, Doctor>();
            CreateMap<CreateExaminationDto, Examination>();
            CreateMap<Patient, GetpatientDto>();
            CreateMap<Doctor, GetDoctorDto>();
            CreateMap<Examination, GetExaminationDto>();
        }
    }
}
