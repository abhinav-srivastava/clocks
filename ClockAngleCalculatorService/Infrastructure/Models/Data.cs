using System.ComponentModel.DataAnnotations;

namespace SampleService.Infrastructure.Models
{
    public class Data
    {
        [Key]
        public string Id { get; set; }
        public string Value { get; set; }
    }
}
