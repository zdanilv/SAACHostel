using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Events;
using Prism.Mvvm;

namespace SAACHostel.Models
{
    internal class StudentItemOpenAddDataBase : BindableBase
    {
        public static ViewModels.StudentItemInfoAdvancedViewModel GetViewModel(int id, IEventAggregator _eventAggregator)
        {
            ViewModels.StudentItemInfoAdvancedViewModel viewModel = new ViewModels.StudentItemInfoAdvancedViewModel(_eventAggregator);
            if (id != -1)
            {
                using (DataBaseModel dataBase = new DataBaseModel())
                {
                    foreach (DataBaseModel.Student student in dataBase.Students)
                    {
                        if (student.ID == id)
                        {
                            viewModel.IsNew = false;
                            viewModel.IsReadOnly = true;
                            viewModel.IsEnabledSaveButton = false;
                            viewModel.ID = student.ID;
                            viewModel.DateCreate = student.Date_Create;
                            viewModel.Student_Photo = student.Photo;
                            viewModel.Student_FirstName = student.First_Name;
                            viewModel.Student_LastName = student.Last_Name;
                            viewModel.Student_MiddleName = student.Middle_Name;
                            viewModel.Student_Group = student.Group;
                            viewModel.Student_Passport = student.Passport_ID;
                            viewModel.Student_Phone = student.Phone;
                            viewModel.Student_HomeAddress = student.Home_address;

                            foreach (DataBaseModel.User user in dataBase.Users)
                            {
                                if (user.ID == student.UserID)
                                {
                                    viewModel.User_ID = user.ID;
                                    string[] shortName = new string[] { user.Last_Name, user.First_Name.FirstOrDefault().ToString(), user.Middle_Name.FirstOrDefault().ToString() };
                                    viewModel.User_ShortName = String.Join(". ", shortName);
                                    viewModel.User_Phone = user.Phone;
                                }
                            }
                            foreach (DataBaseModel.Faculty faculty in dataBase.Facultys)
                            {
                                if (faculty.ID == student.FacultyID)
                                    viewModel.Student_Faculty = faculty.Full_Name;
                            }
                            foreach (DataBaseModel.Specialty specialty in dataBase.Specialtys)
                            {
                                if (specialty.ID == student.FacultyID)
                                    viewModel.Student_Specialty = specialty.Full_Name;
                            }
                            foreach (DataBaseModel.User user in dataBase.Users)
                            {
                                if (user.ID == student.UserID)
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
                viewModel.ID = Services.CheckNullID.CheckID("student");
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
