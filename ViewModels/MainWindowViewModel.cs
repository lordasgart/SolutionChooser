using System;
using System.Collections.Generic;
using System.Text;
using SolutionChooser.Interfaces;
using SolutionChooser.Services;

namespace SolutionChooser.ViewModels
{
    public class MainWindowViewModel : IMainWindowViewModel
    {
        private readonly ISolutionChooserService _solutionChooserService;

        public MainWindowViewModel(ISolutionChooserService solutionChooserService)
        {
            _solutionChooserService = solutionChooserService;
        }
    }
}
