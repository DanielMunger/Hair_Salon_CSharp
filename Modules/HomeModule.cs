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
      Post["/stylists/new"] = _ => {
        string stylistName = Request.Form["stylist-name"];
        string stylistWorkHours = Request.Form["stylist-work-hours"];
        string stylistSchedule = Request.Form["stylist-schedule"];
        Stylist newStylist = new Stylist(stylistName,stylistWorkHours,stylistSchedule);
        newStylist.Save();
        return View["index.cshtml"];
      };
      Get["/stylists/{id}"] = parameters => {
        var SelectedStylist = Stylist.Find(parameters.id);
        return View["stylist.cshtml", SelectedStylist];
      };
      Get["/clients/new"] = _ => {
        List<Stylist> allStylists = Stylist.GetAll();
        return View["client_form.cshtml", allStylists];
      };
      Post["/clients/new"] = _ => {
        string clientName = Request.Form["client-name"];
        int stylistId = Request.Form["stylist-id"];
        Client newClient = new Client(clientName, stylistId);
        newClient.Save();
        return View["index.cshtml"];
      } ;
      Get["/stylists/update/{id}"] = parameters => {
        Stylist selectedStylist = Stylist.Find(parameters.id);
        return View["update_stylist.cshtml", selectedStylist];
      };
      Post["/stylists/update/{id}"] = parameters => {
        Stylist selectedStylist = Stylist.Find(parameters.id);
        string newName = Request.Form["new-stylist-name"];
        string newHours = Request.Form["new-stylist-work-hours"];
        string newSchedule = Request.Form["new-stylist-schedule"];
        selectedStylist.Update(newName, newHours, newSchedule);
        return View["index.cshtml"];
      };
    }
  }
}
