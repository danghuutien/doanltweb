﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GioithieuCongTy.Models
{
    [Table("Categorys")]
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string ParentId { get; set; }
        public string Typecategory_id { get; set; }
        public string Name { get; set; }

        public string Slug { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Created_by { get; set; }
        public DateTime? Updated_by { get; set; }
        public DateTime? Updated_at { get; set; }
    }
}