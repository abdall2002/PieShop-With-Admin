using BethenyPieShopAdmin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BethenyPieShopAdmin.ViewModels
{
    public class PieEditViewModel
    {
        public IEnumerable<SelectListItem>? Categories { get; set; } = default!;
        public Pie Pie { get; set; }
    }
}
