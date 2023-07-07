using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace StudyApp.Models
{
    public class ProgramOfStudy
    {
        /// <value> Property <c>User</c> Unique Id for database primary key</value>
        private List<Profile>? _students; // should this be nullable
        public int ProgramOfStudyId { get; set; }
        public string Name { get; set; }
        
        // DB relations
        [InverseProperty("CurrentProgram")]
        public List<Profile> Students { get; set; } = new(); 

        [InverseProperty("RelatedProgram")]
        public List<Event> Events { get; } = new();

        private ProgramOfStudy() {}
        public ProgramOfStudy(string program)
        {
            this.Name = program;
            // this._students = new students;
            // possibly add the relationship fields too? idk, ask andrew
        }

    }
}