using Microsoft.AspNetCore.Mvc;

namespace KTGK.Models
{
    public class Grade
    {
        public int GradeId { get; set; }

        public string GradeName { get; set; }

        public string ImagePath { get; set; } 

        public List<Student> Students { get; set; }
    }
}
