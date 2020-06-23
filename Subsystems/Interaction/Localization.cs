using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DietApplication.Interaction
{
    interface ILocalization
    {
        string GetLocalizedString(string stringName);
    }

    class Localization : ILocalization
    {
        string ILocalization.GetLocalizedString(string stringName)
        {
            throw new NotImplementedException();
        }
    }
}
