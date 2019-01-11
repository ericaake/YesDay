using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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

        public CoupleServices(
            UserManager<MyIdentityUser> userManager,
            SignInManager<MyIdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            YesDayContext context,
            IHttpContextAccessor httpContextAccessor)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
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

        public string Userref()
        {
            return userManager.GetUserId(httpContextAccessor.HttpContext.User);
        }


        public CoupleChecklistVM[] GetChecklist()
        {
           
            return context.Task
                .Select(r => new CoupleChecklistVM()
                {
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
                TaskStatus = newTaskVM.TaskStatus,
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
    }
}
