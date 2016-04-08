using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuthAuthDemo.Domain;
using AuthAuthDemo.Repositories;
using AuthAuthDemo.Web.Models;

namespace AuthAuthDemo.Web.ModelHelpers
{
    public class UserModelHelper
    {
        private UserRepository _userRepo;

        public UserModelHelper()
        {
            _userRepo = new UserRepository();
        }

        public IList<UserViewModel>GetAllUsers()
        {
            var domainUsers = _userRepo.GetAllUsers();

            var userViewModels = domainUsers.Aggregate(new List<UserViewModel>(), (users, user) => {
                                                                                    users.Add(new UserViewModel {
                                                                                        ID = user.ID,
                                                                                        EmailAddress = user.EmailAddress,
                                                                                        FirstName = user.FirstName,
                                                                                        LastName = user.LastName,
                                                                                        Password = _userRepo.GetUserMembership(user.ID).Password
                                                                                    });
                                                                                    return users;
                                                                                 });

            return userViewModels;
        }

        public void UpdateUser(RegisterViewModel viewModel)
        {
            var domainUser = new User
            {
                EmailAddress = viewModel.Email,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
            };

            _userRepo.UpdateUser(domainUser);
        }
    }
}