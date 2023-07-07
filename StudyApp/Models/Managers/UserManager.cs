
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StudyApp.Models;
using System;
using StudyApp.Models;
using StudyApp.Models.Search;
namespace StudyApp.Models.Managers
{
    public class UserManager
    {
        private StudyBuddyContext _db;
        ///<summary> 
        /// This service will handle login and register methods
        ///</summary>
        public UserManager(StudyBuddyContext db)
        {
            _db = db;
        }
        public bool register(string username, string password)
        {
            //take in username and password
            User newUser = new User(username, PasswordHasher.hash(password));
            //make a user object and try to add the object to the database
            Console.WriteLine("checking if user already exists");
            User checkUser = _db.StudyBuddy_Users.Where(u => u.Username == username).FirstOrDefault();
            //if it works return the obejct
            if (checkUser == null)
            {
                //add to the table of users
                Console.WriteLine("Registration successful");
                _db.StudyBuddy_Users.Add(newUser);
                _db.SaveChanges();
                return true;
            }
            //else return null
            Console.WriteLine("Registraion failed");
            return false;
        }

        //delete a user from the database
        public bool DeleteSelf(User? user)
        {   
            if (user != null)
            {
                User self = _db.StudyBuddy_Users.Where(u => u.Username == user.Username).FirstOrDefault();
                if (self != null)
                {
                    _db.StudyBuddy_Users.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    _db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        //change the password of a user

        public bool ChangePassword(User? user, string newPassword)
        {
            if (user != null)
            {
                User self = _db.StudyBuddy_Users.Where(u => u.Username == user.Username).FirstOrDefault();
                if (self != null)
                {
                    self.Psswd = newPassword;
                    _db.SaveChanges();
                    return true;
                }
            }
            return false;

        }

        //login method
        public User? Login(string username, string password)
        {
            //validate both inputs
            if (username != null && password != null)
            {
                //check if a user with with the provided username exists in the db
                User? checkUser = getUser(username); //This step takes forever
                if (checkUser != null)
                {
                    //if there is a user with a given username in the db, fetch it from the db
                    //then check if the password matches the password present in the db
                    if (PasswordHasher.Validate(checkUser.Psswd, password))
                    {
                        Console.WriteLine("Authentication Succesful");
                        return checkUser;
                    }
                    Console.WriteLine("Authentication Failed: invalid password");
                    return null;
                }
                Console.WriteLine("Username is not present in the database");
                return null;
            }
            Console.WriteLine("A valid username and password must be provided");
            return null;

        }

        private User? getUser(string username)
        {
            User? account = _db.StudyBuddy_Users.Include(u => u.Profile)
            .Include(u => u.Profile.Hobbies)
            .Include(u => u.Profile.DesiredCourses)
            .Include(u => u.Profile.PreviousSchools)
            .Include(u => u.Profile.CurrentCourses)
            .Include(u => u.Profile.SentMessages)
            .Include(u => u.Profile.ReceivedMessages)
            .Include(u => u.Profile.AttendingEvents)    
            .Include(u => u.Profile.HostedEvents)
            .FirstOrDefault(u => u.Username == username);
            return account;
        }

    }

}
