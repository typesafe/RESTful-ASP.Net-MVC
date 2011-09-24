using System;
using System.Diagnostics;
using System.IO;

namespace Typesafe.Web.Mvc.IntegrationTesting
{
	internal class WebServer : IDisposable
	{
		private readonly Process process;

		public WebServer(string physicalPath, int port)
		{
			var psi = new ProcessStartInfo
			{
				FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "IIS Express\\iisexpress.exe"),
				Arguments = string.Format("/path:\"{0}\" /port:{1} /clr:4.0 /systray:false", physicalPath, port),

				UseShellExecute = false, 
				RedirectStandardError = true, 
				CreateNoWindow = true
			};

			process = new Process {StartInfo = psi };
			process.OutputDataReceived += (o, e) => Console.Write(e.Data);
			
			process.Start();
		}

		~WebServer()
		{
			Dispose(false);
		}

		public void Stop()
		{
			//process.StandardInput.Write("Q");
			process.Kill();
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