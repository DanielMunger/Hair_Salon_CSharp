using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;
using HairSalon.Objects;

namespace HairSalon
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };
      Get["/stylists"] = _ => {
        List<Stylist> allStylists = Stylist.GetAll();
        return View["stylists.cshtml", allStylists];
      };
      Get["/stylists/new"] = _ => {
        return View["stylist_form.cshtml"];
      };
      Post["stylists/new"] = _ => {
        string stylistName = Request.Form["stylist-name"];
        string stylistWorkHours = Request.Form["stylist-work-hours"];
        string stylistSchedule = Request.Form["stylist-schedule"];
        Stylist newStylist = new Stylist(stylistName,stylistWorkHours,stylistSchedule);
        newStylist.Save();
        return View["index.cshtml"];
      };
    }
  }
}
