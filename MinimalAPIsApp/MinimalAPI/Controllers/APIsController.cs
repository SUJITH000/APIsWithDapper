using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Data;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace MinimalAPI.Controllers;
[ApiController]
[Route("[controller]/[action]")]
public class APIsController : ControllerBase
{
    private readonly IUserData _userData;

    public APIsController(IUserData userData)
    {
        _userData = userData;
    }

    [HttpGet]
    public  async Task<IResult> GetUsers()
    {
        try {
           
            return Results.Ok(await _userData.GetUsers());
        }
        catch (Exception e) {
            return Results.Problem(e.Message);
        }
    }
    [HttpGet]
    public async Task<IActionResult> Getuser(int id)
    {
        try {
            var dat= await _userData.GetUser(id);
            if(dat!=null) return Ok(dat);
            return NotFound();
        }
        catch (Exception e) {
            return Problem(e.Message);
        }
    }
    [HttpPost]
    public async Task<IActionResult> InsertUser(UserModel user)
    {
        try {
            await _userData.InsertUser(user);
            return Ok();
        }
        catch (Exception e) {
            return Problem(e.Message);
        }
    }
    [HttpPut]
    public async Task<IActionResult>UpdateUser(UserModel user)
    {
        try {
            await _userData.UpdateUser(user);
            return Ok();
        }
        catch (Exception e) {
            return Problem(e.Message);
        }
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteUser(int id)
    {
        try {
            await _userData.DeleteUser(id);
            return Ok();
        }
        catch (Exception e) {
            return Problem(e.Message);
        }
    }
}




