//using System;
using System;
using System.IO;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DietApplication.Properties;

namespace DietApplication
{
    // Highest level class that stores data pertaining to an individual user
    public class UserData : INotifyPropertyChanged
    {
        // The collection that stores all meal plan data
        private ObservableCollection<DietPlanEntry> _plannedDiet;
        public ObservableCollection<DietPlanEntry> PlannedDiet
        {
            get { return _plannedDiet; }
            set
            {
                _plannedDiet = value;
                OnPropertyChanged("PlannedDiet");
            }
        }

        // Method to save user data
        public void Save()
        {
            // Serialize the instance of the Data object to a string
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(UserData));
            string serialized;
            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, this);
                serialized = textWriter.ToString();
            }

            // Save the serialized object string to settings
            Properties.Settings.Default.UserData = serialized;
            Properties.Settings.Default.Save();
        }

        // Static method to load the current user's saved data (when the application starts)
        public static UserData Load()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(UserData));
            using (StringReader reader = new StringReader(Settings.Default.UserData))
            {
                object result;
                try
                {
                    result = xmlSerializer.Deserialize(reader);
                }
                catch (InvalidOperationException e)
                {
                    result = new UserData();
                    View.Model.MainWindow.UserData.Save();
                }
                return (UserData)result;
            }
        }

        // An event and helper method to alert WPF when a property has changed
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    // Lower level class that stores data regarding diet plan entries
    public class DietPlanEntry : INotifyPropertyChanged
    {
        /* 
           Properties here correspond to data that is shown on the datagrid
           There is two-way data binding between an instance of the class and the user interface
           Quantity and Unit notify WPF (to update the user interface) and the view model upon being changed
           Scope is used to differentiate among plans such as 'Daily' and 'Tuesdays'
           Scope is used both to show/hide rows in the datagrid and when performing calculations for the Totals tab
        */

        public string FoodName { get; set; }
        private string _Quantity;
        public string Quantity
        {
            get { return _Quantity; }
            set
            {
                _Quantity = value;
                OnPropertyChanged("Quantity");
            }
        }
        private string _Unit;
        public string Unit
        {
            get { return _Unit; }
            set
            {
                _Unit = value;
                OnPropertyChanged("Unit");
            }
        }
        public List<string> Units { get; set; }
        public string Meal { get; set; }
        public string Scope { get; set; }

        // Implement the INotifyPropertyChanged interface
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); }
            View.Model.MainWindow.TotalsTabDataStatus.DataChanged = true;
        }
    }

    // Class to store a single recipe with multiple ingredients
    public class Recipe
    {
        List<Ingredient> Ingredients { get; set; }
    }

    // Lower level class that stores an individual ingredient of a recipe
    public class Ingredient
    {
        public string FoodName { get; set; }
        public string Quantity { get; set; }
        public string Unit { get; set; }
    }
}
