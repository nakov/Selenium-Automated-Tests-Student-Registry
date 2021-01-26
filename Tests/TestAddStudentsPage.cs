using NUnit.Framework;
using Students_Registry_Automated_Tests.PageObjects;
using System;

namespace Students_Registry_Automated_Tests.Tests
{
    public class TestAddStudentPage : BaseTest
    {
        [Test]
        public void Test_TestAddStudentPage_Content()
        {
            var page = new AddStudentPage(driver);
            page.Open();
            Assert.AreEqual("Add Student", page.GetPageTitle());
            Assert.AreEqual("Register New Student", page.GetPageHeadingText());
            Assert.AreEqual("", page.FieldName.Text);
            Assert.AreEqual("", page.FieldEmail.Text);
            Assert.AreEqual("Add", page.ButtonSubmit.Text);
        }

        [Test]
        public void Test_TestAddStudentPage_Links()
        {
            var addStudentPage = new AddStudentPage(driver);

            addStudentPage.Open();
            addStudentPage.LinkHomePage.Click();
            Assert.IsTrue(new HomePage(driver).IsOpen());

            addStudentPage.Open();
            addStudentPage.LinkAddStudentPage.Click();
            Assert.IsTrue(new AddStudentPage(driver).IsOpen());

            addStudentPage.Open();
            addStudentPage.LinkViewStudentsPage.Click();
            Assert.IsTrue(new ViewStudentsPage(driver).IsOpen());
        }

        [Test]
        public void Test_TestAddStudentPage_AddValidStudent()
        {
            var page = new AddStudentPage(driver);
            page.Open();
            string name = "Pesho" + DateTime.Now.Ticks;
            string email = "pesho" + DateTime.Now.Ticks + "@gmail.com";
            page.AddStudent(name, email);
            var viewStudentsPage = new ViewStudentsPage(driver);
            Assert.IsTrue(viewStudentsPage.IsOpen());
            var students = viewStudentsPage.GetRegisteredStudents();
            string newStudent = name + " (" + email + ")";
            Assert.Contains(newStudent, students);
        }

        [Test]
        public void Test_TestAddStudentPage_AddInvalidStudent()
        {
            var page = new AddStudentPage(driver);
            page.Open();
            string name = "";
            string email = "pesho" + DateTime.Now.Ticks + "@gmail.com";
            page.AddStudent(name, email);
            Assert.IsTrue(page.IsOpen());
            Assert.IsTrue(page.ElementErrorMsg.Text.Contains("Cannot add student"));
        }

    }
}