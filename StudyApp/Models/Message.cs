using System;

namespace StudyApp.Models
{
        
    /// <summary>
    /// Class <c>Point</c> models a point in a two-dimensional plane.
    /// </summary>
    public class Message{

        /// <value> Property <c>User</c> Unique Id for database primary key</value>
        private Profile _sender;
        private Profile _recipient;
        private DateTime _timeStamp;
        private string _content;
        private bool _read;

        // [ForeignKey("SenderId")]
        // public int SenderId { get; set; }

        // [ForeignKey("RecipientId")]
        // public int RecipientId { get; set;}
        
        public int MessageId { get; set; }
        public DateTime TimeStamp{ get; set; }

        /// <summary>
        /// Field <c>Sender</c> returns sender
        /// </summary>
        public Profile Sender{
            get{return this._sender;}
            set{
                if(value is not Profile){
                    throw new ArgumentException("Sender is not a User");
                }
                this._sender=value;
            }
        }
        
        /// <summary>
        /// Field <c>Recipient</c> returns or change recipient
        /// </summary>
        public Profile Recipient{
            get{return this._recipient;}
            set{
                if(value is not Profile){
                    throw new ArgumentException("Recipient is not a User");
                }
                this._recipient=value;
            }
        }
        /// <summary>
        /// Field <c>Context</c> returns sender
        /// </summary>
        public string Content{
            get{return this._content;}
            set{
                if(value is not string){
                    throw new ArgumentException("Content is not a text");
                }
                this._content=value;
            }
        }

        /// <summary>
        /// Field <c>Read</c> returns read status
        /// </summary>
        public bool Read{
            get{return this._read;}
            set{
                try{
                    this._read=(bool)value;
                }
                catch{
                    throw new ArgumentException("Not a bool");
                }
            }
        }

        /// <summary>
        /// Constructor <c>Message</c> initializes message fields
        /// </summary>
        public Message(Profile sender, Profile recipient, string content){
            this._sender=sender;
            this._recipient=recipient;
            this._content=content is null?"":content;
            this._timeStamp=DateTime.Now;
            this._read=false;
        }

        public Message() {}

        /// <summary>
        /// Method <c>CreateMessage</c> creates new message
        /// </summary>
        public Message CreateMessage(Profile owner, Profile recipient){ //should figure out how we want to get the recipient
            Console.WriteLine("Type message"); //iu will handle this later
            string? content=Console.ReadLine();
            content=content is null?"":content;
            return new Message(owner,recipient,(string)content);
        }

        /// <summary>
        /// Method <c>RegisterTimestamp</c> registers timestamp to present time when message is sent
        /// </summary>
        public void RegisterTimestamp(){
            this._timeStamp=DateTime.Now;
        }

        /// <summary>
        /// Method <c>MarkAsRead</c> turns -read to true
        /// </summary>
        public void MarkAsRead(){
            this._read=true;
        }
    }

}