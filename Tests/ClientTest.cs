using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;
using HairSalon.Objects;

namespace HairSalon.Test
{
  public class ClientTest
  {
    public ClientTest()
    {
      DBConfiguration.ConnectionString = "Data Source=DESKTOP-GC3DC7B\\SQLEXPRESS;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
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
  }
}
