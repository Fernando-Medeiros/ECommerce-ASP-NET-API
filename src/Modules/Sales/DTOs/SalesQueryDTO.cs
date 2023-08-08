namespace ECommerce.Modules.Sales.DTOs;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public class SalesQueryDTO
{
    [DefaultValue(false)]
    public bool Price { get; set; }

    [DefaultValue(10)]
    [Range(1, 50)]
    public int Limit { get; set; }

    [DefaultValue(0)]
    [Range(0, 50)]
    public int Skip { get; set; }
}