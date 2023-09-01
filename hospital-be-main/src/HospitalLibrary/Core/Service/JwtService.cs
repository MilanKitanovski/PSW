using HospitalAPI.Model;
using HospitalLibrary.Core.Repository.Interfaces;
using HospitalLibrary.Core.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using HospitalLibrary.Exceptions;
using System.Security.Claims;

namespace HospitalLibrary.Core.Service
{
    public class JwtService : IJwtService
    {
        private readonly IUserRepository _userRepository;


        public JwtService( IUserRepository userRepository, IConfiguration configuration) 
        { 
            _userRepository = userRepository;

        }

        public string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("DhftOS5uphK3vmCJQrexST1RsyjZBjXWRgJMFPU4"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


            var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Email.Address),
                    new Claim(ClaimTypes.Role, user.UserType.ToString()),
                    new Claim("role", user.UserType.ToString()),
                    new Claim("userId", user.Id.ToString())
                };

            var token = new JwtSecurityToken("http://localhost:16177/",
             "http://localhost:16177/",
             claims,
             expires: DateTime.Now.AddDays(3),
             signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        
        public User GetCurrentUser(IPrincipal httpContextUser)
        {
            var identity = httpContextUser.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;
                string email = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value;
                User user = _userRepository.GetUserWithEmail(email);
            

                if (user != null)
                {
                    return user;
                }

                throw new InvalidJwtException("Invalid JWT");
            }
            throw new InvalidJwtException("Invalid JWT");
        }

        public bool HasMatchingRoles(string expectedRoles, IPrincipal httpContextUser)
        {
            throw new NotImplementedException();
        }
    }
}
