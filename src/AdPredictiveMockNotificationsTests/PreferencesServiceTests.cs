using DAL.DomainModels;
using DAL.DomainRepositories;
using DAL.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AdPredictiveMockSituationTests
{
    //Small sample set of unit tests

    [TestClass]
    public class PreferencesServiceTests
    {
        private static IPreferences _userPreferences;

        [TestInitialize]
        public void Setup()
        {
            _userPreferences = new UserPreferencesService();
        }

        [TestMethod]
        public void PutPreferences()
        {
            //test add or update functionality
            AddTestPreferenceSets();

            //change user 2 preferences from true, false, true to false, false, true
            UserPreferences user2Prefs = _userPreferences.GetUserPreferencesById(2);
            user2Prefs.UserPrefs.CampaignStatusChangedNotificaiton = false;
            Assert.AreEqual(_userPreferences.GetUserPreferencesById(2).UserPrefs.CampaignStatusChangedNotificaiton, false);
        }

        [TestMethod]
        public void GetAllPreferences()
        {
            //test get all functionality
            AddTestPreferenceSets();

            List<UserPreferences> userPrefs = (List<UserPreferences>)_userPreferences.All;
            Assert.AreEqual(userPrefs.Count, 3);
            _userPreferences.UpdatePreferences(CreateUser4());
            userPrefs = (List<UserPreferences>)_userPreferences.All;
            Assert.AreEqual(userPrefs.Count, 4);
        }

        [TestMethod]
        public void GetPreferencesById()
        {
            //test get by id functionality
            AddTestPreferenceSets();

            UserPreferences userPrefs = _userPreferences.GetUserPreferencesById(3);
            Assert.AreEqual(userPrefs.UserId, 3);
        }

        private void AddTestPreferenceSets()
        {
            _userPreferences.UpdatePreferences(CreateUser1());
            _userPreferences.UpdatePreferences(CreateUser2());
            _userPreferences.UpdatePreferences(CreateUser3());
        }

        #region Sample data sets
        private UserPreferences CreateUser1()
        {
            return new UserPreferences()
            {
                UserId = 1,
                UserPrefs = new Preferences()
                {
                    CampaignStatusChangedNotificaiton = true,
                    NewCommentNotificaiton = true,
                    NewReportAvailableNotification = true
                }
            }
            ;
        }
        private UserPreferences CreateUser2()
        {
            return new UserPreferences()
            {
                UserId = 2,
                UserPrefs = new Preferences()
                {
                    CampaignStatusChangedNotificaiton = true,
                    NewCommentNotificaiton = false,
                    NewReportAvailableNotification = true
                }
            }
            ;
        }
        private UserPreferences CreateUser3()
        {
            return new UserPreferences()
            {
                UserId = 3,
                UserPrefs = new Preferences()
                {
                    CampaignStatusChangedNotificaiton = false,
                    NewCommentNotificaiton = true,
                    NewReportAvailableNotification = false
                }
            }
            ;
        }
        private UserPreferences CreateUser4()
        {
            return new UserPreferences()
            {
                UserId = 4,
                UserPrefs = new Preferences()
                {
                    CampaignStatusChangedNotificaiton = false,
                    NewCommentNotificaiton = false,
                    NewReportAvailableNotification = false
                }
            }
            ;
        }

        #endregion

    }
}
