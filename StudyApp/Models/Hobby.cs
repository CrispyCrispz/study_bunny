using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace StudyApp.Models 
{
    public class Hobby
    {
        /// <value> Property <c>name</c> description</value>
        private string? _hobbyName;
        private List<Profile>? _interestedPeople;
        

        public int HobbyId { get; set; }
        public string HobbyName { get; set; }

        [InverseProperty("Hobbies")]
        public List<Profile> InterestedPeople { get ;} = new();


        private Hobby() {}
        public Hobby(string hobbyName, List<Profile>? interestedPeople)
        {
            HobbyName = hobbyName;

            if ( interestedPeople == null) { this.InterestedPeople = new List<Profile>(); }
            else { this.InterestedPeople = interestedPeople; }
        }
        
        public override string ToString(){
            return HobbyName;
        }

    }
    
}