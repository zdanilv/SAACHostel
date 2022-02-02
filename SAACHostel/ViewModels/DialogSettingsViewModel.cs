using MvvmValidation;
using Prism.Commands;
using Prism.Services.Dialogs;
using SAACHostel.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SAACHostel.ViewModels
{
    internal class DialogSettingsViewModel : DialogViewModelBase, INotifyDataErrorInfo
    {
        private bool? isValid;
        private string validationErrorsString;
        protected ValidationHelper Validator { get; private set; }
        private NotifyDataErrorInfoAdapter NotifyDataErrorInfoAdapter { get; set; }
        private int _paymentAmount;
        private List<PeriodItems> _periodItems;
        private PeriodItems _selectedPeriodItems;
        public string ValidationErrorsString
        {
            get { return validationErrorsString; }
            private set { SetProperty(ref validationErrorsString, value); }
        }

        public bool? IsValid
        {
            get { return isValid; }
            private set { SetProperty(ref isValid, value); }
        }
        public int PaymentAmount
        {
            get { return _paymentAmount; }
            set { SetProperty(ref _paymentAmount, value); Validator.ValidateAsync(nameof(PaymentAmount)); }
        }
        public PeriodItems SelectedPeriodItems
        {
            get { return _selectedPeriodItems; }
            set { SetProperty(ref _selectedPeriodItems, value); Validator.ValidateAsync(nameof(SelectedPeriodItems)); }
        }
        public DelegateCommand CloseDialogCommand { get; set; }
        public DelegateCommand SaveCommand { get; set; }
        public DialogSettingsViewModel()
        {
            Validator = new ValidationHelper();
            NotifyDataErrorInfoAdapter = new NotifyDataErrorInfoAdapter(Validator);
            Title = "Настройки";
            CloseDialogCommand = new DelegateCommand(CloseDialogMethod);
            SaveCommand = new DelegateCommand(SaveMethod);
            _periodItems = new List<PeriodItems>();
            //AddAllItems();
            ConfigureValidationRules();
            Validator.ResultChanged += OnValidationResultChanged;
            Validate();
            InitialDataBase();
            AddAllItems();
        }
        private void CloseDialogMethod()
        {
            RaiseRequestClose(new DialogResult(ButtonResult.Cancel));
        }
        public override void OnDialogOpened(IDialogParameters parameters)
        {
            //Message = parameters.GetValue<string>("message");
        }
        private void InitialDataBase()
        {
            using (DataBaseModel dataBase = new DataBaseModel())
            {
                if(dataBase.PaymentAndPeriods.FirstOrDefault() == null)
                {
                    DataBaseModel.PaymentAndPeriod paymentAndPeriod1 = new DataBaseModel.PaymentAndPeriod()
                    {
                        ID = 1,
                        Period = "1 день",
                        SelectedPeriod = false
                    };
                    DataBaseModel.PaymentAndPeriod paymentAndPeriod2 = new DataBaseModel.PaymentAndPeriod()
                    {
                        ID = 2,
                        Period = "7 дней",
                        SelectedPeriod = false
                    };
                    DataBaseModel.PaymentAndPeriod paymentAndPeriod3 = new DataBaseModel.PaymentAndPeriod()
                    {
                        ID = 3,
                        Period = "Месяц",
                        SelectedPeriod = false
                    };
                    dataBase.PaymentAndPeriods.Add(paymentAndPeriod1);
                    dataBase.PaymentAndPeriods.Add(paymentAndPeriod2);
                    dataBase.PaymentAndPeriods.Add(paymentAndPeriod3);
                }
                if(dataBase.Payments.FirstOrDefault() == null)
                {
                    DataBaseModel.Payment payment = new DataBaseModel.Payment()
                    {
                        ID = 1,
                        Amount = 0
                    };
                    dataBase.Payments.Add(payment);
                }
                dataBase.SaveChanges();
            }
            MessageBox.Show("Инициализация завершилась!");
        }
        private void AddAllItems()
        {
            using (DataBaseModel dataBase = new DataBaseModel())
            {
                foreach (DataBaseModel.PaymentAndPeriod paymentAndPeriod in dataBase.PaymentAndPeriods)
                {
                    var periodItem = new PeriodItems() { ID = paymentAndPeriod.ID, Name = paymentAndPeriod.Period };
                    _periodItems.Add(periodItem);
                    if(paymentAndPeriod.SelectedPeriod == true)
                        SelectedPeriodItems = periodItem;

                }
                DataBaseModel.Payment payment = dataBase.Payments.First();
                PaymentAmount = payment.Amount;
            }
        }
        private void SaveMethod()
        {
            using (DataBaseModel dataBase = new DataBaseModel())
            {
                foreach(DataBaseModel.PaymentAndPeriod paymentAndPeriod in dataBase.PaymentAndPeriods)
                {
                    if (paymentAndPeriod.Period == _selectedPeriodItems.Name)
                    {
                        paymentAndPeriod.SelectedPeriod = true;
                        dataBase.PaymentAndPeriods.Update(paymentAndPeriod);
                    }
                }
                foreach(DataBaseModel.Payment payment in dataBase.Payments)
                {
                    if(payment.ID == 1)
                    {
                        payment.Amount = _paymentAmount;
                        dataBase.Payments.Update(payment);
                    }
                }
                dataBase.SaveChanges();
                MessageBox.Show("Данные сохранены!");
            }
        }
        public List<PeriodItems> PeriodItems
        {
            get { return _periodItems; }
        }
        private void ConfigureValidationRules()
        {
            Validator.AddRequiredRule(() => PaymentAmount, "Сумма оплаты обязательно");
            Validator.AddRequiredRule(() => SelectedPeriodItems, "Период обязательно");
        }
        private async void Validate()
        {
            await ValidateAsync();
        }
        private async Task ValidateAsync()
        {
            var result = await Validator.ValidateAllAsync();

            UpdateValidationSummary(result);
        }
        private void OnValidationResultChanged(object sender, ValidationResultChangedEventArgs e)
        {
            if (!IsValid.GetValueOrDefault(true))
            {
                ValidationResult validationResult = Validator.GetResult();

                UpdateValidationSummary(validationResult);
            }
        }
        private void UpdateValidationSummary(ValidationResult validationResult)
        {
            IsValid = validationResult.IsValid;
            ValidationErrorsString = validationResult.ToString();
        }
        public IEnumerable GetErrors(string propertyName)
        {
            return NotifyDataErrorInfoAdapter.GetErrors(propertyName);
        }
        public bool HasErrors
        {
            get { return NotifyDataErrorInfoAdapter.HasErrors; }
        }
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged
        {
            add { NotifyDataErrorInfoAdapter.ErrorsChanged += value; }
            remove { NotifyDataErrorInfoAdapter.ErrorsChanged -= value; }
        }
    }
    internal class PeriodItems
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
