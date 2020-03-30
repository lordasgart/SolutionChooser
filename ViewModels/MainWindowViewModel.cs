using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Windows.Input;
using Microsoft.Extensions.Options;
using Prism.Commands;
using SolutionChooser.Interfaces;
using SolutionChooser.Options;
using SolutionChooser.Services;

namespace SolutionChooser.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {
        private readonly ISolutionChooserService _solutionChooserService;
        private readonly IOptions<SolutionChooserOptions> _solutionChooserOptions;

        public ICommand OpenSolutionCommand { get; set; }

        private string _selectedSolution;

        public string SelectedSolution
        {
            get => _selectedSolution;
            set => SetProperty(ref _selectedSolution, value);
        }

        private ObservableCollection<string> _solutions;

        public ObservableCollection<string> Solutions
        {
            get => _solutions;
            set => SetProperty(ref _solutions, value);
        }

        private string _directory;

        public string Directory
        {
            get => _directory;
            set => SetProperty(ref _directory, value);
        }

        public MainWindowViewModel(ISolutionChooserService solutionChooserService, IOptions<SolutionChooserOptions> solutionChooserOptions)
        {
            _solutionChooserService = solutionChooserService;
            _solutionChooserOptions = solutionChooserOptions;

            OpenSolutionCommand = new DelegateCommand(OpenSolution, CanOpenSolution);

            Solutions = new ObservableCollection<string>(_solutionChooserService.GetSolutions());

            SelectedSolution = Solutions.FirstOrDefault();

            Directory = solutionChooserOptions.Value.Directory;
        }

        private bool CanOpenSolution()
        {
            return true;
        }

        private void OpenSolution()
        {
            Process.Start(_solutionChooserOptions.Value.VisualStudioPath.Replace("\"",""), SelectedSolution);
        }
    }
}
