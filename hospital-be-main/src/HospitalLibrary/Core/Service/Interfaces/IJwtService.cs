using HospitalAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service.Interfaces
{
    public interface IJwtService
    {
        public string GenerateToken(User user);
        public User GetCurrentUser(System.Security.Principal.IPrincipal httpContextUser);
        public bool HasMatchingRoles(string expectedRoles, System.Security.Principal.IPrincipal httpContextUser);
    }
}
