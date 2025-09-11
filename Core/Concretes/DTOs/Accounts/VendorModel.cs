using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concretes.DTOs.Accounts
{
    public class VendorModel
    {
        public required string StoreName { get; set; }
        public string? Description { get; set; }
        public string? Logo { get; set; }
        public string? Banner { get; set; }
        public required string Username { get; set; }
    }
}
