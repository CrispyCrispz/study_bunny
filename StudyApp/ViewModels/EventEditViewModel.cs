using StudyApp.Models.Managers;
using System.Reactive;
using StudyApp.Models;
using ReactiveUI;
using System;

namespace StudyApp.ViewModels
{

    public class EventEditViewModel : ViewModelBase
    {
        
        public Session UserSession { get; set;} = null!;
        public Event Event {get; set;} = null!;
        private StudyBuddyContext _context {get; set;} = null!;
        public string Title {get; set;} = null!;
        public DateTime DateTime{get; set;}
        public string Description{get; set;} = null!;
        public string Location{get; set;} = null!;
        public ReactiveCommand<Unit, Unit> Edit { get; }
        public ReactiveCommand<Unit, Unit> Delete { get; }
        public ReactiveCommand<Unit, Unit> Leave { get; }

        public EventEditViewModel(Event e, Session session)
        {
            this.UserSession=session;
            this.Event = e;
            this._context=new StudyBuddyContext();

            Edit = ReactiveCommand.Create(() => { });
            Delete = ReactiveCommand.Create(() => { });
            Leave = ReactiveCommand.Create(() => { });
        }

        public void EditEvent()
        {
            EventsManager? db = UserSession.EventServices;
            if(db is EventsManager)
            db.EditEventGUI(Event.EventId,Event); 
        }

        public void DeleteEvent()
        {
            EventsManager? db = UserSession.EventServices;
            if(db is EventsManager)
            db.DeleteEvent(this.Event.EventId);
        }

    }
    
}
