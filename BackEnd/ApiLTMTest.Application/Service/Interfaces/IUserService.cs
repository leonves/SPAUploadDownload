using ApiLTMTest.Application.ViewModel;
using ApiLTMTest.Application.ViewModel.User;
using ApiLTMTest.Domain.Entities;
using System.Threading.Tasks;

namespace ApiLTMTest.Application.Service.Interfaces
{
    public interface IUserService
    {
        Task<RequestReturnVM<bool>> RegisterAsync(RegisterVM registerVM);

        Task<RequestReturnVM<UserVM>> GetUserInfoAsync(string currentUserID);

        Task<RequestReturnVM<bool>> UpdatePasswordAsync(string currentUserID, UpdatePasswordVM updatePasswordVM);

        Task<RequestReturnVM<bool>> UpdateUserAsync(string currentUserID, UserVM userVM);
    }
}
