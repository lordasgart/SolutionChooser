using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            var solutions = Directory.GetFiles(_solutionChooserOptions.Value.Directory, "*.sln", SearchOption.AllDirectories);
            var csprojs = Directory.GetFiles(_solutionChooserOptions.Value.Directory, "*.csproj", SearchOption.AllDirectories);
            return !solutions.Any() ? csprojs : solutions;
        }
    }
}
