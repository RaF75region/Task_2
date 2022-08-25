using System;
using System.Text.Json.Serialization;

namespace Task2.Models
{
    public class Entity
    {
        public Guid Id { get; set; }
        public DateTime OperationDate { get; set; }
        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }
        public Entity()
        {
            this.Id = Guid.NewGuid();
            this.OperationDate = DateTime.Now;
        }
    }
}
