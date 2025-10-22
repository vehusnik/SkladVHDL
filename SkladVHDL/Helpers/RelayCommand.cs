using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SkladVHDL.Helpers
{
    internal class RelayCommand : ICommand
    {
        // Delegát s "tělem" příkazu (co se má udělat)
        private readonly Action<object?> _execute;

        // Delegát vracející true/false (kdy je příkaz povolený); může být null → pak je vždy povolený
        private readonly Predicate<object?>? _canExecute;

        // Konstruktor – předáš "co dělat" a volitelně "kdy povolit"
        public RelayCommand(Action<object?> execute, Predicate<object?>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute)); // ochrana: execute nesmí být null
            _canExecute = canExecute;                                              // canExecute může být null (→ vždy true)
        }

        // Událost, kterou WPF sleduje. Když se vyvolá, WPF znovu zavolá CanExecute
        // My ji nepřivoláváme ručně – připojujeme/odpojujeme se na CommandManager.RequerySuggested,
        // který WPF vyvolává při změnách ve fókusování, vstupu apod.
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }   // napojení na globální událost WPF
            remove { CommandManager.RequerySuggested -= value; } // odpojení – brání únikům paměti
        }

        // Vrací true/false podle _canExecute; když není dodán (null), default je true
        public bool CanExecute(object? parameter) => _canExecute?.Invoke(parameter) ?? true;

        // Provede akci – to je "tělo" příkazu (např. volání metody ve ViewModelu)
        public void Execute(object? parameter) => _execute(parameter);
    }
}
