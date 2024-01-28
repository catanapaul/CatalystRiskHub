using System.ComponentModel.DataAnnotations;

namespace CatalystRiskHub.DataAccess.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
