using DAL.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DomainRepositories
{
    public interface IPreferences //: IRepository  this was too simplistic to need a base interface
    {
        IEnumerable<UserPreferences> All { get; }
        UserPreferences GetUserPreferencesById(int userId);
        void UpdatePreferences(UserPreferences userPreferences);
    }
}
