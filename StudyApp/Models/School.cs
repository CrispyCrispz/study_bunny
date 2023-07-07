using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace StudyApp.Models
{
    public class School
    {
        /// <value> Property <c>User</c> Unique Id for database primary key</value>
        private string? _schoolName;
        private List<Profile>? _students;
        private List<Profile>? _alumnae;
        private List<Event>? _events;

        public int SchoolId { get; set; }
        public string SchoolName { get; set; }

        [InverseProperty("CurrentSchool")]
        public List<Profile> Students { get; } = new();

        [InverseProperty("PreviousSchools")]
        public List<Profile> Alumnae { get; } = new();

        [InverseProperty("RelatedSchool")]
        public List<Event> Events { get; } = new();

        private School() {}
        public School(string schoolName, List<Profile>? students, List<Profile>? alumnae, List<Event>? events)
        {
            SchoolName = schoolName;

            if ( students == null) { this.Students = new List<Profile>(); }
            else { this.Students = students; }

            if ( alumnae == null) { this.Alumnae = new List<Profile>(); }
            else { this.Alumnae = alumnae; }

            if ( events == null) { this.Events = new List<Event>(); }
            else { this.Events = events; }
        }

        public override string ToString(){
            return SchoolName;
        }

    }

}