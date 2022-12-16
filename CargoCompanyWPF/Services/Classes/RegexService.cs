using CargoCompanyWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CargoCompanyWPF.Services.Classes
{
    public static class RegexService
    {
        public static Error? Error { get; set; } = new();
        public static int counter = 0;
        public static (Error?,int) RegexForUser(User? user)
        {
            counter = 0;
            Error = new();
            if (!Regex.IsMatch((user?.Phone!), @"^(70)|(50)|(10)|(55)|(51)|(77)|(99)[0-9](\d{7})$")) { Error.Phone_error = "Phone number must be az"; counter++; }

            if (!Regex.IsMatch((user?.Serial!), @"^[a-zA-Z]{2,3}(\d{7,15})$")) { Error.Serial_error = "Serial number must have 2-3 en alph in the beginning and 7-15 digits "; counter++; }

            if (!Regex.IsMatch((user?.FIN!), @"^[a-zA-Z0-9]{6,9}$")) { Error.Fin_error = "FIN number must have 6-9 symb of (with en alph) and digits "; counter++; }

            if (!Regex.IsMatch((user?.Email!), @"^[^.][a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{1,63}$")) { Error.Email_error = "Invalid email"; counter++; }

            if (!Regex.IsMatch((user?.Password!), @"^(?=.*?[A-Za-z])(?=.*?[0-9]).{6,}$")) { Error.Password_error = "Must include at least an alphabet and one number and more than 6 characters "; counter++; }

            if (!Regex.IsMatch((user?.FirstName!), @"^[~`!@#$%^&*()_+=[\]\\{}|;':"",.\/<>? a-zA-Z0-9-]*$")) { Error.FirstName_error = "Only english letters allowed"; counter++; }

            if (!Regex.IsMatch((user?.LastName!), @"^[~`!@#$%^&*()_+=[\]\\{}|;':"",.\/<>? a-zA-Z0-9-]*$")) { Error.LastName_error = "Only english letters allowed"; counter++; }

            if (!Regex.IsMatch((user?.Address!), @"^[~`!@#$%^&*()_+=[\]\\{}|;':"",.\/<>? a-zA-Z0-9-]*$")) { Error.Address_error = "Only english letters allowed"; counter++; }
            return (Error, counter);
        }
        public static (Error?, int) RegexForOrder(Order? Order)
        {
            counter = 0;
            Error = new();
            if (!Regex.IsMatch((Order?.Link!), @"^http(s)?://([\w-]+.)+[\w-]+(/[\w- ./?%&=])?$") && !String.IsNullOrEmpty(Order?.Link)) { Error.LinkError = "Invalid link"; counter++; }
            if (!Regex.IsMatch((Order?.Amount!), @"^[0-9]*(?:\,[0-9]*)?$")) { Error.AmountError = "Must contain only digits and comma"; counter++; }
            if (!Regex.IsMatch((Order?.Quantity!), @"^[0-9]*$")) { Error.QuantityError = "Must contain only digits"; counter++; }
            return (Error, counter);
        }
        public static (Error?, int) RegexForBalance(string? Amount,Card? Card)
        {
            counter = 0;
            Error = new();
            if (!Regex.IsMatch((Amount!), @"^[0-9]*(?:\,[0-9]*)?$")) { Error.AmountError = "Must contain only digits and comma"; counter++; }
            if (!Regex.IsMatch((Card?.Name!), @"^[~`!@#$%^&*()_+=[\]\\{}|;':"",.\/<>? a-zA-Z0-9-]*$")) { Error.FirstName_error = "Only english letters allowed"; counter++; }
            if (!Regex.IsMatch((Card?.Surname!), @"^[~`!@#$%^&*()_+=[\]\\{}|;':"",.\/<>? a-zA-Z0-9-]*$")) { Error.LastName_error = "Only english letters allowed"; counter++; }
            if (!Regex.IsMatch((Card?.Number!), @"^[0-9]*$")) { Error.QuantityError = "Must contain only digits"; counter++; }
            if (!Regex.IsMatch((Card?.Month!), @"^[0-9]*$")) { Error.MonthError = "Must contain only digits"; counter++; }
            if (!Regex.IsMatch((Card?.Year!), @"^[0-9]*$")) { Error.YearError = "Must contain only digits"; counter++; }
            if (!Regex.IsMatch((Card?.CVV!), @"^[0-9]*$")) { Error.CVVError = "Must contain only digits"; counter++; }

            return (Error, counter);
        }
    }

}
