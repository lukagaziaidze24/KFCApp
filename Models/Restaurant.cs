using System;
using System.Collections.Generic;
using System.Data.Entity;

public class Restaurant
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string TelNum { get; set; }
    public string WorkingHours { get; set; }

    public virtual ICollection<Staff> StaffMembers { get; set; }
}
