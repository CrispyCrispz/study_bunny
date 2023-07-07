using System.Reactive;
using StudyApp.Models;
using ReactiveUI;
using System;
using StudyApp.Models.Managers;

namespace StudyApp.ViewModels
{

    public class EventDisplayViewModel : ViewModelBase
    {

        private string _attendStatus;
        private bool _status;
        private Session _session = null!;
        public Event Event { get; private set;} = null!;
        public bool AttendVisible;
        public ReactiveCommand<Unit, Unit> Attend { get; }
        public bool UnattendVisible;
        public ReactiveCommand<Unit, Unit> Unattend { get; }
        public ReactiveCommand<Unit, Unit> Leave { get; }

        public EventDisplayViewModel(Event e, Session session)
        {
            _session=session;
            Event = e;
            IsAttending="Attend";
            Status=false;
            Leave=ReactiveCommand.Create(() => { });
            Attend=ReactiveCommand.Create(() => { });
            Unattend=ReactiveCommand.Create(() => { });
            if(_session.User is User)
            if(_session.User.Profile is Profile)
            ButtonSetup(Event.CheckPresence(_session.User.Profile));
        }

        private void ButtonSetup(bool userIsAttending)
        {   
            if(userIsAttending){
                AttendVisible=false;
                UnattendVisible=true;
            }else{
                AttendVisible=true;
                UnattendVisible=false;
            }
        }

        public Event DisplayEvent()
        {
            return this.Event;
        }

        public void AttendEvent()
        {
            Status=true;
            if(_session.EventServices is EventsManager)
            this._session.EventServices.AttendEvent(this.Event.EventId);
            ButtonSetup(Status);
        }

        public void UnattendEvent()
        {
            Status=false;
            if(_session.EventServices is EventsManager)
            this._session.EventServices.UnattendEvent(this.Event.EventId);
            ButtonSetup(Status);
            
        }

        public string IsAttending { 
           get => _attendStatus;
           private set => _attendStatus=value;
        }

        public bool Status { 
           get => _status;
           private set => _status=value;
        }

    }
    
}