using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLibrary
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required] public Classroom Classroom { get; set; }

        public ICollection<Course> courses { get; set; }
    }
}
