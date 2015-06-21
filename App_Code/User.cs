using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for User
/// </summary>
public class User
{
    private String firstName;

    public String FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }
    
    private String lastName;

    public String LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }
    
    private String mail;

    public String Mail
    {
        get { return mail; }
        set { mail = value; }
    }
    
    private String userName;

    public String UserName
    {
        get { return userName; }
        set { userName = value; }
    }
    
    private String password;

    public String Password
    {
        get { return password; }
        set { password = value; }
    }


	public User()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}