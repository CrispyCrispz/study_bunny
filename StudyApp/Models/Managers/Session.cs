using System;
using StudyApp.Models;
using StudyApp.Models.Search;
using StudyApp.Models;
namespace StudyApp.Models.Managers
{

    public class Session
    {

        public User? User;

        public UserManager UserServices;
        private StudyBuddyContext _db;
        public EventsManager? EventServices;
        public MessageManager? MessageServices;
        public ProfileManager? ProfileServices;
        public SearchEvent SearchEvents;
        public SearchMessage? SearchMessages;
        public SearchProfile SearchProfiles;

        //at Initialization session shouldn't create all the services at once since there is the possibility of a user not having a profile yet

        public Session(StudyBuddyContext db)
        {
            this._db = db;
            this.UserServices = new UserManager(db);
            this.SearchEvents = new SearchEvent(db);
            this.SearchProfiles = new SearchProfile(db);
        }
        public bool Login(string username, string password)
        {
            this.User = UserServices.Login(username, password);
            if (this.User != null)
            {
                this.ProfileServices = new ProfileManager(this.User, _db);
                
                if (this.ProfileServices.HasProfile())
                {
                    //if user has a profile attached to the user, initalize the profile related services
                    this.InitUserSession(this.User);
                    return true;
                }
                // else initialize a dummy profile services and only allow the user to use userservices and profile services
                Profile dummyProfile = new Profile(User, null, "Must Edit", "Must Edit", "Must Edit", null, null, null, null, null, null , null ,null , null ,null ,null ,null);
                this.ProfileServices.RegisterOrReplace(dummyProfile);
                Console.WriteLine("User has been logged in but no profile was found, user was assigned an unpersonalized profile");
            }
            return false;

        }


        public bool Logout()
        {
            if (this.User != null)
            {
                this.MessageServices = null;
                this.EventServices = null;
                this.SearchMessages = null;
                this.ProfileServices = null;
                this.User = null;
                return false;
            }
            return false;
        }
        public void InitUserSession(User user)
        {
            this.MessageServices = new MessageManager(User.Profile, _db);
            this.EventServices = new EventsManager(User.Profile, _db);
            this.SearchMessages = new SearchMessage(User, _db);
            this.ProfileServices = new ProfileManager(user, _db);
            this.User = user;
        }
        
        public bool DeleteAccount(){
        return  UserServices.DeleteSelf(User);
        }

        public bool ChangePassword(string newPassword){
            return  UserServices.ChangePassword(User, newPassword);
        }

        public bool Register(string username, string password){
            return UserServices.register(username,password);
        }
    }

}