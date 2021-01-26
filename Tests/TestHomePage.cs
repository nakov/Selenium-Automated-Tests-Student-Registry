using NUnit.Framework;
using Students_Registry_Automated_Tests.PageObjects;

namespace Students_Registry_Automated_Tests.Tests
{
    public class TestHomePage : BaseTest
    {
        [Test]
        public void Test_HomePage_Content()
        {
            var page = new HomePage(driver);
            page.Open();
            Assert.AreEqual("MVC Example", page.GetPageTitle());
            Assert.AreEqual("Students Registry", page.GetPageHeadingText());
            page.GetStudentsCount();
            Assert.Pass();
        }

        [Test]
        public void Test_HomePage_Links()
        {
            var homePage = new HomePage(driver);

            homePage.Open();
            homePage.LinkHomePage.Click();
            Assert.IsTrue(new HomePage(driver).IsOpen());

            homePage.Open();
            homePage.LinkAddStudentPage.Click();
            Assert.IsTrue(new AddStudentPage(driver).IsOpen());

            homePage.Open();
            homePage.LinkViewStudentsPage.Click();
            Assert.IsTrue(new ViewStudentsPage(driver).IsOpen());
        }
    }
}