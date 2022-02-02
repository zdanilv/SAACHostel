using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SAACHostel.Models
{
    internal class RoomItemSaveDataBase
    {
        public static void SaveDataBase(ViewModels.RoomItemInfoAdvancedViewModel view)
        {
            using (DataBaseModel dataBase = new DataBaseModel())
            {
                try
                {
                    DataBaseModel.Room room = new DataBaseModel.Room()
                    {
                        ID = view.ID,
                        Date_Create = view.DateCreate,
                        Capacity = view.Capacity
                    };
                    
                    foreach (DataBaseModel.User user in dataBase.Users)
                    {
                        if (user.ID == view.User_ID)
                        {
                            room.User = user;
                            room.UserID = view.User_ID;
                        }
                    }
                    foreach (DataBaseModel.Hostel hostel in dataBase.Hostels)
                    {
                        if (hostel.ID == view.Hostel_ID)
                        {
                            room.Hostel = hostel;
                            room.HostelID = view.Hostel_ID;
                        }
                    }
                    dataBase.Rooms.Add(room);
                    dataBase.SaveChanges();
                }
                catch(System.ArgumentOutOfRangeException) { }
            }
        }
        public static void ChangeDataBase(ViewModels.RoomItemInfoAdvancedViewModel view)
        {
            using (DataBaseModel dataBase = new DataBaseModel())
            {
                foreach (DataBaseModel.Room room in dataBase.Rooms)
                {
                    if(room.ID == view.ID)
                    {
                        room.Capacity = view.Capacity;
                        foreach (DataBaseModel.Hostel hostel in dataBase.Hostels)
                        {
                            if (hostel.ID == view.Hostel_ID)
                            {
                                room.Hostel = hostel;
                                room.HostelID = view.Hostel_ID;
                            }
                        }
                        dataBase.Rooms.Update(room);
                    }
                }
                dataBase.SaveChanges();
            }
        }
    }
}
