using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using System;
using ReactiveUI;
using StudyApp.Models;
using StudyApp.Models.Managers;

namespace StudyApp.ViewModels
{

    public class CreateEventViewModel : ViewModelBase
    {

        public Session UserSession { get; set;} = null!;
        public Event Event { get; set;} = null!;
        public Profile User {get; set;} = null!;
        public string School{get; set;}
        public string Program{get; set;}
        public string Course{get; set;}
        public ReactiveCommand<Unit,Unit> PostEvent { get; } = ReactiveCommand.Create(() => { });
        public ReactiveCommand<Unit,Unit> Leave { get; } = ReactiveCommand.Create(() => { });

        public CreateEventViewModel(Event e, Session userSession)
        {
            this.UserSession=userSession;
            this.User=userSession.User.Profile;
            this.Event=e;
        }

        public Event AddEvent()
        {
            EventsManager? db = UserSession.EventServices;
            if(db is EventsManager)
            db.AddEvent(this.Event); 
            return this.Event;
        }
        
    }
    
}