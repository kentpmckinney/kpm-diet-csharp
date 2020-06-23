using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DietApplication.Food
{
    interface IFood
    {
        List<string> GetAvailableFoodDatabases();
        string GetActiveDatabaseName();
        string GetActiveDatabaseDescription();
        Status SetFoodListDataViewFilter(string newFilter);
        Status SetActiveDatabase(string databaseName);
        List<string> GetAvailableFoodItemUnits();
        FoodDatabaseItem GetFoodItem(string foodItemDisplayName);
        DataView GetActiveFoodListDataView();
        DataView GetActiveFoodCategoryDataView();
    }

    class Food : IFood
    {
        private FoodDatabase USDA;
        private FoodDatabase activeDatabase;

        public Food()
        {
            // initialize but do not load food database objects
        }

        string IFood.GetActiveDatabaseDescription()
        {
            throw new NotImplementedException();
        }

        string IFood.GetActiveDatabaseName()
        {
            throw new NotImplementedException();
        }

        DataView IFood.GetActiveFoodCategoryDataView()
        {
            throw new NotImplementedException();
        }

        DataView IFood.GetActiveFoodListDataView()
        {
            throw new NotImplementedException();
        }

        List<string> IFood.GetAvailableFoodDatabases()
        {
            throw new NotImplementedException();
        }

        List<string> IFood.GetAvailableFoodItemUnits()
        {
            throw new NotImplementedException();
        }

        FoodDatabaseItem IFood.GetFoodItem(string foodItemDisplayName)
        {
            throw new NotImplementedException();
        }

        Status IFood.SetActiveDatabase(string databaseName)
        {
            throw new NotImplementedException();
        }

        Status IFood.SetFoodListDataViewFilter(string newFilter)
        {
            throw new NotImplementedException();
        }
    }
}
