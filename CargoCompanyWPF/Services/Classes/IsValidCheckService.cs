using CargoCompanyWPF.Model;
using System;
using System.Text.RegularExpressions;

namespace CargoCompanyWPF.Services.Classes
{
    public static class IsValidCheckService
    {
        public static Error? Error { get; set; } = new();
        public static (Error?, bool) IsValidForRegistrationVM(User? user)
        {
            Error = new();
            bool Flag = false;
            int counter = 0;
            var errors = RegexService.RegexForUser(user);
            Error = errors.Item1;
            if (String.IsNullOrEmpty(user?.FirstName) || String.IsNullOrEmpty(user?.LastName) || String.IsNullOrEmpty(user?.Email) || String.IsNullOrEmpty(user?.Password) || String.IsNullOrEmpty(user?.PasswordConfirmation) || String.IsNullOrEmpty(user?.Address) || String.IsNullOrEmpty(user?.Phone) || String.IsNullOrEmpty(user?.Serial) || String.IsNullOrEmpty(user?.FIN))
            {
                Error!.Empty_error = "All fields must be filled in";
                counter++;
            }

            if (user?.PasswordConfirmation != user?.Password) { Error!.PasswordConfirmation_error = "The password confirmation does not match"; counter++; }

            if (Users.All_users.Exists(u => ((u?.Email)?.ToLower()) == user?.Email?.ToLower())) { Error!.Email_error = "Email has already been taken"; counter++; }

            if (Users.All_users.Exists(u => ((u?.FIN)?.ToLower() == user?.FIN?.ToLower()))) { Error!.Fin_error = "FIN has already been taken"; counter++; }

            if (Users.All_users.Exists(u => (u?.Serial)?.ToLower() == user?.Serial?.ToLower())) { Error!.Serial_error = "Serial number has already been taken"; counter++; }

            if (Users.All_users.Exists(u => (u?.Phone)?.ToLower() == user?.Phone?.ToLower())) { Error!.Phone_error = "Phone number has already been taken"; counter++; }
            counter += errors.Item2;

            if (counter == 0) { Flag = true; }

            return (Error, Flag);
        }

        public static (Error?, bool) IsValidForLoginVM(User? user)
        {
            Error = new();
            bool Flag = false;
            int counter = 0;
            if (String.IsNullOrEmpty(user?.Email)) { Error.Email_error = "Fill in field"; counter++; }
            if (String.IsNullOrEmpty(user?.Password)) { Error.Password_error = "Fill in field"; counter++; }
            if (counter == 0) { Flag = true; }
            return (Error, Flag);
        }

        public static (Error?, bool) IsValidForChangesVM(User? user)
        {
            Error = new();
            bool Flag = false;
            int counter = 0;
            var errors = RegexService.RegexForUser(user);
            Error = errors.Item1;

            if (String.IsNullOrEmpty(user?.FirstName) || String.IsNullOrEmpty(user?.LastName) || String.IsNullOrEmpty(user?.Email) || String.IsNullOrEmpty(user?.Password) || String.IsNullOrEmpty(user?.PasswordConfirmation) || String.IsNullOrEmpty(user?.Address) || String.IsNullOrEmpty(user?.Phone) || String.IsNullOrEmpty(user?.Serial) || String.IsNullOrEmpty(user?.FIN))
            {
                Error!.Empty_error = "All fields must be filled in";
                counter++;
            }


            if (user?.PasswordConfirmation?.ToLower() != user?.Password?.ToLower()) { Error!.PasswordConfirmation_error = "The password confirmation does not match"; counter++; }
            if (user?.Email?.ToLower() != Users.All_users[UserIndex.Index]?.Email?.ToLower() && !String.IsNullOrEmpty(user?.Email))
            {

                if (Users.All_users.Exists(u => ((u?.Email)?.ToLower()) == user?.Email?.ToLower())) { Error!.Email_error = "Email has already been taken"; counter++; }
            }
            if (user?.FIN?.ToLower() != Users.All_users[UserIndex.Index]?.FIN?.ToLower() && !String.IsNullOrEmpty(user?.FIN))
            {
                if (Users.All_users.Exists(u => ((u?.FIN)?.ToLower() == user?.FIN?.ToLower()))) { Error!.Fin_error = "FIN has already been taken"; counter++; }
            }
            if (user?.Serial?.ToLower() != Users.All_users[UserIndex.Index]?.Serial?.ToLower() && !String.IsNullOrEmpty(user?.Serial))
            {
                if (Users.All_users.Exists(u => (u?.Serial)?.ToLower() == user?.Serial?.ToLower())) { Error!.Serial_error = "Serial number has already been taken"; counter++; }
            }
            if (user?.Phone?.ToLower() != Users.All_users[UserIndex.Index]?.Phone?.ToLower() && !String.IsNullOrEmpty(user?.Phone))
            {
                if (Users.All_users.Exists(u => (u?.Phone)?.ToLower() == user?.Phone?.ToLower())) { Error!.Phone_error = "Phone number has already been taken"; counter++; }
            }
            counter += errors.Item2;
            if (counter == 0) { Flag = true; }

            return (Error, Flag);
        }
        public static (Error?, bool) IsValidForPlaceOrderVM(Order? Order)
        {
            Error = new();
            bool Flag = false;
            int counter = 0;
            var errors = RegexService.RegexForOrder(Order);
            Error = errors.Item1;
            if (String.IsNullOrEmpty(Order?.Link) || String.IsNullOrEmpty(Order?.Size) || String.IsNullOrEmpty(Order?.Color) || String.IsNullOrEmpty(Order?.Category) || String.IsNullOrEmpty(Order?.Amount) || String.IsNullOrEmpty(Order?.Quantity) )
            {
                Error.Empty_error = "All fields except \"Note\" must be filled in";
                counter++;
            }
            

            counter += errors.Item2;
            if (counter == 0) { Flag = true; }
            return (Error, Flag);
        }
        public static (Error?, bool) IsValidForDeclareVM(Order? Order)
        {
            Error = new();
            bool Flag = false;
            int counter = 0;
            var errors = RegexService.RegexForOrder(Order);
            Error = errors.Item1;
            if (String.IsNullOrEmpty(Order?.Link) || String.IsNullOrEmpty(Order?.Tracking_number) || String.IsNullOrEmpty(Order?.Category) || String.IsNullOrEmpty(Order?.Quantity) || String.IsNullOrEmpty(Order?.Amount) || Order?.Uri == null )
            {
                Error!.Empty_error = "All fields except \"Note\" must be filled in";
                counter++;
            }

            counter += errors.Item2;
            if (counter == 0) { Flag = true; }
            return (Error, Flag);
        }
        public static (Error?, bool) IsValidForIncreasingBalanceVM(string? Amount,Card? Card)
        {
            Error = new();
            bool Flag = false;
            int counter = 0;
            var errors = RegexService.RegexForBalance(Amount,Card);
            Error = errors.Item1;
            if (String.IsNullOrEmpty(Card?.Number) || String.IsNullOrEmpty(Card?.Name) || String.IsNullOrEmpty(Card?.Surname!) || String.IsNullOrEmpty(Card?.Month!) || String.IsNullOrEmpty(Card?.Year!) || String.IsNullOrEmpty(Card?.CVV!) || String.IsNullOrEmpty(Amount!) )
            {
                Error!.Empty_error = "All fields must be filled in";
                counter++;
            }

            counter += errors.Item2;
            if (counter == 0) { Flag = true; }
            return (Error, Flag);
        }
    }
}
