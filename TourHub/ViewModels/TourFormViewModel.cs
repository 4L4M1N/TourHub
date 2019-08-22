using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using TourHub.Controllers;
using TourHub.Models;

namespace TourHub.ViewModels
{
    public class TourFormViewModel
    {
        public int  Id { get; set; }

        [Required]
        public string Place { get; set; }

        [Required]
        public decimal Cost { get; set; }

        [Required]
        [FutureDate]
        public string Date { get; set; }

        [Required]
        public string Time { get; set; }

        [Required]
        public byte Genre { get; set; }

        [Required]
        public int TotalSeat { get; set; }

        public string Heading { get; set; }

        public string Action
        {
            get
            {
                Expression<Func<TourController, ActionResult>> update =
                    (c => c.Update(this)); //update() controller

                Expression<Func<TourController, ActionResult>> create =
                    (c => c.Create(this)); //create() controller
                var action = (Id != 0) ? update : create;
                return (action.Body as MethodCallExpression).Method.Name; //return action name
            }
        }
        public IEnumerable<Genre> Genres { get; set; }
        public DateTime GetDateTime() {

                return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }
    }
}