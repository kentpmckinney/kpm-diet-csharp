namespace DietApplication
{
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using DietApplication.Properties;

    public partial class MainWindow : Window
    {
        // Constructor
        public MainWindow()
        {
            // Set the data context of the window to the MainWindowViewModel class
            DataContext = View.Model.MainWindow;

            // Populate initial data in the user interface's food list
            List<string> l = USDA.GetFoodList("", true);
            MessageBox.Show(l.Count.ToString());
            View.Model.MainWindow.FoodList = USDA.GetFoodList("", true);

            // Populate the tree view
            List<string> list = USDA.GetFoodGroups();
            foreach (var group in list)
            {
                CategorizedFoodListItem entry = new CategorizedFoodListItem(group, USDA.GetFoodListByGroup(group));
                View.Model.MainWindow.CategorizedFoodList.Add(entry);
            }

            // Load user data
            UserData data = UserData.Load();
            if (data != null) View.Model.MainWindow.UserData = data;

            // Load the user interface
            InitializeComponent();

            // Set name scopes for context menus so they can bind to elements in the XAML tree
            NameScope.SetNameScope(DietPlanDataGridContextMenu, NameScope.GetNameScope(this));
        }

        #region Events

        // The main window is closing
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Settings.Default.Save();
        }

        #region TreeView Events

        // The (food item) treeview selection changed
        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            // Handling as an event and manually invoking the viewmodel command due to the complexity of handling via XAML binding
            TreeView view = ((TreeView)sender);
            if (sender != null && view.SelectedItem != null)
            {
                string selectedItemName = view.SelectedItem.ToString();

                // Invoke the view model's DisplayFoodData command
                View.Model.MainWindow.TotalsTabDataStatus.UpdateNeeded = true;
                View.Model.MainWindow._displayFoodData.Execute(selectedItemName);
            }
        }

        // The left mouse button is pressed over the (food item) treeview, which is part of drag-and-drop
        private void TreeView_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Ensure that this code fires only once by using a global (and nullable) Point variable
            if (Global.DragDrop.FoodTreeViewDragStartPoint == null && e.OriginalSource is TextBlock)
            {
                TreeView parent = (TreeView)sender;

                // Record the point where the left mouse button was last pressed
                Global.DragDrop.FoodTreeViewDragStartPoint = e.GetPosition(parent);
            }
        }

        // Always clear the Global.DragDrop.FoodTreeViewDragStartPoint variable when the left mouse button is up to avoid glitches
        private void TreeView_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Global.DragDrop.FoodTreeViewDragStartPoint = null;
        }

        // The mouse is moving over the (food item) treeview
        // This is the main function responsible for beginning the drag-and-drop operation
        private void TreeView_MouseMove(object sender, MouseEventArgs e)
        {
            // Go no further if the left mouse button has not been pressed over the listbox
            if (Global.DragDrop.FoodTreeViewDragStartPoint == null) return;

            TreeView parent = (TreeView)sender;
            var dragPoint = e.GetPosition(parent);

            // Enforce a drag distance threshhold which is necessary to avoid inopportune firing of DoDragDrop() and its associated glitches
            Vector potentialDragLength = dragPoint - Global.DragDrop.FoodTreeViewDragStartPoint.Value;
            if (potentialDragLength.Length > 5)
            {
                TextBlock treeViewItem = e.OriginalSource as TextBlock;
                if (treeViewItem != null && treeViewItem.GetType() == typeof(TextBlock))
                {
                    string food = treeViewItem.Text;
                    if (food != null)
                    {
                        // Begin the drag-and-drop operation
                        DragDrop.DoDragDrop(parent, food, DragDropEffects.Copy);

                        // Clear the global variable so that this function will not fire again during the current drag-and-drop operation
                        Global.DragDrop.FoodTreeViewDragStartPoint = null;
                    }
                }
            }
        }

        #endregion

        #region ListBox Events

        // The (food item) listbox selection changed
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handling as an event and manually invoking the viewmodel command due to the complexity of handling via XAML binding
            ListBox parent = (ListBox)sender;
            if (parent != null && parent.SelectedItem != null)
            {
                string _selectedItemName = parent.SelectedItem.ToString();

                // Invoke the view model's DisplayFoodData command
                View.Model.MainWindow.TotalsTabDataStatus.UpdateNeeded = true;
                View.Model.MainWindow._displayFoodData.Execute(_selectedItemName);
            }
        }

        // The left mouse button is pressed over the (food item) listbox, which is part of drag-and-drop
        private void ListBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Ensure that this code fires only once by using a global (and nullable) Point variable
            if (Global.DragDrop.FoodListBoxDragStartPoint == null && e.OriginalSource is TextBlock)
            {
                ListBox parent = (ListBox)sender;

                // Record the point where the left mouse button was last pressed
                Global.DragDrop.FoodListBoxDragStartPoint = e.GetPosition(parent);
            }
        }

        // Always clear the Global.DragDrop.FoodListBoxDragStartPoint variable when the left mouse button is up to avoid glitches
        private void ListBox_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Global.DragDrop.FoodListBoxDragStartPoint = null;
        }

        // The mouse is moving over the (food item) listbox
        // This is the main function responsible for beginning a drag-and-drop operation from the (food item) listbox
        private void ListBox_MouseMove(object sender, MouseEventArgs e)
        {
            // Go no further if the left mouse button has not been pressed over the listbox
            if (Global.DragDrop.FoodListBoxDragStartPoint == null) return;

            ListBox parent = (ListBox)sender;
            var dragPoint = e.GetPosition(parent);

            // Enforce a drag distance threshhold which is necessary to avoid inopportune firing of DoDragDrop() and its associated glitches
            Vector potentialDragLength = dragPoint - Global.DragDrop.FoodListBoxDragStartPoint.Value;
            if (potentialDragLength.Length > 5)
            {
                var listBoxItem = ItemsControl.ContainerFromElement(sender as ListBox, e.OriginalSource as DependencyObject) as ListBoxItem;
                if (listBoxItem != null && listBoxItem.GetType() == typeof(ListBoxItem))
                {
                    string food = listBoxItem.Content.ToString();
                    if (food != null && food != "")
                    {
                        // Begin the drag-and-drop operation
                        DragDrop.DoDragDrop(parent, food, DragDropEffects.Copy);

                        // Clear the global variable so that this function will not fire again during the current drag-and-drop operation
                        Global.DragDrop.FoodListBoxDragStartPoint = null;
                    }
                }
            }
        }

        #endregion

        // The mouse is hovering over the (diet plan) datagrid control
        private void DataGrid_DragOver(object sender, DragEventArgs e)
        {
            // Change the mouse cursor to show the user they can copy the item
            e.Effects = DragDropEffects.Copy;
        }

        // The user has completed a drop over the (diet plan) datagrid control with the source as either the listbox or the treeview
        private void DataGrid_Drop(object sender, DragEventArgs e)
        {
            DataObject item = (((DragEventArgs)e).Data) as DataObject;
            string food = item.GetData(DataFormats.StringFormat) as string;
            DataGrid grid = (DataGrid)e.Source;

            // Set the units to display in the combobox for the new row in the datagrid
            List<string> units = new List<string>();
            units.Add("Gram");
            List<string> foodunits = USDA.GetUnits(USDA.GetNDBNumber(food));
            foreach (string unit in foodunits) { units.Add(unit.FirstLetterToUpper()); }
            foodunits = null;

            // Create a new DietEntry object and set values
            DietPlanEntry d = new DietPlanEntry();
            d.FoodName = food;
            d.Units = units;
            d.Quantity = "100";
            d.Unit = "gram";
            d.Meal = "Breakfast";
            d.Scope = ((ListBoxItem)DietPlanScopeListBox.SelectedItem).Content.ToString();

            // Add the new DietEntry object to the diet plan tab
            View.Model.MainWindow.UserData.PlannedDiet.Add(d);

            // Save user data
            View.Model.MainWindow.UserData.Save();

            e.Handled = true;
        }

        // Event to handle a mouse click anywhere on the Plan tabitem
        private void TabItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // Handling as an event and manually invoking the viewmodel command due to the complexity of handling via XAML binding
            // Invoke the view model's DisplayFoodData command
            string parameter = (DietPlanScopeListBox.SelectedItem as ListBoxItem).Content as string;

            if (View.Model.MainWindow.TotalsTabDataStatus.IsShowingDataGridTotals == false)
            {
                View.Model.MainWindow.TotalsTabDataStatus.UpdateNeeded = true;
                View.Model.MainWindow._displayFoodData.Execute(parameter);
            }
        }

        private void DietPlanScopeListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handling as an event and manually invoking the viewmodel command due to the complexity of handling via XAML binding
            // Invoke the view model's DisplayFoodData command
            string parameter = (DietPlanScopeListBox.SelectedItem as ListBoxItem).Content as string;
            View.Model.MainWindow.TotalsTabDataStatus.UpdateNeeded = true;
            View.Model.MainWindow._displayFoodData.Execute(parameter);
        }

        #endregion
    }
}
