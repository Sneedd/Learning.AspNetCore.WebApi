using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learning.AspNetCore.WebApi.Entities
{
    public class MenuEntity
    {
        [Key, Column("Id")]
        public int Id { get; set; }

        [Column("Order")]
        public int Order { get; set; }

        [Column("Target", TypeName = "VARCHAR(255)")]
        public string Target { get; set; }

        [Column("DisplayName", TypeName = "VARCHAR(255)")]
        public string DisplayName { get; set; }
    }
}