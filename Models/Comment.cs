using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaceWalk.Models
{
  public class Comment : BaseModel
  {
    [Required]
    public string content { get; set; }

    [ForeignKey("Thread")]
    public int thread_id { get; set; }
    public Threads Threads { get; set; }
  }
}