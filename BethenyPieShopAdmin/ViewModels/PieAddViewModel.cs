using BethenyPieShopAdmin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BethenyPieShopAdmin.ViewModels
{
    public class PieAddViewModel
    {
        public IEnumerable<SelectListItem>? Categories { get; set; } = default!;
        public Pie Pie { get; set; }

    }
}
