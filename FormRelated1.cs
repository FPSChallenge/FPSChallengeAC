using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using FPSCAnticheat.Shared.DTO;
using Microsoft.Win32;
using PFSCAnticheat.Interfaces;
using PFSCAnticheat.SettingsNameSpace;

namespace FPSAC
{
	// Token: 0x02000009 RID: 9
	public class FormRelated1 : Window, IComponentConnector
	{
		// Token: 0x06000022 RID: 34 RVA: 0x00005988 File Offset: 0x00003B88
		[CompilerGenerated]
		public void 슟(EventHandler A_1)
		{
			EventHandler eventHandler = this.슟;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value = (EventHandler)Delegate.Combine(eventHandler2, A_1);
				eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.슟, value, eventHandler2);
			}
			while (eventHandler != eventHandler2);
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000059C0 File Offset: 0x00003BC0
		[CompilerGenerated]
		public void 슖(EventHandler A_1)
		{
			EventHandler eventHandler = this.슟;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value = (EventHandler)Delegate.Remove(eventHandler2, A_1);
				eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.슟, value, eventHandler2);
			}
			while (eventHandler != eventHandler2);
		}

		// Token: 0x06000024 RID: 36 RVA: 0x000059F8 File Offset: 0x00003BF8
		[CompilerGenerated]
		public void 슺(EventHandler A_1)
		{
			EventHandler eventHandler = this.슖;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value = (EventHandler)Delegate.Combine(eventHandler2, A_1);
				eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.슖, value, eventHandler2);
			}
			while (eventHandler != eventHandler2);
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00005A30 File Offset: 0x00003C30
		[CompilerGenerated]
		public void 슎(EventHandler A_1)
		{
			EventHandler eventHandler = this.슖;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value = (EventHandler)Delegate.Remove(eventHandler2, A_1);
				eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.슖, value, eventHandler2);
			}
			while (eventHandler != eventHandler2);
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00005A68 File Offset: 0x00003C68
		public FormRelated1()
		{
			this.InitializeComponent();
			this.식();
			this.슇.Visibility = Visibility.Hidden;
			this.슮.Visibility = Visibility.Hidden;
			this.슠.Visibility = Visibility.Hidden;
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00005AD8 File Offset: 0x00003CD8
		public FormRelated1(싶 A_1, ISettings A_2, AuthenticationLoginMainInterface A_3, EventHandler A_4) : this()
		{
			base.WindowStartupLocation = WindowStartupLocation.CenterScreen;
			this.슟 = A_4;
			this.슟 = A_1;
			this.슟 = A_2;
			this.슟 = A_3;
			LoginDataDTO loginDataDTO = this.슟.슖();
			this.슟.Content = loginDataDTO.Username;
			this.슟 = A_2.GetCurrentSettings();
			this.슺(null);
			this.슮();
			VersionDTO versionDTO = this.슟.슎();
			if (!versionDTO.Success)
			{
				if (versionDTO.Banned)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(51, 5);
					defaultInterpolatedStringHandler.AppendLiteral("You have been banned! ");
					defaultInterpolatedStringHandler.AppendFormatted(Environment.NewLine);
					defaultInterpolatedStringHandler.AppendLiteral("Reason: ");
					defaultInterpolatedStringHandler.AppendFormatted(versionDTO.BanReason);
					defaultInterpolatedStringHandler.AppendLiteral(" ");
					defaultInterpolatedStringHandler.AppendFormatted(Environment.NewLine);
					defaultInterpolatedStringHandler.AppendFormatted(Environment.NewLine);
					defaultInterpolatedStringHandler.AppendLiteral("Ban will expire on: ");
					defaultInterpolatedStringHandler.AppendFormatted(versionDTO.BanExpireDate.ToShortDateString());
					MessageBox.Show(defaultInterpolatedStringHandler.ToStringAndClear(), "Banned", MessageBoxButton.OK, MessageBoxImage.Hand);
					Application.Current.Shutdown();
				}
				else if (versionDTO.Logout)
				{
					this.슟.슺();
					this.싓();
					return;
				}
			}
			this.슖.Content = "Version: " + ((versionDTO != null) ? versionDTO.VersionNumber : null);
			string a = VersionAndHashing.슟.Trim();
			string versionGuid = versionDTO.VersionGuid;
			if (a != ((versionGuid != null) ? versionGuid.Trim() : null))
			{
				this.슟();
			}
			if (!this.슟.슖())
			{
				this.슇();
			}
			A_1.슟(new EventHandler(this.슟));
			base.Closing += A_1.슟;
			base.Loaded += this.슟;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x0000305C File Offset: 0x0000125C
		private void 슟(object A_1, RoutedEventArgs A_2)
		{
			new Thread(new ThreadStart(this.슭)).Start();
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00005CB8 File Offset: 0x00003EB8
		private void 슖(object A_1, RoutedEventArgs A_2)
		{
			this.슆();
			long num = 0L;
			if (string.IsNullOrEmpty(this.슖.Text) || !long.TryParse(this.슖.Text, out num))
			{
				this.슎();
				return;
			}
			Tuple<bool, string> tuple = this.슟.슟(this.슟.Text, this.슟.SelectedGame, this.슺.Text, num);
			if (tuple.Item1)
			{
				this.슟(tuple.Item2);
				return;
			}
			if (tuple.Item2 == "Update")
			{
				this.슟();
			}
			if (tuple.Item2 == "MediaServices")
			{
				this.슖();
			}
			if (tuple.Item2 == "cplus")
			{
				this.슺();
				return;
			}
			this.슖(tuple.Item2);
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00003074 File Offset: 0x00001274
		private void 슟()
		{
			this.슠();
			this.슟.IsEnabled = false;
			this.슖.IsEnabled = false;
			this.슇.Visibility = Visibility.Visible;
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00005D94 File Offset: 0x00003F94
		public void 슖()
		{
			this.슟.Text = "You need to enable media features in windows: start menu -> settings -> apps -> optional features -> more windows features (at the bottom) -> Media features -> press ok";
			this.슟.Foreground = new SolidColorBrush(Colors.Red);
			this.슟.IsEnabled = false;
			this.슖.IsEnabled = false;
			this.슮.Visibility = Visibility.Visible;
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00005DEC File Offset: 0x00003FEC
		public void 슺()
		{
			this.슟.Text = "You need to install Microsoft Visual C++ Redistributable (x86)";
			this.슟.Foreground = new SolidColorBrush(Colors.Red);
			this.슟.IsEnabled = false;
			this.슖.IsEnabled = false;
			this.슠.Visibility = Visibility.Visible;
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000030A0 File Offset: 0x000012A0
		private void 슟(object A_1, EventArgs A_2)
		{
			base.Dispatcher.Invoke(new Action(this.슗));
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00005E44 File Offset: 0x00004044
		private void 슎()
		{
			Brush borderBrush = new SolidColorBrush(Colors.Red);
			this.슖.BorderBrush = borderBrush;
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00005E68 File Offset: 0x00004068
		private void 슆()
		{
			Brush borderBrush = new SolidColorBrush(Colors.White);
			this.슖.BorderBrush = borderBrush;
		}

		// Token: 0x06000030 RID: 48 RVA: 0x000030B9 File Offset: 0x000012B9
		private void 슇()
		{
			this.슖.Text = "Since you are using Windows 7 or lower, you must turn off AA, or upgrade to Windows 10 for the Anticheat to support your OS. (else the game will be closed)";
			this.슖.Foreground = new SolidColorBrush(Colors.Red);
		}

		// Token: 0x06000031 RID: 49 RVA: 0x000030E0 File Offset: 0x000012E0
		private void 슮()
		{
			this.슟.Text = "Anti cheat is NOT running.";
			this.슟.Foreground = new SolidColorBrush(Colors.Red);
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00003107 File Offset: 0x00001307
		private void 슠()
		{
			this.슟.Text = "Update your anticheat before you can play a match.";
			this.슟.Foreground = new SolidColorBrush(Colors.Red);
		}

		// Token: 0x06000033 RID: 51 RVA: 0x0000312E File Offset: 0x0000132E
		private void 슟(string A_1)
		{
			this.슟.IsEnabled = false;
			this.슖.IsEnabled = false;
			this.슟.Text = A_1;
			this.슟.Foreground = new SolidColorBrush(Colors.Green);
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00003169 File Offset: 0x00001369
		private void 슖(string A_1)
		{
			this.슟.Text = A_1;
			this.슟.Foreground = new SolidColorBrush(Colors.Red);
		}

		// Token: 0x06000035 RID: 53 RVA: 0x0000318C File Offset: 0x0000138C
		private void 슟(object A_1, MouseButtonEventArgs A_2)
		{
			if (A_2.ChangedButton == MouseButton.Left)
			{
				base.DragMove();
			}
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00005E8C File Offset: 0x0000408C
		private void 슺(object A_1, RoutedEventArgs A_2)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			bool? flag = openFileDialog.ShowDialog();
			bool flag2 = true;
			if (flag.GetValueOrDefault() == flag2 & flag != null)
			{
				this.슟.Text = openFileDialog.FileName;
				this.슺(openFileDialog.FileName);
				this.슟.SaveSettings(this.슟);
			}
		}

		// Token: 0x06000037 RID: 55 RVA: 0x0000319C File Offset: 0x0000139C
		private void 슎(object A_1, RoutedEventArgs A_2)
		{
			this.슔();
		}

		// Token: 0x06000038 RID: 56 RVA: 0x000031A4 File Offset: 0x000013A4
		private void 싓()
		{
			if (this.슟 != null)
			{
				this.슟 = true;
				this.슟(this, EventArgs.Empty);
				base.Close();
			}
		}

		// Token: 0x06000039 RID: 57 RVA: 0x000031CC File Offset: 0x000013CC
		private void 슔()
		{
			if (this.슖 != null)
			{
				this.슖(this, EventArgs.Empty);
				base.Close();
			}
		}

		// Token: 0x0600003A RID: 58 RVA: 0x000031ED File Offset: 0x000013ED
		private void 슆(object A_1, RoutedEventArgs A_2)
		{
			this.슟.슺();
			this.싓();
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00003200 File Offset: 0x00001400
		private void 슇(object A_1, RoutedEventArgs A_2)
		{
			base.Close();
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00003208 File Offset: 0x00001408
		private void 슮(object A_1, RoutedEventArgs A_2)
		{
			base.WindowState = WindowState.Minimized;
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00005EEC File Offset: 0x000040EC
		private void 식()
		{
			foreach (string newItem in this.슟)
			{
				this.슟.Items.Add(newItem);
			}
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00003211 File Offset: 0x00001411
		private void 슟(object A_1, SelectionChangedEventArgs A_2)
		{
			this.슟.SelectedGame = A_2.AddedItems[0].ToString();
			this.슺(null);
			this.슟.SaveSettings(this.슟);
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00005F24 File Offset: 0x00004124
		public void 슺(string A_1)
		{
			if (A_1 == null)
			{
				string selectedGame = this.슟.SelectedGame;
				if (!(selectedGame == "Call of Duty 4"))
				{
					if (!(selectedGame == "Call of Duty 2"))
					{
						if (!(selectedGame == "Call of Duty 1"))
						{
							if (selectedGame == "Call of Duty 1 UO")
							{
								this.슟.Text = this.슟.Installationpathcod1UO;
							}
						}
						else
						{
							this.슟.Text = this.슟.Installationpathcod1;
						}
					}
					else
					{
						this.슟.Text = this.슟.Installationpathcod2;
					}
				}
				else
				{
					this.슟.Text = this.슟.Installationpathcod4;
				}
				if (this.슟.SelectedGame == null)
				{
					this.슟.SelectedIndex = 0;
					return;
				}
				this.슟.SelectedItem = this.슟.SelectedGame;
				return;
			}
			else
			{
				string selectedGame = this.슟.SelectedGame;
				if (selectedGame == "Call of Duty 4")
				{
					this.슟.Installationpathcod4 = A_1;
					return;
				}
				if (selectedGame == "Call of Duty 2")
				{
					this.슟.Installationpathcod2 = A_1;
					return;
				}
				if (selectedGame == "Call of Duty 1")
				{
					this.슟.Installationpathcod1 = A_1;
					return;
				}
				if (!(selectedGame == "Call of Duty 1 UO"))
				{
					return;
				}
				this.슟.Installationpathcod1UO = A_1;
				return;
			}
		}

		// Token: 0x06000040 RID: 64 RVA: 0x0000607C File Offset: 0x0000427C
		private void 슠(object A_1, RoutedEventArgs A_2)
		{
			this.슮();
			this.슟.IsEnabled = true;
			this.슖.IsEnabled = true;
			this.슮.Visibility = Visibility.Hidden;
			string fileName = "https://support.microsoft.com/en-us/windows/media-feature-pack-for-windows-n-8622b390-4ce6-43c9-9b42-549e5328e407";
			Process.Start(new ProcessStartInfo
			{
				FileName = fileName,
				UseShellExecute = true
			});
		}

		// Token: 0x06000041 RID: 65 RVA: 0x000060D4 File Offset: 0x000042D4
		private void 싓(object A_1, RoutedEventArgs A_2)
		{
			this.슮();
			this.슟.IsEnabled = true;
			this.슖.IsEnabled = true;
			this.슠.Visibility = Visibility.Hidden;
			string fileName = "https://aka.ms/vs/17/release/vc_redist.x86.exe";
			Process.Start(new ProcessStartInfo
			{
				FileName = fileName,
				UseShellExecute = true
			});
		}

		// Token: 0x06000042 RID: 66 RVA: 0x0000612C File Offset: 0x0000432C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.5.0")]
		public void InitializeComponent()
		{
			if (this.슖)
			{
				return;
			}
			this.슖 = true;
			Uri resourceLocator = new Uri("/FPSChallenge Anticheat;V3.0.2.0;component/screens/mainwindow.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000043 RID: 67 RVA: 0x0000615C File Offset: 0x0000435C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.5.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.슟(int A_1, object A_2)
		{
			switch (A_1)
			{
			case 1:
				((FormRelated1)A_2).MouseDown += this.슟;
				return;
			case 2:
				this.슟 = (Button)A_2;
				this.슟.Click += this.슖;
				return;
			case 3:
				this.슟 = (TextBox)A_2;
				return;
			case 4:
				this.슖 = (TextBox)A_2;
				return;
			case 5:
				this.슟 = (TextBlock)A_2;
				return;
			case 6:
				this.슖 = (Button)A_2;
				this.슖.Click += this.슺;
				return;
			case 7:
				this.슺 = (Button)A_2;
				this.슺.Click += this.슇;
				return;
			case 8:
				this.슎 = (Button)A_2;
				this.슎.Click += this.슮;
				return;
			case 9:
				this.슟 = (Label)A_2;
				return;
			case 10:
				this.슆 = (Button)A_2;
				this.슆.Click += this.슆;
				return;
			case 11:
				this.슖 = (TextBlock)A_2;
				return;
			case 12:
				this.슖 = (Label)A_2;
				return;
			case 13:
				this.슇 = (Button)A_2;
				this.슇.Click += this.슎;
				return;
			case 14:
				this.슺 = (TextBox)A_2;
				return;
			case 15:
				this.슟 = (ComboBox)A_2;
				this.슟.SelectionChanged += this.슟;
				return;
			case 16:
				this.슮 = (Button)A_2;
				this.슮.Click += this.슠;
				return;
			case 17:
				this.슠 = (Button)A_2;
				this.슠.Click += this.싓;
				return;
			default:
				this.슖 = true;
				return;
			}
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00003247 File Offset: 0x00001447
		[CompilerGenerated]
		private void 슭()
		{
			this.슟.슟(this.슟.슟());
		}

		// Token: 0x06000045 RID: 69 RVA: 0x0000325F File Offset: 0x0000145F
		[CompilerGenerated]
		private void 슗()
		{
			this.슟.IsEnabled = true;
			this.슖.IsEnabled = true;
			this.슮();
		}

		// Token: 0x0400000B RID: 11
		[CompilerGenerated]
		private EventHandler 슟;

		// Token: 0x0400000C RID: 12
		[CompilerGenerated]
		private EventHandler 슖;

		// Token: 0x0400000D RID: 13
		private readonly 싶 슟;

		// Token: 0x0400000E RID: 14
		private readonly ISettings 슟;

		// Token: 0x0400000F RID: 15
		private readonly AuthenticationLoginMainInterface 슟;

		// Token: 0x04000010 RID: 16
		private Settings.SettingsObject 슟;

		// Token: 0x04000011 RID: 17
		public bool 슟;

		// Token: 0x04000012 RID: 18
		private readonly string[] 슟 = new string[]
		{
			"Call of Duty 4",
			"Call of Duty 2",
			"Call of Duty 1 UO",
			"Call of Duty 1"
		};

		// Token: 0x04000013 RID: 19
		internal Button 슟;

		// Token: 0x04000014 RID: 20
		internal TextBox 슟;

		// Token: 0x04000015 RID: 21
		internal TextBox 슖;

		// Token: 0x04000016 RID: 22
		internal TextBlock 슟;

		// Token: 0x04000017 RID: 23
		internal Button 슖;

		// Token: 0x04000018 RID: 24
		internal Button 슺;

		// Token: 0x04000019 RID: 25
		internal Button 슎;

		// Token: 0x0400001A RID: 26
		internal Label 슟;

		// Token: 0x0400001B RID: 27
		internal Button 슆;

		// Token: 0x0400001C RID: 28
		internal TextBlock 슖;

		// Token: 0x0400001D RID: 29
		internal Label 슖;

		// Token: 0x0400001E RID: 30
		internal Button 슇;

		// Token: 0x0400001F RID: 31
		internal TextBox 슺;

		// Token: 0x04000020 RID: 32
		internal ComboBox 슟;

		// Token: 0x04000021 RID: 33
		internal Button 슮;

		// Token: 0x04000022 RID: 34
		internal Button 슠;

		// Token: 0x04000023 RID: 35
		private bool 슖;
	}
}
