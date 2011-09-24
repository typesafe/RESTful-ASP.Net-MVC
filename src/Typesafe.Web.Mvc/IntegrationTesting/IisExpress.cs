using System;
using System.Diagnostics;
using System.IO;

namespace Typesafe.Web.Mvc.IntegrationTesting
{
	public class IisExpress : IDisposable
	{
		private readonly Process process;

		public IisExpress(string physicalPath, int port)
		{
			if (!Directory.Exists(physicalPath))
				throw new DirectoryNotFoundException(string.Format("The web site path ('{0}') does not exist. Did you provide an incorrect path?", physicalPath));

			var iisExpressExe = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "IIS Express\\iisexpress.exe");

			if(!File.Exists(iisExpressExe))
				throw new FileNotFoundException(string.Format("The IISExpress executable ('{0}') could not be found. Please installe IIS Express first.", iisExpressExe));

			var psi = new ProcessStartInfo
			{
				FileName = iisExpressExe,
				Arguments = string.Format("/path:\"{0}\" /port:{1} /clr:4.0 /systray:false", physicalPath, port),

				UseShellExecute = false, 
				RedirectStandardError = true, 
				CreateNoWindow = true
			};

			process = new Process {StartInfo = psi };
			process.OutputDataReceived += (o, e) => Console.Write(e.Data);
			
			process.Start();
		}

		~IisExpress()
		{
			Dispose(false);
		}

		public void Stop()
		{
			process.Kill(); // The following should, but doesn't, do it : process.StandardInput.Write("Q");
			process.WaitForExit();
		}

		public void Dispose()
		{
			Dispose(true);
		}

		private void Dispose(bool disposing)
		{
			if (disposing) GC.SuppressFinalize(this);

			Stop();
		}
	}
}