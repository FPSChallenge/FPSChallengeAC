using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace FPSAC
{
	// Token: 0x0200000A RID: 10
	public class AutoUpdater : Window, IComponentConnector
	{
		// Token: 0x06000046 RID: 70 RVA: 0x0000327F File Offset: 0x0000147F
		[CompilerGenerated]
		public string 슟()
		{
			return this.슟;
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00003287 File Offset: 0x00001487
		[CompilerGenerated]
		public void 슟(string A_1)
		{
			this.슟 = A_1;
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00006378 File Offset: 0x00004578
		public AutoUpdater()
		{
			this.InitializeComponent();
			base.WindowStartupLocation = WindowStartupLocation.CenterScreen;
			this.슟(Directory.GetCurrentDirectory() + "\\update");
			if (!Directory.Exists(this.슟()))
			{
				Directory.CreateDirectory(this.슟());
			}
			this.슖();
		}

		// Token: 0x06000049 RID: 73 RVA: 0x0000318C File Offset: 0x0000138C
		private void 슟(object A_1, MouseButtonEventArgs A_2)
		{
			if (A_2.ChangedButton == MouseButton.Left)
			{
				base.DragMove();
			}
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00003290 File Offset: 0x00001490
		private void 슖()
		{
			new Thread(new ThreadStart(this.DownloadAndExecuteUpdate)).Start();
		}

		// Token: 0x0600004B RID: 75 RVA: 0x000063CC File Offset: 0x000045CC
		private void 슟(object A_1, DownloadProgressChangedEventArgs A_2)
		{
			AutoUpdater.슖 슖 = new AutoUpdater.슖();
			슖.슟 = A_2;
			슖.슟 = this;
			base.Dispatcher.Invoke(new Action(슖.슟));
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00006404 File Offset: 0x00004604
		private void 슟(object A_1, AsyncCompletedEventArgs A_2)
		{
			string fileName = this.슟() + "\\FPSCACInstaller.msi";
			new Process
			{
				StartInfo = new ProcessStartInfo(fileName)
				{
					UseShellExecute = true
				}
			}.Start();
			base.Dispatcher.Invoke(new Action(AutoUpdater.슟.슟.슟));
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00003200 File Offset: 0x00001400
		private void 슟(object A_1, RoutedEventArgs A_2)
		{
			base.Close();
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00003208 File Offset: 0x00001408
		private void 슖(object A_1, RoutedEventArgs A_2)
		{
			base.WindowState = WindowState.Minimized;
		}

		// Token: 0x0600004F RID: 79 RVA: 0x0000646C File Offset: 0x0000466C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.5.0")]
		public void InitializeComponent()
		{
			if (this.슟)
			{
				return;
			}
			this.슟 = true;
			Uri resourceLocator = new Uri("/FPSChallenge Anticheat;V3.0.2.0;component/screens/updatewindow.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000050 RID: 80 RVA: 0x0000649C File Offset: 0x0000469C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.5.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.슟(int A_1, object A_2)
		{
			switch (A_1)
			{
			case 1:
				((AutoUpdater)A_2).MouseDown += this.슟;
				return;
			case 2:
				this.슟 = (Button)A_2;
				this.슟.Click += this.슟;
				return;
			case 3:
				this.슖 = (Button)A_2;
				this.슖.Click += this.슖;
				return;
			case 4:
				this.슟 = (TextBlock)A_2;
				return;
			case 5:
				this.슟 = (Label)A_2;
				return;
			case 6:
				this.슟 = (ProgressBar)A_2;
				return;
			default:
				this.슟 = true;
				return;
			}
		}

		// Token: 0x06000051 RID: 81 RVA: 0x0000655C File Offset: 0x0000475C
		[CompilerGenerated]
		private void DownloadAndExecuteUpdate()
		{
			try
			{
				WebClient webClient = new WebClient();
				webClient.DownloadProgressChanged += this.슟;
				webClient.DownloadFileCompleted += this.슟;
				webClient.DownloadFileAsync(new Uri("https://dl.fpschallenge.eu/anticheat/FPSCACInstaller.msi"), this.슟() + "\\\\FPSCACInstaller.msi");
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x04000024 RID: 36
		[CompilerGenerated]
		private string 슟;

		// Token: 0x04000025 RID: 37
		internal Button 슟;

		// Token: 0x04000026 RID: 38
		internal Button 슖;

		// Token: 0x04000027 RID: 39
		internal TextBlock 슟;

		// Token: 0x04000028 RID: 40
		internal Label 슟;

		// Token: 0x04000029 RID: 41
		internal ProgressBar 슟;

		// Token: 0x0400002A RID: 42
		private bool 슟;

		// Token: 0x0200000B RID: 11
		[CompilerGenerated]
		[Serializable]
		private sealed class 슟
		{
			// Token: 0x06000054 RID: 84 RVA: 0x000032B4 File Offset: 0x000014B4
			internal void 슟()
			{
				Application.Current.Shutdown();
			}

			// Token: 0x0400002B RID: 43
			public static readonly AutoUpdater.슟 슟 = new AutoUpdater.슟();

			// Token: 0x0400002C RID: 44
			public static Action 슟;
		}

		// Token: 0x0200000C RID: 12
		[CompilerGenerated]
		private sealed class 슖
		{
			// Token: 0x06000056 RID: 86 RVA: 0x000065C8 File Offset: 0x000047C8
			internal void 슟()
			{
				double num = double.Parse(this.슟.BytesReceived.ToString());
				double num2 = double.Parse(this.슟.TotalBytesToReceive.ToString());
				double d = num / num2 * 100.0;
				this.슟.슟.Text = string.Concat(new string[]
				{
					"Downloading update: kb ",
					(this.슟.BytesReceived / 1000L).ToString(),
					" of ",
					(this.슟.TotalBytesToReceive / 1000L).ToString(),
					" kb"
				});
				this.슟.슟.Value = (double)int.Parse(Math.Truncate(d).ToString());
			}

			// Token: 0x0400002D RID: 45
			public DownloadProgressChangedEventArgs 슟;

			// Token: 0x0400002E RID: 46
			public AutoUpdater 슟;
		}
	}
}
