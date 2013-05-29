using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChgkStorage;

namespace Chgk.Controllers
{
    public class ChgkController : Controller
    {
        public ActionResult Index()
        {
			//ChgkStorage.ChgkStorage storage = new ChgkStorage.ChgkStorage(new ChgkStorage.MySqlContextManager(
			//	"Server=127.0.0.1;Database=chgkdb;Uid=root;Pwd=21121986chbs"));

			//List<Team> teams = storage.GetAllTeams().ToList<Team>();

			return View (/*teams*/);
        }
    }
}
