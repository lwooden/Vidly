using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required] // filed won't be nullable
        [StringLength(255)] // set a static string length
        public String Name { get; set; }
        public bool isSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        public byte MembershipTypeId { get; set; }
    }
}