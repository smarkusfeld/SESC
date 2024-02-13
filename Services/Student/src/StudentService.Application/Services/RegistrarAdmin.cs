using AutoMapper;
using StudentService.Application.Common.Exceptions;
using StudentService.Application.Interfaces.Repositories;
using StudentService.Application.Interfaces.Services;
using StudentService.Application.Models.DTOs;
using StudentService.Application.Models.DTOs.InputModels;
using StudentService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace StudentService.Application.Services
{
    public class RegistrarAdmin : IRegistrarAdminService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RegistrarAdmin(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<NewCourseDTO> AddCourse(NewCourseDTO courseDTO)
        {
            //check course, school, and subject
            courseDTO = await ValidateNewCourse(courseDTO);

            var containedAwards = await GetContainedAwardList(courseDTO.ContainedCourseAwards);

            var newCourse = _mapper.Map<Course>(courseDTO);
            foreach(var award in containedAwards)
            {
                newCourse.AddContainedAward(award.Id);
            }
             var result = await _unitOfWork.Courses.AddAsync(newCourse);
            if(result !=  null)
            {
                return await _unitOfWork.Save() > 0 ? _mapper.Map<NewCourseDTO>(newCourse) : throw new MySQLException();
            }
            

        }

        public Task<NewCourseDTO> AddCourseLevel(NewCourseDTO course)
        {
            throw new NotImplementedException();
        }

        public Task<CourseLevelDTO> AddCourseLevelModules(CourseLevelDTO course)
        {
            throw new NotImplementedException();
        }

        public Task<CourseLevelDTO> AddCourseLevelSessions(CourseLevelDTO course)
        {
            throw new NotImplementedException();
        }

        public Task<CourseLevelDTO> CloseSessionEnrolment(CourseLevelDTO course)
        {
            throw new NotImplementedException();
        }

        public Task<CourseLevelDTO> DeactivateSessions(CourseLevelDTO course)
        {
            throw new NotImplementedException();
        }

        public Task<CourseLevelDTO> OpenSessionEnrolment(CourseLevelDTO course)
        {
            throw new NotImplementedException();
        }

        public Task<NewCourseDTO> UpdateCourse(NewCourseDTO course)
        {
            throw new NotImplementedException();
        }

      
        private async Task<NewCourseDTO> ValidateNewCourse(NewCourseDTO course)
        {
            var check = await _unitOfWork.Courses.GetByAsync(x => x.CourseCode == course.CourseCode && x.IsActive);
            if (check != null) { throw new BadRequestException("Course Already Exists", course.CourseCode); }

            var school = await _unitOfWork.Schools.GetByAsync(x=>x.Name.Normalize().Equals(course.CourseSchool.Normalize()));
            if (school != null) { throw new BadRequestException("Course School Does Not Exists", course.CourseSchool); }
            course.SchoolId = school.Id;

            var subject = await _unitOfWork.Subjects.GetByAsync(x => x.Name.Normalize().Equals(course.CourseSubject.Normalize()));
            if (subject != null) { throw new BadRequestException("Course Subject Does Not Exists", course.CourseSubject); }
            course.SubjectId = subject.Id;

            var award = await _unitOfWork.Awards.GetByAsync(x => x.Name.Normalize().Equals(course.CourseAward.Normalize()));
            if (award != null) { throw new BadRequestException("Course Award Does Not Exists", course.CourseAward); }
            course.AwardId = award.Id;

            return course;
        }

        private async Task<List<Award>> GetContainedAwardList(List<string> AwardNames)
        {
            List<Award> AwardList = new();
            foreach(string awardName in AwardNames) 
            {
                var award = await _unitOfWork.Awards.GetByAsync(x => x.Name.Normalize().Equals(awardName.Normalize()));
                if (award != null) { throw new BadRequestException("Course Award Does Not Exists", awardName); }
                AwardList.Add(award);
            }
            return AwardList;
        }
    }
}
