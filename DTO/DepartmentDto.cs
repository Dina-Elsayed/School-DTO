using System.ComponentModel.DataAnnotations;

namespace School.DTO
{
    public class DepartmentDto
    {

        public int Id { get; set; }
        
        public string Name { get; set; }

        public string? Description { get; set; }
    }
}
