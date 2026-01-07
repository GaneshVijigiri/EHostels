using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHostels.Common.Models
{
    public record struct UserData(long entityId, string fullName, string email, string mobileNumber);
}
