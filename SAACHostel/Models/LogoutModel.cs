using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SAACHostel.Models
{
    internal class LogoutModel
    {
        public static bool Logout()
        {
            try
            {
                bool result = false;
                using (DataBaseModel dataBase = new DataBaseModel())
                {
                    foreach (DataBaseModel.User user in dataBase.Users)
                    {
                        if (user.Active)
                        {
                            user.Active = false;
                            result = true;
                        }
                    }
                    dataBase.SaveChanges();
                    MessageBox.Show("Logout!");
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
