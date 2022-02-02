using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAACHostel.Models
{
    internal class JournalItemSaveDataBase
    {
        public static void SaveDataBase(ViewModels.JournalItemInfoAdvancedViewModel view)
        {
            using (DataBaseModel dataBase = new DataBaseModel())
            {
                DataBaseModel.LogEntry logEntry = new DataBaseModel.LogEntry()
                {
                    ID = view.ID,
                    Date_Create = view.DateCreate,
                    Date_Ent = view.Date_Ent, //DateTime.ParseExact(view.Date_Ent, "dd.MM.yyyy", null)
                    Date_Ext = view.Date_Ext,
                    Pay = view.Pay,
                    Total_Paid = view.TotalPaid,
                    State = view.State.State,
                    RoomID = view.Room_ID,
                    HostelID = view.Hostel_ID,
                    StudentID = view.Student_ID,
                    UserID = view.User_ID,
                    PaymentAndPeriodID = view.PaymentAndPeriod_ID
                };
                foreach (DataBaseModel.User user in dataBase.Users)
                {
                    if (user.ID == view.User_ID)
                        logEntry.User = user;
                }
                dataBase.LogEntrys.Add(logEntry);
                dataBase.SaveChanges();
            }
        }
        public static void ChangeDataBase(ViewModels.JournalItemInfoAdvancedViewModel view)
        {
            using (DataBaseModel dataBase = new DataBaseModel())
            {
                foreach(DataBaseModel.LogEntry logEntry in dataBase.LogEntrys)
                {
                    if(logEntry.ID == view.ID)
                    {
                        logEntry.Date_Create = view.DateCreate;
                        logEntry.Date_Ent = view.Date_Ent;
                        logEntry.Date_Ext = view.Date_Ext;
                        logEntry.Pay = view.Pay;
                        logEntry.Total_Paid = view.TotalPaid;
                        logEntry.State = view.State.State;
                        logEntry.RoomID = view.Room_ID;
                        logEntry.HostelID = view.Hostel_ID;
                        logEntry.StudentID = view.Student_ID;
                        dataBase.LogEntrys.Update(logEntry);
                    }
                }
                dataBase.SaveChanges();
            }
        }
    }
}
