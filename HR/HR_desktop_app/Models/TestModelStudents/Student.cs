using System;

namespace HR_desktop_app.Models.TestModelStudents
{
    internal class Student
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime Birthday { get; set; }
        public Group Group { get; set; }
        public string Description { get; set; } = "Test record";
        public override string ToString()
        {
            return $"{Name} {SurName} {Group}";
        }
    }
}
