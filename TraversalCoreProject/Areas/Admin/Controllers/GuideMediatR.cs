﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.CQRS.Commands.GuideCommands;
using TraversalCoreProject.CQRS.Queries.GuideQueries;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class GuideMediatR : Controller
    {
        private readonly IMediator _mediator;

        public GuideMediatR(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _mediator.Send(new GetAllGuideQuery());

            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> GetGuides(int id)
        {
            var values = await _mediator.Send(new GetGuideByIDQuery(id));
            return View(values);
        }

        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddGuide(CreateGuideCommand command)
        {
           


            await _mediator.Send(command);
          
            return RedirectToAction("Index");


       
        }
    }
}
