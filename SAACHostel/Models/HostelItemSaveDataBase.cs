using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAACHostel.Models
{
    internal class HostelItemSaveDataBase
    {
        public static void SaveDataBase(ViewModels.HostelItemInfoAdvancedViewModel view)
        {
            using (DataBaseModel dataBase = new DataBaseModel())
            {
                try
                {
                    DataBaseModel.Hostel hostel = new DataBaseModel.Hostel()
                    {
                        ID = view.ID,
                        Date_Create = view.DateCreate,
                        Count_Room = view.Count_Rooms,
                        Phone = view.Phone,
                        Home_address = view.Home_Address,
                        UserID = view.User_ID
                    };

                    foreach (DataBaseModel.User user in dataBase.Users)
                    {
                        if (user.ID == view.User_ID)
                            hostel.User = user;
                    }
                    dataBase.Hostels.Add(hostel);
                    dataBase.SaveChanges();
                }
                catch (System.ArgumentOutOfRangeException) { }
            }
        }
        public static void ChangeDataBase(ViewModels.HostelItemInfoAdvancedViewModel view)
        {
            using (DataBaseModel dataBase = new DataBaseModel())
            {
                foreach(DataBaseModel.Hostel hostel in dataBase.Hostels)
                {
                    if(hostel.ID == view.ID)
                    {
                        hostel.Count_Room = view.Count_Rooms;
                        hostel.Phone = view.Phone;
                        hostel.Home_address = view.Home_Address;
                        
                        dataBase.Hostels.Update(hostel);
                    }
                }
                dataBase.SaveChanges();
            }
        }
    }
}
