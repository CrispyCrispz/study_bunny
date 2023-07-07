// using Microsoft.EntityFrameworkCore;
// using Moq;

// namespace StuddyBuddyTests;

// [TestClass]
// public class EventsManagerTest
// {
//     [TestMethod]
//     public void Create_EventsManagerTest()
//     {
//         //Arrange
//         var mockEventsSet = new Mock<DbSet<Event>>();
//         var mockEventContext = new Mock<StudyBuddyContext>();
//         mockEventContext.Setup(m => m.StudyGroupEvents).Returns(mockEventsSet.Object);
//         Profile user = new Profile();
//         var eventsManager = new EventsManager(user,mockEventContext.Object);

//         //Act
//         eventsManager.CreateEvent("study",DateTime.Now,"lct",null,null,null, "dsc");

//         //Assert
//         mockEventsSet.Verify(m => m.Add(It.IsAny<Event>()), Times.Once());
//         mockEventContext.Verify(m => m.SaveChanges(), Times.Once());
//     }
//     [TestMethod]
//     public void EditEventTest()
//     {
//         //Arrange
//         var mockEventsSet = new Mock<DbSet<Event>>();
//         var mockEventContext = new Mock<StudyBuddyContext>();
//         mockEventContext.Setup(m => m.StudyGroupEvents).Returns(mockEventsSet.Object);
//         Profile user = new Profile();
//         User u = new User("test","pwd");
//         user.User=u;
//         var eventsManager = new EventsManager(user,mockEventContext.Object);

//         //Act
//         eventsManager.CreateEvent("study",DateTime.Now,"lct",null,null,null, "dsc");
//         eventsManager.OwnersEvents[0].EventId=0;
//         eventsManager.EditEventMock(0);


//         //Assert
//         mockEventsSet.Verify(m => m.Add(It.IsAny<Event>()), Times.Once());
//         mockEventContext.Verify(m => m.SaveChanges(), Times.Once());
//         Assert.AreEqual("testing lc",eventsManager.OwnersEvents[0].Location);
//     }
    
//     [TestMethod]
//     public void DeleteEventTest()
//     {
//         //Arrange
//         var mockEventsSet = new Mock<DbSet<Event>>();
//         var mockEventContext = new Mock<StudyBuddyContext>();
//         mockEventContext.Setup(m => m.StudyGroupEvents).Returns(mockEventsSet.Object);
//         Profile user = new Profile();
//         var eventsManager = new EventsManager(user,mockEventContext.Object);

//         //Act
//         eventsManager.CreateEvent("study",DateTime.Now,"lct",null,null,null, "dsc");
//         eventsManager.OwnersEvents[0].EventId=0;
//         eventsManager.DeleteEvent(0);


//         //Assert
//         mockEventsSet.Verify(m => m.ExecuteDelete(It.IsAny<Event>()), Times.Once());
//         mockEventContext.Verify(m => m.SaveChanges(), Times.Once());
//         Assert.AreEqual("testing lc",eventsManager.OwnersEvents[0].Location);
//     }

//     [TestMethod]
//     public void AttendAndUnattendEventTest()
//     {
//         //Arrange
//         var mockEventsSet = new Mock<DbSet<Event>>();
//         var mockEventContext = new Mock<StudyBuddyContext>();
//         mockEventContext.Setup(m => m.StudyGroupEvents).Returns(mockEventsSet.Object);
//         Profile user = new Profile();
//         User u = new User("test","pwd");
//         user.User=u;
//         var eventsManager = new EventsManager(user,mockEventContext.Object);

//         //Act
//         eventsManager.CreateEvent("study",DateTime.Now,"lct",null,null,null,"dsc");
//         eventsManager.OwnersEvents[0].EventId=0;
//         eventsManager.AttendEvent(0);
//         List<Profile> attendees= new List<Profile>{user};

//         //Assert
//         CollectionAssert.AreEqual(attendees,eventsManager.SeeAttendees());

//         //Act2
//         eventsManager.UnattendEvent(0);

//         //Assert
//         CollectionAssert.AreEqual(new List<Profile>(),eventsManager.SeeAttendees());

//         mockEventContext.Verify(m => m.SaveChanges(), Times.AtLeastOnce());
//     }
// }
