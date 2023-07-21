using HospitalLibrary.Exceptions;
using System;

namespace HospitalAPI.Model
{
    public class Notification
    {
        public Guid Id { get; set; }
        public Guid? AdminId { get; set; }
        //ne sme da bude prazno
        public string TextNotification { get; set; }

        public Notification() { }

        public Notification(Guid id, Guid? adminId, string textNotification)
        {
            Id = id;
            AdminId = adminId;
            TextNotification = textNotification;
            Validate();
        }

        private void Validate()
        {
            if (Id.Equals(Guid.Empty))
                throw new EntityObjectValidationFailedException();
            if (AdminId.Equals(Guid.Empty))
                throw new EntityObjectValidationFailedException();
            if (string.IsNullOrEmpty(TextNotification))
                throw new EntityObjectValidationFailedException();
        }
    }
}