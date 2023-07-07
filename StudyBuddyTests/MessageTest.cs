// namespace StudyBuddyTests;
// using StudyBuddyApp;

// [TestClass]
// public class MessageTests
// {
//     [TestMethod]
//     public void CreateMessageTest()
//     {
//         User owner = new User("userid","userpwd");
//         User recipient = new User("userid2","userpwd");
//         Message message = new Message(owner,recipient,"context");
//         Assert.AreEqual("context",message.MContent);
//     }
//     [TestMethod]
//     public void MarkAsReadTest()
//     {
//         User owner = new User("userid","userpwd");
//         User recipient = new User("userid2","userpwd");
//         Message message = new Message(owner,recipient,"context");
//         message.MarkAsRead();
//         Assert.AreEqual(true,message.Read);
//     }
//     [TestMethod]
//     public void SenderTest()
//     {
//         User owner = new User("userid","userpwd");
//         User recipient = new User("userid2","userpwd");
//         Message message = new Message(owner,recipient,"context");
//         Assert.AreEqual(owner,message.Sender);
//     }
//     [TestMethod]
//     public void GetRecipientTest()
//     {
//         User owner = new User("userid","userpwd");
//         User recipient = new User("userid2","userpwd");
//         Message message = new Message(owner,recipient,"context");
//         Assert.AreEqual(recipient,message.Recipient);
//     }
//     [TestMethod]
//     public void SetRecipientTest()
//     {
//         User owner = new User("userid","userpwd");
//         User recipient = new User("userid2","userpwd");
//         User recipient2 = new User("userid2","userpwd");
//         Message message = new Message(owner,recipient,"context");
//         message.MRecipient=recipient2;
//         Assert.AreEqual(recipient2, message.Recipient);
//     }
//     [TestMethod]
//     [ExpectedException(typeof(ArgumentException))]
//     public void SetRecipientFailTest()
//     {
//         User owner = new User("userid","userpwd");
//         User recipient = new User("userid2","userpwd");
//         Message message = new Message(owner,recipient,"context");
//         message.MRecipient=100;
//     }
//     [TestMethod]
//     public void GetContextTest()
//     {
//         User owner = new User("userid","userpwd");
//         User recipient = new User("userid2","userpwd");
//         Message message = new Message(owner,recipient,"context");
//         Assert.AreEqual("context",message.MContent);
//     }
//     [TestMethod]
//     public void SetContextTest()
//     {
//         User owner = new User("userid","userpwd");
//         User recipient = new User("userid2","userpwd");
//         Message message = new Message(owner,recipient,"context");
//         message.MContent="test";
//         Assert.AreEqual("test",message.MContent);
//     }
//     [TestMethod]
//     [ExpectedException(typeof(ArgumentException))]
//     public void SetContextFailTest()
//     {
//         User owner = new User("userid","userpwd");
//         User recipient = new User("userid2","userpwd");
//         Message message = new Message(owner,recipient,"context");
//         message.MContent=100;
//     }
// }
