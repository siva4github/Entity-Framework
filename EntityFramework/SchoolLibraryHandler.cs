using Microsoft.EntityFrameworkCore;
using SchoolLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public static class SchoolLibraryHandler
    {
        public static void DataProcess()
        {
            var options = new DbContextOptionsBuilder<SchoolContext>()
                   .UseSqlite("Filename=../../../SchoolLibrary.db").Options;

            using var db = new SchoolContext(options);
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            SeedData(db);
        }

        static void SeedData(SchoolContext context)
        {
            Teacher t1 = new Teacher { Name = "Ramanji" };
            Teacher t2 = new Teacher { Name = "Shanti Sri" };

            Classroom r1 = new Classroom { Number = "R01" };
            Classroom r2 = new Classroom { Number = "R02" };

            Course c1 = new Course { Author = t1, Editor = t2, Title = "Programming C" };
            Course c2 = new Course { Author = t2, Editor = t1, Title = "Programming ADA" };

            Student s1 = new Student { Name = "Siva", Classroom = r1 };
            Student s2 = new Student { Name = "Sankar", Classroom = r1 };
            Student s3 = new Student { Name = "Madhu", Classroom = r1 };
            Student s4 = new Student { Name = "Sravani", Classroom = r2 };
            Student s5 = new Student { Name = "Anand", Classroom = r2 };
            Student s6 = new Student { Name = "Hanu", Classroom = r2 };

            c1.Students = new Student[] { s1, s2, s3, s4 };
            c2.Students = new Student[] { s3, s4, s5, s6 };

            context.Add(c1);
            context.Add(c2);

            context.SaveChanges();

        }
    }
}
