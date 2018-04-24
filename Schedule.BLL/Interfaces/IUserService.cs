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
        Task<OperationDetails> Edit(string name, UserDTO updatedUser);
        Task<OperationDetails> EditByIdWithoutPassword(string id, UserDTO updatedUser);
        Task<OperationDetails> Delete(string name);
        Task<OperationDetails> DeleteById(string id);
        Task<UserDTO> GetUser(string name);
        Task<UserDTO> GetUserById(string id);

        Task<List<UserDTO>> GetAll();
        

        Task<ClaimsIdentity> Authenticate(UserDTO userDto);
        Task SetInitialData(UserDTO adminDto, List<string> roles);
    }
}
