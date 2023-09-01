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
using HospitalLibrary.Core.Model;

namespace HospitalAppTests.UnitiTest
{
    public class BlockingUserTest
    {

        [Fact]
        public void Blocking_unblocked_user_with_more_than_enough_suspicious_activities()
        {
            User user = new User(Guid.NewGuid(), Guid.NewGuid(), UserType.Patient, "milan.kitanovski@gmail.com", "Test");
            SuspiciousActivity suspiciousActivity = new SuspiciousActivity("TEST");
            user.AddSuspiciousActivity(suspiciousActivity);
            user.AddSuspiciousActivity(suspiciousActivity);
            user.AddSuspiciousActivity(suspiciousActivity);
            user.AddSuspiciousActivity(suspiciousActivity);
            user.Block();
            user.IsBlock.ShouldBe(true);
        }

        [Fact]
        public void Unblocking_blocked_user()
        {
            User user = new User(Guid.NewGuid(), Guid.NewGuid(), UserType.Patient, "milan.kitanovski@gmail.com", "Test");
            SuspiciousActivity suspiciousActivity = new SuspiciousActivity("TEST");
            user.AddSuspiciousActivity(suspiciousActivity);
            user.AddSuspiciousActivity(suspiciousActivity);
            user.AddSuspiciousActivity(suspiciousActivity);
            user.AddSuspiciousActivity(suspiciousActivity);
            user.Block();
            user.Unblock();
            user.IsBlock.ShouldBe(false);
        }

        [Fact]
        public void Unblocking_unblocked_user()
        {
            User user = new User(Guid.NewGuid(), Guid.NewGuid(), UserType.Patient, "milan.kitanovski@gmail.com", "Test");
            Should.Throw<UserIsNotBlockedException>(() => user.Unblock());
        }


        [Fact]
        public void Blocking_unblocked_user_with_less_than_enough_suspicious_activities()
        {

            User user = new User(Guid.NewGuid(), Guid.NewGuid(), UserType.Patient, "milan.kitanovski@gmail.com", "Test");
            SuspiciousActivity suspiciousActivity = new SuspiciousActivity("TEST");
            user.AddSuspiciousActivity(suspiciousActivity);
            Should.Throw<UserCanNotBeBlocked>(() => user.Block());
        }

        [Fact]
        public void Blocking_unblocked_user_with_suspicious_activities_limit_case()
        {
            User user = new User(Guid.NewGuid(), Guid.NewGuid(), UserType.Patient, "milan.kitanovski@gmail.com", "Test");
            SuspiciousActivity suspiciousActivity = new SuspiciousActivity("TEST");
            user.AddSuspiciousActivity(suspiciousActivity);
            user.AddSuspiciousActivity(suspiciousActivity);
            user.AddSuspiciousActivity(suspiciousActivity);

            user.Block();

            user.IsBlock.ShouldBe(true);
        }

        [Fact]
        public void Blocking_blocked_patient()
        {
            User user = new User(Guid.NewGuid(), Guid.NewGuid(), UserType.Patient, "milan.kitanovski@gmail.com", "Test");
            SuspiciousActivity suspiciousActivity = new SuspiciousActivity("TEST");
            user.AddSuspiciousActivity(suspiciousActivity);
            user.AddSuspiciousActivity(suspiciousActivity);
            user.AddSuspiciousActivity(suspiciousActivity);
            user.AddSuspiciousActivity(suspiciousActivity);
            user.Block();
            Should.Throw<UserIsAlreadyBlockedException>(() => user.Block());
        }

        [Fact]
        public void Suspicious_activity_value_object_created()
        {
            var result = new SuspiciousActivity("21321312321123213232312123321");
            result.ShouldNotBeNull();
        }


        [Fact]
        public void Suspicious_activity_value_object_not_created()
        {
           
            Should.Throw<ValueObjectValidationFailedException>(() => new SuspiciousActivity(""));
          
        }
    }
}
