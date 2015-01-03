using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EasyBoni.Models
{
    public partial class Rating
    {
        [Column(Order = 0), Key]
        public int RestaurantID { get; set; }
        [Column(Order = 1), Key, ForeignKey("User")]
        public string UserID { get; set; }
        public int Value { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}