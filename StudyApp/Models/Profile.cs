using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Text.RegularExpressions;

// TODO: ad validation in school and course class so that names are under a certain length
namespace StudyApp.Models
{
    /// <summary>
    /// Class <c>Profile</c>  Represents all the perosnal information of a user.
    /// </summary>
    public class Profile {

        // A regex option to compare values to for validating fields
        private Regex onlyNumbers = new Regex("^[0-9]+");

// TODO: ensure validation is done either in the user class OR here, if done here, make a backing field

        /// <value>
        /// Property <c>CurrentSchool</c> Curret school user attends.
        /// </value>
        public School? CurrentSchool {get; set;}

        /// <value>
        /// Property <c>ProgramOfStuy</c> User's current program of study.
        /// </value>
        public ProgramOfStudy? CurrentProgram {get; set;}

        /// <value>
        /// Property <c>SentMessages</c> User's sent messages.
        /// </value>
        [InverseProperty("Sender")]
        public List<Message> SentMessages {get; set;} = new();

        /// <value>
        /// Property <c>ReceivedMessages</c> User's received messages.
        /// </value>
        [InverseProperty("Recipient")]
        public List<Message> ReceivedMessages {get; set;} = new();


        /// <value>
        /// Property <c>Image</c> Bitmap object for the image the profile picture will be.
        /// </value>
        private Bitmap? _image;
        [NotMapped]
        public Bitmap Image
        {
            get {return _image;} 
            set 
            {
// TODO: Some kind of fancy bitmap validation for size or something
// TODO: If the bitmap is null, set it to a default one, not sure how to do yet
                _image = value;
            }
        }

        /// <value>
        /// Property <c>FirstName</c> User's first name.
        /// </value>
        private string? _firstName;
        public string FirstName
        {
            get {return _firstName;} 
            set 
            {
                if (!onlyNumbers.Match(value).Success)
                {
                    _firstName = value;
                }
                else
                {
                    throw new ArgumentException("Name can't be made up of digits only.");
                }
            }
        }

        /// <value>
        /// Property <c>LastName</c> User's last name.
        /// </value>
        private string? _lastName;
        public string LastName
        {
            get {return _lastName;} 
            set 
            {
                if (!onlyNumbers.Match(value).Success)
                {
                    _lastName = value;
                }
                else
                {
                    throw new ArgumentException("Name can't be made up of digits only.");
                }
            }
        }

        /// <value>
        /// Property <c>Pronouns</c> User's pronouns (string under 10 characters).
        /// </value>
        private string? _pronouns;
        public string? Pronouns
        {
            get {return _pronouns;} 
            set 
            {
                if (value != null && value.Length < 10)
                {
                    _pronouns = value;
                }
                else
                {
                    throw new ArgumentException("Pronouns field must be less than 10 characters");
                }
            }
        }

        /// <value>
        /// Property <c>Age</c> User's age between 0 and 115.
        /// </value>
        private int? _age;
        public int? Age
        {
            get {return _age;} 
            set 
            {
                if (value != null)
                if (value.HasValue && value < 115 && value > 0)
                {
                    _age = value;
                }
                else
                {
                    throw new ArgumentException("Age field must be between 1 and 115.");
                }
            }
        }

        /// <value>
        /// Property <c>Hobbies</c> List of strings representing user's hobbies.
        /// </value>
        private List<Hobby>? _hobbies;
        [InverseProperty("InterestedPeople")]
        public List<Hobby>? Hobbies
        {
            get {return _hobbies;} 
            set 
            {
                if (value.Count < 10)
                {
                    _hobbies = value;
                }
                else
                {
                    throw new ArgumentException("Hobbies list can't exceed ten.");
                }
            }
        }

        /// <value>
        /// Property <c>CurrentCourses</c> List of courses user is currently taking.
        /// </value>
        private List<Course>? _currentCourses;
        [InverseProperty("CurrentStudents")]
        public List<Course>? CurrentCourses
        {
            get {return _currentCourses;} 
            set 
            {
                if (value.Count < 10)
                {
                    _currentCourses = value;
                }
                else
                {
                    throw new ArgumentException("Courses list can't exceed ten.");
                }
            }
        }

        /// <value>
        /// Property <c>DesiredCourses</c> List of courses user desires to take.
        /// </value>
        private List<Course>? _desiredCourses;
        [InverseProperty("AspiringStudents")]
        public List<Course>? DesiredCourses
        {
            get {return _desiredCourses;} 
            set 
            {
                if (value.Count < 10)
                {
                    _desiredCourses = value;
                }
                else
                {
                    throw new ArgumentException("Courses list can't exceed ten.");
                }
            }
        }

        /// <value>
        /// Property <c>PreviousSchools</c> List of schools user previously attended.
        /// </value>
        private List<School>? _previousSchools;
        [InverseProperty("Alumnae")]
        public List<School>? PreviousSchools
        {
            get {return _previousSchools;}
            set 
            {
                if (value.Count < 10)
                {
                    _previousSchools = value;
                }
                else
                {
                    throw new ArgumentException("Schools list can't exceed ten.");
                }
            }
        }

        /// <value>
        /// Property <c>Biography</c> User's description of themselves under 200 characters.
        /// </value>
        private String? _biography;
        public String? Biography
        {
            get {return _biography;} 
            set 
            {
                if (value != null)
                if ( value.Length > 200)
                {
                    throw new ArgumentException("Biography can't exceed 200 chars.");
                }
                else
                {
                    _biography = value;
                }
            }
        }

        // DB relationship properties
        // [Key]
        // [ForeignKey("User")]
        public int ProfileId { get; set; }

        public int UserId { get; set;}

        public User User { get; set; } = null!;

        [InverseProperty("Owner")]
        public List<Event>? HostedEvents { get; } = new List<Event>();

        [InverseProperty("Attendees")]
        public List<Event>? AttendingEvents { get; } = new List<Event>();
        
        /// <summary>
        /// Constructor <c>Profile</c> Creates an instance of a profile object with the given values.
        /// </summary>
        /// <param name="user"> User object profile is being made for </param>
        /// <param name="image"> Bitmap object for the image the profile picture will be </param>
        /// <param name="firstName"> User's first name </param>
        /// <param name="lastName"> User's last name </param>
        /// <param name="pronouns"> User's pronouns (string under 10 characters) </param>
        /// <param name="age"> User's age between 0 and 115 </param>
        /// <param name="hobbies"> List of hobbies representing user's hobbies </param>
        /// <param name="currentCourses"> List of courses user is currently taking </param>
        /// <param name="desiredCourses"> List of courses user desires to take </param>
        /// <param name="previousSchools"> List of schools user previously attended </param>
        /// <param name="currentSchool"> Curret school user attends </param>
        /// <param name="currentProgram"> User's current program of study </param>
        /// <param name="biography"> User's description of themselves under 200 characters </param>
        /// <param name="sentMessages"> User's sent messages </param>
        /// <param name="receivedMessages"> User's received messages </param>
        /// <param name="hostedEvenets"> User's hosted events </param>
        /// <param name="attendingEvents"> Events user is marked as attending on </param>
// TODO: Ask Andrew if doing the checking for null lists, then assigning an empty list if they are actually does anything, and what we can do instead
        public Profile(User user, Bitmap? image, string fisrtName, string lastName, string? pronouns, int? age, ProgramOfStudy? currentProgram, School? currentSchool,
        string? biography, List<Hobby>? hobbies, List<Course>? currentCourses, List<Course>? desiredCourses, List<School>? previousSchools,
        List<Message>? sentMessages, List<Message>? receivedMessages, List<Event>? hostedEvents, List<Event>? attendingEvents)
        {
            this.User = user; // TODO: ask Andrew if this will use the setters so it passes through validation
            this.FirstName = fisrtName;
            this.LastName = lastName;
            this.Pronouns = pronouns;
            this.Biography = biography;
            this.CurrentProgram = currentProgram;
            this.CurrentSchool = currentSchool;
            this.Age = age;
            
//TODO: figure out how to give default image
            // if (image == null) { this.Image = defaultImage; }
            // else { this.Image = image; }
            //remove following line...
            this.Image = null;

            if ( receivedMessages == null ) { this.ReceivedMessages = new List<Message>(); }
            else { this.ReceivedMessages = receivedMessages; }

            if ( sentMessages == null ) { this.SentMessages = new List<Message>(); }
            else { this.SentMessages = sentMessages; }

            if ( hobbies == null ) { this.Hobbies = new List<Hobby>(); }
            else { this.Hobbies = hobbies; }

            if ( currentCourses == null) { this.CurrentCourses = new List<Course>(); }
            else { this.CurrentCourses = currentCourses; }

            if ( desiredCourses == null) { this.DesiredCourses = new List<Course>(); }
            else { this.DesiredCourses = desiredCourses; }

            if ( previousSchools == null) { this.PreviousSchools = new List<School>(); }
            else { this.PreviousSchools = previousSchools; }

            if ( hostedEvents == null) { this.HostedEvents = new List<Event>(); }
            else { this.HostedEvents = hostedEvents; }

            if ( attendingEvents == null) { this.AttendingEvents = new List<Event>(); }
            else { this.AttendingEvents = attendingEvents; }
        }

        public Profile() {}

    }
}