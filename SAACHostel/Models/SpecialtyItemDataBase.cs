using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAACHostel.Models
{
    internal class SpecialtyItemDataBase
    {
        public static void AddDataBase(ViewModels.SpecialtyListItem item)
        {
            using (DataBaseModel dataBase = new DataBaseModel())
            {
                DataBaseModel.Specialty specialty = new DataBaseModel.Specialty()
                {
                    ID = Services.CheckNullID.CheckID("specialty"),
                    Date_Create = DateTime.Now,
                    Full_Name = item.Full_Name,
                    Short_Name = item.Short_Name

                };
                foreach (DataBaseModel.User user in dataBase.Users)
                {
                    if (user.Active)
                        specialty.UserID = user.ID;
                }
                dataBase.Specialtys.Add(specialty);
                dataBase.SaveChanges();
            }
        }
        public static void ChangeDataBase(ViewModels.SpecialtyListItem item, int _id)
        {
            using (DataBaseModel dataBase = new DataBaseModel())
            {
                foreach (DataBaseModel.Specialty specialty in dataBase.Specialtys)
                {
                    if (specialty.ID == _id)
                    {
                        specialty.Full_Name = item.Full_Name;
                        specialty.Short_Name = item.Short_Name;
                        dataBase.Specialtys.Update(specialty);
                    }
                }
                dataBase.SaveChanges();
            }
        }
    }
}
