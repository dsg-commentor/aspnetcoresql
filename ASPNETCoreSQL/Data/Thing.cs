using System.ComponentModel.DataAnnotations;

namespace ASPNETCoreSQL.Data
{
    public class Thing
    {
        public int Id { get; set; }
        public int ExampleNumber { get; set; }
        [Required]
        public string ExampleString { get; set; }
    }
}
