using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TourHub.App_Start;
using TourHub.DTOs;
using TourHub.Models;

namespace TourHub.Controllers.Api
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private readonly ApplicationDbContext _context;
        //private AutoMapperConfig _config;
        //private IMapper _mapper;
        
        public NotificationsController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<NotificationDTO> GetNewNotifications()
        {
            var userId = User.Identity.GetUserId();
            var notifications = _context.UserNotifications
                .Where(u => u.UserId == userId && !u.IsRead)
                .Select(u => u.Notification)
                .Include(t => t.Tour.Traveller)
                .ToList();

            //Automapper
            var config = new AutoMapperConfig().Configure();
            IMapper mapper = config.CreateMapper();

            return notifications.Select(mapper.Map<Notification,NotificationDTO>);
            //{
            //    DateTime = n.DateTime,
            //    Tour = new TourDTO
            //    {
            //        Traveller = new UserDTO
            //        {
            //            UserId = n.Tour.Traveller.Id,
            //            Name = n.Tour.Traveller.Name
            //        },
            //        DateTime = n.Tour.DateTime,
            //        Id = n.Tour.Id,
            //        IsCanceled = n.Tour.IsCanceled,
            //        Place = n.Tour.Place,
            //        Cost = n.Tour.Cost,
            //        TotalSeat = n.Tour.TotalSeat
            //    },
            //    OrginalDateTime = n.OrginalDateTime,
            //    OrginalPlace = n.OrginalPlace,
            //    Type = n.Type
            //}
            //);
        }

        [HttpPost]
        public IHttpActionResult MarkAsRead()
        {
            var userId = User.Identity.GetUserId();
            var notifications = _context.UserNotifications
                .Where(u => u.UserId == userId && !u.IsRead)
                .ToList();
            notifications.ForEach(n => n.Read());
            _context.SaveChanges();
            return Ok();
        }
    }
}
