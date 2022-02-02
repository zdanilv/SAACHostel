using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Events;
using Prism.Mvvm;

namespace SAACHostel.Models
{
    internal class JournalItemOpenAddDataBase : BindableBase
    {
        public static ViewModels.JournalItemInfoAdvancedViewModel GetViewModel (int id, IEventAggregator _eventAggregator)
        {
            ViewModels.JournalItemInfoAdvancedViewModel viewModel = new ViewModels.JournalItemInfoAdvancedViewModel(_eventAggregator);
            if(id != -1)
            {
                using (DataBaseModel dataBase = new DataBaseModel())
                {
                    foreach (DataBaseModel.LogEntry logEntry in dataBase.LogEntrys)
                    {
                        if (logEntry.ID == id)
                        {
                            viewModel.IsNew = false;
                            viewModel.IsReadOnly = true;
                            viewModel.IsEnabledSaveButton = false;
                            viewModel.ID = logEntry.ID;
                            viewModel.DateCreate = logEntry.Date_Create;
                            viewModel.Date_Ent = logEntry.Date_Ent;
                            viewModel.Date_Ext = logEntry.Date_Ext;
                            viewModel.Hostel_ID = logEntry.HostelID;
                            viewModel.Room_ID = logEntry.RoomID;
                            viewModel.Pay = logEntry.Pay;
                            foreach(DataBaseModel.PaymentAndPeriod paymentAndPeriod in dataBase.PaymentAndPeriods)
                            {
                                if(paymentAndPeriod.SelectedPeriod == true)
                                {
                                    viewModel.SelectedPaymentPeriod = paymentAndPeriod.Period;
                                    viewModel.PaymentAndPeriod_ID = paymentAndPeriod.ID;
                                }
                            }
                            if (logEntry.State)
                                viewModel.State = new ViewModels.ComboBoxState { State = logEntry.State, Name_State = "Оплачено" };
                            else viewModel.State = new ViewModels.ComboBoxState { State = logEntry.State, Name_State = "Не оплачено" };

                            foreach (DataBaseModel.Student student in dataBase.Students)
                            {
                                if (student.ID == logEntry.StudentID)
                                {
                                    viewModel.Student_ID = student.ID;
                                    viewModel.Student_Photo = student.Photo;
                                    viewModel.Student_FirstName = student.First_Name;
                                    viewModel.Student_LastName = student.Last_Name;
                                    viewModel.Student_MiddleName = student.Middle_Name;
                                    viewModel.Student_Faculty = student.FacultyID;
                                    viewModel.Student_Specialty = student.SpecialtyID;
                                    viewModel.Student_Group = student.Group;
                                    viewModel.Student_Passport = student.Passport_ID;
                                    viewModel.Student_Phone = student.Phone;
                                    viewModel.Student_HomeAddress = student.Home_address;
                                }
                            }
                            foreach (DataBaseModel.User user in dataBase.Users)
                            {
                                if (user.ID == logEntry.UserID)
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
            }
            else
            {
                viewModel.IsNew = true;
                viewModel.ID = Services.CheckNullID.CheckID("journal");
                viewModel.DateCreate = DateTime.Now;
                viewModel.IsReadOnly = false;
                using (DataBaseModel dataBase = new DataBaseModel())
                {
                    foreach(DataBaseModel.PaymentAndPeriod paymentAndPeriod in dataBase.PaymentAndPeriods)
                    {
                        if(paymentAndPeriod.SelectedPeriod == true)
                        {
                            viewModel.SelectedPaymentPeriod = paymentAndPeriod.Period;
                            viewModel.PaymentAndPeriod_ID = paymentAndPeriod.ID;
                        }
                    }
                    if(dataBase.Payments.ToList().Count != 0)
                        viewModel.Pay = dataBase.Payments.FirstOrDefault().Amount;
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
