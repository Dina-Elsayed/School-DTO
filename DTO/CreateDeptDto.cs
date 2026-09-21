using System.ComponentModel.DataAnnotations;

namespace School.DTO
{
    public class CreateDeptDto
    {

        [Required, MaxLength(100)]
        public string Name { get; set; }

        public string? Description { get; set; }

    }
}
