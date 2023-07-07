using System.Reactive;
using StudyApp.Models;
using StudyApp.Models.Managers;
using ReactiveUI;

namespace StudyApp.ViewModels
{
    
    public class ProfileEditViewModel : ViewModelBase
    {
        
        public Profile Profile {get; set;}
        public ReactiveCommand<Unit, Unit> Ok { get; }
        public ReactiveCommand<Unit,Unit> Leave { get; }
        public Session currentSession;

        public ProfileEditViewModel(Profile p, Session session)
        {
            Profile = p;
            currentSession = session;
            Ok = ReactiveCommand.Create(SaveProfile);
            Leave = ReactiveCommand.Create(() => { });
        }


        public void SaveProfile(){
            currentSession.ProfileServices.RegisterOrReplace(Profile);
        }
        
    }

}
