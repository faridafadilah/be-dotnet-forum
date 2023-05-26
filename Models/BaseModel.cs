using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaceWalk.Models
{
    public abstract class BaseModel
    {
        public BaseModel()
        {
            createdBy = "System";
            createdTime = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string createdBy { get; set; }
        public DateTime? createdTime { get; set; }
        public DateTime? lastModifiedTime { get; set; }
    }
}