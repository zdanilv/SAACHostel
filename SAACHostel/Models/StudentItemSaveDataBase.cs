using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAACHostel.Models
{
    internal class StudentItemSaveDataBase
    {
        public static void SaveDataBase(ViewModels.StudentItemInfoAdvancedViewModel view)
        {
            using (DataBaseModel dataBase = new DataBaseModel())
            {
                DataBaseModel.Student student = new DataBaseModel.Student()
                {
                    ID = view.ID,
                    Date_Create = view.DateCreate,
                    Photo = view.Student_Photo,
                    First_Name = view.Student_FirstName,
                    Last_Name = view.Student_LastName,
                    Middle_Name = view.Student_MiddleName,
                    Group = view.Student_Group,
                    Passport_ID = view.Student_Passport,
                    Phone = view.Student_Phone,
                    Home_address = view.Student_HomeAddress,
                };
                foreach(DataBaseModel.Faculty faculty in dataBase.Facultys)
                {
                    if (faculty.Full_Name == view.Student_Faculty)
                    {
                        student.Faculty = faculty;
                        student.FacultyID = faculty.ID;
                    }
                }
                foreach (DataBaseModel.Specialty specialty in dataBase.Specialtys)
                {
                    if (specialty.Full_Name == view.Student_Specialty)
                    {
                        student.Specialty = specialty;
                        student.SpecialtyID = specialty.ID;
                    }
                }
                foreach (DataBaseModel.User user in dataBase.Users)
                {
                    if (user.ID == view.User_ID)
                    {
                        student.User = user;
                        student.UserID = user.ID;
                    }

                }
                dataBase.Students.Add(student);
                dataBase.SaveChanges();
            }
        }
        public static void ChangeDataBase(ViewModels.StudentItemInfoAdvancedViewModel view)
        {
            using (DataBaseModel dataBase = new DataBaseModel())
            {
                foreach(DataBaseModel.Student student in dataBase.Students)
                {
                    if(student.ID == view.ID)
                    {
                        student.Photo = view.Student_Photo;
                        student.First_Name = view.Student_FirstName;
                        student.Last_Name = view.Student_LastName;
                        student.Middle_Name = view.Student_MiddleName;
                        student.Group = view.Student_Group;
                        student.Passport_ID = view.Student_Passport;
                        student.Phone = view.Student_Phone;
                        student.Home_address = view.Student_HomeAddress;

                        foreach (DataBaseModel.Faculty faculty in dataBase.Facultys)
                        {
                            if (faculty.Full_Name == view.Student_Faculty)
                            {
                                student.Faculty = faculty;
                                student.FacultyID = faculty.ID;
                            }
                        }
                        foreach (DataBaseModel.Specialty specialty in dataBase.Specialtys)
                        {
                            if (specialty.Full_Name == view.Student_Specialty)
                            {
                                student.Specialty = specialty;
                                student.SpecialtyID = specialty.ID;
                            }
                        }
                        dataBase.Students.Update(student);
                    }
                }
                dataBase.SaveChanges();
            }
        }
    }
}
