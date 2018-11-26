using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DomainModels
{
    public class UserPreferences
    {
        public UserPreferences() {  }

        public UserPreferences(int userId, Preferences userPrefs)
        {
            UserId = userId;
            UserPrefs = userPrefs;
        }

        public int UserId { get; set; }
        public Preferences UserPrefs { get; set; }
    }
}
