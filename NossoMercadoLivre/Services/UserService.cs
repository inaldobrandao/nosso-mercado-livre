using NossoMercadoLivre.Models.Entities;
using NossoMercadoLivre.Models.ViewModels;
using NossoMercadoLivre.Repositories;
using NossoMercadoLivre.Utils;
using System;

namespace NossoMercadoLivre.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Create(CreateUserViewModel user)
        {
            try
            {
                User newUser = new User
                {
                    Username = user.Username
                };


                newUser.Password = UserUtil.GeneratePass(newUser, user.Password);

                _userRepository.CreateUser(newUser);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
