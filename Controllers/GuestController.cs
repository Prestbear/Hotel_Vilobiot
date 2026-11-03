using Azure.Core;
using FluentValidation;
using Hotel_Vilobiot.DTO.Request;
using Hotel_Vilobiot.Services.GuestService;
using Hotel_Vilobiot.Services.IGuestService;
using Hotel_Vilobiot.Validators;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Vilobiot.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GuestController : Controller
{
    private readonly IGuestService _gs;
    private readonly IValidator<RegisterRequest> _registerValidator;
    private readonly IValidator<EditGuestRequest> _editValidator;
    private readonly IValidator<LoginRequest> _loginValidator;

    public GuestController(IGuestService gs, IValidator<RegisterRequest> registerValidator, IValidator<EditGuestRequest> editValidator, IValidator<LoginRequest> loginValidator)
    {
        _gs = gs;
        _registerValidator = registerValidator;
        _editValidator = editValidator;
        _loginValidator = loginValidator;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest req)
    {
        var result = _registerValidator.Validate(req);
        if (!result.IsValid) return BadRequest(result);

        var userToAdd = _gs.Register(req);

        if (!userToAdd) return BadRequest("Invalid credentials!");

        return Ok("guest registered");
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var result = _loginValidator.Validate(request);
        if (!result.IsValid) return BadRequest(result);

        var userLogin = _gs.Login(request);

        if (userLogin == null) return BadRequest("Invalid email or password.");


        return Ok("guest logged in");
    }

    [HttpPost("Verify")]
    public IActionResult Verify(string email, string code)
    {
        var result = _gs.Verify(email, code);
        if(!result) return BadRequest("Incorrect email or code!");

        return Ok("guest verified");
    }

    [HttpPost("resend-code")]
    public async Task<IActionResult> ResendCode(string email)
    {
        bool resend = await _gs.ResendCode(email);

        //return Ok() miuxedavad imisa, rom email ver ipova
        // daregistrirebuli emailebi ar chandes.

        return Ok("A new verification code has been sent to your email");
    }

    [HttpPut("update-guest/{id}")]
    public IActionResult Update(int id, EditGuestRequest req)
    {
        var result = _editValidator.Validate(req);
        if (!result.IsValid) return BadRequest(result);

        var updatedUser = _gs.UpdateGuest(id, req);
        if (!updatedUser) return BadRequest("Guest not found!");

        return Ok("guest updated");
    }

    [HttpDelete("delete-guest/{id}")]
    public IActionResult Deleter(int id)
    {
        var userToRemove = _gs.DeleteGuest(id);

        if (!userToRemove) return NotFound("Guest not found!");

        return Ok("guest deleted");
    }
}