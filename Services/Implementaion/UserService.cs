using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MoneyTransferApplication.Models;
using MoneyTransferApplication.Repositories.Interface;
using MoneyTransferApplication.Services.Interface;
using MoneyTransferApplication.ViewModel.Authentication.User;

namespace MoneyTransferApplication.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IGenericUnitofWork _uow;

    
        public UserService(IUserRepository userRepository, UserManager<User> userManager,IMapper mapper,IGenericUnitofWork uow)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<GetUserVM> GetUserByIdAsync(Guid id)
        {
            var userdt= await _userRepository.GetByGuidAsync(id);
            var userdata= _mapper.Map<GetUserVM>(id);
            return userdata;
        }

        public async Task<GetUserVM> GetUserByEmailAsync(string email)
        {   
            var data= await _userRepository.GetUserByEmailAsync(email);
            var userdata= _mapper.Map<GetUserVM>(data);
            return userdata;

        }

        public async Task<GetUserVM> CreateUserAsync(RegisterUserVM user)
        {
            var userdt = _mapper.Map<User>(user);
            var data =_userRepository.AddSync(userdt);

            return _mapper.Map<GetUserVM>(data);
        }

        public async Task<GetUserVM> UpdateUserAsync(UpdateUserVM Updateuser)
        {
            try
            {
                var userdt = await _userRepository.GetByGuidAsync(Updateuser.Id) ?? throw new Exception("User not found");
                _mapper.Map(Updateuser, userdt);
                await _uow.SaveChangesAsync();
                return _mapper.Map<GetUserVM>(userdt);
            }
            catch (Exception ex)
            {
                throw new Exception("User cannot be updated", ex);
            }

        }

        public async Task DeleteUserAsync(Guid id)
        {
            var user = await _userRepository.GetByGuidAsync(id);
            if (user != null)
            {
                await _userRepository.DeleteAsync(user);
            }
        }
        public async Task<GetUserVM> RegisterAsync(RegisterUserVM user)
        {
           
            var userdt = _mapper.Map<User>(user);
            var result = await _userManager.CreateAsync(userdt, userdt.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(userdt, "User");
            }
            return _mapper.Map<GetUserVM>(userdt);
        }
        
    }
}
