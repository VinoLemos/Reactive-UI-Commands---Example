using System.Dynamic;

namespace Reactive_UI_Commands.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public ReactiveUiCommandsViewModel ReactiveViewModel { get; } = new ReactiveUiCommandsViewModel();
    }
}
