using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWashBackend.Models;

namespace CarWashBackend.Repository
{
    internal interface IAccount
    {
        UserTable VerifyLogin(string Email, string Password);
    }
}
