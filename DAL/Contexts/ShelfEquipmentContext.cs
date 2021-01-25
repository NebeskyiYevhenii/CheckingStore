using DAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DAL.Contexts
{
    public class ShelfEquipmentContext
    {
        public List<ShelfEquipment> _shelfEquipments = new List<ShelfEquipment>();

        public ShelfEquipmentContext()
        {
            _shelfEquipments = File.ReadAllLines("http://share.abmretail.com/basket/equipment.csv").Skip(1)
                                           .Select(v => ShelfEquipmentContext.FromCsvEquipment(v))
                                           .ToList();
        }


        public static ShelfEquipment FromCsvEquipment(string csvLine)
        {
            string[] values = csvLine.Split('|');
            ShelfEquipment shelfEquipment = new ShelfEquipment();
            shelfEquipment.Equipment_ID = Convert.ToString(values[0]);
            shelfEquipment.Store_ID = Convert.ToString(values[1]);
            shelfEquipment.Store_Name = Convert.ToString(values[2]);
            shelfEquipment.Name = Convert.ToString(values[3]);
            shelfEquipment.Equipment_type = Convert.ToString(values[4]);
            shelfEquipment.Width = Convert.ToString(values[5]);
            shelfEquipment.Height = Convert.ToString(values[6]);
            shelfEquipment.Depth = Convert.ToString(values[7]);
            return shelfEquipment;
        }
    }
}
