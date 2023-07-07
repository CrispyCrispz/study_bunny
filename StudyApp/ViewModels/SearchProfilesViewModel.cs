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

    public class SearchProfilesViewModel : ViewModelBase
    {

        private Boolean _showProfileResults;
        public Session UserSession { get; set;} = null!;
        public Profile User {get; set;} = null!;
        private List<Profile> _profileResults;
        public string Keyword {get; set;} = null!;
        public ReactiveCommand<Unit,Unit> Search { get; } = ReactiveCommand.Create(() => { });
        public ReactiveCommand<Unit,Unit> Clear { get; } = ReactiveCommand.Create(() => { });
        public ReactiveCommand<Unit,Unit> Leave { get; } = ReactiveCommand.Create(() => { });

        public SearchProfilesViewModel(Session userSession)
        {
            this.UserSession=userSession;
            this.User=userSession.User.Profile;
            this._profileResults=new List<Profile>();
        }

        public void SearchProfiles(){ 
            SearchProfile profilesQuery = UserSession.SearchProfiles;
            ProfileResults=profilesQuery.byName(Keyword);
        }
        
        public Boolean ShowProfileResults
        {
            get => _showProfileResults;
            private set => this.RaiseAndSetIfChanged(ref _showProfileResults, value);
        }

        public List<Profile> ProfileResults         
        {
            get => _profileResults;
            private set => this.RaiseAndSetIfChanged(ref _profileResults, value);
        }

        private void DisplayProfileResults()
        {
            ShowProfileResults = true;
            //byProgramName 
            //bySchoolName
            //byDescription
            //byTitle
            ProfileResults = UserSession.SearchProfiles.byName(Keyword);
        }

    }

}