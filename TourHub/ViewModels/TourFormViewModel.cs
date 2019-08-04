﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TourHub.Models;

namespace TourHub.ViewModels
{
    public class TourFormViewModel
    {
        public string Place { get; set; }
        public decimal Cost { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public byte Genre { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public DateTime DateTime {
            get
            {
                return DateTime.Parse(string.Format("{0} {1}", Date, Time));
            }
        }
    }
}