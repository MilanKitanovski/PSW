using HospitalLibrary.Core.Model;
using HospitalLibrary.Exceptions;
using System;

namespace HospitalAPI.Model
{
    public class Notification
    {
        public Guid Id { get; private set; }
        public Guid AdminId { get; private set; }
        public virtual Admin Admin { get; private set; }
        //ne sme da bude prazno
        public string TextNotification { get; private set; }

        public Notification() { }

        public Notification(Guid id, Admin admin, string textNotification)
        {
            Id = id;
            Admin = admin;
            TextNotification = textNotification;
            Validate();
        }

        private void Validate()
        {
            if (Id.Equals(Guid.Empty))
                throw new EntityObjectValidationFailedException("Id is empty");
            if (Admin == null)
                throw new EntityObjectValidationFailedException("Admin cant be null");
            if (string.IsNullOrEmpty(TextNotification))
                throw new EntityObjectValidationFailedException("Text of the notification is empty");
        }
    }
}