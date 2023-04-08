using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Faker;
using HR_desktop_app.Models.TestModelStudents;

namespace HR_desktop_app.Data.GeneratorFakeStudents
{
    /// <summary>
    /// Генератор персон.
    /// </summary>
    internal static class GeneratorStudents
    { 
        /// <summary>
        /// Генерация студентов группы.
        /// </summary>
        /// <param name="count">Число студентов в группе.</param>
        /// <param name="group">Группа для которой генерируются студенты.</param>
        /// <returns>Студенты.</returns>
        public static ICollection<Student> GetStudents(int count, Group group)
        {
            var students = new List<Student>();
            Student person;
            for (int i = 0; i < count; i++)
            {
                person = new Student()
                {
                    Name = Faker.Name.First(),
                    SurName = Faker.Name.Last(),
                    Birthday = GetDateBirthday(),
                    Group = group
                };
                students.Add(person);
            }
            return students;
        }

        private static DateTime GetDateBirthday()
        {
            var current = DateTime.Now;
            var rnd = new Random();
            var target_date = current.AddYears(-rnd.Next(10,60));
            target_date = target_date.AddMonths(-rnd.Next(12));
            target_date = target_date.AddDays(-rnd.Next(28));
            return target_date;
        }
    }
}
