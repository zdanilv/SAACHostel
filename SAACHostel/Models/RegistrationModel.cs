using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SAACHostel.Models
{
    internal class RegistrationModel : BindableBase
    {
        public static bool Registered(ViewModels.RegistrationViewModel view)
        {
            try
            {
                using (DataBaseModel dataBase = new DataBaseModel())
                {

                    DataBaseModel.User user = new DataBaseModel.User
                    {
                        Photo = view.Photo,
                        Login = view.Login,
                        Password = view.Password,
                        First_Name = view.FirstName,
                        Last_Name = view.LastName,
                        Middle_Name = view.MiddleName,
                        Pasport_ID = view.Passport,
                        Phone = view.PhoneNumber,
                        Home_address = view.HomeAddress
                    };
                    dataBase.Users.Add(user);
                    dataBase.SaveChanges();
                }
                return false;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Failed! " + ex);
                return true;
            }
        }
    }
}
