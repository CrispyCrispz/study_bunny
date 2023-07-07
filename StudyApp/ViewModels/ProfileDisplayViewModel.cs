using System.Collections.Generic;
using System.Collections.ObjectModel;
using StudyApp.Models;
using StudyApp.Models.Managers;

namespace StudyApp.ViewModels
{
    
    public class ProfileDisplayViewModel : ViewModelBase
    {

        public Profile Profile { get; }
        public Session Session { get; }

        public ProfileDisplayViewModel(Session currentSession)
        {
            Session = currentSession;
            Profile = currentSession.User.Profile;
        }

    }

}