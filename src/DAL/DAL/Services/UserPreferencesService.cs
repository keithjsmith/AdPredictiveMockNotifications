using DAL.DomainModels;
using DAL.DomainRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Services
{
    public class UserPreferencesService : IPreferences
    {
        private static List<UserPreferences> _usersPreferences;

        public UserPreferencesService()
        {
            if (_usersPreferences == null)
            {
                _usersPreferences = new List<UserPreferences>();
            }
        }

        /// <summary>
        /// Property containing all users notification preferences settings
        /// </summary>
        public IEnumerable<UserPreferences> All { get => _usersPreferences; }

        /// <summary>
        /// Public method for returning a single users noitification preference settings
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UserPreferences GetUserPreferencesById(int userId)
        {
            try
            {
                UserPreferences userPrefs = _usersPreferences.Find(u => u.UserId == userId);
                return userPrefs;
            }
            catch
            {
                //handle errors and log negative result
                throw;
            }

        }

        /// <summary>
        /// Private method for adding new set of user notification preferences 
        /// Utilize Update Preferences for a publicly available method
        /// </summary>
        /// <param name="userPreferences">Single instance of userPreferences class</param>
        private void AddPreferences(UserPreferences userPreferences)
        {
            try
            {
                _usersPreferences.Add(userPreferences);
                //log positive result
            }
            catch 
            {
                //handle errors
                //log negative result
                throw;
            }
        }

        /// <summary>
        /// Public method of updating or adding a set of user notification preferences
        /// </summary>
        /// <param name="newUserPrefs">Single instance of userPreferences class</param>
        public void UpdatePreferences(UserPreferences newUserPrefs)
        {
            UserPreferences existingUserPrefs = GetUserPreferencesById(newUserPrefs.UserId);

            if (existingUserPrefs == null)
            {
                AddPreferences(newUserPrefs);
            }
            else
            {
                existingUserPrefs.UserPrefs.CampaignStatusChangedNotificaiton = newUserPrefs.UserPrefs.CampaignStatusChangedNotificaiton;
                existingUserPrefs.UserPrefs.NewCommentNotificaiton = newUserPrefs.UserPrefs.NewCommentNotificaiton;
                existingUserPrefs.UserPrefs.NewReportAvailableNotification = newUserPrefs.UserPrefs.NewReportAvailableNotification;
            }
            
        }
    }
}
