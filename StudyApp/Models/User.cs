using System.ComponentModel.DataAnnotations.Schema;
namespace StudyApp.Models
{
    public class User
    {
        /// <value> Property <c>User</c> Unique Id for database primary key</value>
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Psswd { get; set; }
        public Profile? Profile { get; set; }  // WHY CAN"T I SEE IT IN TABLES???

        public User(string username, string psswd)
        {
            Username = username;
            Psswd = psswd;
        }

        private User() {}

        public Profile login(string userId, string password)
        {
            // if the user was able to be authenticated, return the profile mathcing the user
            // if (authenticate(userId, password))
            // {
            //     var user = db.getUser(userId);
                //after verifying the user does exist
                //if the user has already made a profile,  fetch it from the database, otherwise leave it null
            //     var prof = db.getUserProfile(userId);
            //     if (prof)
            //     {
            //         profile = prof;
            //     }
            //     return user;
            // }
            return null;
        }

        public static bool authenticate(string username, string password)
        {
            //to avoid possble user enumeration,whether the username dosent exist or the password didnt match , return false 
            // var user = db.getUser(username);
            // if (user)
            // {
                //once we get back a user matching the same username from the database we will verify the passwords match
            //     if (authenticate(password, user.password))
            //     {
                    //once we have authenticated the user, call login and return a user object
            //         return true;
            //     }
            // }
            return false;
        }

        public static void signup(){

        }

        public void changePassword(string oldPassword, string newPassword)
        {
            //implement later on 
        }

        public bool checkPassword(string input, string password)
        {
            if (input == password)
            {
                return true;
            }
            return false;
        }
        public void deleteAccount(string userId)
        {
            // db.removeAccount(userId);
        }

    }

}