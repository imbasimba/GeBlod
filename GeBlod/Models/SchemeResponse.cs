using System.Collections.Generic;

namespace GeBlod.Models
{
    public class SchemeResponse
    {
        public string Type { get; set; }
        public List<DonationSite> Data { get; set;}
        public string Status { get; set; }
        public string D1 { get; set; }
        public string D2 { get; set; }
    }
}
