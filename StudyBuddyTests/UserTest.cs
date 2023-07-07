namespace UserTest
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void addAUserTest()
        {
            //make a user
            //add user to database
            //attempt to fetch the user object from the database
        }

        public void loginAsANewUserTest()
        {
            //make a user
            //attempt to login as user
        }

        public void changePasswordTest()
        {
            //make a user
            //attempt to change password
            //attempt to login as the user with the new password
        }

        public void authenticateTest()
        {
            //pass valid user credentials and expect to receive a valid user object
        }

        public void deleteAccountTest()
        {
            //make a user account
            //delete the user object from the database
            //attempt to login as the user
        }
    }