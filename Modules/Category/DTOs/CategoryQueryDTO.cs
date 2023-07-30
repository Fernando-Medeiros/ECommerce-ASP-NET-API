namespace ECommerce_ASP_NET_API.Modules.Category.DTOs;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public class CategoryQueryDTO
{
    [DefaultValue(false)]
    public bool Id { get; set; }

    [DefaultValue(false)]
    public bool Name { get; set; }

    [DefaultValue(10)]
    [Range(1, 50)]
    public int Limit { get; set; }
}
