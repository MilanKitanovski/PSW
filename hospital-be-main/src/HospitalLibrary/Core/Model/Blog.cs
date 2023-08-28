using HospitalLibrary.Core.Enum;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Exceptions;
using System;
using System.ComponentModel.DataAnnotations;
namespace HospitalAPI.Model

{
    public class Blog
    {
        public Guid Id { get; set; }
        public Guid DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public string TextBlog { get; set; }
        public BlogTheme Theme { get; set; }


        public Blog() { }

        public Blog(Guid id, string textBlog, Doctor doctor, BlogTheme theme)
        {
            Id = id;
            Doctor = doctor;
            TextBlog = textBlog;
            Theme = theme;
            Validate();
        }

        private void Validate()
        {
            if (Id.Equals(Guid.Empty))
                throw new EntityObjectValidationFailedException("Id is empty");
            if (Doctor==null)
                throw new EntityObjectValidationFailedException("DoctorId is empty");
            if (string.IsNullOrEmpty(TextBlog))
                throw new EntityObjectValidationFailedException("Textblog is empty");
        }
    }
}