using System.ComponentModel.DataAnnotations;

namespace POS.Web.ViewModels.Category
{
    public class CategoryCreateViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
