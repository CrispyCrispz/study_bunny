using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using System;
using ReactiveUI;
using StudyApp.Models;
using StudyApp.Models.Managers;
using StudyApp.Models.Search;

namespace StudyApp.ViewModels
{

    public class SearchEventsViewModel : ViewModelBase
    {

        private Boolean _showEventResults;
        public Session UserSession { get; set;} = null!;
        public Profile User {get; set;} = null!;
        private List<Event> _eventResults;
        public string Keyword {get; set;} = null!;
        public ReactiveCommand<Unit,Unit> Search { get; } = ReactiveCommand.Create(() => { });
        public ReactiveCommand<Unit,Unit> Clear { get; } = ReactiveCommand.Create(() => { });
        public ReactiveCommand<Unit,Unit> Leave { get; } = ReactiveCommand.Create(() => { });

        public SearchEventsViewModel(Session userSession)
        {
            this.UserSession=userSession;
            this.User=userSession.User.Profile;
            this._eventResults=new List<Event>();
        }

        public void SearchEvents(){ 
            SearchEvent eventsQuery = UserSession.SearchEvents;
            EventResults=eventsQuery.byTitle(Keyword);
        }
        public Boolean ShowEventResults
        {
            get => _showEventResults;
            private set => this.RaiseAndSetIfChanged(ref _showEventResults, value);
        }

        public List<Event> EventResults         
        {
            get => _eventResults;
            private set => this.RaiseAndSetIfChanged(ref _eventResults, value);
        }

        private void DisplayEventResults()
        {
            ShowEventResults = true;
            //byProgramName 
            //bySchoolName
            //byDescription
            //byTitle
            EventResults = UserSession.SearchEvents.byTitle(Keyword);
        }

    }

}