using ApiLTMTest.Application.Service.Interfaces;
using ApiLTMTest.Application.Util.Functions;
using ApiLTMTest.Application.ViewModel;
using ApiLTMTest.Application.ViewModel.User;
using ApiLTMTest.Domain.Context;
using ApiLTMTest.Domain.Entities;
using ApiLTMTest.Domain.Enums;
using ApiLTMTest.Domain.Repositories.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiLTMTest.Application.Service
{
    public class UserService : UserManager<User>, IUserService
    {
        public IRepository<User> UserRepository { get; }


        public UserService(ApiLTMTestContext context, IRepository<User> userRepository) : base(new UserStore<User>(context))
        {
            UserRepository = userRepository;

            // Configuração de confirmação de e-mail
            //appUserManager.EmailService = new EmailService();

            var options = new IdentityFactoryOptions<UserService>();

            // Configuração de Token de Email
            var dataProtectionProvider = options.DataProtectionProvider;

            if (dataProtectionProvider != null)
            {
                UserTokenProvider = new DataProtectorTokenProvider<User>(dataProtectionProvider.Create("Versian-Identity"))
                {
                    TokenLifespan = TimeSpan.FromHours(1)
                };
            }

            // Validação de Usuário
            UserValidator = new UserValidator<User>(this)
            {
                AllowOnlyAlphanumericUserNames = true,
                RequireUniqueEmail = true
            };

            // Validação de Senha
            PasswordValidator = new PasswordValidator
            {
                RequireLowercase = false,
                RequireUppercase = false,
                RequireDigit = false,
                RequiredLength = 0
            };
        }


        public async Task<RequestReturnVM<bool>> RegisterAsync(RegisterVM registerVM)
        {
            try
            {
                var user = Functions.ConvertObjectTo<User>(registerVM);
                user.UserName = registerVM.Email;
                user.Password = registerVM.Password;

                user.Claims.Add(new IdentityUserClaim
                {
                    ClaimType = nameof(UserLevel),
                    ClaimValue = UserLevel.COMMON_USER.ToString(),
                    UserId = user.Id
                });

                var userExistent = UserRepository.Find(wh => wh.UserName == user.UserName) != null;

                if (userExistent)
                    throw new Exception("Usuário já existe");

                var result = await CreateAsync(user, registerVM.Name);

                if (!result.Succeeded)
                    throw new Exception(String.Join(" | ", result.Errors));

                return new RequestReturnVM<bool>
                {
                    Success = true,
                    MessageTitle = "Cadastro de Usuário",
                    MessageBody = "Usuário cadastro com sucesso!",
                    Data = true
                };
            }
            catch (Exception e)
            {
                return new RequestReturnVM<bool>
                {
                    Success = false,
                    MessageTitle = "Cadastro de Usuário",
                    MessageBody = "Ocorreu um erro ao cadastrar o usuário. Código do Erro: ",
                    Data = false
                };
            }
        }

        public async Task<RequestReturnVM<UserVM>> GetUserInfoAsync(string currentUserID)
        {
            try
            {
                var user = await FindByIdAsync(currentUserID);

                var userVM = Functions.ConvertObjectTo<UserVM>(user);

                return new RequestReturnVM<UserVM>
                {
                    MessageTitle = "Busca de Usuário",
                    MessageBody = "Busca realizada com sucesso!",
                    Success = true,
                    Data = userVM
                };
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<RequestReturnVM<bool>> UpdatePasswordAsync(string currentUserID, UpdatePasswordVM updatePasswordVM)
        {
            try
            {
                var result = await ChangePasswordAsync(currentUserID, updatePasswordVM.OldPassword, updatePasswordVM.NewPassword);

                if (!result.Succeeded)
                    throw new Exception(string.Join(" | ", result.Errors));

                return new RequestReturnVM<bool>
                {
                    MessageTitle = "Troca de Senha",
                    MessageBody = "Troca de senha efetuada com sucesso!",
                    Success = true,
                    Data = true
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<RequestReturnVM<bool>> UpdateUserAsync(string currentUserID, UserVM userVM)
        {
            try
            {
                var user = await FindByIdAsync(currentUserID);

                if (user.Id != currentUserID)
                    throw new Exception("Chamada inválida");

                user = user.CopyPropertiesFrom(userVM);

                var result = await UpdateAsync(user);

                if (!result.Succeeded)
                    throw new Exception(string.Join(" |", result.Errors));

                return new RequestReturnVM<bool>
                {
                    MessageTitle = "Atualização de Usuário",
                    MessageBody = "Atualização dos dados do usuário efetuada com sucesso!",
                    Success = true,
                    Data = true
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
