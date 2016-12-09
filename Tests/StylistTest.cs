using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;
using HairSalon.Objects;


namespace HairSalon.Test
{
  public class StylistTest
  {
    public StylistTest()
    {
      DBConfiguration.ConnectionString = "Data Source=DESKTOP-GC3DC7B\\SQLEXPRESS;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void Test_StylistTableEmpty_True()
    {
      //Arrange,Act
      int result = Stylist.GetAll().Count;
      //Assert
      Assert.Equal(0,result);
    }
  }
}
