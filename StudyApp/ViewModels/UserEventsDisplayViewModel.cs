using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using ReactiveUI;
using StudyApp.Models.Managers;
using StudyApp.Models;

namespace StudyApp.ViewModels
{
    
    public class  EventsDisplayViewModel : ViewModelBase
    {
        public Session UserSession { get; set;} = null!;
        public List<Event> Events { get; set;} = null!;
        public ReactiveCommand<Unit,Unit> EditT { get; } = ReactiveCommand.Create(() => { });
        public ReactiveCommand<Unit,Unit> Leave { get; } = ReactiveCommand.Create(() => { });

        public EventsDisplayViewModel (Session session)
        {
            this.UserSession=session;
            User? p = session.User;
            GetEvents();
        }

        public void GetEvents(){

            
            EventsManager? db = UserSession.EventServices;
            if(db is EventsManager)
            this.Events=db.OwnersEvents;
            else this.Events=new List<Event>();

        }

    }

}