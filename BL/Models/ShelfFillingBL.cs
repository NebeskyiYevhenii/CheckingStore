﻿using BL.Models;
using System;

namespace BL.Models
{
    public class ShelfFillingBL
    {
        public int Id { get; set; }

        public string HardwareId { get; set; }
        public string EquipmentName { get; set; }
        public string ShelfId { get; set; }
        public string ShelfNumber { get; set; }
        public string Article { get; set; }
        public string ProductId { get; set; }
        public int NumberOnTheShelf { get; set; }
        public int NumberInWidth { get; set; }
        public int NumberInHeight { get; set; }
        public int NumberInDepth { get; set; }

        public int LocationId { get; set; }
        public LocationBL Location { get; set; }
    }
}
