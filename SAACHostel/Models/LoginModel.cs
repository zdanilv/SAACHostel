using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SAACHostel.Models
{
    internal class LoginModel
    {
        public static bool Logined(string login, string password)
        {
            try
            {
                bool result = false;
                using (DataBaseModel dataBase = new DataBaseModel())
                {
                    foreach (DataBaseModel.User user in dataBase.Users)
                    {
                        if (user.Login == login && user.Password == password)
                        {
                            user.Active = true;
                            result = true;
                        }
                    }
                    dataBase.SaveChanges();
                }
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed! " + ex);
                return false;
            }
        }
    }
}
