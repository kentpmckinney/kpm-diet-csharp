using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DietApplication.Food
{
    interface IFoodDatabase
    {
        string GetName();
        string GetDescription();
        Status SetFoodListDataViewFilter(string newFilter);
        Status LoadDatabase(string databaseName);
        Status UnloadDatabase();
        List<string> GetAvailableFoodItemUnits(string foodItemDisplayName);
        FoodDatabaseItem GetFoodDatabaseItem(string foodItemDisplayName);
        DataView GetFoodListDataView();
        DataView GetFoodCategoryDataView();
    }

    class FoodDatabase : IFoodDatabase
    {
        public FoodDatabase()
        {

        }

        private string name;
        private string description;
        private string foodListDataViewFilter;
        private DataView foodListDataView;
        private DataView foodCategoryDataView;

        string IFoodDatabase.GetName()
        {
            throw new NotImplementedException();
        }

        string IFoodDatabase.GetDescription()
        {
            throw new NotImplementedException();
        }

        Status IFoodDatabase.SetFoodListDataViewFilter(string newFilter)
        {
            throw new NotImplementedException();
        }

        Status IFoodDatabase.LoadDatabase(string databaseName)
        {
            throw new NotImplementedException();
        }

        Status IFoodDatabase.UnloadDatabase()
        {
            throw new NotImplementedException();
        }

        List<string> IFoodDatabase.GetAvailableFoodItemUnits(string foodItemDisplayName)
        {
            throw new NotImplementedException();
        }

        FoodDatabaseItem IFoodDatabase.GetFoodDatabaseItem(string foodItemDisplayName)
        {
            throw new NotImplementedException();
        }

        DataView IFoodDatabase.GetFoodListDataView()
        {
            throw new NotImplementedException();
        }

        DataView IFoodDatabase.GetFoodCategoryDataView()
        {
            throw new NotImplementedException();
        }
    }
}
