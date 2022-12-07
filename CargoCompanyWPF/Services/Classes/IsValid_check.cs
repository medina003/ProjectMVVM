using CargoCompanyWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace CargoCompanyWPF.Services.Classes
{
    public static class IsValid_check
    {
        public static Error? Error { get; set; } = new();    
        public static (Error?, bool) IsValidForRegistrationVM(User? user)
        {
            Error = new();
            bool Flag = false;
            int? counter = 0;

             Error.Empty_error = "";
             Error.Email_error = "";
             Error.Fin_error = "";
             Error.Serial_error = "";
             Error.Phone_error = "";
             Error.Password_error = "";
             Error.PasswordConfirmation_error = "";
             Error.FirstName_error = "";
             Error.LastName_error = "";
             Error.Address_error = "";
            if ((user.FirstName == null || user?.LastName == null || user?.Email == null || user?.Password == null || user?.PasswordConfirmation == null || user?.Address == null || user?.Phone == null || user?.Serial == null || user?.FIN == null))
            {
                Error.Empty_error = "All fields must be filled in";
                counter++;
            }
            if (user?.Phone != null)
            {
                if (!Regex.IsMatch((user?.Phone), @"^(70)|(50)|(10)|(55)|(51)|(77)|(99)[0-9](\d{7})$")) { Error.Phone_error = "Phone number must be az"; counter++; }
            }
            if (user?.Serial != null)
            {
                if (!Regex.IsMatch((user?.Serial), @"^[a-zA-Z]{2,3}(\d{7,15})$")) { Error.Serial_error = "Serial number must have 2-3 en alph in the beginning and 7-15 digits "; counter++; }
            }
            if (user?.FIN != null)
            {
                if (!Regex.IsMatch((user?.FIN), @"^[a-zA-Z0-9]{6,9}$")) { Error.Fin_error = "FIN number must have 6-9 symb of (with en alph) and digits "; counter++; }
            }
            if (user?.Email != null)
            {
                if (!Regex.IsMatch((user?.Email), @"^[^.][a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{1,63}$")) { Error.Email_error = "Invalid email"; counter++; }

            }
            if (user?.Password != null)
            {
                if (!Regex.IsMatch((user?.Password), @"^(?=.*?[A-Za-z])(?=.*?[0-9]).{6,}$")) { Error.Password_error = "Must include at least an alphabet and one number and more than 6 characters "; counter++; }
            }
            if (user?.FirstName != null)
            {
                if (!Regex.IsMatch((user?.FirstName), @"^[~`!@#$%^&*()_+=[\]\\{}|;':"",.\/<>? a-zA-Z0-9-]*$")) { Error.FirstName_error = "Only english letters allowed"; counter++; }
            }
            if (user?.LastName != null)
            {
                if (!Regex.IsMatch((user?.LastName), @"^[~`!@#$%^&*()_+=[\]\\{}|;':"",.\/<>? a-zA-Z0-9-]*$")) { Error.LastName_error = "Only english letters allowed"; counter++; }
            }
            if (user?.Address != null)
            {
                if (!Regex.IsMatch((user?.Address), @"^[~`!@#$%^&*()_+=[\]\\{}|;':"",.\/<>? a-zA-Z0-9-]*$")) { Error.Address_error = "Only english letters allowed"; counter++; }
            }
            if (user?.PasswordConfirmation != user?.Password) { Error.PasswordConfirmation_error = "The password confirmation does not match"; counter++; }

            if (Users.All_users.Exists(u => ((u.Email)?.ToLower()) == user?.Email?.ToLower())) { Error.Email_error = "Email has already been taken"; counter++; }
            if (Users.All_users.Exists(u => ((u.FIN)?.ToLower() == user?.FIN?.ToLower()))) { Error.Fin_error = "FIN has already been taken"; counter++; }
            if (Users.All_users.Exists(u => (u.Serial)?.ToLower() == user?.Serial?.ToLower())) { Error.Serial_error = "Serial number has already been taken"; counter++; }
            if (Users.All_users.Exists(u => (u.Phone)?.ToLower() == user?.Phone?.ToLower())) { Error.Phone_error = "Phone number has already been taken"; counter++; }
            if (counter == 0) { Flag = true; }


            return (Error, Flag);
        }

        public static (Error?,bool) IsValidForLoginVM(User? user)
        {
            Error = new();
            bool Flag = false;
            int counter = 0;
            Error.Email_error = "";
            Error.Password_error = "";
            if (user?.Email == "" || user?.Email == null) { Error.Email_error = "Fill in field" ;counter++; }
            if (user?.Password == "" || user?.Password == null) { Error.Password_error = "Fill in field"; counter++; }
            if(counter==0) { Flag = true; } 
            return (Error, Flag);
        }



    }
}
