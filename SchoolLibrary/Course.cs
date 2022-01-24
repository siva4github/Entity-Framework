using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLibrary
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        
        public ICollection<Student> Students { get; set; }

        public Teacher Author { get; set; }
        public int TeacherId { get; set; }
        public Teacher Editor { get; set; }
        public int EditorId { get; set; }
    }
}
