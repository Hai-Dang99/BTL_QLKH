using QLKH.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLKH.Controllers
{
    [AuthorizeCustom]
    public class BaseController : Controller
    {
       
    }
}