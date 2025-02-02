using AutoMapper;
using StudentAPI.Domain.DataTransfareObjects;
using StudentAPI.Domain.Entities;

namespace StudentAPI.Profiles
{
	public class MappingProfile:Profile
	{
		public MappingProfile()
		{
			CreateMap<StudentDto, Student>();
			CreateMap<Student,StudentToReturnDto>();
		}
	}
}
