// using Microsoft.EntityFrameworkCore;
// using Moq;

// namespace StuddyBuddyTests;

// [TestClass]
// public class MessageManagerTest
// {
//     [TestMethod]
//     public void Create_MessageManager()
//     {
//         //Arrange
//         var mockMessagesSet = new Mock<DbSet<Message>>();
//         var mockStudyBuddyContext = new Mock<StudyBuddyContext>();
//         mockStudyBuddyContext.Setup(m => m.Messages).Returns(mockMessagesSet.Object);
//         var messageManager = new MessageManager(mockStudyBuddyContext.Object);

//         //Act
//         messageManager.AddMessage(new Message());

//         //Assert
//         mockReceivedMessagesSet.Verify(m => m.Add(It.IsAny<Message>()), Times.Once());
//         mockStudyBuddyContext.Verify(m => m.SaveChanges(), Times.Once());
//     }
    
//     [TestMethod]
//     public void ReadMessageTest()
//     {
//         //Arrange
//         var mockMessagesSet = new Mock<DbSet<Message>>();
//         var mockStudyBuddyContext = new Mock<StudyBuddyContext>();
//         mockStudyBuddyContext.Setup(m => m.Messages).Returns(mockMessagesSet.Object);
//         var messageManager = new MessageManager(mockStudyBuddyContext.Object);

//         //Act
//         Profile test =new Profile();
//         Message msg=new Message(test,test, " ");
//         msg.MessageId=0;
//         messageManager.AddMessage(msg);
//         messageManager.ReadMessage(0);

//         //Assert
//         mockReceivedMessagesSet.Verify(m => m.ExecuteUpdate(It.IsAny<Message>()), Times.Once()); //not sure 
//         Assert.AreEqual(true,messageManager.ReceivedMessages[0].IsRead); 
//         mockStudyBuddyContext.Verify(m => m.SaveChanges(), Times.Once());
//     }
//     [TestMethod]
//     public void DeleteMessageTest()
//     {
//         //Arrange
//         var mockMessagesSet = new Mock<DbSet<Message>>();
//         var mockStudyBuddyContext = new Mock<StudyBuddyContext>();
//         mockStudyBuddyContext.Setup(m => m.Messages).Returns(mockMessagesSet.Object);
//         var messageManager = new MessageManager(mockStudyBuddyContext.Object);

//         //Act
//         Message msg = new Message(); 
//         msg.MessageId=1;
//         messageManager.AddMessage(msg);
//         messageManager.DeleteMessage(msg.MessageId);

//         //Assert
//         mockReceivedMessagesSet.Verify(m => m.ExecuteDelete(It.IsAny<Message>()), Times.Once()); //not sure
//         mockStudyBuddyContext.Verify(m => m.SaveChanges(), Times.Once());
//     }
//     [TestMethod]
//     public void DeleteAllMessagesTest() //duplicate?
//     {
//         //Arrange
//         var mockMessagesSet = new Mock<DbSet<Message>>();
//         var mockStudyBuddyContext = new Mock<StudyBuddyContext>();
//         mockStudyBuddyContext.Setup(m => m.Messages).Returns(mockMessagesSet.Object);
//         var messageManager = new MessageManager(mockStudyBuddyContext.Object);

//         //Act
//         messageManager.AddMessage(new Message());
//         messageManager.DeleteAllMessages();

//         //Assert
//         mockSentMessagesSet.Verify(m => m.ExecuteDelete(It.IsAny<Message>()), Times.Once()); 
//         mockStudyBuddyContext.Verify(m => m.SaveChanges(), Times.Once());
//     }
//     [TestMethod]
//     public void SortMessagesByUnreadTest(){

//         //Arrange
//         var mockMessagesSet = new Mock<DbSet<Message>>();
//         var mockStudyBuddyContext = new Mock<StudyBuddyContext>();
//         mockStudyBuddyContext.Setup(m => m.Messages).Returns(mockMessagesSet.Object);
//         var messageManager = new MessageManager(mockStudyBuddyContext.Object);

//         //Act
//         Message msg = new Message(); 
//         Message msg2 = new Message(); 
//         msg.IsRead=true;
//         msg2.IsRead=false;
//         messageManager.AddSentMessage(msg);
//         messageManager.AddSentMessage(msg2);
//         List<Message> messagesSorted= new List<Message>{msg2};

//         //Assert
//         mockReceivedMessagesSet.Verify(m => m.ExecuteUpdate(It.IsAny<Message>()), Times.Once()); //not sure
//         mockStudyBuddyContext.Verify(m => m.SaveChanges(), Times.Once());
//         CollectionAssert.AreEqual(messagesSorted,messageManager.SortMessagesByUnread());
//     }
//     [TestMethod]
//     public void SortMessagesBySenderTest(){

//         //Arrange
//         var mockMessagesSet = new Mock<DbSet<Message>>();
//         var mockStudyBuddyContext = new Mock<StudyBuddyContext>();
//         mockStudyBuddyContext.Setup(m => m.Messages).Returns(mockMessagesSet.Object);
//         var messageManager = new MessageManager(mockStudyBuddyContext.Object);

//         //Act
//         Profile test =new Profile();
//         Message msg= new Message(test,test, " ");
//         messageManager.AddMessage(msg);
//         List<Message> messagesSorted=messageManager.SortMessagesBySender(test);
//         List<Message> messagesFromSender= new List<Message>{msg};

//         //Assert
//         CollectionAssert.AreEqual(messagesFromSender,messagesSorted);
//     }
//     [TestMethod]

//     public void SortMessagesByRecipientTest(){

//         //Arrange
//         var mockMessagesSet = new Mock<DbSet<Message>>();
//         var mockStudyBuddyContext = new Mock<StudyBuddyContext>();
//         mockStudyBuddyContext.Setup(m => m.Messages).Returns(mockMessagesSet.Object);
//         var messageManager = new MessageManager(mockStudyBuddyContext.Object);

//         //Act
//         Profile test =new Profile();
//         Message msg= new Message(test,test, " ");
//         messageManager.AddMessage(msg);
//         List<Message> messagesSorted=messageManager.SortMessagesByRecipient(test);
//         List<Message> messagesToRecipient= new List<Message>{msg};

//         //Assert
//         CollectionAssert.AreEqual(messagesToRecipient,messagesSorted);
//     }
// }
