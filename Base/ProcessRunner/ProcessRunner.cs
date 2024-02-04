using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.ProcessRunner
{
    public class ProcessRunner : IProcessRunner
    {
        public string? RunProcess(string fileName, string arguments)
        {
            try
            {
                ProcessStartInfo startInfo = new()
                {
                    FileName = fileName,
                    Arguments = arguments,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                };

                Process process = new() { StartInfo = startInfo };
                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                return output;
            }
            catch
            {
                return null;
            }
        }

        public async Task<string?> RunProcessAsync(string fileName, string arguments)
        {
            try
            {
                ProcessStartInfo startInfo = new()
                {
                    FileName = fileName,
                    Arguments = arguments,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                };

                Process process = new() { StartInfo = startInfo };
                process.Start();

                string output = await process.StandardOutput.ReadToEndAsync();
                await process.WaitForExitAsync();

                return output;
            }
            catch
            {
                return null;
            }
        }
    }
}
