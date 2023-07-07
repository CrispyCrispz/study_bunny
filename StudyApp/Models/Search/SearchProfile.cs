using System.Collections.Generic;
using System.Linq;
using StudyApp.Models;
namespace StudyApp.Models.Search
{
    public class SearchProfile: ISearch<Profile>
    {
        private StudyBuddyContext _db;

        public SearchProfile(StudyBuddyContext db)
        {
            this._db = db;
        }

        public List<Profile>? byCourseName(string query)
        {
            query = query.ToUpper();
            List<Profile> results = _db.StudyBuddy_Profiles
                                    .Where(p => p.CurrentCourses
                                    .Any( p => p.CourseName.Contains(query)) || p.DesiredCourses
                                    .Any( p => p.CourseName.Contains(query)))
                                    .ToList<Profile>();
            return results;
        }

        public List<Profile>? byProgramName(string query)
        {
            query = query.ToUpper();
            List<Profile> results = _db.StudyBuddy_Profiles
                                    .Where(p => p.CurrentProgram.Name.Contains(query))
                                    .ToList<Profile>();
            return results;
        }

        public List<Profile>? bySchoolName(string query)
        {
            query = query.ToUpper();
            List<Profile> results = _db.StudyBuddy_Profiles
                                    .Where(p => p.PreviousSchools
                                    .Any( p => p.SchoolName.Contains(query)) || p.CurrentSchool.SchoolName.Contains(query))
                                    .ToList<Profile>();
            return results;
        }

        public List<Profile>? byDescription(string query)
        {
            // query = query.ToUpper(); ?????
            List<Profile> results = _db.StudyBuddy_Profiles
                                    .Where(p => p.Biography.Contains(query))
                                    .ToList<Profile>();
            return results;
        }

        public List<Profile>? byInterests(string query)
        {
            query = query.ToUpper();
            List<Profile>? results = _db.StudyBuddy_Profiles
                                    .Where(p => p.Hobbies
                                    .Any( h => h.HobbyName.Contains(query)))
                                    .ToList<Profile>();
            return results;
        }

        public List<Profile>? byName(string query){
            query = query.ToUpper();
            List<Profile>? results = (from p in _db.StudyBuddy_Profiles
                                    where p.FirstName.Contains(query) || p.LastName.Contains(query)
                                    select p)
                                    .ToList<Profile>();
            return results;
        }
        
    }
}
