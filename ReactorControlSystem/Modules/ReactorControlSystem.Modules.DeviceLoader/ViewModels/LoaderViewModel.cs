using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using ReactorControlSystem.Core.Enums;
using ReactorControlSystem.Devices;
using ReactorControlSystem.Repositories.Models;

namespace ReactorControlSystem.Modules.DeviceLoader.ViewModels
{
    public class LoaderViewModel : BindableBase, IDialogAware
    {
        public string Title => "硬件加载";
        private readonly DevicesManager _devicesManager;

        private string _successMessage = string.Empty;
        public string SuccessMessage
        {
            get { return _successMessage; }
            set { SetProperty(ref _successMessage, value); }
        }

        private string _errorMessage = string.Empty;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { SetProperty(ref _errorMessage, value); }
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set { SetProperty(ref _isLoading, value); }
        }

        private DelegateCommand _skipLoadCommand;
        public DelegateCommand SkipLoadCommand =>
            _skipLoadCommand ??= new DelegateCommand(SkipLoad, CanRetryLoad).ObservesProperty(
                () => IsLoading
            );

        private DelegateCommand _retryLoadCommand;

        public DelegateCommand RetryLoadCommand =>
            _retryLoadCommand ??= new DelegateCommand(RetryLoad, CanRetryLoad).ObservesProperty(
                () => IsLoading
            );

        public event Action<IDialogResult> RequestClose;

        public LoaderViewModel(DevicesManager devicesManager)
        {
            _devicesManager = devicesManager;
        }

        private async Task LoadDevices()
        {
            SuccessMessage = "正在加载设备...";
            IsLoading = true;

            List<Device> devices = await _devicesManager.InitializeAllAsync();

            if (devices.All(device => device != null && device.Status == DeviceStatus.Connected))
            {
                RequestClose.Invoke(new DialogResult(ButtonResult.OK));
                return;
            }

            IsLoading = false;

            ShowLoadResult(devices);
        }

        private void ShowLoadResult(List<Device> devices)
        {
            SuccessMessage = string.Empty;
            ErrorMessage = string.Empty;

            if (devices.All(device => device == null))
            {
                ErrorMessage = "暂未设置初始化设备";
                return;
            }

            var successDeviceNames = devices
                .Where(device => device != null && device.Status == DeviceStatus.Connected)
                .Select(device => device.Name)
                .ToList();

            var errorDeviceNames = devices
                .Where(device => device != null && device.Status == DeviceStatus.Error)
                .Select(device => device.Name)
                .ToList();

            if (successDeviceNames.Any())
            {
                SuccessMessage = $"{string.Join(',', successDeviceNames)} 加载成功";
            }

            if (errorDeviceNames.Any())
            {
                ErrorMessage = $"{string.Join(',', errorDeviceNames)} 加载失败";
            }
        }

        private void SkipLoad()
        {
            RequestClose.Invoke(new DialogResult(ButtonResult.OK));
        }

        private async void RetryLoad()
        {
            SuccessMessage = string.Empty;
            ErrorMessage = string.Empty;
            _devicesManager.DisconnectAll();
            await LoadDevices();
        }

        private bool CanRetryLoad()
        {
            return !IsLoading;
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed() { }

        public void OnDialogOpened(IDialogParameters parameters) { }
    }
}
