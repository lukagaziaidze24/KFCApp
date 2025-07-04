using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

[Table("staff")]
public class Staff
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string TelNum { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public int RestaurantId { get; set; }
    public virtual Restaurant Restaurant { get; set; }
}
