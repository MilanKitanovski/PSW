using HospitalLibrary.Core.Enum;
using HospitalLibrary.Exceptions;
using System;
using System.ComponentModel.DataAnnotations;
namespace HospitalAPI.Model

{
    public class Blog
    {
        public Guid Id { get; set; }
        public Guid? DoctorId { get; set; }
        public string TextBlog { get; set; }
        public BlogTheme Theme { get; set; }


        public Blog() { }

        public Blog(Guid id, string textBlog, Guid? doctorId, BlogTheme theme)
        {
            Id = id;
            DoctorId = doctorId;
            TextBlog = textBlog;
            Theme = theme;
            Validate();
        }

        private void Validate()
        {
            if (Id.Equals(Guid.Empty))
                throw new EntityObjectValidationFailedException();
            if (DoctorId.Equals(Guid.Empty))
                throw new EntityObjectValidationFailedException();
            if (string.IsNullOrEmpty(TextBlog))
                throw new EntityObjectValidationFailedException();
            if(Theme == null)
                throw new EntityObjectValidationFailedException();
        }
    }
}