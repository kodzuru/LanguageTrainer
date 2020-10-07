﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanguageTrainer.Services.TelegramBot;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;

namespace LanguageTrainer.Controllers
{
    [Route("api/[controller]")]
    public class UpdateController : Controller
    {
        private readonly IUpdateService _updateService;

        public UpdateController(IUpdateService updateService)
        {
            _updateService = updateService;
        }

        // POST api/update
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Update update)
        {
            await _updateService.EchoAsync(update);
            return Ok();
        }
    }
}
