using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.XPath;

namespace BD.Web2.Controllers
{
	public class HomeController : Controller
	{
		//
		// GET: /Index/

		public ActionResult Index()
		{
			var filename = Server.MapPath("~/app_data/Beards.xml");
			var doc = new XmlDocument();
			doc.Load(filename);

			var entry = (BeardedEntry)null;

			var list = new List<BeardedEntry>();
			foreach (var node in doc.SelectNodes("/beards/entry"))
			{
				var xmlNode = (XmlElement)node;
				entry = new BeardedEntry();
				entry.Name = (xmlNode.SelectSingleNode("Name").InnerText);
				entry.Image = (xmlNode.SelectSingleNode("Image").InnerText);
				entry.Number = Convert.ToInt32(xmlNode.SelectSingleNode("Number").InnerText);
				entry.FullBeard = Convert.ToBoolean(xmlNode.SelectSingleNode("FullBeard").InnerText);
				list.Add(entry);
			}
			return View(list);
		}

	}
}