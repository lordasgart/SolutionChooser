using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Options;
using SolutionChooser.Interfaces;
using SolutionChooser.Options;

namespace SolutionChooser.Services
{
    public class SolutionChooserService : ISolutionChooserService
    {
        private readonly IOptions<SolutionChooserOptions> _solutionChooserOptions;

        public SolutionChooserService(IOptions<SolutionChooserOptions> solutionChooserOptions)
        {
            _solutionChooserOptions = solutionChooserOptions;
        }

        public IEnumerable<string> GetSolutions()
        {
            return Directory.GetFiles(_solutionChooserOptions.Value.Directory, "*.sln", SearchOption.AllDirectories);
        }
    }
}
