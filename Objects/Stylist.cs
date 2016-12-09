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

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO stylists (stylist_name, work_hours, days_of_week) OUTPUT INSERTED.id VALUES (@StylistName, @WorkHours, @WorkSchedule);", conn);

      SqlParameter stylistNameParameter = new SqlParameter("@StylistName", this.GetName());
      cmd.Parameters.Add(stylistNameParameter);

      SqlParameter workHoursParameter = new SqlParameter("@WorkHours", this.GetWorkHours());
      cmd.Parameters.Add(workHoursParameter);

      SqlParameter WorkScheduleParameter = new SqlParameter("@WorkSchedule", this.GetWorkSchedule());
      cmd.Parameters.Add(WorkScheduleParameter);

      SqlDataReader rdr = cmd.ExecuteReader();
      while(rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }
      if(rdr!=null)
      {
        rdr.Close();
      }
      if(conn!=null)
      {
        conn.Close();
      }
    }

    public static Stylist Find(int Id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM stylists WHERE id = @StylistId;", conn);

      SqlParameter stylistIdParameter = new SqlParameter("@StylistId", Id.ToString());
      cmd.Parameters.Add(stylistIdParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      int foundStylistId = 0;
      string foundStylistName = null;
      string foundStylistHours = null;
      string foundStylistSchedule = null;

      while(rdr.Read())
      {
        foundStylistId = rdr.GetInt32(0);
        foundStylistName = rdr.GetString(1);
        foundStylistHours = rdr.GetString(2);
        foundStylistSchedule = rdr.GetString(3);
      }
      Stylist foundStylist = new Stylist(foundStylistName, foundStylistHours, foundStylistSchedule, foundStylistId);
      if(rdr!=null)
      {
        rdr.Close();
      }
      if(conn!=null)
      {
        conn.Close();
      }
      return foundStylist;
    }

    public void Update(string newName, string newHours, string newSchedule)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("UPDATE stylists SET stylist_name = @NewName, work_hours = @NewWorkHours, days_of_week = @NewSchedule OUTPUT INSERTED.stylist_name, INSERTED.work_hours, INSERTED.days_of_week WHERE id = @StylistId;", conn);

      SqlParameter stylistIdParameter = new SqlParameter("@StylistId", this.GetId());
      cmd.Parameters.Add(stylistIdParameter);

      SqlParameter stylistNameParameter = new SqlParameter("@NewName", newName);
      cmd.Parameters.Add(stylistNameParameter);

      SqlParameter workHoursParameter = new SqlParameter("@NewWorkHours", newHours);
      cmd.Parameters.Add(workHoursParameter);

      SqlParameter scheduleParameter = new SqlParameter("@NewSchedule", newSchedule);
      cmd.Parameters.Add(scheduleParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._stylistName = rdr.GetString(0);
        this._workHours = rdr.GetString(1);
        this._workSchedule = rdr.GetString(2);
      }
      if(rdr!=null)
      {
        rdr.Close();
      }
      if(conn!=null)
      {
        conn.Close();
      }
    }
    public List<Client> GetClients()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("SELECT * FROM clients WHERE stylist_id = @StylistId;", conn);
      SqlParameter stylistIdParameter = new SqlParameter("@StylistId", this.GetId());
      cmd.Parameters.Add(stylistIdParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      List<Client> clients = new List<Client>{};

      while(rdr.Read())
      {
        int clientId = rdr.GetInt32(0);
        string clientName = rdr.GetString(1);
        int stylistId = rdr.GetInt32(2);
        Client newClient = new Client(clientName, stylistId, clientId);
        clients.Add(newClient);
      }
      if(rdr!=null)
      {
        rdr.Close();
      }
      if(conn!=null)
      {
        conn.Close();
      }
      return clients;
    }
    public void Delete()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM stylists WHERE id = @StylistId; DELETE FROM clients WHERE stylist_id = @StylistId;", conn);

      SqlParameter stylistIdParameter = new SqlParameter("@StylistId", this.GetId());
      cmd.Parameters.Add(stylistIdParameter);
      cmd.ExecuteNonQuery();

      if(conn!=null)
      {
        conn.Close();
      }
    }
    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM stylists;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      if(conn!=null)
      {
        conn.Close();
      }
    }

  }

}
