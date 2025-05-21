using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Reactive_UI_Commands.ViewModels
{
    public class ReactiveUiCommandsViewModel : ReactiveObject
    {
        private string? _RobotName;
        public ObservableCollection<string> ConversationLog { get; } = new ObservableCollection<string>();
        public ICommand OpenThePodBayDoorDirectCommand { get; }
        public ICommand OpenThePodBayDoorsFellowRobotCommand { get; }
        public ICommand OpenThePodBayDoorsAsyncCommand { get; }

        public ReactiveUiCommandsViewModel()
        {
            // Inicializando comandos
            OpenThePodBayDoorDirectCommand = ReactiveCommand.Create(OpenThePodBayDoors);

            // Observador que irá chamar o comando caso RobotName seja diferente de nulo
            IObservable<bool> canExecuteFellowRobotCommand = this.WhenAnyValue(vm => vm.RobotName, (name) => !string.IsNullOrEmpty(name));
            // A tipagem entre <> define qual o tipo de parâmetro esperado pelo comando
            OpenThePodBayDoorsFellowRobotCommand = ReactiveCommand.Create<string?>(name => OpenThePodBayDoorsFellowRobot(name), canExecuteFellowRobotCommand);

            OpenThePodBayDoorsAsyncCommand = ReactiveCommand.CreateFromTask(OpenThePodBayDoorsAsync);
        }

        public string? RobotName
        {
            get => _RobotName;
            set => this.RaiseAndSetIfChanged(ref _RobotName, value);
        }

        private void AddtoConvo(string content)
        {
            ConversationLog.Add(content);
        }

        private void OpenThePodBayDoors()
        {
            ConversationLog.Clear();
            AddtoConvo("I'm sorry, Dave, I'm afarid I can't do that.");
        }

        private void OpenThePodBayDoorsFellowRobot(string? robotName)
        {
            ConversationLog.Clear();
            AddtoConvo($"Hello {robotName}, the Pod Bay is open :-)");
        }

        private async Task OpenThePodBayDoorsAsync()
        {
            ConversationLog.Clear();
            AddtoConvo("Preparing to open the Pod Bay...");
            await Task.Delay(1000);

            AddtoConvo("Depressurizing Airlock...");
            await Task.Delay(2000);

            AddtoConvo("Retracting blast doors...");
            await Task.Delay(1000);

            AddtoConvo("Pod Bay is open to space!");
        }
    }
}
