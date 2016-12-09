using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace HairSalon.Objects
{
  public class Stylist
  {
    private int _id;
    private string _stylistName;
    private string _workHours;
    private string _workSchedule;

    public Stylist(string StylistName, string WorkHours, string WorkSchedule, int Id = 0)
    {
      _stylistName = StylistName;
      _workHours = WorkHours;
      _workSchedule = WorkSchedule;
      _id = Id;
    }

    public int GetId()
    {
      return _id;
    }
    public string GetName()
    {
      return _stylistName;
    }
    public string GetWorkHours()
    {
      return _workHours;
    }
    public string GetWorkSchedule()
    {
      return _workSchedule;
    }

    public override bool Equals(System.Object otherStylist)
    {
      if(!(otherStylist is Stylist))
      {
        return false;
      }
      else
      {
        Stylist newStylist = (Stylist) otherStylist;
        bool idEquality = this.GetId() == newStylist.GetId();
        bool nameEquality = this.GetName() == newStylist.GetName();
        bool workEquality = this.GetWorkHours() == newStylist.GetWorkHours();
        bool scheduleEquality = this.GetWorkSchedule() == newStylist.GetWorkSchedule();
        return(idEquality && nameEquality && workEquality && scheduleEquality);
      }
    }

    public static List<Stylist> GetAll()
    {
      List<Stylist> allStylists = new List<Stylist>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM stylists;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int stylistId = rdr.GetInt32(0);
        string stylistName = rdr.GetString(1);
        string workHours = rdr.GetString(2);
        string workSchedule = rdr.GetString(3);
        Stylist newStylist = new Stylist(stylistName, workHours, workSchedule, stylistId);
        allStylists.Add(newStylist);
      }
      if(rdr!=null)
      {
        rdr.Close();
      }
      if(conn!=null)
      {
        conn.Close();
      }
      return allStylists;
    }

  }

}
