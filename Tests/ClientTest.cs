using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;
using HairSalon.Objects;

namespace HairSalon.Test
{
  public class ClientTest : IDisposable
  {
    public ClientTest()
    {
      DBConfiguration.ConnectionString = "Data Source=DESKTOP-GC3DC7B\\SQLEXPRESS;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }
    public void Dispose()
    {
      Client.DeleteAll();
      Stylist.DeleteAll();
    }
    [Fact]
    public void Test_DatabaseEmpty()
    {
      int result = Client.GetAll().Count;
      Assert.Equal(0,result);
    }
    [Fact]
    public void Test_EqualOveride()
    {
      Client firstClient = new Client("Bob", 1);
      Client secondClient = new Client("Bob", 1);

      Assert.Equal(firstClient, secondClient);
    }
    [Fact]
    public void Test_Save()
    {
      Client newClient = new Client("Mary", 3);
      newClient.Save();
      List<Client> savedClient = Client.GetAll();
      List<Client> testClient = new List<Client> {newClient};

      Assert.Equal(savedClient, testClient);
    }
    [Fact]
    public void Test_AssignsIdToClient()
    {
      Client newClient = new Client("Mary", 3);
      newClient.Save();
      Client savedClient = Client.GetAll()[0];
      int result = savedClient.GetId();
      int testId = newClient.GetId();

      Assert.Equal(result, testId);
    }
    [Fact]
    public void Test_FindClient()
    {
      Client newClient = new Client("Susan", 2);
      newClient.Save();
      Client foundClient = Client.Find(newClient.GetId());

      Assert.Equal(newClient, foundClient);
    }
    [Fact]
    public void Update_UpdatesClientinDB_True()
    {
      Client newClient = new Client("Barb", 1);
      newClient.Save();
      string newName = "Barbara";
      newClient.Update(newName);
      string expected = newClient.GetClientName();

      Assert.Equal(expected, newName);
    }
    [Fact]
    public void Delete_DeletesInstanceFromDB_True()
    {
      Client newClient = new Client("Daniel", 1);
      newClient.Save();
      newClient.Delete();
      List<Client> expected = new List<Client>{};
      List<Client> result = Client.GetAll();

      Assert.Equal(expected, result);
    }
  }
}
