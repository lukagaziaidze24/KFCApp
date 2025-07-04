using System;
using System.Collections.Generic;
using System.Data.Entity;

public class Order
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public string Status { get; set; } // "Pending", "Prepared", "Canceled"

    public int UserId { get; set; }
    public virtual User User { get; set; }

    public int ProductId { get; set; }
    public virtual Product Product { get; set; }

    public int RestaurantId { get; set; }
    public virtual Restaurant Restaurant { get; set; }
}
