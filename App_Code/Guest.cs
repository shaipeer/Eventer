using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Guest
{
    int guestId;

    public int GuestId
    {
        get { return guestId; }
        set { guestId = value; }
    }
    String firstName;

    public String FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }
    String lastName;

    public String LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }
    String phone;

    public String Phone
    {
        get { return phone; }
        set { phone = value; }
    }
    String groupId;

    public String GroupId
    {
        get { return groupId; }
        set { groupId = value; }
    }
    
    String status;

    public String Status
    {
        get { return status; }
        set { status = value; }
    }
    String arriving;

    public String Arriving
    {
        get { return arriving; }
        set { arriving = value; }
    }

	public Guest()
	{
		
	}
}