using System;
using System.Collections.Generic;
using System.Data.Entity;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }

    public virtual ICollection<Order> Orders { get; set; }
}
