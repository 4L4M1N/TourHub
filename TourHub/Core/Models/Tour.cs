using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TourHub.Core.Models
{
    public class Tour
    {
      
        public int Id { get; set; }

        public bool IsCanceled { get; private set; }
        public ApplicationUser Traveller { get; set; }

        public string TravellerID { get; set; }
        public DateTime DateTime { get; set; }


        public string Place { get; set; }


        public decimal Cost { get; set; }
        public Genre Genre { get; set; }

        public byte GenreID { get; set; }


        public int TotalSeat { get; set; }
        public ICollection<Attendence> Attendences { get; private set; }

        public void cancel()
        {
            IsCanceled = true;
            var notification = Notification.TourCanceled(this);
            foreach (var attendee in Attendences.Select(a => a.Attendee))
            {
                attendee.Notify(notification);

            }
        }

        public Tour()
        {
            Attendences = new Collection<Attendence>();
        }

        public void Modify(DateTime dateTime, string place, int totalSeat, decimal cost, byte genre)
        {
            var notification = Notification.TourUpdated(this, DateTime, Place);
            Place = place;
            DateTime = dateTime;
            TotalSeat = totalSeat;
            Cost = cost;
            GenreID = genre;

            foreach( var attendee in Attendences.Select(a =>a.Attendee))
            {
                attendee.Notify(notification);
            }
        }
    }
}