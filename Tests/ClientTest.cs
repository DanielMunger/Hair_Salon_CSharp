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
  }
}
