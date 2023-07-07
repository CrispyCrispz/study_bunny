// ASK andrew if we have to make events include coure program AND SUBJECT (rather not)
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace StudyApp.Models;
/// <summary>
/// Class <c>Event</c> describes an event.
/// </summary>
public class Event
{

    /// <value> Property <c>User</c> Unique Id for database primary key</value>
    public int EventId { get; set; }
    private string _title;
    private DateTime _dateTime;
    public DateTimeOffset DateOfDay {
        get{return DateTime.Date;}
        set{DateTime = value.Add(DateTime.TimeOfDay).DateTime;}
    }
        
    public TimeSpan TimeOfDay {
        get{return DateTime.TimeOfDay;}
        set{DateTime = DateTime.Date.Add(value);}
    }

    private string _location;
    private School? _relatedSchool;
    private ProgramOfStudy? _relatedProgram;
    private Course? _relatedCourse;
    private string _description;
    private Profile _owner;
    private List<Profile> _attendees;

    /// <summary>
    /// Property <c>RelatedSchool</c> takes a string value and modifies the related school of the event
    /// </summary>
    public School? RelatedSchool { get; set; }

    /// <summary>
    /// Property <c>RelatedLearningCourse</c> takes a string value and modifies the related course of the event
    /// </summary>
    public Course? RelatedCourse { get; set; }

    /// <summary>
    /// Property <c>RelatedProgram</c> takes a string value and modifies the related program of the event
    /// </summary>
    public ProgramOfStudy? RelatedProgram { get; set; }

    /// <summary>
    /// Property <c>ProfileId</c> Required Foreign key to profile of owner of event
    /// </summary>
    //public int ProfileId { get; set; }

    /// <summary>
    /// Property <c>Owner</c> Required reference for the owner of the event
    /// </summary>
    [ForeignKey("ProfileId")]
    public Profile Owner { get; set; } = null!;

    /// <summary>
    /// Property <c>Attendees</c> Profiles of the users attending this event
    /// </summary>
    [InverseProperty("AttendingEvents")]
    public List<Profile> Attendees { get; set; } = new();

    /// <summary>
    /// Constructor <c>Event</c> initialazes fields for Event objects.
    /// </summary>
    public Event(string title, DateTime dateTime, string location, School? relatedSchool, ProgramOfStudy? relatedProgram, Course? relatedCourse,
                    string description, Profile owner)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Title is null");
        }
        try
        {
            this.DateTime = dateTime;
        }
        catch
        {
            throw new ArgumentException("Event date invalid");
        }
        if (string.IsNullOrWhiteSpace(location))
        {
            throw new ArgumentException("Location is null");
        }
        if (string.IsNullOrWhiteSpace(description))
        {
            throw new ArgumentException("Description is null");
        }
        this.Title = title;
        this.Location = location;
        this.RelatedCourse = relatedCourse;
        this.RelatedProgram = relatedProgram;
        this.RelatedSchool = relatedSchool;
        this.Description = description;
        this.Owner = owner;
        this.Attendees = new List<Profile>();
    }

    public Event() {}


    /// <summary>
    /// Method <c>CreateEvent</c> creates an event from user inputs
    /// Only the user who created it will also have the ability to edit the event
    /// </summary>
    public Event CreateEvent(User owner)
    {
        string? title = null;
        while (string.IsNullOrWhiteSpace(title))
        {
            Console.WriteLine("Event title:");
            title = Console.ReadLine();
        }
        DateTime? dateTime = null;
        while (dateTime is null)
        {
            Console.WriteLine("Event date&time:");
            try
            {
                string? newDateTime = Console.ReadLine();
                newDateTime = newDateTime is null ? " " : newDateTime;
                dateTime = DateTime.Parse(newDateTime);
            }
            catch
            {
                Console.WriteLine("Invalid date input");
            }
        }
        string? location = null;
        while (string.IsNullOrWhiteSpace(location))
        {
            Console.WriteLine("Event location:");
            location = Console.ReadLine();
        }
        string? relatedSchoolName = null;
        while (string.IsNullOrWhiteSpace(relatedSchoolName))
        {
            Console.WriteLine("Event related school:");
            relatedSchoolName = Console.ReadLine();
        }
        string? relatedProgramName = null;
        while (string.IsNullOrWhiteSpace(relatedProgramName))
        {
            Console.WriteLine("Event related program:");
            relatedProgramName = Console.ReadLine();
        }
        string? relatedCourseName = null;
        while (string.IsNullOrWhiteSpace(relatedCourseName))
        {
            Console.WriteLine("Event related school, course or program:");
            relatedCourseName = Console.ReadLine();
        }
        string? description = null;
        while (string.IsNullOrWhiteSpace(description))
        {
            Console.WriteLine("Event description:");
            description = Console.ReadLine();
        }
        // maybe put db methods here to check if inputs already exist in db ACTUALLY maybe create evenet method should be in event manager services and not in event class
        School relatedSchool = new School(relatedSchoolName, null, null, null);
        ProgramOfStudy relatedProgram = new ProgramOfStudy(relatedProgramName);
        Course relatedCourse = new Course(relatedCourseName, null, null, null);
        return new Event(title, (DateTime)dateTime, location, relatedSchool, relatedProgram, relatedCourse, description, owner.Profile);
    }

    /// <summary>
    /// Method <c>WillAttend</c> adds user to attendees list if they are not present yet.
    /// </summary>
    public void WillAttend(Profile attendingStudent)
    {
        if (!CheckPresence(attendingStudent))
        {
            this.Attendees.Add(attendingStudent);
        }
    }

    /// <summary>
    /// Method <c>WillNotAttend</c> removes user from attendees list while looking if they are in it.
    /// </summary>
    public void WillNotAttend(Profile unattendingStudent)
    {
        if (CheckPresence(unattendingStudent))
        {
            this.Attendees.Remove(unattendingStudent);
        }
    }

    /// <summary>
    /// Method <c>CheckPresence</c> returns bool for if the user is in attendees list.
    /// </summary>
    public bool CheckPresence(Profile student)
    {
        foreach (Profile attendee in this.Attendees)
        {
            if (attendee.Equals(student))
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Method <c>EditEventUserInteractive</c> if the user is the owner of the event, 
    /// it interacts with them to modify the properties of the event.
    /// </summary>
    public void EditEventUserInteractive(User? owner)
    { //enable ui to modify event box
        if (IsEventOwner(owner))
        {
            while (true)
            {
                Console.WriteLine("What will you edit? Type no to stop");
                Console.WriteLine("t: title d: date&time l: location s: description f: related-learning-field");
                string? field = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(field))
                {
                    if (field is "no")
                    {
                        break;
                    }
                    if (field is "t" or "d" or "l" or "s" or "f" or "rs" or "rp" or "rc")
                    {
                        EditEvent(field);
                    }
                }
            }
        }
    }
    /// <summary>
    /// Method <c>EditEvent</c> looks at the field to be modified and takes new value from user
    /// </summary>
 public void EditEvent(string editField)
    { //enable ui to modify event box
        string? value = null;
        switch (editField)
        {
            case "t":
                Console.WriteLine("New title: ");
                while (string.IsNullOrWhiteSpace(value))
                    {
                        value = Console.ReadLine();
                    }
                Title = value;
                break;
            case "d":
                Console.WriteLine("New Date format ex(Jan 1, 2009): ");              
                    while (string.IsNullOrWhiteSpace(value))
                    {
                        value = Console.ReadLine();
                        try
                        {
                            DateTime dateInput = DateTime.Parse(value);
                            DateTime = dateInput;
                        }
                        catch
                        {
                            Console.WriteLine("Invalid date input");
                            value = null;
                        }
                    }
                    break;
            case "l":
                Console.WriteLine("New location: ");
                while (string.IsNullOrWhiteSpace(value))
                    {
                        value = Console.ReadLine();
                    }
                Location = value;
                break;
            case "s":
                Console.WriteLine("New description: ");
                while (string.IsNullOrWhiteSpace(value))
                    {
                        value = Console.ReadLine();
                    }
                Description = value;
                break;
            case "rs":
                Console.WriteLine("New related school: ");
                while (string.IsNullOrWhiteSpace(value))
                    {
                        value = Console.ReadLine();
                        try
                        {
                            School newSchool = new School(value, null, null, null);
                            RelatedSchool = newSchool;
                        
                        }
                        catch
                        {
                            Console.WriteLine("Invalid input");
                            value = null;
                        }
                    }
                    break;
            case "rc":
                Console.WriteLine("New related school: ");
                while (string.IsNullOrWhiteSpace(value))
                    {
                        value = Console.ReadLine();
                        try
                        {
                            Course newCourse = new Course(value, null, null, null);
                            RelatedCourse = newCourse;
                        
                        }
                        catch
                        {
                            value = null;
                        }
                    }
                    break;
            case "rp":
                Console.WriteLine("New related program: ");
                while (string.IsNullOrWhiteSpace(value))
                    {
                        value = Console.ReadLine();
                        try
                        {
                            ProgramOfStudy newProgram = new ProgramOfStudy(value);
                            RelatedProgram = newProgram;
                        }
                        catch
                        {
                            value = null;
                        }
                    }
                break;      
            }
        }
    /// <summary>
    /// Method <c>EventOwner</c> takes a user parameter and returns bool if the event owner is the same person as the provided user
    /// </summary>
    public bool IsEventOwner(User? owner)
    {
        //return this._owner.Equals(owner);
        return true;
    }
    public void EditEventGUI(Profile user, Event editedEvent){
        this.Title=editedEvent.Title;
        this.DateTime=editedEvent.DateTime;
        this.Location=editedEvent.Location;
        this.RelatedSchool=editedEvent.RelatedSchool;
        this.RelatedProgram=editedEvent.RelatedProgram;
        this.RelatedCourse=editedEvent.RelatedCourse;
        this.Description=editedEvent.Description;
        this.Owner=editedEvent.Owner;
    }
    

    /// <summary>
    /// Method <c>EditTitle</c> takes a string value and modifies the title of the event
    /// </summary>
    public string Title
    {
        get { return this._title; }
        set
        {
            // if (string.IsNullOrWhiteSpace(value))
            // {
            //     throw new ArgumentException("Title is null");
            // }
            this._title = value;
        }

    }
    /// <summary>
    /// Method <c>EditDate</c> takes a DateTime value and modifies the date and time of the event
    /// </summary>
    public DateTime DateTime
    {
        get { return this._dateTime; }
        set
        {
            if (value < DateTime.Now)
            {
                // throw new ArgumentException("Date passed");
            }
            this._dateTime = value;
        }
    }

    /// <summary>
    /// Method <c>EditLocation</c> takes a string value and modifies the location of the event
    /// </summary>
    public string Location
    {
        get
        {
            return this._location;
        }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Location is empty");
            }
            this._location = value;
        }
    }

    /// <summary>
    /// Method <c>EditLocation</c> takes a string value and modifies the description of the event
    /// </summary>
    public string Description
    {
        get
        {
            return this._description;
        }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Description is empty");
            }
            this._description = value;
        }

    }
}
