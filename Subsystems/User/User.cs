using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietApplication.User
{
    interface IUser
    {
        string GetName();
        double GetAgeInYears();
        double GetHeightInMeters();
        List<string> GetUserList();
        Status LoadUser();
        Status SaveUser();
        Status GetPlanList();
        Status GetTrackList();
        Status GetRecipeList();
    }

    class User : IUser
    {
        public User()
        {
            throw new NotImplementedException();
        }

        string IUser.GetName()
        {
            throw new NotImplementedException();
        }

        double IUser.GetAgeInYears()
        {
            throw new NotImplementedException();
        }

        double IUser.GetHeightInMeters()
        {
            throw new NotImplementedException();
        }

        List<string> IUser.GetUserList()
        {
            throw new NotImplementedException();
        }

        Status IUser.LoadUser()
        {
            throw new NotImplementedException();
        }

        Status IUser.SaveUser()
        {
            throw new NotImplementedException();
        }

        Status IUser.GetPlanList()
        {
            throw new NotImplementedException();
        }

        Status IUser.GetTrackList()
        {
            throw new NotImplementedException();
        }

        Status IUser.GetRecipeList()
        {
            throw new NotImplementedException();
        }
    }
}
