using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DietApplication.Food;
using System.Windows.Input;

namespace DietApplication.Interaction
{
    interface IInteraction
    {
        void PopulateUserList();
        void SetActiveUserName(string userName);
        void RemoveUserName(string userName);
        void AddUserName(string userName);
        void PopulateDatabaseList();
        void SetActiveDatabaseName(string databaseName);
        void SetFoodListDataView(DataView listView);
        void SetFoodListDataViewFilter(string filter);
        void SetFoodCategoryDataView(DataView categoryView);
        void UpdateNutrientViewBasedOnSingleFoodItem(FoodDatabaseItem foodItem);
        void UpdateNutrientViewBasedOnDataGridItems(FoodDatabaseItem foodItem);
        void AddPlanItem(string databaseName, string foodItemDisplayName);
        void ModifyPlanItem();
        void RemovePlanItem();
        void ModifyTrackItem();
    }

    class Interaction : ViewModelBase, IInteraction
    {
        private Localization localization;

        // Commands
        public ICommand TestCommand { get; private set; }

        public Interaction()
        {
            // Initialize Commands
            //TestCommand = new Command(Execution.DoTest);
        }

        void IInteraction.AddPlanItem(string databaseName, string foodItemDisplayName)
        {
            throw new NotImplementedException();
        }

        void IInteraction.AddUserName(string userName)
        {
            throw new NotImplementedException();
        }

        void IInteraction.ModifyPlanItem()
        {
            throw new NotImplementedException();
        }

        void IInteraction.ModifyTrackItem()
        {
            throw new NotImplementedException();
        }

        void IInteraction.PopulateDatabaseList()
        {
            throw new NotImplementedException();
        }

        void IInteraction.PopulateUserList()
        {
            throw new NotImplementedException();
        }

        void IInteraction.RemovePlanItem()
        {
            throw new NotImplementedException();
        }

        void IInteraction.RemoveUserName(string userName)
        {
            throw new NotImplementedException();
        }

        void IInteraction.SetActiveDatabaseName(string databaseName)
        {
            throw new NotImplementedException();
        }

        void IInteraction.SetActiveUserName(string userName)
        {
            throw new NotImplementedException();
        }

        void IInteraction.SetFoodCategoryDataView(DataView categoryView)
        {
            throw new NotImplementedException();
        }

        void IInteraction.SetFoodListDataView(DataView listView)
        {
            throw new NotImplementedException();
        }

        void IInteraction.SetFoodListDataViewFilter(string filter)
        {
            throw new NotImplementedException();
        }

        void IInteraction.UpdateNutrientViewBasedOnDataGridItems(FoodDatabaseItem foodItem)
        {
            throw new NotImplementedException();
        }

        void IInteraction.UpdateNutrientViewBasedOnSingleFoodItem(FoodDatabaseItem foodItem)
        {
            throw new NotImplementedException();
        }
    }
}
