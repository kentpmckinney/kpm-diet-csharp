using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.ComponentModel;
using System.Windows.Input;
using DietApplication.Properties;

namespace DietApplication
{
    // The ViewModel class is a static wrapper for all view models in this application
    public sealed class View
    {
        // Implement a singleton pattern for the View class with an instance of Model
        private static readonly View model = new View();
        public static View Model
        {
            get { return model; }
        }

        // Instances of individual view models which support data binding
        public MainWindowViewModel MainWindow = new MainWindowViewModel();

        private View() { }

        public class MainWindowViewModel : INotifyPropertyChanged
        {
            public TotalsTabDataStatusClass TotalsTabDataStatus = new TotalsTabDataStatusClass();
            public class TotalsTabDataStatusClass
            {
                public bool UpdateNeeded = false;
                public bool DataChanged = false;
                public bool IsShowingDataGridTotals = false;
            }

            #region Properties

            // Define a string that contains the description under the Totals tab
            private string _totalsTabDescription = "Select a plan scope or Food Item to view totals";
            public string TotalsTabDescription
            {
                get { return _totalsTabDescription; }
                set
                {
                    _totalsTabDescription = value;
                    OnPropertyChanged("TotalsTabDescription");
                }
            }

            // Maybe this should be UserData?
            // Define an instance of the Data class which includes all user input
            private UserData _userdata = new UserData();
            public UserData UserData
            {
                get { return _userdata; }
                set
                {
                    _userdata = (UserData)value;
                    OnPropertyChanged("UserData");
                }
            }

            // This is confusing
            // A property to track the state of the Starts With radio button which is used to determine the search mode
            // There are two radio buttons in the group so it is assumed that the state of one of them is enough to determine the user's choice
            // TODO: REDO THIS SOMEHOW MAYBE JUST CALL IT SEARCHMODE?
            private bool _radioButtonStartsWith = true;
            public bool RadioButtonStartsWith
            {
                get { return _radioButtonStartsWith; }
                set
                {
                    _radioButtonStartsWith = value;
                    OnPropertyChanged("RadioButtonStartsWith");
                }
            }

            // The list of foods in the listbox
            private List<string> _foodList = new List<string>();
            public List<string> FoodList
            {
                get { return _foodList; }
                set
                {
                    _foodList = value;
                    OnPropertyChanged("FoodList");
                }
            }

            // The object which contains all data currently displayed on the Totals tab
            private FoodData _FoodData = new FoodData();
            public FoodData FoodData
            {
                get { return _FoodData; }
                set
                {
                    _FoodData = (FoodData)value;
                    OnPropertyChanged("FoodData");
                }
            }

            // The list of foods in the treeview
            private List<CategorizedFoodListItem> _categorizedFoodList = new List<CategorizedFoodListItem>();
            public List<CategorizedFoodListItem> CategorizedFoodList
            {
                get { return _categorizedFoodList; }
                set
                {
                    _categorizedFoodList = value;
                    OnPropertyChanged("CategorizedFoodList");
                }
            }

            #endregion

            #region Commands

            // Search the food list
            private ICommand _searchCommand = new SearchCommand();
            public ICommand Search
            {
                get { return _searchCommand; }
            }
            public class SearchCommand : ICommand
            {
                public bool CanExecute(object parameter)
                {
                    return true;
                }

                public event EventHandler CanExecuteChanged;

                public void Execute(object parameter)
                {
                    // Delegate to the USDA.GetFoodList method, passing both the search string as the first argument and the search mode based on radio selection
                    View.Model.MainWindow.FoodList = USDA.GetFoodList(parameter.ToString(), View.Model.MainWindow.RadioButtonStartsWith);
                }
            }

            // Update the data on the Totals tab
            public ICommand _displayFoodData = new DisplayFoodDataCommand();
            public ICommand DisplayFoodData
            {
                get { return _displayFoodData; }
            }
            public class DisplayFoodDataCommand : ICommand
            {
                public bool CanExecute(object parameter)
                {
                    return true;
                }

                public event EventHandler CanExecuteChanged;

                public void Execute(object parameter)
                {
                    if (View.Model.MainWindow.TotalsTabDataStatus.UpdateNeeded == false && View.Model.MainWindow.TotalsTabDataStatus.DataChanged == false) return;

                    // Flag that helps this command fire at the proper time which is set to true initially and set to false as needed
                    View.Model.MainWindow.TotalsTabDataStatus.IsShowingDataGridTotals = true;

                    string _parameter = ((string)parameter).ToLower();
                    switch (_parameter)
                    {
                        // Passing one of the following strings causes appropriate data to be displayed in the Totals tab
                        case "daily":
                            View.Model.MainWindow.TotalsTabDescription = "Totals for the 'Daily' meal plan";
                            UpdateTotals("Daily");
                            break;
                        case "mondays":
                            View.Model.MainWindow.TotalsTabDescription = "Totals for the 'Mondays' meal plan";
                            UpdateTotals("Mondays");
                            break;
                        case "tuesdays":
                            View.Model.MainWindow.TotalsTabDescription = "Totals for the 'Tuesdays' meal plan";
                            UpdateTotals("Tuesdays");
                            break;
                        case "wednesdays":
                            View.Model.MainWindow.TotalsTabDescription = "Totals for the 'Wednesdays' meal plan";
                            UpdateTotals("Wednesdays");
                            break;
                        case "thursdays":
                            View.Model.MainWindow.TotalsTabDescription = "Totals for the 'Thursdays' meal plan";
                            UpdateTotals("Thursdays");
                            break;
                        case "fridays":
                            View.Model.MainWindow.TotalsTabDescription = "Totals for the 'Fridays' meal plan";
                            UpdateTotals("Fridays");
                            break;
                        case "saturdays":
                            View.Model.MainWindow.TotalsTabDescription = "Totals for the 'Saturdays' meal plan";
                            UpdateTotals("Saturdays");
                            break;
                        case "sundays":
                            View.Model.MainWindow.TotalsTabDescription = "Totals for the 'Sundays' meal plan";
                            UpdateTotals("Sundays");
                            break;
                        case "weekends":
                            View.Model.MainWindow.TotalsTabDescription = "Totals for the 'Weekends' meal plan";
                            UpdateTotals("Weekends");
                            break;
                        case "weekdays":
                            View.Model.MainWindow.TotalsTabDescription = "Totals for the 'Weekdays' meal plan";
                            UpdateTotals("Weekdays");
                            break;
                        default:
                            // Display details for an individual food item (the case when one of the above keywords is not passed in _parameter

                            // Update the Totals tab description text
                            View.Model.MainWindow.TotalsTabDescription = "Totals for: '" + _parameter + "' (100 gram portion)";

                            // Apply rounding to the data if the option is set and update the data
                            FoodData d = USDA.GetFoodData(_parameter);
                            if (Properties.Settings.Default.Rounding) { d = FoodData.Round(d, Settings.Default.RoundingNumberOfFractionalDigits); }
                            View.Model.MainWindow.FoodData = d;
                            View.Model.MainWindow.TotalsTabDataStatus.IsShowingDataGridTotals = false;
                            break;
                    }
                    if (View.Model.MainWindow.TotalsTabDataStatus.DataChanged) View.Model.MainWindow.UserData.Save();
                    View.Model.MainWindow.TotalsTabDataStatus.DataChanged = false;
                    View.Model.MainWindow.TotalsTabDataStatus.UpdateNeeded = false;
                }

                private void UpdateTotals(string scope)
                {
                    FoodData totals = new FoodData();
                    if (View.Model.MainWindow.UserData.PlannedDiet == null) return;
                    foreach (DietPlanEntry entry in View.Model.MainWindow.UserData.PlannedDiet)
                    {
                        // Restrict results to the specified scope
                        if (entry.Scope != scope) continue;

                        FoodData data = USDA.GetFoodData(entry.FoodName);

                        // Adjust the nutrient values to reflect the quantity and unit
                        double quantity = Convert.ToDouble(entry.Quantity);
                        string NDB_No = USDA.GetNDBNumber(entry.FoodName);
                        double factor = USDA.GetNutrientConversionFactor(NDB_No, entry.Unit, quantity);
                        data *= factor;

                        // Add the adjusted data to the total
                        totals += data;
                    }

                    // Apply rounding to the data if the option is set and update the data
                    if (Settings.Default.Rounding == true) { totals = FoodData.Round(totals, Settings.Default.RoundingNumberOfFractionalDigits); }
                    View.Model.MainWindow.FoodData = totals;
                }
            }

            // Remove an item from the Plan tab
            private ICommand _removeCommand = new RemoveCommand();
            public ICommand Remove
            {
                get { return _removeCommand; }
            }

            public class RemoveCommand : ICommand
            {
                public bool CanExecute(object parameter) { return true; }
                public event EventHandler CanExecuteChanged;

                public void Execute(object parameter)
                {
                    if (parameter != null)
                    {
                        // The DataGrid was passed to this function as a CommandParameter
                        DataGrid datagrid = (DataGrid)parameter;

                        // The SelectedItems collection contains DietEntry objects
                        for (var i = 0; i < datagrid.SelectedItems.Count; i++)
                        {
                            if ((DietPlanEntry)datagrid.SelectedItems[i] != null)
                            {
                                // The i-- here is necessary due to the SelectedItems collection reducing in count by one when an item is removed
                                View.Model.MainWindow.UserData.PlannedDiet.Remove((DietPlanEntry)datagrid.SelectedItems[i--]);
                            }
                        }
                        View.Model.MainWindow.UserData.Save();
                    }
                }
            }

            #endregion

            #region Methods

            // An event and helper method to alert WPF when a property has changed
            public event PropertyChangedEventHandler PropertyChanged;
            private void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

            #endregion
        }
    }
}
