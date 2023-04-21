using System.ComponentModel.DataAnnotations;
using RedisRest.Model;

namespace RedisRest.Model
{
    public class Macmiilka
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
  
    }
}