using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Events;
using Prism.Mvvm;

namespace SAACHostel.Models
{
    internal class RoomItemOpenAddDataBase : BindableBase
    {
        public static ViewModels.RoomItemInfoAdvancedViewModel GetViewModel(int id, IEventAggregator _eventAggregator)
        {
            ViewModels.RoomItemInfoAdvancedViewModel viewModel = new ViewModels.RoomItemInfoAdvancedViewModel(_eventAggregator);
            if (id != -1)
            {
                using (DataBaseModel dataBase = new DataBaseModel())
                {
                    foreach (DataBaseModel.Room room in dataBase.Rooms)
                    {
                        if (room.ID == id)
                        {
                            viewModel.IsNew = false;
                            viewModel.IsReadOnly = true;
                            viewModel.IsEnabledSaveButton = false;
                            viewModel.ID = room.ID;
                            viewModel.DateCreate = room.Date_Create;
                            viewModel.Capacity = room.Capacity;
                            viewModel.Hostel_ID = room.HostelID;
                        }
                        foreach (DataBaseModel.User user in dataBase.Users)
                        {
                            if (user.ID == room.UserID)
                            {
                                viewModel.User_ID = user.ID;
                                string[] shortName = new string[] { user.Last_Name, user.First_Name.FirstOrDefault().ToString(), user.Middle_Name.FirstOrDefault().ToString() };
                                viewModel.User_ShortName = String.Join(". ", shortName);
                                viewModel.User_Phone = user.Phone;
                            }
                        }
                    }
                }
            }
            else
            {
                viewModel.IsNew = true;
                viewModel.ID = Services.CheckNullID.CheckID("room");
                viewModel.DateCreate = DateTime.Now;
                viewModel.IsReadOnly = false;
                using (DataBaseModel dataBase = new DataBaseModel())
                {
                    foreach (DataBaseModel.User user in dataBase.Users)
                    {
                        if (user.Active)
                        {
                            viewModel.User_ID = user.ID;
                            string[] shortName = new string[] { user.Last_Name, user.First_Name.FirstOrDefault().ToString(), user.Middle_Name.FirstOrDefault().ToString() };
                            viewModel.User_ShortName = String.Join(". ", shortName);
                            viewModel.User_Phone = user.Phone;
                        }
                    }
                }
            }
            return viewModel;
        }
    }
}
