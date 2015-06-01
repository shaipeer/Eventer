using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Group
{
    int userId;
    public int UserId
    {
      get { return userId; }
      set { userId = value; }
    }

    String name;
    public String Name
    {
      get { return name; }
      set { name = value; }
    }
    
    
    public Group()
	{
		
	}
}