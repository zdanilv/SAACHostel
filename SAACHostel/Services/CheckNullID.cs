
using SAACHostel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SAACHostel.Services
{
    internal class CheckNullID
    {
        public static int CheckID(string _key)
        {
            switch (_key)
            {
                case "journal":
                    return CheckJournalID();
                case "student":
                    return CheckStudentID();
                case "room":
                    return CheckRoomID();
                case "hostel":
                    return CheckHostelID();
                case "faculty":
                    return CheckFacultyID();
                case "specialty":
                    return CheckSpecialtyID();
                default:
                    return -1;
            }
        }
        private static int CheckJournalID()
        {
            using (DataBaseModel dataBase = new DataBaseModel())
            {
                if ((from DataBaseModel.LogEntry logEntry in dataBase.LogEntrys select logEntry.ID).Count() >= 1)
                {
                    int ID = (from DataBaseModel.LogEntry logEntry in dataBase.LogEntrys select logEntry.ID).ToList().Last();
                    return ID + 1;
                }
                else return 1;
            }
        }
        private static int CheckStudentID()
        {
            using (DataBaseModel dataBase = new DataBaseModel())
            {
                if ((from DataBaseModel.Student student in dataBase.Students select student.ID).Count() >= 1)
                {
                    int ID = (from DataBaseModel.Student student in dataBase.Students select student.ID).ToList().Last();
                    return ID + 1;
                }
                else return 1;
            }
        }
        private static int CheckRoomID()
        {
            using (DataBaseModel dataBase = new DataBaseModel())
            {
                if ((from DataBaseModel.Room room in dataBase.Rooms select room.ID).Count() >= 1)
                {
                    int ID = (from DataBaseModel.Room room in dataBase.Rooms select room.ID).ToList().Last();
                    return ID + 1;
                }
                else return 1;
                           }
        }
        private static int CheckHostelID()
        {
            using (DataBaseModel dataBase = new DataBaseModel())
            {
                if ((from DataBaseModel.Hostel hostel in dataBase.Hostels select hostel.ID).Count() >= 1)
                {
                    int ID = (from DataBaseModel.Hostel hostel in dataBase.Hostels select hostel.ID).ToList().Last();
                    return ID + 1;
                }
                else return 1;
            }
        }
        private static int CheckFacultyID()
        {
            using (DataBaseModel dataBase = new DataBaseModel())
            {
                if ((from DataBaseModel.Faculty faculty in dataBase.Facultys select faculty.ID).Count() >= 1)
                {
                    int ID = (from DataBaseModel.Faculty faculty in dataBase.Facultys select faculty.ID).ToList().Last();
                    return ID + 1;
                }
                else return 1;
            }
        }
        private static int CheckSpecialtyID()
        {
            using (DataBaseModel dataBase = new DataBaseModel())
            {
                if ((from DataBaseModel.Specialty specialty in dataBase.Specialtys select specialty.ID).Count() >= 1)
                {
                    int ID = (from DataBaseModel.Specialty specialty in dataBase.Specialtys select specialty.ID).ToList().Last();
                    return ID + 1;
                }
                else return 1;
            }
        }
    }
}
