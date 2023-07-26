using HospitalAPI.Model;
using HospitalAPI.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;
using HospitalLibrary.Exceptions;
using HospitalLibrary.Core.Enum;

namespace HospitalAppTests.UnitiTest
{
    public class BlockingUserTest
    {
        [Fact]
        public void Unblocking_blocked_user()
        {
            User user = new User("Test", "Test", "Test", "Test", "Test", UserType.Patient, Gender.Male);
            user.Block();
            user.Unblock();
            user.IsBlock.ShouldBe(false);
        }

        [Fact]
        public void Unblocking_unblocked_user()
        {
            User user = new User("Test", "Test", "Test", "Test", "Test", UserType.Patient, Gender.Male);
            Should.Throw<UserIsNotBlockedException>(() => user.Unblock());
        }

        [Fact]
        public void Blocking_unblocked_user_with_more_than_enough_suspicious_activities()
        {
            User user = new User("Test", "Test", "Test", "Test", "Test", UserType.Patient, Gender.Male);
            user.Block();
            user.IsBlock.ShouldBe(true);
        }

        [Fact]
        public void Blocking_blocked_patient()
        {
            User user = new User("Test", "Test", "Test", "Test", "Test", UserType.Patient, Gender.Male);
            user.Block();
            Should.Throw<UserIsAlreadyBlockedException>(() => user.Block());
        }
    }
}
