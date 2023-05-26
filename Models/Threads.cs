using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaceWalk.Models
{
  public class Threads : BaseModel
  {
    [Required]
    public string title { get; set; }
    public string name_image { get; set; }
    public string url_image { get; set; }
    public int view { get; set; } = 0;
    public int liked { get; set; } = 0;
    public string content { get; set; }
    [ForeignKey("SubForum")]
    public int sub_id { get; set; }
    public SubForum SubForum { get; set; }
    [ForeignKey("User")]
    public int user_id { get; set; }
    public User User { get; set; }

    [NotMapped]
    public IEnumerable<Comment> comments {get; set;}
  }
}