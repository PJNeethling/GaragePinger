using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ParkBee.Assessment.API.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ParkBee.Assessment.API.Controllers
{
    public class AccountController : Controller
    {
        #region Private Fields
        private IOptions<JwtSettings> _jwtSettings;
        #endregion

        #region Constructor
        public AccountController(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }
        #endregion

        #region Public Methods
        [HttpPost("token"), AllowAnonymous]
        public IActionResult RequestToken([FromBody] TokenRequestModel request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = Authenticate(request.Username, request.Password);
            if (user == null)
                return Unauthorized();

            var token = GetJwtSecurityToken(user);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        } 
        #endregion

        #region Private Methods
        private UserModel Authenticate(string username, string password) =>
            // For simple authentication we just compare username and password
            username.Equals(password)
                ? new UserModel
                {
                    Name = "Joe Soap",
                    Email = "joe@mailinator.com",
                    GarageId = 2
                }
                : default(UserModel);

        private JwtSecurityToken GetJwtSecurityToken(UserModel user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ParkBeeClaimTypes.GarageId, user.GarageId.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Value.SecurityKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_jwtSettings.Value.Issuer,
                _jwtSettings.Value.Audience,
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return token;
        } 
        #endregion
    }
}