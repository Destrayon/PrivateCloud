using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.ProcessRunner
{
    public interface IProcessRunner
    {
        string? RunProcess(string fileName, string arguments);

        Task<string?> RunProcessAsync(string fileName, string arguments);
    }
}
