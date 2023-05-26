using SpaceWalk.Models;

namespace SpaceWalk.Data.Interface
{
  public interface IUserRepository
  {
    User authenticate(string username, string password);
    IEnumerable<User> getAllUser();
    User getById(int id);
    User create(User user, string password);
    void update(User user, string password = null);
    void delete(int id);
    bool saveChanges();
  }
}