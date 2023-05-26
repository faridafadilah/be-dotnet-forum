using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaceWalk.Models
{
  public class UserLike : BaseModel
  {
    [ForeignKey("Thread")]
    public int thread_id { get; set; }
    public Threads Threads { get; set; }

    [ForeignKey("User")]
    public int user_id { get; set; }
    public User User { get; set; }
  }
}