
using System.Collections.Generic;
using System.Linq;
using StudyApp.Models;
namespace StudyApp.Models.Search
{
    // TODO: contemplate if it would be easier to just make this class one method in the inbox class, I think it might be?
    public class SearchMessage
    {
        public User User {get;set;}
        
        private StudyBuddyContext _db;

        public SearchMessage(User user, StudyBuddyContext db)
        {
            this._db = db;
            this.User = user;
        }

        public List<Message>? bySender(string query)
        {
            query = query.ToUpper();
            List<Message> results = _db.StudyBuddy_Messages
                                    .Where(m => m.Sender.FirstName.Contains(query) || m.Sender.LastName.Contains(query))
                                    .OrderByDescending(m => m.TimeStamp)
                                    .ToList<Message>();
            return results;
        }

        public List<Message>? byRecipient(string query)
        {
            query = query.ToUpper();
            List<Message> results = _db.StudyBuddy_Messages
                                    .Where(m => m.Recipient.FirstName.Contains(query) || m.Recipient.LastName.Contains(query))
                                    .OrderByDescending(m => m.TimeStamp)
                                    .ToList<Message>();
            return results;
        }

        public List<Message>? byContent(string query)
        {
            List<Message> results = _db.StudyBuddy_Messages
                                    .Where(m => m.Content.Contains(query))
                                    .OrderByDescending(m => m.TimeStamp)
                                    .ToList<Message>();
            return results;
        }
    }
}
