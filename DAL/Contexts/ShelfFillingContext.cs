﻿using DAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DAL.Contexts
{
    public class ShelfFillingContext
    {
        public List<ShelfFilling> _shelfFillings = new List<ShelfFilling>();

        public ShelfFillingContext()
        {
            _shelfFillings = File.ReadAllLines("http://share.abmretail.com/basket/Filling.csv").Skip(1)
                                           .Select(v => ShelfFillingContext.FromCsvFilling(v))
                                           .ToList();
        }


        public static ShelfFilling FromCsvFilling(string csvLine)
        {
            string[] values = csvLine.Split('|');
            ShelfFilling shelfFilling = new ShelfFilling();
            shelfFilling.Store_ID = Convert.ToString(values[0]);
            shelfFilling.Hardware_id = Convert.ToString(values[1]);
            shelfFilling.Equipment_Name = Convert.ToString(values[2]);
            shelfFilling.Shelf_ID = Convert.ToString(values[3]);
            shelfFilling.Shelf_number = Convert.ToString(values[4]);
            shelfFilling.Article_Nomenclature = Convert.ToString(values[5]);
            shelfFilling.Product_id = Convert.ToString(values[6]);
            shelfFilling.Number_on_the_shelf = Convert.ToString(values[6]);
            shelfFilling.Number_in_width = Convert.ToString(values[7]);
            shelfFilling.Number_in_height = Convert.ToString(values[8]);
            shelfFilling.Number_in_depth = Convert.ToString(values[9]);
            return shelfFilling;
        }
    }
}
