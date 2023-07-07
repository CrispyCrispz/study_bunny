using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StudyApp.Models;
namespace StudyApp.Models.Managers
{


    public class EventsManager{
        /// <value>
        /// Property <c>_user</c> user's profile.
        /// </value>
        private Profile _user;
        /// <value>
        /// Property <c>_context</c> events db.
        /// </value>
        private StudyBuddyContext _context;
        /// <value>
        /// Property <c>_events</c> all events in the app.
        /// </value>
        private List<Event> _events;

        /// <summary>
        /// Constructor <c>EventsManager</c> creates events manager for a user
        /// </summary>
        public EventsManager(Profile user, StudyBuddyContext context){
            this._user=user;
            this._context=context;
        }
        /// <summary>
        /// Method <c>CreateEvent</c> creates an event and stores it to db
        /// </summary>
        public Event CreateEvent(string title, DateTime dateTime, string location, School? relatedSchool, ProgramOfStudy? relatedProgram, 
                                Course? relatedCourse, string description)
        {
            Event usersNewEvent=new Event (title, dateTime, location, relatedSchool, relatedProgram, 
                                relatedCourse, description, this._user);
            this._context.StudyBuddy_Events.Add(usersNewEvent);
            this._context.SaveChanges();
            return usersNewEvent;

        }
        public Event AddEvent(Event newEvent)
        {
            newEvent.Owner=this._user;
            this._context.StudyBuddy_Events.Add(newEvent);
            this._context.SaveChanges();
            return newEvent;
        }
        /// <summary>
        /// Method <c>EditEventGUI</c> edit an event and updates it in db
        /// </summary>
        public void EditEventGUI(int eventId,Event editedEvent){
            Event? targetEvent=this._context.StudyBuddy_Events.Where(e=>e.EventId==eventId).FirstOrDefault<Event>();
            if(targetEvent is Event){
                Event updateTarget=new Event(editedEvent.Title,editedEvent.DateTime,editedEvent.Location,editedEvent.RelatedSchool,
                                    editedEvent.RelatedProgram,editedEvent.RelatedCourse,editedEvent.Description,this._user);
                targetEvent.EditEventGUI(this._user,updateTarget);
                this._context.SaveChanges();
            }
        }
        /// <summary>
        /// Method <c>EditEvent</c> edit an event and updates it in db for mock
        /// </summary>
        public void EditEventMock(int eventId){
            Event? targetEvent = this._context.StudyBuddy_Events.Where(e=>e.EventId==eventId).FirstOrDefault<Event>();
            if(targetEvent is Event)
            targetEvent.Location="testing lc";
            this._context.SaveChanges();
        }
        /// <summary>
        /// Method <c>DeleteEvent</c> deletes an event and deletes it in db
        /// </summary>
        public void DeleteEvent(int eventId){
            Event? targetEvent = this._context.StudyBuddy_Events
            
            .Where(e=>e.EventId==eventId).FirstOrDefault<Event>();
            if(targetEvent is Event)
            if(targetEvent.IsEventOwner(this._user.User)){
                this._context.StudyBuddy_Events.Remove(targetEvent);
                this._context.SaveChanges();
            }
        }
        /// <summary>
        /// Method <c>AttendEvent</c> adds user to an event and registers it in db
        /// </summary>
        public void AttendEvent(int eventId){
            Event? targetEvent = this._context.StudyBuddy_Events
            .Where(e=>e.EventId==eventId).FirstOrDefault<Event>();
            if(targetEvent is Event)
            targetEvent.WillAttend(this._user);
            //this._context.SaveChanges();
        }
        /// <summary>
        /// Method <c>UnattendEvent</c> deletes user from an event and removes their attendance it in db
        /// </summary>
        public void UnattendEvent(int eventId){
            Event? targetEvent = this._context.StudyBuddy_Events.Where(e=>e.EventId==eventId).FirstOrDefault<Event>();
            if(targetEvent is Event)
            targetEvent.WillNotAttend(this._user);
            this._context.SaveChanges();
        }
        /// <summary>
        /// Method <c>SeeAttendees</c> gets the list of attendees for a specific event
        /// </summary>
        public List<Profile> SeeAttendees(int eventId){
            Event? targetEvent = this._events.Where(e=>e.EventId==eventId).FirstOrDefault<Event>();
            if(targetEvent is Event)
            return targetEvent.Attendees;
            else return new List<Profile>();
        }
        /// <summary>
        /// Field <c>AttendingEvents</c> gets all events user will attend
        /// </summary>
        public List<Event> AttendingEvents{
            get{
                return this._context.StudyBuddy_Events
                .Where(e => e.Attendees.Contains(_user))
                .ToList<Event>();
            }
        }
        /// <summary>
        /// Field <c>OwnersEvents</c> gets all events made by user
        /// </summary>
        public List<Event> OwnersEvents{
            get{
                return this._context.StudyBuddy_Events
                .Include(e => e.Owner)
                .Include(e => e.Attendees)
                .Include(e => e.RelatedCourse)
                .Include(e => e.RelatedProgram)
                .Include(e => e.RelatedSchool)
                .Where(e => e.Owner.ProfileId==_user.ProfileId)
                .ToList<Event>();
            }
        }

    }

}