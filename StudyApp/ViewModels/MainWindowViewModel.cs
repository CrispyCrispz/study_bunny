using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using ReactiveUI;
using StudyApp.Models;
using StudyApp.Models.Managers;

namespace StudyApp.ViewModels
{
    
    class MainWindowViewModel : ViewModelBase
    {

        Session currentSession;
        StudyBuddyContext db;
        ViewModelBase content;
        User? LoggedInUser;
        Profile? User;

        public ViewModelBase Content
        {
            get => content;
            private set => this.RaiseAndSetIfChanged(ref content, value);
        }

        public MainWindowViewModel()
        {

            //at app startup create a session and db context
            db = new StudyBuddyContext();
            currentSession = new Session(db);
            //create a 
            LogInViewModel vm = new LogInViewModel();

            //make a connection between Login reactive command in vm to call method PrepareMainPage with an argument that should be a valid user
            vm.Login.Subscribe(x =>{PrepareMainPage(vm.LoginUser(currentSession));});
            vm.Register.Subscribe(x => { PrepareMainPage(vm.RegisterUser(currentSession)); });

            Content = vm;
        }

        public void PrepareMainPage(Session currentSession)
        {
            this.LoggedInUser = currentSession.User; 
            Profile p = new Profile(currentSession.User, null, "FirstName","LastName","they/them",20, new ProgramOfStudy("CS"), new School("Dawson",null,null,null),
                       "biography", new List<Hobby>{new Hobby("cs", new List<Profile>()),new Hobby("Dancing", null), new Hobby("Running", null), new Hobby("Coding", null) },
                       new List<Course> {new Course("CurrentCourse1",null,null,null), new Course("CurrentCourse2",null,null,null), new Course("CurrentCourse3",null,null,null)},
                       new List<Course> {new Course("DesiredCourse1",null,null,null), new Course("DesiredCourse2",null,null,null), new Course("DesiredCourse3",null,null,null)},
                        new List<School>{new School("Previous School",null,null,null), new School("Previous School 1",null,null,null), new School("Previous School 2",null,null,null)},null,null,null,null);
            Content = new ProfileDisplayViewModel(currentSession);
        }

        public void ViewEvent(Event e)
        {
            EventDisplayViewModel vm = new EventDisplayViewModel(e,currentSession);
            ProfileDisplayViewModel dispvm_main =  new ProfileDisplayViewModel(currentSession);
            Content = vm;
            vm.Leave.Subscribe(x => {PrepareMainPage(this.currentSession); Content = dispvm_main;});
            vm.Attend.Subscribe(x => {vm.AttendEvent();}); 
            vm.Unattend.Subscribe(x => {vm.UnattendEvent();}); 
        }

        public void EditEvent(Event targetEvent)
        {
            
            ProfileDisplayViewModel dispvm_main =  new ProfileDisplayViewModel(currentSession);
            var vm = new EventEditViewModel(targetEvent, this.currentSession);
            
            vm.Edit.Subscribe(x => {vm.EditEvent();  PrepareMainPage(this.currentSession); Content = dispvm_main;});
            vm.Delete.Subscribe(x => {vm.DeleteEvent();  PrepareMainPage(this.currentSession); Content = new EventsDisplayViewModel(currentSession);});
            vm.Leave.Subscribe(x => {PrepareMainPage(this.currentSession); Content = dispvm_main;});
            Content = vm;
        }
        
        public void CreateEvent()
        {
            ProfileDisplayViewModel dispvm = (ProfileDisplayViewModel) Content; //change to view event
            ProfileDisplayViewModel dispvm_main =  new ProfileDisplayViewModel(currentSession);
            Content = new CreateEventViewModel(new Event(), currentSession); //what is content
            var vm = (CreateEventViewModel) Content; // no need
            
            vm.PostEvent.Subscribe(x => {vm.AddEvent(); PrepareMainPage(currentSession); Content = dispvm;}); 
            vm.Leave.Subscribe(x => {PrepareMainPage(this.currentSession); Content = dispvm_main;});
            
        }
        public void UserDisplayEvents() //come back
        {
            ProfileDisplayViewModel dispvm_main = (ProfileDisplayViewModel) Content;
            Content = new EventsDisplayViewModel(this.currentSession); //what is content
            var vm = (EventsDisplayViewModel) Content; // no need

            //go main page
            vm.Leave.Subscribe(x => {PrepareMainPage(currentSession); Content = dispvm_main;}); 
            
        }

        private void SearchEvent()
        {
            SearchEventsViewModel vm= new SearchEventsViewModel(this.currentSession);
            ProfileDisplayViewModel dispvm_main = new ProfileDisplayViewModel(this.currentSession);
            Content=vm;
            //go main page
            vm.Leave.Subscribe(x => {PrepareMainPage(currentSession); Content = dispvm_main;}); 
            vm.Search.Subscribe(x => {vm.SearchEvents(); Content=vm;}); 
            
        }

        private void SearchProfile()
        {
            SearchProfilesViewModel vm= new SearchProfilesViewModel(this.currentSession);
            ProfileDisplayViewModel dispvm_main = new ProfileDisplayViewModel(this.currentSession);
            Content=vm;
            //go main page
            vm.Leave.Subscribe(x => {PrepareMainPage(currentSession); Content = dispvm_main;}); 
            vm.Search.Subscribe(x => {vm.SearchProfiles(); Content=vm;}); 
            
        }

        private object FindControl<T>(string v)
        {
            throw new NotImplementedException();
        }

        public void EditProfile(Session currentSession)
        {
            ProfileDisplayViewModel dispvm = (ProfileDisplayViewModel) Content;
            var vm = new ProfileEditViewModel(dispvm.Session.User.Profile, dispvm.Session);
            
            vm.Ok.Subscribe(x => {Content = dispvm;});
            Content = vm;
        }

    }

}