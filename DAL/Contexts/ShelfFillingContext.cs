using DAL.Models;
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
            shelfFilling.LocationId = Convert.ToInt32(values[0]);
            shelfFilling.HardwareId = Convert.ToString(values[1]);
            shelfFilling.EquipmentName = Convert.ToString(values[2]);
            shelfFilling.ShelfId = Convert.ToString(values[3]);
            shelfFilling.ShelfNumber = Convert.ToString(values[4]);
            shelfFilling.Article = Convert.ToString(values[5]);
            shelfFilling.ProductId = Convert.ToString(values[6]);
            shelfFilling.NumberOnTheShelf = Convert.ToInt32(values[6]);//.ToString(values[6]);
            shelfFilling.NumberInWidth = Convert.ToInt32(values[7]);
            shelfFilling.NumberInHeight = Convert.ToInt32(values[8]);
            shelfFilling.NumberInDepth = Convert.ToInt32(values[9]);

            return shelfFilling;
        }
    }
}
