using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAACHostel.Models
{
    internal class ProfileSaveDataBase
    {
        public static void SaveDataBase(ViewModels.DialogProfileViewModel view)
        {
            using (DataBaseModel dataBase = new DataBaseModel())
            {

                foreach (DataBaseModel.User user in dataBase.Users)
                {
                    if (user.Active)
                    {
                        user.Login = view.Login;
                        user.Password = view.Password;
                        user.Photo = view.Photo;
                        user.First_Name = view.FirstName;
                        user.Last_Name = view.LastName;
                        user.Middle_Name = view.MiddleName;
                        user.Pasport_ID = view.Passport;
                        user.Phone = view.PhoneNumber;
                        user.Home_address = view.HomeAddress;
                    }
                }
                dataBase.SaveChanges();
            }
        }
    }
}
