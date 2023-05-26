using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaceWalk.Models
{
  public class SubForum : BaseModel
  {
    [Required]
    public string judul { get; set; }
    public string name_image { get; set; }
    public string url_image { get; set; }
    public string description { get; set; }
    [ForeignKey("MainForum")]
    public int main_id { get; set; }
    public MainForum MainForum { get; set; }
    [NotMapped]
    public IEnumerable<Threads> threads {get; set;}
  }
}