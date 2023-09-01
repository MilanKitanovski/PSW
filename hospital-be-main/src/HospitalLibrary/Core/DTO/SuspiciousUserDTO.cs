using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.DTO
{
    public class SuspiciousUserDTO
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public bool IsBlocked { get; set; }
        public int NumberOfRecentSuspiciousActivities { get; set; }


        public SuspiciousUserDTO(Guid userId,string username, bool isBlocked, int numberOfRecentSuspiciousActivities)
        {
            UserId = userId;
            Username = username;
            IsBlocked = isBlocked;
            NumberOfRecentSuspiciousActivities = numberOfRecentSuspiciousActivities;
        }
    }
}
