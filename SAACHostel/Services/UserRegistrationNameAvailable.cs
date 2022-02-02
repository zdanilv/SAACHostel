using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAACHostel.Services
{
    internal class UserRegistrationNameAvailable
    {
        public static IObservable<bool> IsUserNameAvailable(string userName)
        {
            bool isNameAvailable = true;
            using(Models.DataBaseModel dataBase = new Models.DataBaseModel())
            {
                if(dataBase.Users != null)
                {
                    foreach (Models.DataBaseModel.User user in dataBase.Users)
                    {
                        if (user.Login == userName)
                        {
                            isNameAvailable = false;
                        }
                    }
                }
            }
            return Observable.Return(isNameAvailable).Delay(TimeSpan.FromMilliseconds(500));
        }
    }
}
