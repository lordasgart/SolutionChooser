using System;
using System.Collections.Generic;
using System.Text;

namespace SolutionChooser.Interfaces
{
    public interface ISolutionChooserService
    {
        IEnumerable<string> GetSolutions();
    }
}
