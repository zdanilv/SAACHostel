using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAACHostel.Models
{
    internal class ProfileGetDataBase
    {
        public static ViewModels.DialogProfileViewModel GetInfo()
        {
            ViewModels.DialogProfileViewModel view = new ViewModels.DialogProfileViewModel();
            using (DataBaseModel dataBase = new DataBaseModel())
            {
                foreach (DataBaseModel.User user in dataBase.Users)
                {
                    if (user.Active)
                    {
                        view.Login = user.Login;
                        view.Password = user.Password;
                        view.Photo = user.Photo;
                        view.FirstName = user.First_Name;
                        view.LastName = user.Last_Name;
                        view.MiddleName = user.Middle_Name;
                        view.Passport = user.Pasport_ID;
                        view.PhoneNumber = user.Phone;
                        view.HomeAddress = user.Home_address;
                    }
                }
            }
            return view;
        }
    }
}
