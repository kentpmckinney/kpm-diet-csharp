using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DietApplication.Food;
using DietApplication.User;
using DietApplication.Interaction;
using DietApplication.Print;
using DietApplication.Report;


namespace DietApplication
{
    /// <summary>
    /// Centralized starting point for all application code that causes a change from the user's point of view
    /// Wraps calls to target code with support for exception handling, undo, and redo
    /// </summary>
    interface IExecution
    {
        void Undo();
        void Redo();
        void DoOpenDataFile();
        void DoSaveDataFile();
        void DoSaveDataFileAs();
        void DoPrint();
        void DoShowReport(string reportName);
        void DoPopulateUserList();
        void DoSetActiveUser(string userName);
        void DoRenameUser(string oldName, string newName);
        void DoRemoveUser(string userName);
        void DoPopulateDatabaseList();
        void DoSetActiveDatabase(string databaseName);
        void DoSetFoodListDataView(DataView listView);
        void DoSetFoodListDataViewFilter(string filter);
        void DoSetFoodCategoryDataView(DataView categoryView);
        void DoUpdateNutrientViewBasedOnSingleFoodItem(FoodDatabaseItem foodItem);
        void DoUpdateNutrientViewBasedOnDataGridItems(FoodDatabaseItem foodItem);
        void DoAddPlanItem(AddPlanItemExecutionParameters e);
        void DoModifyPlanItem();
        void DoRemovePlanItem();
        void DoModifyTrackItem();
        void DoCheckForUpdates();
        void DoTest();
    }

    public class ExecutionClass : IExecution
    {
        void IExecution.DoAddPlanItem(AddPlanItemExecutionParameters e)
        {
            throw new NotImplementedException();
        }

        void IExecution.DoCheckForUpdates()
        {
            throw new NotImplementedException();
        }

        void IExecution.DoModifyPlanItem()
        {
            throw new NotImplementedException();
        }

        void IExecution.DoModifyTrackItem()
        {
            throw new NotImplementedException();
        }

        void IExecution.DoOpenDataFile()
        {
            throw new NotImplementedException();
        }

        void IExecution.DoPopulateDatabaseList()
        {
            throw new NotImplementedException();
        }

        void IExecution.DoPopulateUserList()
        {
            throw new NotImplementedException();
        }

        void IExecution.DoPrint()
        {
            throw new NotImplementedException();
        }

        void IExecution.DoRemovePlanItem()
        {
            throw new NotImplementedException();
        }

        void IExecution.DoRemoveUser(string userName)
        {
            throw new NotImplementedException();
        }

        void IExecution.DoRenameUser(string oldName, string newName)
        {
            throw new NotImplementedException();
        }

        void IExecution.DoSaveDataFile()
        {
            throw new NotImplementedException();
        }

        void IExecution.DoSaveDataFileAs()
        {
            throw new NotImplementedException();
        }

        void IExecution.DoSetActiveDatabase(string databaseName)
        {
            throw new NotImplementedException();
        }

        void IExecution.DoSetActiveUser(string userName)
        {
            throw new NotImplementedException();
        }

        void IExecution.DoSetFoodCategoryDataView(DataView categoryView)
        {
            throw new NotImplementedException();
        }

        void IExecution.DoSetFoodListDataView(DataView listView)
        {
            throw new NotImplementedException();
        }

        void IExecution.DoSetFoodListDataViewFilter(string filter)
        {
            throw new NotImplementedException();
        }

        void IExecution.DoShowReport(string reportName)
        {
            throw new NotImplementedException();
        }

        void IExecution.DoTest()
        {
            throw new NotImplementedException();
        }

        void IExecution.DoUpdateNutrientViewBasedOnDataGridItems(FoodDatabaseItem foodItem)
        {
            throw new NotImplementedException();
        }

        void IExecution.DoUpdateNutrientViewBasedOnSingleFoodItem(FoodDatabaseItem foodItem)
        {
            throw new NotImplementedException();
        }

        void IExecution.Redo()
        {
            throw new NotImplementedException();
        }

        void IExecution.Undo()
        {
            throw new NotImplementedException();
        }
    }

    public abstract class ExecutionParameters
    {
    }

    public class AddPlanItemExecutionParameters : ExecutionParameters
    {
        string databaseName;
        string foodItemDisplayName;
    }
}
