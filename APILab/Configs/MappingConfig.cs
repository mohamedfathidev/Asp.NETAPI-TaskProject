using APILab.DTOs;
using APILab.Models;
using Mapster;

namespace APILab.Configs
{
    public static class MappingConfig
    {
        public static void RegisterMappings()
        {
            TypeAdapterConfig<Department, DepartmentWithEmployeesDto>.NewConfig()
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.StudentNames, src => src.Students.Select(e => e.Name).ToList())
                .Map(dest => dest.StudentCount, src => src.Students.Count)
                .Map(dest => dest.Message, src => src.Students.Count > 1 ? "Overloaded" : "Normal");
        }
    }
}
