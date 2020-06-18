using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Album_Web.Models
{
    public class UserModel
    {
        [BindRequired]
        [Required, MaxLength(20)]
        public string UserName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [BindRequired]
        [Required/*(ErrorMessage = "密码错误")*/, DataType(DataType.Password)]
        public string Password { get; set; }

        public string AccessToken { get; set; }
    }
}