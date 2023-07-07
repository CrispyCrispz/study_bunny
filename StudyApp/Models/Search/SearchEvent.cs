 using System.Collections.Generic;
 using System.Linq;
 using StudyApp.Models;
 
 namespace StudyApp.Models.Search
 {
    public class SearchEvent: ISearch<Event>
    {
        private StudyBuddyContext _db;

         public SearchEvent(StudyBuddyContext db)
        {
            this._db = db;
        }

        public List<Event>? byCourseName(string query)
        {
            query = query.ToUpper();
            List<Event>? results = (from e in _db.StudyBuddy_Events
                                    where e.RelatedCourse.CourseName.Contains(query)
                                    select e).ToList<Event>();
            return results;
        }

        public List<Event>? byProgramName(string query)
        {
            query = query.ToUpper();
            List<Event>? results = (from e in _db.StudyBuddy_Events
                                    where e.RelatedProgram.Name.Contains(query)
                                    select e).ToList<Event>();
            return results;
        }

        public List<Event>? bySchoolName(string query)
        {
            query = query.ToUpper();
            List<Event>? results = (from e in _db.StudyBuddy_Events
                                    where e.RelatedSchool.SchoolName.Contains(query)
                                    select e).ToList<Event>();
            return results;
        }

        public List<Event>? byDescription(string query)
        {
            query = query.ToUpper();
            List<Event>? results = (from e in _db.StudyBuddy_Events
                                    where e.Description.Contains(query)
                                    select e).ToList<Event>();
            return results;
        }

        public List<Event>? byTitle(string query)
        {
           
            query = query.ToUpper();
            List<Event>? results = (from e in _db.StudyBuddy_Events
                                    where e.Title.Contains(query)
                                    select e).ToList<Event>();
            return results;
        }

    }
}
