using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAACHostel.Models
{
    internal class FacultyItemDataBase
    {
        public static void AddDataBase(ViewModels.FacultyListItem item)
        {
            using (DataBaseModel dataBase = new DataBaseModel())
            {
                DataBaseModel.Faculty faculty = new DataBaseModel.Faculty()
                {
                    ID = Services.CheckNullID.CheckID("faculty"),
                    Date_Create = DateTime.Now,
                    Full_Name = item.Full_Name,
                    Full_Name_Decan = item.Full_Name_Decan,
                    Phone_Decane = item.Phone_Decan,
                    Short_Name = item.Short_Name
                    
                };
                foreach (DataBaseModel.User user in dataBase.Users)
                {
                    if (user.Active)
                        faculty.UserID = user.ID;
                }
                dataBase.Facultys.Add(faculty);
                dataBase.SaveChanges();
            }
        }
        public static void ChangeDataBase(ViewModels.FacultyListItem item, int _id)
        {
            using (DataBaseModel dataBase = new DataBaseModel())
            {
                foreach(DataBaseModel.Faculty faculty in dataBase.Facultys)
                {
                    if(faculty.ID == _id)
                    {
                        faculty.Full_Name = item.Full_Name;
                        faculty.Full_Name_Decan = item.Full_Name_Decan;
                        faculty.Phone_Decane = item.Phone_Decan;
                        faculty.Short_Name = item.Short_Name;
                        dataBase.Facultys.Update(faculty);
                    }
                }
                dataBase.SaveChanges();
            }
        }
    }
}
