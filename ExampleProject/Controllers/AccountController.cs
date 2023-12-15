using ExampleProject.Model;
using ExampleProject.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExampleProject.Controllers
{

    public class AccountController : Controller
    {
        private readonly AccountRepository _accountRepository;

        public AccountController(AccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [Route("SignIn")]
      
        public IActionResult SignIn(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
    
        [HttpPost]
        [Route ("SignIn")]
        public async Task<IActionResult> SignIn(SignInModel signInModel)
        {
            if (ModelState.IsValid)
            {
                var result =await _accountRepository.SignInRepository(signInModel);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index","Home");
                }
                ModelState.AddModelError("", "Invalid Credential");
            }
            return View(signInModel);

        }

        
        [Route("SignUp")]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [Route ("SignUp")]
        public async Task<IActionResult> SignUp(SignUpModel signUpModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.SignUpRepository(signUpModel);
                if(!result.Succeeded)
                {
                    foreach(var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("",errorMessage.Description);
                    }
                }
                ModelState.Clear();
            }
            return View();

        }

    
    }
}
