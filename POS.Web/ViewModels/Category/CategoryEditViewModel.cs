﻿using System.ComponentModel.DataAnnotations;

namespace POS.Web.ViewModels.Category
{
    public class CategoryEditViewModel
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
