using Microsoft.AspNetCore.Mvc;

namespace NexaWorksTicket.Controllers
{
    public class AccountController : Controller
    {
        [HttpPost]
        [Route("Account/Login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            if (model.Username == "admin" && model.Password == "1234")
            {
                return Json(new { success = true, message = "Connexion réussie. Bienvenue, Admin !" });
            }
            else
            {
                return Json(new { success = false, message = "Nom d'utilisateur ou mot de passe incorrect." });
            }
        }
    }

    // Modèle simple pour la requête
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
