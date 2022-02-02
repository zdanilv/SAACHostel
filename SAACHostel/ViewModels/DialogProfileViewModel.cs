using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using SAACHostel.Interface;

namespace SAACHostel.ViewModels
{
    internal class DialogProfileViewModel : DialogViewModelBase
    {
        private Visibility _visibilityViewing;
        private Visibility _visibilityEditing;
        private bool _isEnabledSaveButton;

        private byte[] _photo;
        private string _login;
        private string _password;
        private string _firstName;
        private string _lastName;
        private string _middleName;
        private int _passport;
        private string _phoneNumber;
        private string _homeAddress;
        public Visibility VisibilityViewing
        {
            get { return _visibilityViewing; }
            set { SetProperty(ref _visibilityViewing, value); }
        }
        public Visibility VisibilityEditing
        {
            get { return _visibilityEditing; }
            set { SetProperty(ref _visibilityEditing, value); }
        }
        public bool IsEnabledSaveButton
        {
            get { return _isEnabledSaveButton; }
            set { SetProperty(ref _isEnabledSaveButton, value); }
        }
        public byte[] Photo
        {
            get { return _photo; }
            set { SetProperty(ref _photo, value); }
        }
        public string Login
        {
            get { return _login; }
            set { SetProperty(ref _login, value); }
        }
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }
        public string FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); }
        }
        public string LastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); }
        }
        public string MiddleName
        {
            get { return _middleName; }
            set { SetProperty(ref _middleName, value); }
        }
        public int Passport
        {
            get { return _passport; }
            set { SetProperty(ref _passport, value); }
        }
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { SetProperty(ref _phoneNumber, value); }
        }
        public string HomeAddress
        {
            get { return _homeAddress; }
            set { SetProperty(ref _homeAddress, value); }
        }
        public DelegateCommand AddPhotoCommand { get; set; }
        public DelegateCommand ChangeProfileCommand { get; set; }
        public DelegateCommand SaveProfileCommand { get; set; }
        public DelegateCommand BackCommand { get; set; }

        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public DelegateCommand CloseDialogCommand { get; set; }

        public DialogProfileViewModel()
        {
            Title = "Профиль";
            VisibilityEditing = Visibility.Hidden;
            VisibilityViewing = Visibility.Visible;

            AddPhotoCommand = new DelegateCommand(AddPhotoMethod);
            ChangeProfileCommand = new DelegateCommand(ChangeProfileMethod);
            SaveProfileCommand = new DelegateCommand(SaveProfileMethod);
            BackCommand = new DelegateCommand(BackMethod);
            //StartUpLoaded();
        }
        private void StartUpLoaded()
        {
            var view = Models.ProfileGetDataBase.GetInfo();
            Login = view.Login;
            Password = view.Password;
            Photo = view.Photo;
            FirstName = view.FirstName;
            LastName = view.LastName;
            MiddleName = view.MiddleName;
            Passport = view.Passport;
            PhoneNumber = view.PhoneNumber;
            HomeAddress = view.HomeAddress;
        }
        private void ChangeProfileMethod()
        {
            IsEnabledSaveButton = true;
            VisibilityViewing = Visibility.Hidden;
            VisibilityEditing = Visibility.Visible;
        }
        private void AddPhotoMethod()
        {
            Photo = Services.OpenDialogAddPhoto.ResultDialog();
        }
        private void SaveProfileMethod()
        {
            Models.ProfileSaveDataBase.SaveDataBase(this);
            IsEnabledSaveButton = false;
            VisibilityEditing = Visibility.Hidden;
            VisibilityViewing = Visibility.Visible;
            RaiseRequestClose(new DialogResult(ButtonResult.OK));
        }
        private void BackMethod()
        {
            RaiseRequestClose(new DialogResult(ButtonResult.Cancel));
        }
        public override void OnDialogOpened(IDialogParameters parameters)
        {
            //Message = parameters.GetValue<string>("message");
            using (Models.DataBaseModel dataBase = new Models.DataBaseModel())
            {
                foreach (Models.DataBaseModel.User user in dataBase.Users)
                {
                    if (user.Active)
                    {
                        Login = user.Login;
                        Password = user.Password;
                        Photo = user.Photo;
                        FirstName = user.First_Name;
                        LastName = user.Last_Name;
                        MiddleName = user.Middle_Name;
                        Passport = user.Pasport_ID;
                        PhoneNumber = user.Phone;
                        HomeAddress = user.Home_address;
                    }
                }
            }
        }
    }
}
