using System;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace ReactorControlSystem.Modules.HardwareLoader.ViewModels
{
    public class LoaderViewModel : BindableBase, IDialogAware
    {
        public string Title => "硬件加载";

        private string _message = string.Empty;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set { SetProperty(ref _isLoading, value); }
        }

        private DelegateCommand _skipLoadCommand;
        public DelegateCommand SkipLoadCommand =>
            _skipLoadCommand ??= new DelegateCommand(SkipLoad, CanRetryLoad).ObservesProperty(() => IsLoading);

        private DelegateCommand _retryLoadCommand;
        public DelegateCommand RetryLoadCommand =>
            _retryLoadCommand ??= new DelegateCommand(RetryLoad, CanRetryLoad).ObservesProperty(() => IsLoading);

        public event Action<IDialogResult> RequestClose;

        public LoaderViewModel()
        {
            LoadHardwares();
        }

        private async void LoadHardwares()
        {
            Message = "正在加载硬件...";
            IsLoading = true;

            // todo: 加载硬件
            await Task.Delay(2000);

            IsLoading = false;
            Message = "硬件加载失败";
        }

        private void SkipLoad()
        {
            RequestClose.Invoke(new DialogResult(ButtonResult.OK));
        }

        private void RetryLoad()
        {
            LoadHardwares();
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
