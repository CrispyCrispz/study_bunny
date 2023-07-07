using System.Collections.Generic;
namespace  StudyApp.Models.Search
{
    public interface ISearch<T>
    //TODO: Ask andrew if making an interface is alright, or if just aking spereate unrelated classes with all static methods that just take a string query is better
    {
        public List<T>? byCourseName(string query);
        public List<T>? byProgramName(string query);
        public List<T>? bySchoolName(string query);
        public List<T>? byDescription(string query);
    }
}
