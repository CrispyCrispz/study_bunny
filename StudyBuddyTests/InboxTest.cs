
// namespace StudyBuddyTests;
// using StudyBuddyApp;


// [TestClass]
// public class MessageTest
// {
//     [TestMethod]
//     public void SortMessagesByUnreadTest(){
//         User user = new User("userid","userpwd");
//         Message message = new Message(user,user,"test");
//         List<Message> messagesList = new List<Message>(){message};
//         Inbox inbox = new Inbox(user,messagesList,messagesList,messagesList);
//         CollectionAssert.AreEqual(messagesList,inbox.SortMessagesByUnread());
//     }
//     [TestMethod]
//     public void SortMessagesByRecipientTest(){
//         User user = new User("userid","userpwd");
//         Message message = new Message(user,user,"test");
//         List<Message> messagesList = new List<Message>(){message};
//         Inbox inbox = new Inbox(user,messagesList,messagesList,messagesList);
//         CollectionAssert.AreEqual(messagesList,inbox.SortMessagesByRecipient(user));
//     }
//     [TestMethod]
//     public void SortMessagesBySenderTest(){
//         User user = new User("userid","userpwd");
//         Message message = new Message(user,user,"test");
//         List<Message> messagesList = new List<Message>(){message};
//         Inbox inbox = new Inbox(user,messagesList,messagesList,messagesList);
//         CollectionAssert.AreEqual(messagesList,inbox.SortMessagesBySender(user));
//     }
//     [TestMethod]
//     public void ReadMessageTest(){
//         User user = new User("userid","userpwd");
//         Message message = new Message(user,user,"test");
//         List<Message> messagesList = new List<Message>(){message};
//         Inbox inbox = new Inbox(user,messagesList,messagesList,messagesList);
//         inbox.ReadMessage(0);
//         Assert.AreEqual(true,inbox.GetMessage(0).IsRead);
//     }
//     [TestMethod]
//     [ExpectedException(typeof(ArgumentOutOfRangeException))]
//     public void ReadMessageFailTest(){
//         User user = new User("userid","userpwd");
//         Message message = new Message(user,user,"test");
//         List<Message> messagesList = new List<Message>(){message};
//         Inbox inbox = new Inbox(user,messagesList,messagesList,messagesList);
//         inbox.ReadMessage(-1);
//     }
//     [TestMethod]
//     public void DeleteMessageTest(){
//         User user = new User("userid","userpwd");
//         Message message = new Message(user,user,"test");
//         List<Message> messagesList = new List<Message>(){message};
//         Inbox inbox = new Inbox(user,messagesList,messagesList,messagesList);
//         inbox.DeleteMessage(0);
//         Assert.AreEqual(0,inbox.ReceivedMessages.Count);
//     }

//     [TestMethod]
//     [ExpectedException(typeof(ArgumentOutOfRangeException))]
//     public void DeleteMessageFailTest(){
//         User user = new User("userid","userpwd");
//         Message message = new Message(user,user,"test");
//         List<Message> messagesList = new List<Message>(){message};
//         Inbox inbox = new Inbox(user,messagesList,messagesList,messagesList);
//         inbox.DeleteMessage(-1);
//     }
//     [TestMethod]
//     public void GetMessageTest(){
//         User user = new User("userid","userpwd");
//         Message message = new Message(user,user,"test");
//         List<Message> messagesList = new List<Message>(){message};
//         Inbox inbox = new Inbox(user,messagesList,messagesList,messagesList);
//         inbox.GetMessage(0);
//         Assert.AreEqual(0,inbox.GetMessage(0));
//     }
    
//     [TestMethod]
//     [ExpectedException(typeof(ArgumentOutOfRangeException))]
//     public void GetMessageFailTest(){
//         User user = new User("userid","userpwd");
//         Message message = new Message(user,user,"test");
//         List<Message> messagesList = new List<Message>(){message};
//         Inbox inbox = new Inbox(user,messagesList,messagesList,messagesList);
//         inbox.DeleteMessage(-1);
//     }

// }