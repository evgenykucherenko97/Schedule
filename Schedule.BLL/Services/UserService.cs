using Schedule.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schedule.BLL.DTO;
using Schedule.BLL.Infrastructure;
using Schedule.DAL.Interfaces;
using System.Security.Claims;
using Schedule.DAL.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Schedule.BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<OperationDetails> Create(UserDTO userDto)
        {
            ApplicationUser user = await Database.UserManager.FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                user = new ApplicationUser { Email = userDto.Email, UserName = userDto.Email };
                var result = await Database.UserManager.CreateAsync(user, userDto.Password);
                if (result.Errors.Count() > 0)
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");
                // добавляем роль
                await Database.UserManager.AddToRoleAsync(user.Id, userDto.Role);
                // создаем профиль клиента
                //ClientProfile clientProfile = new ClientProfile { Id = user.Id, Name = userDto.Name };
                ClientProfile clientProfile = new ClientProfile { Id = user.Id, Address = userDto.Address, Name = userDto.Name };
                Database.ClientManager.Create(clientProfile);
                await Database.SaveAsync();
                return new OperationDetails(true, "Регистрация успешно пройдена", "");
            }
            else
            {
                return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");
            }
        }


        public async Task<OperationDetails> Edit(string name, UserDTO updatedUser)
        {
            ApplicationUser user = await Database.UserManager.FindByEmailAsync(name);
            if (user != null)
            {
                user.Email = updatedUser.Email;
                IdentityResult validEmail
                    = await Database.UserManager.UserValidator.ValidateAsync(user);

                if (!validEmail.Succeeded)
                {
                    return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");
                }

                IdentityResult validPass = null;
                if (updatedUser.Password != string.Empty)
                {
                    validPass
                        = await Database.UserManager.PasswordValidator.ValidateAsync(updatedUser.Password);

                    if (validPass.Succeeded)
                    {
                        user.PasswordHash =
                            Database.UserManager.PasswordHasher.HashPassword(updatedUser.Password);
                    }
                    else
                    {
                        return new OperationDetails(false, "Что-то не так с паролем!", "Password");
                    }
                }

                if ((validEmail.Succeeded && validPass == null) ||
                        (validEmail.Succeeded && updatedUser.Password != string.Empty && validPass.Succeeded))
                {
                    IdentityResult result = await Database.UserManager.UpdateAsync(user);
                    ClientProfile profile = Database.ClientManager.Get(user.Id);
                    profile.Name = updatedUser.Name;
                    profile.Address = updatedUser.Address;
                    Database.ClientManager.Update(profile);
                    await Database.SaveAsync();
                    if (result.Succeeded)
                    {
                        return new OperationDetails(true, "Изменение успешно!", "");
                    }
                    else
                    {
                        return new OperationDetails(false, "Что-то пошло не так", "");
                    }
                }
                else
                {
                    return new OperationDetails(false, "Что-то пошло не так", "");
                }
            }
            else
            {
                return new OperationDetails(false, "Пользователь не найден", "");
            }
        }


        public async Task<OperationDetails> Edit(UserDTO currentUserDto, UserDTO updatedUser)
        {
            ApplicationUser user = await Database.UserManager.FindByEmailAsync(currentUserDto.Name);
            if (user != null)
            {
                user.Email = updatedUser.Email;
                IdentityResult validEmail
                    = await Database.UserManager.UserValidator.ValidateAsync(user);

                if (!validEmail.Succeeded)
                {
                    return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");
                }

                IdentityResult validPass = null;
                if (updatedUser.Password != string.Empty)
                {
                    validPass
                        = await Database.UserManager.PasswordValidator.ValidateAsync(updatedUser.Password);

                    if (validPass.Succeeded)
                    {
                        user.PasswordHash =
                            Database.UserManager.PasswordHasher.HashPassword(updatedUser.Password);
                    }
                    else
                    {
                        return new OperationDetails(false, "Что-то не так с паролем!", "Password");
                    }
                }

                if ((validEmail.Succeeded && validPass == null) ||
                        (validEmail.Succeeded && updatedUser.Password != string.Empty && validPass.Succeeded))
                {
                    IdentityResult result = await Database.UserManager.UpdateAsync(user);
                    ClientProfile profile = Database.ClientManager.Get(user.Id);
                    profile.Name = updatedUser.Name;
                    profile.Address = updatedUser.Address;
                    Database.ClientManager.Update(profile);

                    if (result.Succeeded)
                    {
                        return new OperationDetails(true, "Изменение успешно!", "");
                    }
                    else
                    {
                        return new OperationDetails(false, "Что-то пошло не так", "");
                    }
                }
                else
                {
                    return new OperationDetails(false, "Что-то пошло не так", "");
                }
            }
            else
            {
                return new OperationDetails(false, "Пользователь не найден", "");
            }
        }

        public async Task<OperationDetails> Delete(string name)
        {
            ApplicationUser user = await Database.UserManager.FindByEmailAsync(name);
            if (user != null)
            {
                Database.ClientManager.Delete(user.Id);
                IdentityResult result = await Database.UserManager.DeleteAsync(user);
                await Database.SaveAsync();
                if (result.Succeeded)
                {
                    return new OperationDetails(true, "Удаление успешно!", "");
                }
                else
                {
                    return new OperationDetails(false, "Что-то пошло не так", "");
                }
            }
            else
            {
                return new OperationDetails(false, "Пользователь не найден", "");
            }
        }

        public async Task<ClaimsIdentity> Authenticate(UserDTO userDto)
        {
            ClaimsIdentity claim = null;
            // находим пользователя
            ApplicationUser user = await Database.UserManager.FindAsync(userDto.Email, userDto.Password);
            // авторизуем его и возвращаем объект ClaimsIdentity
            if (user != null)
                claim = await Database.UserManager.CreateIdentityAsync(user,
                                            DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }

        // начальная инициализация бд
        public async Task SetInitialData(UserDTO adminDto, List<string> roles)
        {
            foreach (string roleName in roles)
            {
                var role = await Database.RoleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new ApplicationRole { Name = roleName };
                    await Database.RoleManager.CreateAsync(role);
                }
            }
            await Create(adminDto);
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public async Task<UserDTO> GetUser(string name)
        {
            UserDTO userDto = new UserDTO();
            ApplicationUser user = await Database.UserManager.FindByEmailAsync(name);
            if (user != null)
            {
                userDto.Email = user.Email;
                userDto.Password = null;
                userDto.UserName = user.Email;
                ClientProfile profile = Database.ClientManager.Get(user.Id);
                userDto.Address = profile.Address;
                userDto.Name = profile.Name;                
            }
            return userDto;
        }

        public async Task<List<UserDTO>> GetAll()
        {
            List<UserDTO> users = new List<UserDTO>();       

            await Task.Run(() => 
            {
                foreach (var item in
                      Database.ClientManager.GetAll())
                {
                    users.Add(new UserDTO()
                    {
                        Id = item.ApplicationUser.Id,
                        Email = item.ApplicationUser.Email,
                        Password = null,
                        UserName = item.ApplicationUser.Email,
                        Name = item.Name,
                        Address = item.Address,
                        Role = item.ApplicationUser.Roles.ToList().ToString()
                    });
                }
            }
        );
            return users;
        }
           
    }
}
