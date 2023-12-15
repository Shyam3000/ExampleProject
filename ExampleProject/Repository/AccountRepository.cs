using ExampleProject.Model;
using Microsoft.AspNetCore.Identity;

namespace ExampleProject.Repository
{
    public class AccountRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountRepository(UserManager<IdentityUser> userManager ,  SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IdentityResult> SignUpRepository(SignUpModel signUpModel)
        {
            var user = new IdentityUser()
            {
                Email = signUpModel.Email,
                UserName = signUpModel.Email
            };
            var result =  await _userManager.CreateAsync(user, signUpModel.Password);
            return result;
        }
       public async Task<SignInResult> SignInRepository(SignInModel signInModel )
        {

            var result =await _signInManager.PasswordSignInAsync(signInModel.Email, signInModel.Password, false, false);
            return result;
        }

    }
}
