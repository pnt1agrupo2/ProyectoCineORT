using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ORTCine.ViewModel;
using ORTCine.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace ORTCine.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserManager<Cliente> _clienteManager;

        public AccountController(IMapper mapper, UserManager<Cliente> clienteManager)
        {
            _mapper = mapper;
            _clienteManager = clienteManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegistrationModel clienteModel)
        {
            if (!ModelState.IsValid)
            {
                return View(clienteModel);
            }
            var cliente = _mapper.Map<Cliente>(clienteModel);
            var result = await _clienteManager.CreateAsync(cliente, clienteModel.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return View(clienteModel);
            }
            //await _clienteManager.AddToRoleAsync(cliente, "Visitor");
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginModel clienteModel)
        {
            if (!ModelState.IsValid)
            {
                return View(clienteModel);
            }
            var cliente = await _clienteManager.FindByEmailAsync(clienteModel.Email);
            if (cliente != null &&
                await _clienteManager.CheckPasswordAsync(cliente, clienteModel.Password))
            {
                var identity = new ClaimsIdentity(IdentityConstants.ApplicationScheme);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, cliente.Id.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Name, cliente.UserName));
                await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme,
                    new ClaimsPrincipal(identity));
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid UserName or Password");
                return View();
            }
        }
    }
}
