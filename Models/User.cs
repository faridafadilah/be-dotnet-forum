using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaceWalk.Models
{
  public class User
  {
    public int id { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string username { get; set; }
    [EmailAddress]
    public string email { get; set; }
    public byte[] passwordHash { get; set; }
    public byte[] passwordSalt { get; set; }
    public string role { get; set; }
    public string image { get; set; }
    public string urlImage { get; set; }
    public string bio { get; set; }
    public string github { get; set; }
    public string whatsapp { get; set; }
    public string linkedin { get; set; }
    public string gender { get; set; }
    public string address { get; set; }
    public string hobies { get; set; }
    public string birth { get; set; }

     [NotMapped]
    public IEnumerable<Threads> threads {get; set;}
     [NotMapped]
    public IEnumerable<Comment> comments {get; set;}
  }
}