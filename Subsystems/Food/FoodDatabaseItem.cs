using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DietApplication.Food
{
    interface IFoodDatabaseItem
    {
        string GetFoodName();
        string GetFoodID();
        double GetQuantity();
        string GetUnit();
    }

    class FoodDatabaseItem //: NutrientsBase, IFoodDatabaseItem
    {
        private string name;
        private string id;
        private double quantity;
        private string unit;

        //string IFoodDatabaseItem.GetFoodName()
        //{
        //    throw new NotImplementedException();
        //}

        //string IFoodDatabaseItem.GetFoodID()
        //{
        //    throw new NotImplementedException();
        //}

        //double IFoodDatabaseItem.GetQuantity()
        //{
        //    throw new NotImplementedException();
        //}

        //string IFoodDatabaseItem.GetUnit()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
