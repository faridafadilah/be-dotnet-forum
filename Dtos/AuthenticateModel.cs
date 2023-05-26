using System.ComponentModel.DataAnnotations;

namespace SpaceWalk.Dtos
{
  public class AuthenticateModel
  {
    [Required]
    public string username { get; set; }
    [Required]
    public string password { get; set; }
  }
}