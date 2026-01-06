using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHostels.Application.Identity.Models
{
    public class AuthenticateResponse
    {
        public bool IsAuthenticated { get; set; }
        public string ErrorMessage { get; set; } = default!;
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}
