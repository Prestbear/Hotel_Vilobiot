using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Hotel_Vilobiot.DTO.Request;
using Hotel_Vilobiot.Services.UserService;

namespace Hotel_Vilobiot.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : Controller
{
    private readonly IGuestService _us;
    public UserController(IGuestService us) => _us = us;

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest req, IValidator<RegisterRequest> validator)
    {
        var result = validator.Validate(req);
        if (!result.IsValid) return BadRequest(result);
        var userToAdd = _us.Register(req);
        return Ok("user registered");
    }

    [HttpPost("login")]
    public IActionResult Login(string email, string password)
    {
        var result = _us.Login(email, password);
        return Ok("user login");
    }
    
    // [HttpGet("Verify")]
    // public IActionResult Verify(string email, string code)
    // {
    //     var result = _us.Verify(email, code);
    //     return Ok("user verified");
    // }

    [HttpPost("update-user/${id}")]
    public IActionResult Update(int id, EditGuestRequest req)
    {
        var updatedUser = _us.UpdateGuest(id, req);
        return Ok("user updated");
    }

    [HttpDelete("delete-user/${id}")]
    public IActionResult Deleter(int id)
    {
        var userToRemove = _us.DeleteGuest(id);
        return Ok("user deleted");
    }
}