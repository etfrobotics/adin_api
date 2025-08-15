using adin_api.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adin_api.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(UserLoginDTO userDTO);
        Task<string> CreateToken();
        Task<IList<string>> GetRoles();
        double ExpiresIn();
    }
}
