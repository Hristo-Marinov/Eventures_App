﻿using Eventures.App_2._0.Data;
using Eventures.App_2._0.Domain;
using Eventures.App_2._0.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;

namespace Eventures.App_2._0.Controllers
{
    [Authorize]
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext context;
        public EventsController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult All()
        {
            List<EventAllViewModel> events = context.Events
                .Select(eventFromDb => new EventAllViewModel
                {
                    Name = eventFromDb.Name,
                    Place = eventFromDb.Place,
                    Start = eventFromDb.Start.ToString("dd-MMM-yyyy HH:mm", CultureInfo.InvariantCulture),
                    End = eventFromDb.End.ToString("dd-MMM-yyyy HH:mm", CultureInfo.InvariantCulture),
                    Owner = eventFromDb.Owner.UserName
                }).ToList();
            return this.View(events);
        }
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(EventCreateBindingModel bindingModel)
        {
            if(this.ModelState.IsValid)
            {
                string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                Event eventFromDb = new Event
                {
                    Name = bindingModel.Name,
                    Place = bindingModel.Place,
                    Start = bindingModel.Start,
                    End = bindingModel.End,
                    TotalTickets = bindingModel.TotalTickets,
                    PricePreTicket = bindingModel.PricePreTicket,
                    OwnerId = currentUserId

                };
                context.Events.Add(eventFromDb);
                context.SaveChanges();
                return this.RedirectToAction("All");
            }
            return this.View();
        }
    }
}
