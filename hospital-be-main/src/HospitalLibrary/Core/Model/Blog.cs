using System.ComponentModel.DataAnnotations;
namespace HospitalAPI.Model

{
    public class Blog
    {
        public int Id { get; set; }
        private int DoctorId;
        private string TextBlog;
    }
}