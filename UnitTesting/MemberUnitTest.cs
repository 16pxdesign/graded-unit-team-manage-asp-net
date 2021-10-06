using System;
using Application.Controllers;
using Application.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Application.Frameworks;
using Application.Models;
using Application.Repo;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using ActionResult = Microsoft.AspNetCore.Mvc.ActionResult;
using DatabaseModel = Application.Data.Models.DatabaseModel;
using ITempDataProvider = Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataProvider;
using TempDataDictionary = Microsoft.AspNetCore.Mvc.ViewFeatures.TempDataDictionary;
using Microsoft.AspNetCore.Mvc;

namespace UnitTesting
{
/**
 * 
 * name         :   MemberRepositories.cs
 * author       :   Aleksy Ruszala
 * date         :   29/04/2019
 *
 * */
    /// <summary>
    /// The task of this class is to test the functionality of the Member controller
    /// </summary>
    [TestClass]
    public class MemberUnitTest
    {
        DbContextOptions<DatabaseModel> _dbOptions = new DbContextOptionsBuilder<DatabaseModel>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .EnableSensitiveDataLogging()
            .Options;

        public MemberUnitTest()
        {
            Mapper.Initialize(cfg => { cfg.AddProfile<AutomapperProfile>(); });
        }

        /// <summary>
        /// Method check is editing mode is triggered after passing an member to form
        /// </summary>
        [TestMethod]
        public void TestMemberFormInEditMode()
        {
            //Arrange
            ITempDataProvider tempDataProvider = Mock.Of<ITempDataProvider>();
            TempDataDictionaryFactory tempDataDictionaryFactory = new TempDataDictionaryFactory(tempDataProvider);
            ITempDataDictionary tempData = tempDataDictionaryFactory.GetTempData(new DefaultHttpContext());


            MemberController controller = new MemberController(new UnitOfWork(new DatabaseModel()))
            {
                TempData = tempData
            };


            //Act
            var viewResult = controller.CreateUpdate("0001") as ViewResult;
            var isEditMode = (bool) viewResult.TempData["EditMember"];
            var model = viewResult.Model as MemberViewModel;

            //Assert
            Assert.IsInstanceOfType(viewResult, typeof(ViewResult));
            Assert.IsTrue(isEditMode);
            Assert.IsInstanceOfType(viewResult.Model, typeof(MemberViewModel));
            Assert.AreEqual(model.Type, MemberType.Member);
            Assert.AreEqual(model.Name, "Kim");
        }

        /// <summary>
        /// Method check is controller give back empty form to add new member
        /// </summary>
        [TestMethod]
        public void TestMemberFormInAddNewMode()
        {
            //Arrange
            ITempDataProvider tempDataProvider = Mock.Of<ITempDataProvider>();
            TempDataDictionaryFactory tempDataDictionaryFactory = new TempDataDictionaryFactory(tempDataProvider);
            ITempDataDictionary tempData = tempDataDictionaryFactory.GetTempData(new DefaultHttpContext());


            MemberController controller = new MemberController(new UnitOfWork(new DatabaseModel()))
            {
                TempData = tempData
            };


            //Act
            var viewResult = controller.CreateUpdate() as ViewResult;
            var isEditMode = (bool) viewResult.TempData["EditMember"];
            var model = viewResult.Model as MemberViewModel;


            //Assert
            Assert.IsFalse(isEditMode);
            Assert.IsInstanceOfType(viewResult.Model, typeof(MemberViewModel));
            Assert.AreEqual(model.SRU, null);
            Assert.AreEqual(model.Name, null);

        }

        /// <summary>
        /// Method check is new user is added to database correctly and its type is match to Data Model
        /// </summary>
        [TestMethod]
        public void TestAddingMember()
        {
            //Arrange
            ITempDataProvider tempDataProvider = Mock.Of<ITempDataProvider>();
            TempDataDictionaryFactory tempDataDictionaryFactory = new TempDataDictionaryFactory(tempDataProvider);
            ITempDataDictionary tempData = tempDataDictionaryFactory.GetTempData(new DefaultHttpContext());
            var unitOfWork = new UnitOfWork(new DatabaseModel(_dbOptions));
            MemberController controller = new MemberController(unitOfWork)
            {
                TempData = tempData
            };

            var testMember = new MemberViewModel()
            {
                SRU = "TestSRU",
                Name = "TestName",
                Surname = "TestSurname",
                Address = new AddressViewModel()
                {
                    City = "TestCity"
                }
            };


            //Act

            controller.CreateUpdate(testMember);
            var memberInDatabase = unitOfWork.MemberRepositories.FindBySRU("TestSRU");

            //Assert
            Assert.IsInstanceOfType(memberInDatabase, typeof(Member));
            Assert.AreEqual(memberInDatabase.SRU, "TestSRU");
            Assert.AreEqual(memberInDatabase.Name, "TestName");
            Assert.AreEqual(memberInDatabase.Surname, "TestSurname");
            Assert.IsInstanceOfType(memberInDatabase.Address, typeof(Address));
            Assert.AreEqual(memberInDatabase.Address.City, "TestCity");
        }
    }
}