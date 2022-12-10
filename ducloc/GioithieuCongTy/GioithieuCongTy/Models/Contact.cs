using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GioithieuCongTy.Models
{
    [Table("Contacts")]
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public double Phone { get; set; }
        public string Gmail { get; set; }

        public DateTime Created_at { get; set; }
        public DateTime Update_at { get; set; }

        public Contact Contacts { get; set; }

    }
}