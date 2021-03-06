﻿using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using WebProject.Models;

namespace WebProject.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() {
                UserName = Email.Text,
                PhoneNumber = Phone.Text,
                Email = Email.Text };
            var customer = new Customer()
            {
                FirstName = Firstname.Text,
                LastName = Surname.Text,
                EmailAddress = Email.Text,
                Password = Password.Text

            };

            ApplicationDbContext ctx = new ApplicationDbContext();
            ctx.Customers.Add(new Customer {
                FirstName = Firstname.Text,
                LastName = Surname.Text,
                EmailAddress = Email.Text,
                Phone = Phone.Text,
                Password = Password.Text,
                Address = Address.Text
                
            });
            ctx.SaveChanges();

            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else 
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}