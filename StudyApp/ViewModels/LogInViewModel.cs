using StudyApp.Models;
using ReactiveUI;
using System.Reactive;
using StudyApp.Models.Managers;
using StudyApp.Models;

namespace StudyApp.ViewModels
{
    
    public class LogInViewModel : ViewModelBase
    {

        public User? User { get; private set;}
        public string Username {get; set;}
        public string Password {get; set;}
        public ReactiveCommand<Unit, Unit> Login { get; } = ReactiveCommand.Create(() => { });
        public ReactiveCommand<Unit, Unit> Register { get; } = ReactiveCommand.Create(() => { });

        public Session RegisterUser(Session session)
        {
            session.Register(Username, Password);
            return session;
        }

        public Session LoginUser(Session session)
        {
            session.Login(Username, Password);
            return session;
        }

    }

}