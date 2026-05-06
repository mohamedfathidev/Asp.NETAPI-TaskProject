namespace APILab.DTOs
{
    public class DepartmentWithEmployeesDto
    {
        public string Name { get; set; }

        public List<string> StudentNames { get; set; }

        public int StudentCount { get; set; }

        public string? Message { get; set; }
    }
}
