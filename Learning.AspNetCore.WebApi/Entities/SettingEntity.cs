using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learning.AspNetCore.WebApi.Entities
{
    [Table("Settings")]
    public class SettingEntity
    {
        [Key, Column("Key", TypeName = "VARCHAR(64)")]
        public string Key { get; set; }

        [Column("Value", TypeName = "VARCHAR(255)")]
        public string Value { get; set; }
    }
}