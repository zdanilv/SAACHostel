using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Events;
using Prism.Mvvm;

namespace SAACHostel.Models
{
    internal class HostelItemOpenAddDataBase : BindableBase
    {
        public static ViewModels.HostelItemInfoAdvancedViewModel GetViewModel(int id, IEventAggregator eventAggregator)
        {
            ViewModels.HostelItemInfoAdvancedViewModel viewModel = new ViewModels.HostelItemInfoAdvancedViewModel(eventAggregator);
            if (id != -1)
            {
                using (DataBaseModel dataBase = new DataBaseModel())
                {
                    foreach (DataBaseModel.Hostel hostel in dataBase.Hostels)
                    {
                        if (hostel.ID == id)
                        {
                            viewModel.IsNew = false;
                            viewModel.IsReadOnly = true;
                            viewModel.IsEnabledSaveButton = false;
                            viewModel.ID = hostel.ID;
                            viewModel.DateCreate = hostel.Date_Create;
                            viewModel.Phone = hostel.Phone;
                            viewModel.Count_Rooms = hostel.Count_Room;
                            viewModel.Home_Address = hostel.Home_address;
                        }
                        foreach (DataBaseModel.User user in dataBase.Users)
                        {
                            if (user.ID == hostel.UserID)
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
                viewModel.ID = Services.CheckNullID.CheckID("hostel");
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
