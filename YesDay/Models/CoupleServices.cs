using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YesDay.Models.Entities;
using YesDay.Models.ViewModels;

namespace YesDay.Models
{
    public class CoupleServices
    {
        UserManager<MyIdentityUser> userManager;
        SignInManager<MyIdentityUser> signInManager;
        RoleManager<IdentityRole> roleManager;
        YesDayContext context;
        IHttpContextAccessor httpContextAccessor;
        MyIdentityContext identityContext;

        SelectListItem[] taskStatus = new SelectListItem[]
        {
                new SelectListItem { Value="0", Text="Uppgift", Selected=true },
                new SelectListItem { Value="1", Text="Påbörjad"},
                new SelectListItem { Value="2", Text="Klar"}
        };


        public CoupleServices(
            UserManager<MyIdentityUser> userManager,
            SignInManager<MyIdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            YesDayContext context,
            IHttpContextAccessor httpContextAccessor,
            MyIdentityContext identityContext)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
            this.identityContext = identityContext;
        }

        public CoupleGuestlistVM[] ShowAllGuests()
        {
            return context.Guest
                .Select(r => new CoupleGuestlistVM()
                {
                    Id = r.Id,
                    Firstname = r.Firstname,
                    Lastname = r.Lastname,
                    Address = r.Address,
                    Email = r.Email,
                    InvitedBy = r.InvitedBy,
                    GuestTitle = r.GuestTitle,
                    WeddingCrewTitle = r.WeddingCrewTitle,
                    Rsvp = r.Rsvp,
                    FoodPreference = r.FoodPreference,
                    GuestNote = r.GuestNote,
                    Userref = r.Userref
                })
                .ToArray();
        }

        public void AddNewGuest(CoupleAddNewGuestVM newGuestVM)
        {
            Guest guest = new Guest()
            {
                Firstname = newGuestVM.Firstname,
                Lastname = newGuestVM.Lastname,
                Address = newGuestVM.Address,
                Email = newGuestVM.Email,
                InvitedBy = newGuestVM.InvitedBy,
                GuestTitle = newGuestVM.GuestTitle,
                WeddingCrewTitle = newGuestVM.WeddingCrewTitle,
                Rsvp = newGuestVM.Rsvp,
                FoodPreference = newGuestVM.FoodPreference,
                GuestNote = newGuestVM.GuestNote,
                Userref = Userref()
            };

            context.Guest.Add(guest);
            context.SaveChanges();
        }

        public MyIdentityUser GetUserById()
        {
            var coupleId = Userref();
            var couple = identityContext.Users
                .Where(c => c.Id == coupleId)
                .FirstOrDefault();
            return couple;

        }

        internal async Task<IdentityResult> UpdateUserAsync(CoupleSettingVM vM)
        {
            var coupleId = Userref();

            MyIdentityUser user = identityContext.Users.SingleOrDefault(u => u.Id == coupleId);
            user.FirstName1 = vM.FirstName1;
            user.FirstName2 = vM.FirstName2;
            user.WeddingDate = vM.WeddingDate;

            return await userManager.UpdateAsync(user);

        }

        public string Userref()
        {
            return userManager.GetUserId(httpContextAccessor.HttpContext.User);
        }

        public DateTime GetWeddingDate()
        {
            var coupleId = Userref();
            var date = identityContext.Users
                .Where(c => c.Id == coupleId)
                .Select(c => c.WeddingDate)
                .FirstOrDefault();
            return date;
        }

        public CoupleChecklistVM[] GetChecklist()
        {

            return context.Task
                .Select(r => new CoupleChecklistVM()
                {
                    Id = r.Id,
                    TaskDescription = r.TaskDescription,
                    DueDate = r.DueDate,
                    TaskNote = r.TaskNote,
                    TaskStatus = r.TaskStatus,
                    Userref = Userref()

                })
                .ToArray();
        }

        public void AddNewTask(CoupleAddNewTaskVM newTaskVM)
        {

            Entities.Task task = new Entities.Task()
            {
                TaskDescription = newTaskVM.TaskDescription,
                DueDate = newTaskVM.DueDate,
                TaskNote = newTaskVM.TaskNote,
                TaskStatus = newTaskVM.SelectedTaskStatus.ToString(),
                Userref = Userref()
            };

            context.Task.Add(task);
            context.SaveChanges();

        }

        internal async Task<IdentityResult> RegisterUserAsync(PublicSignUpVM newCouple)
        {
            return await userManager.CreateAsync(
                new MyIdentityUser
                {
                    UserName = newCouple.Email,
                    Email = newCouple.Email,
                    FirstName1 = newCouple.FirstName1,
                    FirstName2 = newCouple.FirstName2,
                    WeddingDate = newCouple.WeddingDate
                },
                newCouple.Password);
        }

        internal async Task<SignInResult> LoginInUserAsync(PublicLogInVM couple)
        {
            return await signInManager.PasswordSignInAsync(
                 couple.UserName,
                 couple.Password,
                 false,
                 false);
        }

        internal async System.Threading.Tasks.Task LogoutAsync()
        {
            await signInManager.SignOutAsync();
        }

        public CoupleVendorVM[] ShowAllVendors()
        {
            return context.Vendor
                .Select(r => new CoupleVendorVM()
                {
                    Service = r.Service,
                    ContactInfo = r.ContactInfo,
                    Userref = r.Userref

                })
                .ToArray();
        }

        public void AddNewVendor(CoupleAddNewVendorVM newVendorVM)
        {
            Vendor vendor = new Vendor()
            {
                Service = newVendorVM.Service,
                ContactInfo = newVendorVM.ContactInfo,
                Userref = Userref()
            };

            context.Vendor.Add(vendor);
            context.SaveChanges();
        }


        public CoupleExpenseVM[] ShowAllExpenses()
        {
            return context.Expense
                .Select(r => new CoupleExpenseVM
                {
                    Item = r.Item,
                    EstimatedCost = r.EstimatedCost,
                    ActualCost = r.ActualCost,
                    Userref = r.Userref
                })
                .ToArray();
        }


        public void AddNewExpense(CoupleAddNewExpenseVM newExpenseVM)
        {
            Expense expense = new Expense()
            {
                Item = newExpenseVM.Item,
                EstimatedCost = newExpenseVM.EstimatedCost,
                ActualCost = newExpenseVM.ActualCost,
                Userref = Userref()
            };

            context.Expense.Add(expense);
            context.SaveChanges();
        }
        public CoupleAddNewTaskVM CreateViewModel()
        {
            CoupleAddNewTaskVM viewModel = new CoupleAddNewTaskVM
            {
                TaskStatus = taskStatus
            };

            return viewModel;
        }
        public CoupleUpdateGuestlistVM GetGuestForUpdate(int id)
        {
            Guest guest = context.Guest.SingleOrDefault(r => r.Id == id);

            return new CoupleUpdateGuestlistVM()
            {
                Id = guest.Id,
                Firstname = guest.Firstname,
                Lastname = guest.Lastname,
                Address = guest.Address,
                Email = guest.Email,
                FoodPreference = guest.FoodPreference,
                GuestNote = guest.GuestNote,
                GuestTitle = guest.GuestTitle,
                InvitedBy = guest.InvitedBy,
                WeddingCrewTitle = guest.WeddingCrewTitle,
                Rsvp = guest.Rsvp,
                Userref = Userref()
            };
        }

        public void UpdateGuest (CoupleUpdateGuestlistVM updateGuest)
        {
            Guest guest = context.Guest.SingleOrDefault(r => r.Id == updateGuest.Id);

            guest.Firstname = updateGuest.Firstname;
            guest.Lastname = updateGuest.Lastname;
            guest.Address = updateGuest.Address;
            guest.Email = updateGuest.Email;
            guest.FoodPreference = updateGuest.FoodPreference;
            guest.GuestNote = updateGuest.GuestNote;
            guest.GuestTitle = updateGuest.GuestTitle;
            guest.InvitedBy = updateGuest.InvitedBy;
            guest.WeddingCrewTitle = updateGuest.WeddingCrewTitle;
            guest.Rsvp = updateGuest.Rsvp;
            context.SaveChanges();
        }
    }
}
