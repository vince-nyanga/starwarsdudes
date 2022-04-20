using System.Collections.Generic;

namespace ConsoleApp3.Models
{
    public class ApiResponse
    {
        public string Next { get; set; }
        public string Previous { get; set; }
        public IEnumerable<Dude> Results { get; set; }
    }
}