using System.Collections.Generic;

namespace HR_desktop_app.Models.TestModelStudents
{
    internal class Group
    {
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; }
        public string Description { get; set; }
        //public override string ToString()
        //{
        //    return Name;
        //}
    }
}
