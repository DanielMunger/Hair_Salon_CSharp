using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace HairSalon.Objects
{
  public class Client
  {
    private int _id;
    private string _clientName;
    private int _stylistId;

    public Client(string ClientName, int StylistId, int Id = 0)
    {
      _id = Id;
      _clientName = ClientName;
      _stylistId = StylistId;
    }
    public override bool Equals(Object otherClient)
    {
      if(!(otherClient is Client))
      {
        return false;
      }
      else
      {
        Client newClient = (Client) otherClient;
        bool idEquality = (this.GetId() == newClient.GetId());
        bool nameEquality = (this.GetClientName() == newClient.GetClientName());
        bool stylistIdEquality = (this.GetStylistId() == newClient.GetStylistId());
        return(idEquality && nameEquality && stylistIdEquality);
      }
    }
    public int GetId()
    {
      return _id;
    }
    public void SetClientName(string ClientName)
    {
      _clientName = ClientName;
    }
    public string GetClientName()
    {
      return _clientName;
    }
    public void SetStylistId(int StylistId)
    {
      _stylistId = StylistId;
    }
    public int GetStylistId()
    {
      return _stylistId;
    }
    public static List<Client> GetAll()
    {
      List<Client> allClients = new List<Client> {};
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM clients;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int clientId = rdr.GetInt32(0);
        string clientName = rdr.GetString(1);
        int stylistId = rdr.GetInt32(2);
        Client newClient = new Client(clientName, stylistId, clientId);
        allClients.Add(newClient);
      }
      if(rdr!=null)
      {
        rdr.Close();
      }
      if(conn!=null)
      {
        conn.Close();
      }
      return allClients;
    }
    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("INSERT INTO clients (client_name, stylist_id) OUTPUT INSERTED.id VALUES (@ClientName, @StylistId);", conn);

      SqlParameter clientNameParameter = new SqlParameter("@ClientName", this.GetClientName());
      cmd.Parameters.Add(clientNameParameter);

      SqlParameter stylistIdParameter = new SqlParameter("@StylistId", this.GetStylistId());
      cmd.Parameters.Add(stylistIdParameter);

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
    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM clients;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }
  }

}
