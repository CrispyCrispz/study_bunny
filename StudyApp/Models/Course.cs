using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace StudyApp.Models
{
    public class Course
    {
        /// <value> Property <c>User</c> Unique Id for database primary key</value>
        private string? _courseName;
        private List<Profile>? _currentStudents;
        private List<Profile>? _aspiringStudents;
        private List<Event>? _events;
        

        public int CourseId { get; set; }
        public string CourseName { get; set; }

        [InverseProperty("CurrentCourses")]
        public List<Profile> CurrentStudents { get ;} = new();

        [InverseProperty("DesiredCourses")]
        public List<Profile> AspiringStudents { get ;} = new();

        [InverseProperty("RelatedCourse")]
        public List<Event> Events { get; } = new();

        private Course() {}
        public Course(string courseName, List<Profile>? currentStudents, List<Profile>? aspiringStudents, List<Event>? events)
        {
            CourseName = courseName;

            if ( currentStudents == null) { this.CurrentStudents = new List<Profile>(); }
            else { this.CurrentStudents = currentStudents; }

            if ( aspiringStudents == null) { this.AspiringStudents = new List<Profile>(); }
            else { this.AspiringStudents = aspiringStudents; }

            if ( events == null) { this.Events = new List<Event>(); }
            else { this.Events = events; }
        }

        public override string ToString(){
            return CourseName;
        }

    }

}