using System.ComponentModel.DataAnnotations;

namespace TestNorthwind.Models.DTOS.Requests
{
    public class UserLoginRequest
    {

        [Required]
        [EmailAddress]
        //[DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        //[DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
