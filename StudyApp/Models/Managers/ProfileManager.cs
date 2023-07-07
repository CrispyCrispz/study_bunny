using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using StudyApp.Models;

namespace StudyApp.Models.Managers
{

    /// <summary>
    /// Class <c>ProfileManager</c> Supplies database interactive functionalities for a profile object.
    /// </summary>
    public class ProfileManager
    {

        private StudyBuddyContext _db;
        private User _user;

        private Profile? _profile;
        public ProfileManager(User user, StudyBuddyContext db)
        {
            this._user = user; // the issue is that it retrieves the profile, but all the related objects are null
            this._profile = db.StudyBuddy_Profiles.Where(p => p.UserId == user.UserId).FirstOrDefault();
            this._db = db;

        }
        /// <summary>
        /// Adds profile to the user of the current active session if none exist, or replaces the existing one.
        /// </summary>

// TODO: throws an error for primary schools unique constraint 
        public void RegisterOrReplace(Profile newProfile) // this can't be fully replaced, only the trivial 
        {
            try{
                if (this.HasProfile())
                {
                    //replace existing fields with new ones
                    _user.Profile.User = newProfile.User;
                    _user.Profile.Image = newProfile.Image;
                    _user.Profile.FirstName = newProfile.FirstName;
                    _user.Profile.LastName = newProfile.LastName;
                    _user.Profile.Pronouns = newProfile.Pronouns;
                    _user.Profile.Age = newProfile.Age;
                    _user.Profile.Hobbies = newProfile.Hobbies;
                    _user.Profile.CurrentCourses = newProfile.CurrentCourses;
                    _user.Profile.DesiredCourses = newProfile.DesiredCourses;
                    _user.Profile.PreviousSchools = newProfile.PreviousSchools;
                    _user.Profile.CurrentSchool = newProfile.CurrentSchool;
                    _user.Profile.CurrentProgram = newProfile.CurrentProgram;
                    _user.Profile.Biography = newProfile.Biography;
                    _profile = _user.Profile;
                }
                else
                {
                        _user.Profile = newProfile;
                        _profile = newProfile;
                }
                _db.SaveChanges(); 
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException e)
            {
                Console.WriteLine("The same profile id can't be given for more than one account.");
            }
        }

        /// <summary>
        /// Deletes existing profile from user of current active session if there is one.
        /// </summary>
        public void DeleteProfileIfExists()
        {
            if (this.HasProfile())
            {
                _profile = null;
                _db.StudyBuddy_Profiles.Remove(_user.Profile);
                _db.SaveChanges();
            }
        }

        /// <summary>
        /// Verifies if the user of the current active session has a profile registered.
        /// </summary>
        /// <returns>
        /// Boolean value if user of current active session has an assigned profile.
        /// </returns>
        public Boolean HasProfile()
        {
            if (_profile == null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Verifies if minimum fields have been enterred or not
        /// </summary>
        /// <returns>
        /// Boolean value if user of current active session has a valid profile with the minimum fields.
        /// </returns>
        public Boolean MinimumFieldsEnterredCheck()
        {
            if (_user.Profile.User == null)
            {
                return false;
            }
            if (_user.Profile.FirstName == null)
            {
                return false;
            }
            if (_user.Profile.LastName == null)
            {
                return false;
            }
            if (_user.Profile.Age == null)
            {
                return false;
            }
            if (_user.Profile.Pronouns == null)
            {
                return false;
            }
            if (_user.Profile.CurrentSchool == null)
            {
                return false;
            }
            if (_user.Profile.CurrentProgram == null)
            {
                return false;
            }
            return true;
        }

        // TODO: more research on BitMaps
        // /// <summary>
        // /// 
        // /// </summary>
        // public void AddOrReplaceAvatar()
        // {

        // }

        /// <summary>
        /// Modifies first name field of profile of user of current active session.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// Thrown when input value is null, or retrieved profile of current user of active session is null.
        /// </exception>
        /// <param name="firstName">The new first name.</param>
        public void EditFirstName(string firstName)
        {
            try
            {
                if (string.IsNullOrEmpty(firstName))
                {
                    throw new ArgumentNullException("New first name value can't be empty or null");
                }
                if (_user.Profile == null)
                {
                    throw new ArgumentNullException("User account doesn't have a profile assigned to it. It needs to be created first.");
                }
                _user.Profile.FirstName = firstName;
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Modifies first name field of profile of user of current active session.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// Thrown when input value is null, or retrieved profile of current user of active session is null.
        /// </exception>
        /// <param name="lastName">The new last name.</param>
        public void EditLastName(string lastName)
        {
            try
            {
                if (string.IsNullOrEmpty(lastName))
                {
                    throw new ArgumentNullException("New last name value can't be empty or null");
                }
                if (_user.Profile == null)
                {
                    throw new ArgumentNullException("User account doesn't have a profile assigned to it. It needs to be created first.");
                }
                _user.Profile.LastName = lastName;
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Modifies pronouns field of profile of user of current active session.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// Thrown when input value is null, or retrieved profile of current user of active session is null.
        /// </exception>
        /// <param name="pronouns">The new last name.</param>
        public void EditPronouns(string pronouns)
        {
            try
            {
                if (string.IsNullOrEmpty(pronouns))
                {
                    throw new ArgumentNullException("New pronouns value can't be empty or null");
                }
                if (_user.Profile == null)
                {
                    throw new ArgumentNullException("User account doesn't have a profile assigned to it. It needs to be created first.");
                }
                _user.Profile.Pronouns = pronouns;
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Modifies age field of profile of user of current active session.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// Thrown when profile of current user of active session is null.
        /// </exception>
        /// <param name="age">The new age.</param>
        public void EditAge(int age)
        {
            try
            {
                if (_user.Profile == null)
                {
                    throw new ArgumentNullException("User account doesn't have a profile assigned to it. It needs to be created first.");
                }
                _user.Profile.Age = age;
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Modifies current school field of profile of user of current active session.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// Thrown when profile of current user of active session is null or input is empty.
        /// </exception>
        /// <param name="schoolName">The new school nae.</param>
        public void EditCurrentSchool(string schoolName)
        {
            try
            {
                if (string.IsNullOrEmpty(schoolName))
                {
                    throw new ArgumentNullException("New school name value can't be empty or null");
                }
                if (this._user.Profile == null)
                {
                    throw new ArgumentNullException("User account doesn't have a profile assigned to it. It needs to be created first.");
                }
                School school = new School(schoolName, null, null, null);
                _user.Profile.CurrentSchool = school;
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Modifies current program field of profile of user of current active session.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// Thrown when profile of current user of active session is null or input is empty.
        /// </exception>
        /// <param name="programName">The new program name.</param>
        public void EditCurrentProgram(string programName)
        {
            try
            {
                if (string.IsNullOrEmpty(programName))
                {
                    throw new ArgumentNullException("New program name value can't be empty or null");
                }
                if (this._user.Profile == null)
                {
                    throw new ArgumentNullException("User account doesn't have a profile assigned to it. It needs to be created first.");
                }
                ProgramOfStudy program = new ProgramOfStudy(programName);
                _user.Profile.CurrentProgram = program;
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Modifies biography field of profile of user of current active session.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// Thrown when input value is null, or retrieved profile of current user of active session is null.
        /// </exception>
        /// <param name="biography">The new biogrphy.</param>
        public void EditBiography(string biography)
        {
            try
            {
                if (string.IsNullOrEmpty(biography))
                {
                    throw new ArgumentNullException("New biography value can't be empty or null");
                }
                if (_user.Profile == null)
                {
                    throw new ArgumentNullException("User account doesn't have a profile assigned to it. It needs to be created first.");
                }
                _user.Profile.Biography = biography;
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Adds hobby to profile of user of current active session.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// Thrown when input value is null, or retrieved profile of current user of active session is null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when attempting to exceed ten hobbies.
        /// </exception>
        /// <param name="hobbyName">Hobby name to add to profile and database if it doesn't already exist.</param>
        public void AddHobby(string hobbyName)
        {
            try
            {
                if (string.IsNullOrEmpty(hobbyName))
                {
                    throw new ArgumentNullException("Hobby name value can't be empty or null");
                }
                if (_user.Profile == null)
                {
                    throw new ArgumentNullException("User account doesn't have a profile assigned to it. It needs to be created first.");
                }

                // If a hobby with that name exists in db, store in variable, if not, add it to the db
                Hobby? hobbyToAdd = _db.StudyBuddy_Hobbies.Where(h => h.HobbyName == hobbyName).FirstOrDefault();
                if (hobbyToAdd == null)
                {
                    _db.StudyBuddy_Hobbies.Add(new Hobby(hobbyName, null));
                }

                if (_user.Profile.Hobbies != null)
                {
                    _user.Profile.Hobbies = new List<Hobby> { hobbyToAdd };
                }
                else
                {
                    if (_user.Profile.Hobbies.Count > 9)
                    {
                        throw new ArgumentOutOfRangeException("Can't add more than ten hobbies to profile");
                    }
                    _user.Profile.Hobbies.Add(hobbyToAdd);
                }
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Deletes hobby from profile of user of current active session.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// Thrown when input value is null, or retrieved profile of current user of active session is null.
        /// </exception>
        /// <param name="hobbyName">Hobby name to delete from hobbies of profile if it exists.</param>
        public void DeleteHobby(string hobbyName)
        {
            try
            {
                if (string.IsNullOrEmpty(hobbyName))
                {
                    throw new ArgumentNullException("New hobby value can't be empty or null");
                }
                if (_user.Profile == null)
                {
                    throw new ArgumentNullException("User account doesn't have a profile assigned to it. It needs to be created first.");
                }
                if (_user.Profile.CurrentCourses != null)
                {
                    // remove hobby
                    Hobby? hobbyToRemove = _db.StudyBuddy_Hobbies.Where(h => h.HobbyName == hobbyName).FirstOrDefault();
                    if (hobbyToRemove != null)
                    {
                        _user.Profile.Hobbies.Remove(hobbyToRemove);
                        _db.SaveChanges();
                    }
                } 
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Adds current course to profile of user of current active session.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// Thrown when input value is null, or retrieved profile of current user of active session is null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when attempting to exceed ten current courses.
        /// </exception>
        /// <param name="courseName">Course name to add to profile and database if it doesn't already exist.</param>
        public void AddCurrentCourse(string courseName)
        {
            try
            {
                if (string.IsNullOrEmpty(courseName))
                {
                    throw new ArgumentNullException("Course value can't be empty or null");
                }
                if (_user.Profile == null)
                {
                    throw new ArgumentNullException("User account doesn't have a profile assigned to it. It needs to be created first.");
                }

                // If a course with that name exists in db, store in variable, if not, add it to the db
                Course? courseToAdd = _db.StudyBuddy_Courses.Where(c => c.CourseName == courseName).FirstOrDefault();
                if (courseToAdd == null)
                {
                    _db.StudyBuddy_Courses.Add(new Course(courseName, null, null, null));
                }

                if (_user.Profile.CurrentCourses != null)
                {
                    _user.Profile.CurrentCourses = new List<Course> { courseToAdd };
                }
                else
                {
                    if (_user.Profile.CurrentCourses.Count > 9)
                    {
                        throw new ArgumentOutOfRangeException("Can't add more than ten current courses to profile");
                    }
                    _user.Profile.CurrentCourses.Add(courseToAdd);
                }
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Deletes current course from profile of user of current active session.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// Thrown when input value is null, or retrieved profile of current user of active session is null.
        /// </exception>
        /// <param name="courseName">Course name to delete from current courses of profile if it exists.</param>
        public void DeleteCurrentCourse(string courseName)
        {
            try
            {
                if (string.IsNullOrEmpty(courseName))
                {
                    throw new ArgumentNullException("New current course value can't be empty or null");
                }
                if (_user.Profile == null)
                {
                    throw new ArgumentNullException("User account doesn't have a profile assigned to it. It needs to be created first.");
                }
                if (_user.Profile.CurrentCourses != null)
                {
                    // remove course
                    Course? courseToRemove = _db.StudyBuddy_Courses.Where(c => c.CourseName == courseName).FirstOrDefault();
                    if (courseToRemove != null)
                    {
                        _user.Profile.CurrentCourses.Remove(courseToRemove);
                        _db.SaveChanges();
                    }
                } 
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Adds desired course to profile of user of current active session.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// Thrown when input value is null, or retrieved profile of current user of active session is null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when attempting to exceed ten desired courses.
        /// </exception>
        /// <param name="courseName">Course name to add to profile and database if it doesn't already exist.</param>
        public void AddDesiredCourse(string courseName)
        {
            try
            {
                if (string.IsNullOrEmpty(courseName))
                {
                    throw new ArgumentNullException("Course value can't be empty or null");
                }
                if (_user.Profile == null)
                {
                    throw new ArgumentNullException("User account doesn't have a profile assigned to it. It needs to be created first.");
                }

                // If a course with that name exists in db, store in variable, if not, add it to the db
                Course? courseToAdd = _db.StudyBuddy_Courses.Where(c => c.CourseName == courseName).FirstOrDefault();
                if (courseToAdd == null)
                {
                    _db.StudyBuddy_Courses.Add(new Course(courseName, null, null, null));
                }

                if (_user.Profile.DesiredCourses != null)
                {
                    _user.Profile.DesiredCourses = new List<Course> { courseToAdd };
                }
                else
                {
                    if (_user.Profile.DesiredCourses.Count > 9)
                    {
                        throw new ArgumentOutOfRangeException("Can't add more than ten desired courses to profile");
                    }
                    _user.Profile.DesiredCourses.Add(courseToAdd);
                }
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Deletes desired course from profile of user of current active session.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// Thrown when input value is null, or retrieved profile of current user of active session is null.
        /// </exception>
        /// <param name="courseName">Course name to delete from current courses of profile if it exists.</param>
        public void DeleteDesiredCourse(string courseName)
        {
            try
            {
                if (string.IsNullOrEmpty(courseName))
                {
                    throw new ArgumentNullException("New desired course value can't be empty or null");
                }
                if (_user.Profile == null)
                {
                    throw new ArgumentNullException("User account doesn't have a profile assigned to it. It needs to be created first.");
                }
                if (_user.Profile.DesiredCourses != null)
                {
                    // remove course
                    Course? courseToRemove = _db.StudyBuddy_Courses.Where(c => c.CourseName == courseName).FirstOrDefault();
                    if (courseToRemove != null)
                    {
                        _user.Profile.DesiredCourses.Remove(courseToRemove);
                        _db.SaveChanges();
                    }
                } 
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Adds previous school to profile of user of current active session.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// Thrown when input value is null, or retrieved profile of current user of active session is null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when attempting to exceed ten previous schools.
        /// </exception>
        /// <param name="schoolName">School name to add to profile and database if it doesn't already exist.</param>
        public void AddPreviousSchool(string schoolName)
        {
            try
            {
                if (string.IsNullOrEmpty(schoolName))
                {
                    throw new ArgumentNullException("School name value can't be empty or null");
                }
                if (_user.Profile == null)
                {
                    throw new ArgumentNullException("User account doesn't have a profile assigned to it. It needs to be created first.");
                }

                // If a course with that name exists in db, store in variable, if not, add it to the db
                School? schoolToAdd = _db.StudyBuddy_Schools.Where(c => c.SchoolName == schoolName).FirstOrDefault();
                if (schoolToAdd == null)
                {
                    _db.StudyBuddy_Schools.Add(new School(schoolName, null, null, null));
                }

                if (_user.Profile.PreviousSchools != null)
                {
                    _user.Profile.PreviousSchools = new List<School> { schoolToAdd };
                }
                else
                {
                    if (_user.Profile.PreviousSchools.Count > 9)
                    {
                        throw new ArgumentOutOfRangeException("Can't add more than ten desired courses to profile");
                    }
                    _user.Profile.PreviousSchools.Add(schoolToAdd);
                }
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Deletes previous school from profile of user of current active session.
        /// </summary>
        /// <summary>
        /// Deletes previous school from profile of user of current active session.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// Thrown when input value is null, or retrieved profile of current user of active session is null.
        /// </exception>
        /// <param name="schoolName">School name to delete from previous schools of profile if it exists.</param>
        public void DeletePreviousSchool(string schoolName)
        {
            try
            {
                if (string.IsNullOrEmpty(schoolName))
                {
                    throw new ArgumentNullException("New previous school value can't be empty or null");
                }
                if (_user.Profile == null)
                {
                    throw new ArgumentNullException("User account doesn't have a profile assigned to it. It needs to be created first.");
                }
                if (_user.Profile.PreviousSchools != null)
                {
                    // remove course
                    School? schoolToRemove = _db.StudyBuddy_Schools.Where(c => c.SchoolName == schoolName).FirstOrDefault();
                    if (schoolToRemove != null)
                    {
                        _user.Profile.PreviousSchools.Remove(schoolToRemove);
                        _db.SaveChanges();
                    }
                } 
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Interactive cli of minimal requirements for a profile.
        /// </summary>
        public void RegisterProfileInteractive()
        {
            string? firstName = null;
            while (string.IsNullOrWhiteSpace(firstName))
            {
                Console.WriteLine("Enter first name:");
                firstName = Console.ReadLine();
            }
            string? lastName = null;
            while (string.IsNullOrWhiteSpace(lastName))
            {
                Console.WriteLine("Enter last name:");
                lastName = Console.ReadLine();
            }
            string? pronouns = null;
            while (string.IsNullOrWhiteSpace(pronouns))
            {
                Console.WriteLine("Enter pronouns:");
                pronouns = Console.ReadLine();
            }
            int? age = null;
            while (age == null)
            {
                Console.WriteLine("Enter age:");
                age = int.Parse(Console.ReadLine());
            }
            School? currentSchool = null;
            while (currentSchool == null)
            {
                Console.WriteLine("Enter current school::");
                string schoolName = Console.ReadLine();
                currentSchool = new School(schoolName, null, null, null);
            }
            ProgramOfStudy? currentProgram = null;
            while (currentProgram == null)
            {
                Console.WriteLine("Enter current program of study:");
                string programName = Console.ReadLine();
                currentProgram = new ProgramOfStudy(programName);
            }
            string? biography = null;
            while (string.IsNullOrWhiteSpace(biography))
            {
                Console.WriteLine("Enter biography:");
                biography = Console.ReadLine();
            }

            Profile profile = new Profile(this._user, null, firstName, lastName, pronouns, age,
                                        currentProgram, currentSchool, biography,
                                        null, null, null, null, null, null, null, null);

            RegisterOrReplace(profile);
        }

    }
}

// put to upper everywhere for add school hobby course program
// make sure school hobby course program do not add knitting again, if knitting is ALREADY a hobby of yours