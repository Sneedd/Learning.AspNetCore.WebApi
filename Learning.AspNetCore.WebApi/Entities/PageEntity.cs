using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learning.AspNetCore.WebApi.Entities
{
    [Table("Pages")]
    public class PageEntity
    {
        [Key, Column("Id")]
        public int Id { get; set; }

        [Column("Name", TypeName = "VARCHAR(64)")]
        public string Name { get; set; }

        [Column("DisplayName", TypeName = "VARCHAR(128)")]
        public string DisplayName { get; set; }

        [Column("Content", TypeName = "VARCHAR(4000)")]
        public string Content { get; set; }
    }
}