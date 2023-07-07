
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using StudyApp.Models;
namespace StudyApp.Models.Managers
{


    /// <summary>
    /// Class <c>Inbox</c> inbox of user's messages.
    /// </summary>
    public class MessageManager
    {

        private Profile _owner;
        private StudyBuddyContext _context;

        
        public MessageManager(Profile user, StudyBuddyContext context){ 
            this._owner=user;
            this._context=context;
        }

        /// <summary>
        /// Method <c>ReadMessage</c> opens a received message.
        /// </summary>
        public string ReadMessage(int MessageId){ 
            Message? msg = _context.StudyBuddy_Messages.Where(message => message.MessageId == MessageId && message.Recipient==_owner)
            .FirstOrDefault<Message>();
            if(msg is Message){
                msg.MarkAsRead();
                this._context.SaveChanges();
                return msg.Content;
            }
            else return "";
            
        }
        /// <summary>
        /// Method <c>SendMessage</c> sends message.
        /// </summary>
        public void SendMessage(Profile recipient, string content){ 
            Message msg = new Message(this._owner,recipient,content);
            _context.StudyBuddy_Messages.Add(msg);
            this._context.SaveChanges();
            
        }
        /// <summary>
        /// Method <c>DeleteMessage</c> deletes a message.
        /// </summary>
        public void DeleteMessage(int MessageId){ //ui
            Message? msg=_context.StudyBuddy_Messages.Where(message => message.MessageId == MessageId && message.Recipient==_owner).FirstOrDefault<Message>();
            if(msg is Message)
            _context.StudyBuddy_Messages.Remove(msg);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Method <c>DeleteSentMessage</c> deletes a sent message.
        /// </summary>
        public void DeleteSentMessage(int MessageId){ //ui
            Message? msg=_context.StudyBuddy_Messages.Where(message => message.MessageId == MessageId && message.Sender==_owner).FirstOrDefault<Message>();
            if(msg is Message)
            _context.StudyBuddy_Messages.Remove(msg);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Method <c>DeleteAllMessages</c> deletes all Messages.
        /// </summary>
        public void DeleteAllMessages(){ //ui
            this._context.StudyBuddy_Messages.Where(message => message.Recipient==_owner || message.Sender==_owner).ExecuteDelete();
            this._context.SaveChanges(); 
        }
        /// <summary>
        /// Method <c>DeleteAllMessages</c> deletes all Messages.
        /// </summary>

        public void DeleteAllSentMessages(){ //ui
            this._context.StudyBuddy_Messages.Where(message => message.Sender ==_owner).ExecuteDelete();
            this._context.SaveChanges();
        }

        /// <summary>
        /// Method <c>AddMessage</c> adds message to the list of messages when user gets a new message
        /// </summary>
        public void AddMessage(Message message){ 
            _context.StudyBuddy_Messages.Add(message);
            this._context.SaveChanges();
        }

        ///sort messages

        /// <summary>
        /// Method <c>SortMessagesByUnread</c> returns received messages that are unread.
        /// </summary>
        public List<Message> SortMessagesByUnread(){
            List<Message> unreadMessages = _context.StudyBuddy_Messages
            .Where(message => message.Read==false).ToList<Message>();
            return unreadMessages;
        }
        /// <summary>
        /// Method <c>SortMessagesBySender</c> returns received messages that from a specific sender.
        /// </summary>
        public  List<Message> SortMessagesBySender(Profile sender){
            List<Message> messagesFromSender = _context.StudyBuddy_Messages
            .Where(message => message.Sender==sender).ToList<Message>();
            return messagesFromSender;
        }
        /// <summary>
        /// Method <c>SortMessagesByRecipient</c> returns received messages that for a specific recipient.
        /// </summary>
        public  List<Message> SortMessagesByRecipient(Profile recipient){
            List<Message> messagesToRecipient = _context.StudyBuddy_Messages
            .Where(message => message.Recipient==recipient).ToList<Message>();
            return messagesToRecipient;
        }

        /// <summary>
        /// Method <c>Messages</c> returns received messages.
        /// </summary>
        public List<Message>? GetSentMessages() { 
            List<Message>? messages = _context.StudyBuddy_Messages
                                    .Where(m => m.Sender == _owner).ToList<Message>();
            return messages;
        }

        /// <summary>
        /// Method <c>Messages</c> returns sent messages.
        /// </summary>
        public List<Message> GetReceivedMessages() { 
            List<Message>? messages = _context.StudyBuddy_Messages
                                    .Where(m => m.Recipient == _owner).ToList<Message>();
            return messages;
        }
        
    }

}