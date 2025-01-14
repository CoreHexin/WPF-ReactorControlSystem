using ReactorControlSystem.Core.Helpers;
using System.ComponentModel.DataAnnotations;

namespace ReactorControlSystem.Modules.Login.Models
{
    public class LoginModel : NotifyDataErrorInfo
    {
        private string _username = string.Empty;

        [Required(ErrorMessage = "用户名不能为空")]
        public string Username
        {
            get { return _username; }
            set
            {
                if (SetProperty(ref _username, value))
                {
                    Validate(nameof(Username), value);
                }
            }
        }

        private string _password = string.Empty;

        [Required(ErrorMessage = "密码不能为空")]
        public string Password
        {
            get { return _password; }
            set
            {
                if (SetProperty(ref _password, value))
                {
                    Validate(nameof(Password), value);
                }
            }
        }
    }
}
