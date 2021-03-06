// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Jp.UI.SSO.Controllers.Diagnostics
{
    [Authorize]
    public class DiagnosticsController : Controller
    {
        private readonly IConfiguration _configuration;

        public DiagnosticsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> Index()
        {
            //var localAddresses = new string[] { "127.0.0.1", "::1", HttpContext.Connection.LocalIpAddress.ToString() };
            //if (!localAddresses.Contains(HttpContext.Connection.RemoteIpAddress.ToString()))
            //{
            //    return NotFound();
            //}

            var model = new DiagnosticsViewModel(HttpContext, await HttpContext.AuthenticateAsync(), _configuration);
            return View(model);
        }
    }
}