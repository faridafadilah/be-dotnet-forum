using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SpaceWalk.Base;
using SpaceWalk.Data;
using SpaceWalk.Data.Interface;
using SpaceWalk.Dtos;
using SpaceWalk.Models;

namespace SpaceWalk.Controllers
{
  [ApiController]
  [Route("api/user")]
  public class UserController : ControllerBase
  {
    private readonly IUserRepository repository;
    private readonly IMapper mapper;
    private readonly IOptions<AppSettings> appSettings;
    private GetResponse<UserReadDto> getResponse = new GetResponse<UserReadDto>();
    BaseResponse baseResponse = new BaseResponse();
    public UserController(IUserRepository repository, IMapper mapper, IOptions<AppSettings> appSettings)
    {
      this.repository = repository;
      this.mapper = mapper;
      this.appSettings = appSettings;
    }

    [AllowAnonymous]
    [HttpPost("authenticate")]
    public IActionResult authenticate([FromBody] AuthenticateModel model)
    {
      var user = repository.authenticate(model.username, model.password);

      if (user == null)
      {
        return BadRequest(new { message = "Username or password is incorrect" });
      }

      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes(appSettings.Value.secret);
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new Claim[]
          {
                    new Claim(ClaimTypes.Name, user.id.ToString()),
                    new Claim(ClaimTypes.Role, user.role)
          }),
        Expires = DateTime.UtcNow.AddDays(7),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
      };
      var token = tokenHandler.CreateToken(tokenDescriptor);
      var tokenString = tokenHandler.WriteToken(token);

      return Ok(new
      {
        id = user.id,
        username = user.username,
        firstName = user.firstName,
        lastName = user.lastName,
        email = user.email,
        role = user.role,
        Token = tokenString
      });
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public IActionResult register([FromQuery] int[] menuIds, [FromForm] RegisterModel model)
    {
      var user = mapper.Map<User>(model);
      try
      {
        repository.create(user, model.password);
        return Ok(new
        {
          id = user.id,
          username = user.username,
          firstName = user.firstName,
          lastName = user.lastName,
          email = user.email,
          role = user.role
        });
      }
      catch (AppException ex)
      {
        return BadRequest(new { message = ex.Message });
      }
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public IActionResult getById(int id)
    {
      var check = repository.getById(id);
      if (check == null)
      {
        baseResponse.code = 404;
        baseResponse.message = "User Not Found!";
        return NotFound(baseResponse);
      }
      return Ok(check);
    }

    [Authorize(Roles = "superadmin")]
    [HttpPut("update/{id}")]
    public IActionResult update(int id, [FromForm] UserUpdateDto model, [FromQuery] int[] menuIds)
    {
      var user = repository.getById(id);
      if(user == null)
      {
        baseResponse.code = 404;
        baseResponse.message = "Data NotFound!";
        return BadRequest(baseResponse);
      }
      try
      {
        mapper.Map(model, user);
        repository.update(user, model.password);
        repository.saveChanges();
        baseResponse.code = 200;
        baseResponse.message = "Update success!";
        return Ok(baseResponse);
      }
      catch (AppException ex)
      {
        return BadRequest(new { message = ex.Message });
      }
    }

    [Authorize(Roles = "superadmin")]
    [HttpDelete("{id}")]
    public IActionResult delete(int id)
    {
      var check = repository.getById(id);
      if (check == null)
      {
        baseResponse.code = 404;
        baseResponse.message = "User Not Found!";
        return NotFound(baseResponse);
      }
      repository.delete(id);
      baseResponse.code = 200;
      baseResponse.message = "Delete success!";
      return Ok(baseResponse);
    }
  }
}