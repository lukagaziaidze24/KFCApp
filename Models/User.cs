﻿using System;
using System.Collections.Generic;
using System.Data.Entity;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string TelNum { get; set; }
    public string Password { get; set; } // store hashed password

    public virtual ICollection<Order> Orders { get; set; }
}
