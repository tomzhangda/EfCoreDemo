using System.ComponentModel.DataAnnotations.Schema;

namespace EfCoreDemo.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Age { get; set; }

        public Class? Class { get; set; }

        [ForeignKey(nameof(Class))]
        public int ClassId { get; set; }
        
    }

    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
