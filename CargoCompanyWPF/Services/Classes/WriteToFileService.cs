using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CargoCompanyWPF.Model;
namespace CargoCompanyWPF.Services.Classes
{
    public static class WriteToFileService
    {
        public static int WriteUserInfo(User? user)
        {
            User? newUser = new()
            {
                FirstName = user?.FirstName,
                LastName = user?.LastName,
                Email = user?.Email,
                Password = user?.Password,
                Address = user?.Address,
                Phone = user?.Phone,
                Serial = user?.Serial,
                FIN = user?.FIN
            };
            Users.All_users.Add(newUser);

            using var fs = new FileStream("UsersInfo.json", FileMode.OpenOrCreate);
            JsonSerializer.Serialize(fs,Users.All_users);
            return Users.All_users.Count - 1;   
            //_navigationService?.NavigateTo<LoginViewModel>(new ParameterMessage() { Message = newUser });

            //Users users = new Users();  
            //using var fs = new FileStream("data.json", FileMode.OpenOrCreate);
            //JsonSerializer.Serialize(fs,users);
        }

    }
}
