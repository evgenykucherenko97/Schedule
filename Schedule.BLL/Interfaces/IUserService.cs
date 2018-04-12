using Schedule.BLL.DTO;
using Schedule.BLL.Infrastructure;
using Schedule.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Schedule.BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> Create(UserDTO userDto);
        Task<OperationDetails> Edit(UserDTO currentUserDto, UserDTO updatedUser);
        Task<OperationDetails> Edit(string name, UserDTO updatedUser);
        Task<OperationDetails> Delete(string name);
        Task<UserDTO> GetUser(string name);
        Task<List<UserDTO>> GetAll();
        

        Task<ClaimsIdentity> Authenticate(UserDTO userDto);
        Task SetInitialData(UserDTO adminDto, List<string> roles);
    }
}
