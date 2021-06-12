using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers
{
    [Authorize(Policy = "Administrator")]
    public class AdminController : Controller
    {
        public ViewResult Index() => View(User?.Claims);
    }
}