using FluentValidation;
using Hotel_Vilobiot.DTO.Request;
using Hotel_Vilobiot.Services.IGuestService;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Vilobiot.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GuestController : Controller
{
    private readonly IGuestService _gs;
    public GuestController(IGuestService gs) => _gs = gs;

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest req, IValidator<RegisterRequest> validator)
    {
        var result = validator.Validate(req);
        if (!result.IsValid) return BadRequest(result);
        var userToAdd = _gs.Register(req);
        return Ok("guest registered");
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var result = _gs.Login(request);
        return Ok("guest login");
    }

    [HttpPost("Verify")]
    public IActionResult Verify(string email, string code)
    {
        var result = _gs.Verify(email, code);
        return Ok("guest verified");
    }

    [HttpPut("update-guest/${id}")]
    public IActionResult Update(int id, EditGuestRequest req)
    {
        var updatedUser = _gs.UpdateGuest(id, req);
        return Ok("guest updated");
    }

    [HttpDelete("delete-guest/${id}")]
    public IActionResult Deleter(int id)
    {
        var userToRemove = _gs.DeleteGuest(id);
        return Ok("guest deleted");
    }
}