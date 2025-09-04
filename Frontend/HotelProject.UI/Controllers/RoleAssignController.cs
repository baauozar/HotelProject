using HotelProject.DataAccessLayer.EntityFramework;
using HotelProject.EntityLayer.Concrete;
using HotelProject.UI.Model.RoleAssign;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.UI.Controllers
{
    public class RoleAssignController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<AppRole> roleManager;

        public RoleAssignController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var values = userManager.Users.ToList();
            return View(values);
        }
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = userManager.Users.FirstOrDefault(x => x.Id == id);
            var roles = roleManager.Roles.ToList();
            ViewData["UserName"] = user.UserName;
            ViewData["UserId"] = user.Id;
            var userRoles = await userManager.GetRolesAsync(user);
            List<RoleAssignViewModel> model = new List<RoleAssignViewModel>();
            foreach (var item in roles)
            {
                RoleAssignViewModel m = new RoleAssignViewModel();
                m.RoleId = item.Id;
                m.RoleName = item.Name;
                m.Exists = userRoles.Contains(item.Name);
                model.Add(m);
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> model, int userId)
        {
            var user = await userManager.FindByIdAsync(userId.ToString()); // Properly load user
         
          

            var currentRoles = await userManager.GetRolesAsync(user);

            foreach (var item in model)
            {
                if (item.Exists && !currentRoles.Contains(item.RoleName))
                {
                    await userManager.AddToRoleAsync(user, item.RoleName);
                }
                else if (!item.Exists && currentRoles.Contains(item.RoleName))
                {
                    await userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
            }

            return RedirectToAction("Index");
        }
    }
}
