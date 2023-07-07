
// namespace StuddyBuddyTests;
// using StudyBuddyApp;
// [TestClass]
// public class EventsTest{
//     [TestMethod]
//     public void CreateEventTest(){
//         User owner=new User("userid","userpwd");
//         DateTime date=DateTime.Now;
//         Event e = new Event("title",date,"location","rlf","descr",owner);
//         Assert.AreEqual("title",e.Title);
//     }
//     [TestMethod]
//     [ExpectedException(typeof(ArgumentException))]
//     public void FailCreateEventTest(){
//         User owner=new User("userid","userpwd");
//         DateTime date=DateTime.Now;
//         Event e = new Event(null,date,"location","rlf","descr",owner);
        
//     }
//     [TestMethod]
//     public void WillAttendTest(){
//         User user=new User("userid","userpwd");
//         DateTime date=DateTime.Now;
//         Event e = new Event("title",date,"location","rlf","descr",user);
//         e.WillAttend(user);
//         Assert.AreEqual(1,e.GetAttendees().Count);
//     }
//     [TestMethod]
//     public void CheckPresenceTrueTest(){
//         User user=new User("userid","userpwd");
//         DateTime date=DateTime.Now;
//         Event e = new Event("title",date,"location","rlf","descr",user);
//         e.WillAttend(user);
//         Assert.AreEqual(true,e.CheckPresence(user));
//     }
//     [TestMethod]
//     public void CheckPresenceFalseTest(){
//         User user=new User("userid","userpwd");
//         DateTime date=DateTime.Now;
//         Event e = new Event("title",date,"location","rlf","descr",user);
//         Assert.AreEqual(false,e.CheckPresence(user));
//     }

//     [TestMethod]
//     public void WillNotAttendTest(){
//         User user=new User("userid","userpwd");
//         DateTime date=DateTime.Now;
//         Event e = new Event("title",date,"location","rlf","descr",user);
//         e.WillNotAttend(user);
//         Assert.AreEqual(0,e.GetAttendees().Count);
//     }
    
//     [TestMethod]
//     public void GetAttendeesTest(){
//         User user=new User("userid","userpwd");
//         DateTime date=DateTime.Now;
//         Event e = new Event("title",date,"location","rlf","descr",user);
//         e.WillAttend(user);
//         List<User> attendees_comparison = new List<User>(){user};
//         CollectionAssert.AreEqual(attendees_comparison,e.GetAttendees());
//     }
//     [TestMethod]
//     public void EventOwnerTrueTest(){
//         User user=new User("userid","userpwd");
//         DateTime date=DateTime.Now;
//         Event e = new Event("title",date,"location","rlf","descr",user);
//         Assert.AreEqual(true,e.EventOwner(user));
//     }
//     [TestMethod]
//     public void EventOwnerFalseTest(){
//         User user=new User("userid","userpwd");
//         User user2=new User("userid2","userpwd");
//         DateTime date=DateTime.Now;
//         Event e = new Event("title",date,"location","rlf","descr",user);
//         Assert.AreEqual(false,e.EventOwner(user2));
//     }
//     [TestMethod]
//     public void EditTitleTest(){
//         User user=new User("userid","userpwd");
//         DateTime date=DateTime.Now;
//         Event e = new Event("title",date,"location","rlf","descr",user);
//         e.Title=("test");
//         Assert.AreEqual("test",e.Title);
//     }
//     [TestMethod]
//     [ExpectedException(typeof(ArgumentException))]
//     public void EditTitleFailTest(){
//         User user=new User("userid","userpwd");
//         DateTime date=DateTime.Now;
//         Event e = new Event("title",date,"location","rlf","descr",user);
//         e.Title=("");
//     }
//     [TestMethod]
//     public void EditLocationTest(){
//         User user=new User("userid","userpwd");
//         DateTime date=DateTime.Now;
//         Event e = new Event("title",date,"location","rlf","descr",user);
//         e.Location=("test");
//         Assert.AreEqual("test",e.Location);
//     }
//     [TestMethod]
//     [ExpectedException(typeof(ArgumentException))]
//     public void EditLocationFailTest(){
//         User user=new User("userid","userpwd");
//         DateTime date=DateTime.Now;
//         Event e = new Event("title",date,"location","rlf","descr",user);
//         e.Location=("");
//     }
//     [TestMethod]
//     public void EditRelatedLearningFieldTest(){
//         User user=new User("userid","userpwd");
//         DateTime date=DateTime.Now;
//         Event e = new Event("title",date,"location","rlf","descr",user);
//         e.RelatedLearningField=("test");
//         Assert.AreEqual("test",e.RelatedLearningField);
//     }
//     [TestMethod]
//     [ExpectedException(typeof(ArgumentException))]
//     public void EditRelatedLearningFieldFailTest(){
//         User user=new User("userid","userpwd");
//         DateTime date=DateTime.Now;
//         Event e = new Event("title",date,"location","rlf","descr",user);
//         e.RelatedLearningField=("");
//     }
//     [TestMethod]
//     public void EditDescriptionTest(){
//         User user=new User("userid","userpwd");
//         DateTime date=DateTime.Now;
//         Event e = new Event("title",date,"location","rlf","descr",user);
//         e.Description=("test");
//         Assert.AreEqual("test",e.Description);
//     }
//     [TestMethod]
//     [ExpectedException(typeof(ArgumentException))]
//     public void EditDescriptionFailTest(){
//         User user=new User("userid","userpwd");
//         DateTime date=DateTime.Now;
//         Event e = new Event("title",date,"location","rlf","descr",user);
//         e.Description=("");
//     }
//     [TestMethod]
//     public void EditDateTest(){
//         User user=new User("userid","userpwd");
//         DateTime date=DateTime.Now;
//         Event e = new Event("title",date,"location","rlf","descr",user);
//         DateTime new_date=new DateTime(2023,12,09,9,15,0);
//         e.Date=(new_date);
//         Assert.AreEqual(new_date,e.Date);
//     }
//     [TestMethod]
//     [ExpectedException(typeof(ArgumentException))]
//     public void EditDateFailTest(){
//         User user=new User("userid","userpwd");
//         DateTime date=DateTime.Now;
//         Event e = new Event("title",date,"location","rlf","descr",user);
//         DateTime new_date=new DateTime(2019,05,09,9,15,0);
//         e.Date=(new_date);
//     }
// }
