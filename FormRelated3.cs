using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using FPSCAnticheat.Shared.DTO;

namespace FPSAC
{
	// Token: 0x0200005D RID: 93
	public class FormRelated3 : 싶
	{
		// Token: 0x060001EA RID: 490 RVA: 0x0000BB08 File Offset: 0x00009D08
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

		// Token: 0x060001EB RID: 491 RVA: 0x0000BB40 File Offset: 0x00009D40
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

		// Token: 0x060001EC RID: 492 RVA: 0x0000BB78 File Offset: 0x00009D78
		public FormRelated3(AC_ScreenshotInterface A_1, Authentication A_2, AC_BindDetectionInterface A_3, HWID_Interface A_4, 슚 A_5, 슻 A_6, 슱 A_7, 슼 A_8, AC_MainInterface A_9, 슲 A_10, 싚 A_11, AC_CvarCheckInterface A_12, AC_WeirdCvarCheckInterface A_13, AC_MemoryCheckInterface A_14, AC_ScreenRecordingInterface A_15)
		{
			this._AC_ScreenshotInterface = A_1;
			this.슟 = A_11;
			this._AC_BindDetectionInterface = A_3;
			this._HWID_Interface = A_4;
			this._AC_MainInterface = A_9;
			this.슟 = A_2;
			this.슟 = A_10;
			this.슟 = A_5;
			this.슟 = A_6;
			this.슟 = A_12;
			this.슟 = A_7;
			this.슟 = A_8;
			this.슟 = A_13;
			this.슟 = A_14;
			this._AC_ScreenRecordingInterface = A_15;
		}

		// Token: 0x060001ED RID: 493 RVA: 0x00003C8C File Offset: 0x00001E8C
		private void 슟(object A_1, EventArgs A_2)
		{
			this.someBoolean = false;
			if (!this.someBoolean)
			{
				this.슟.슖();
				this.슐();
			}
		}

		// Token: 0x060001EE RID: 494 RVA: 0x00003CAE File Offset: 0x00001EAE
		public bool 슖()
		{
			return this.슟.슖();
		}

		// Token: 0x060001EF RID: 495 RVA: 0x0000BD18 File Offset: 0x00009F18
		public Tuple<bool, string> 슟(string A_1, string A_2, string A_3, long A_4)
		{
			if (A_2 == "Call of Duty 4")
			{
				this.stringProcessName = "iw3mp";
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(19, 1);
				defaultInterpolatedStringHandler.AppendLiteral("; +set fps_matchid ");
				defaultInterpolatedStringHandler.AppendFormatted<long>(A_4);
				return this.슟(A_1, A_3 + defaultInterpolatedStringHandler.ToStringAndClear(), A_4);
			}
			if (A_2 == "Call of Duty 2")
			{
				this.stringProcessName = "CoD2MP_s";
				return this.슖(A_1, A_3, A_4);
			}
			if (A_2 == "Call of Duty 1")
			{
				this.stringProcessName = "CoDMP";
				return this.슺(A_1, A_3, A_4);
			}
			if (!(A_2 == "Call of Duty 1 UO"))
			{
				return new Tuple<bool, string>(false, "No game selected.");
			}
			this.stringProcessName = "CoDUOMP";
			return this.슎(A_1, A_3, A_4);
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x0000BDEC File Offset: 0x00009FEC
		private Tuple<bool, string> 슟(string A_1, string A_2, long A_3)
		{
			this.matchId = A_3;
			if (!File.Exists(A_1) || !A_1.Contains("iw3mp.exe"))
			{
				return new Tuple<bool, string>(false, "Game not found on the given path");
			}
			this.슖 = A_1;
			this.슟.슟(A_1);
			if (this.슟.슖())
			{
				if (!this.슟.슟())
				{
					return new Tuple<bool, string>(false, "MediaServices");
				}
				if (!this.슟.슖())
				{
					return new Tuple<bool, string>(false, "cplus");
				}
			}
			if (!A_2.Contains("connect") || !A_2.Contains("password") || string.IsNullOrEmpty(A_2))
			{
				return new Tuple<bool, string>(false, "Cant connect to this server. Add (connect ip; password password)");
			}
			VersionDTO versionDTO = this.슟.슺();
			if (versionDTO.VersionGuid.Trim() != VersionAndHashing.슟.Trim())
			{
				return new Tuple<bool, string>(false, "Update");
			}
			if (versionDTO.Banned)
			{
				bool item = false;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(52, 5);
				defaultInterpolatedStringHandler.AppendLiteral("You have been banned! Reason: ");
				defaultInterpolatedStringHandler.AppendFormatted(Environment.NewLine);
				defaultInterpolatedStringHandler.AppendLiteral(" ");
				defaultInterpolatedStringHandler.AppendFormatted(versionDTO.BanReason);
				defaultInterpolatedStringHandler.AppendLiteral(" ");
				defaultInterpolatedStringHandler.AppendFormatted(Environment.NewLine);
				defaultInterpolatedStringHandler.AppendFormatted(Environment.NewLine);
				defaultInterpolatedStringHandler.AppendLiteral("Ban will expire on: ");
				defaultInterpolatedStringHandler.AppendFormatted(versionDTO.BanExpireDate.ToShortDateString());
				return new Tuple<bool, string>(item, defaultInterpolatedStringHandler.ToStringAndClear());
			}
			if (!this.StartGameProcess(A_1, A_2))
			{
				return new Tuple<bool, string>(false, "Please close call of duty 4 before starting the anti cheat.");
			}
			if (this.IsGameAlreadyRunning(this.stringProcessName))
			{
				this.someBoolean = true;
				if (!this.슟.슖())
				{
					this.슆();
				}
				this.슇();
				if (this.슟.슖())
				{
					this.StartScreenshotThread();
					this.싓();
				}
				this.슠();
				this.슔();
				this.슭();
				this.식();
				this.슗();
				this.슲();
				this.슖("Call of Duty 4");
				this.슟.슟();
				return new Tuple<bool, string>(true, "Anti cheat is running." + Environment.NewLine + Environment.NewLine + "If you close this application or logout it will quit your game!");
			}
			return new Tuple<bool, string>(false, "Something went wrong.");
		}

		// Token: 0x060001F1 RID: 497 RVA: 0x0000C034 File Offset: 0x0000A234
		private Tuple<bool, string> 슖(string A_1, string A_2, long A_3)
		{
			this.matchId = A_3;
			if (!File.Exists(A_1) || !A_1.ToLower().Contains("cod2mp_s.exe"))
			{
				return new Tuple<bool, string>(false, "Game not found on the given path");
			}
			this.슖 = A_1;
			this.슟.슟(A_1);
			if (this.슟.슖())
			{
				if (!this.슟.슟())
				{
					return new Tuple<bool, string>(false, "MediaServices");
				}
				if (!this.슟.슖())
				{
					return new Tuple<bool, string>(false, "cplus");
				}
			}
			if (!A_2.Contains("connect") || !A_2.Contains("password") || string.IsNullOrEmpty(A_2))
			{
				return new Tuple<bool, string>(false, "Cant connect to this server. Add (connect ip; password password)");
			}
			VersionDTO versionDTO = this.슟.슺();
			if (versionDTO.VersionGuid.Trim() != VersionAndHashing.슟.Trim())
			{
				return new Tuple<bool, string>(false, "Update");
			}
			if (versionDTO.Banned)
			{
				bool item = false;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(52, 5);
				defaultInterpolatedStringHandler.AppendLiteral("You have been banned! Reason: ");
				defaultInterpolatedStringHandler.AppendFormatted(Environment.NewLine);
				defaultInterpolatedStringHandler.AppendLiteral(" ");
				defaultInterpolatedStringHandler.AppendFormatted(versionDTO.BanReason);
				defaultInterpolatedStringHandler.AppendLiteral(" ");
				defaultInterpolatedStringHandler.AppendFormatted(Environment.NewLine);
				defaultInterpolatedStringHandler.AppendFormatted(Environment.NewLine);
				defaultInterpolatedStringHandler.AppendLiteral("Ban will expire on: ");
				defaultInterpolatedStringHandler.AppendFormatted(versionDTO.BanExpireDate.ToShortDateString());
				return new Tuple<bool, string>(item, defaultInterpolatedStringHandler.ToStringAndClear());
			}
			if (!this.StartGameProcess(A_1, A_2))
			{
				return new Tuple<bool, string>(false, "Please close call of duty 2 before starting the anti cheat.");
			}
			if (this.IsGameAlreadyRunning(this.stringProcessName))
			{
				this.someBoolean = true;
				this.슇();
				if (this.슟.슖())
				{
					this.StartScreenshotThread();
					this.싓();
				}
				this.슭();
				this.슗();
				this.슎();
				this.슖("Call of Duty 2");
				this.슟.슟();
				return new Tuple<bool, string>(true, "Anti cheat is running." + Environment.NewLine + Environment.NewLine + "If you close this application or logout it will quit your game!");
			}
			return new Tuple<bool, string>(false, "Something went wrong.");
		}

		// Token: 0x060001F2 RID: 498 RVA: 0x0000C258 File Offset: 0x0000A458
		private Tuple<bool, string> 슺(string A_1, string A_2, long A_3)
		{
			this.matchId = A_3;
			if (!File.Exists(A_1) || !A_1.ToLower().Contains("codmp.exe"))
			{
				return new Tuple<bool, string>(false, "Game not found on the given path");
			}
			this.슖 = A_1;
			this.슟.슟(A_1);
			if (!A_2.Contains("connect") || !A_2.Contains("password") || string.IsNullOrEmpty(A_2))
			{
				return new Tuple<bool, string>(false, "Cant connect to this server. Add (connect ip; password password)");
			}
			VersionDTO versionDTO = this.슟.슺();
			if (versionDTO.VersionGuid.Trim() != VersionAndHashing.슟.Trim())
			{
				return new Tuple<bool, string>(false, "Update");
			}
			if (versionDTO.Banned)
			{
				bool item = false;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(52, 5);
				defaultInterpolatedStringHandler.AppendLiteral("You have been banned! Reason: ");
				defaultInterpolatedStringHandler.AppendFormatted(Environment.NewLine);
				defaultInterpolatedStringHandler.AppendLiteral(" ");
				defaultInterpolatedStringHandler.AppendFormatted(versionDTO.BanReason);
				defaultInterpolatedStringHandler.AppendLiteral(" ");
				defaultInterpolatedStringHandler.AppendFormatted(Environment.NewLine);
				defaultInterpolatedStringHandler.AppendFormatted(Environment.NewLine);
				defaultInterpolatedStringHandler.AppendLiteral("Ban will expire on: ");
				defaultInterpolatedStringHandler.AppendFormatted(versionDTO.BanExpireDate.ToShortDateString());
				return new Tuple<bool, string>(item, defaultInterpolatedStringHandler.ToStringAndClear());
			}
			if (!this.StartGameProcess(A_1, A_2))
			{
				return new Tuple<bool, string>(false, "Please close call of duty before starting the anti cheat.");
			}
			if (this.IsGameAlreadyRunning(this.stringProcessName))
			{
				this.someBoolean = true;
				this.슇();
				if (this.슟.슖())
				{
					this.StartScreenshotThread();
				}
				this.슭();
				this.슗();
				this.슟.슟();
				return new Tuple<bool, string>(true, "Anti cheat is running." + Environment.NewLine + Environment.NewLine + "If you close this application or logout it will quit your game!");
			}
			return new Tuple<bool, string>(false, "Something went wrong.");
		}

		// Token: 0x060001F3 RID: 499 RVA: 0x0000C428 File Offset: 0x0000A628
		private Tuple<bool, string> 슎(string A_1, string A_2, long A_3)
		{
			this.matchId = A_3;
			if (!File.Exists(A_1) || !A_1.ToLower().Contains("coduomp.exe"))
			{
				return new Tuple<bool, string>(false, "Game not found on the given path");
			}
			this.슖 = A_1;
			this.슟.슟(A_1);
			if (!A_2.Contains("connect") || !A_2.Contains("password") || string.IsNullOrEmpty(A_2))
			{
				return new Tuple<bool, string>(false, "Cant connect to this server. Add (connect ip; password password)");
			}
			VersionDTO versionDTO = this.슟.슺();
			if (versionDTO.VersionGuid.Trim() != VersionAndHashing.슟.Trim())
			{
				return new Tuple<bool, string>(false, "Update");
			}
			if (versionDTO.Banned)
			{
				bool item = false;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(52, 5);
				defaultInterpolatedStringHandler.AppendLiteral("You have been banned! Reason: ");
				defaultInterpolatedStringHandler.AppendFormatted(Environment.NewLine);
				defaultInterpolatedStringHandler.AppendLiteral(" ");
				defaultInterpolatedStringHandler.AppendFormatted(versionDTO.BanReason);
				defaultInterpolatedStringHandler.AppendLiteral(" ");
				defaultInterpolatedStringHandler.AppendFormatted(Environment.NewLine);
				defaultInterpolatedStringHandler.AppendFormatted(Environment.NewLine);
				defaultInterpolatedStringHandler.AppendLiteral("Ban will expire on: ");
				defaultInterpolatedStringHandler.AppendFormatted(versionDTO.BanExpireDate.ToShortDateString());
				return new Tuple<bool, string>(item, defaultInterpolatedStringHandler.ToStringAndClear());
			}
			if (!this.StartGameProcess(A_1, A_2))
			{
				return new Tuple<bool, string>(false, "Please close call of duty before starting the anti cheat.");
			}
			if (this.IsGameAlreadyRunning(this.stringProcessName))
			{
				this.someBoolean = true;
				this.슇();
				if (this.슟.슖())
				{
					this.StartScreenshotThread();
				}
				this.슭();
				this.슗();
				this.슟.슟();
				return new Tuple<bool, string>(true, "Anti cheat is running." + Environment.NewLine + Environment.NewLine + "If you close this application or logout it will quit your game!");
			}
			return new Tuple<bool, string>(false, "Something went wrong.");
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x00003CBB File Offset: 0x00001EBB
		public void KillIt(object A_1, CancelEventArgs A_2)
		{
			if (this.targetProcess != null)
			{
				this.targetProcess.Kill();
			}
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x00003CD0 File Offset: 0x00001ED0
		public HardwareDTO _HardwareDTO()
		{
			return this._HWID_Interface.clientHardwareDTO();
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x0000C5F8 File Offset: 0x0000A7F8
		private bool StartGameProcess(string A_1, string A_2)
		{
			if (!this.IsGameAlreadyRunning(this.stringProcessName))
			{
				ProcessStartInfo processStartInfo = new ProcessStartInfo(A_1);
				string workingDirectory = A_1.Substring(0, A_1.LastIndexOf("\\") + 1);
				processStartInfo.WorkingDirectory = workingDirectory;
				processStartInfo.Arguments = "+" + A_2;
				Process.Start(processStartInfo);
				return true;
			}
			return false;
		}

		// Token: 0x060001F7 RID: 503 RVA: 0x0000C650 File Offset: 0x0000A850
		private bool IsGameAlreadyRunning(string A_1)
		{
			if (Process.GetProcessesByName(A_1).Length != 0)
			{
				try
				{
					this.targetProcess = Process.GetProcessesByName(A_1)[0];
				}
				catch (Exception)
				{
					this.슺();
					return false;
				}
				return true;
			}
			this.슺();
			return false;
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x00003CDD File Offset: 0x00001EDD
		private void 슺()
		{
			if (this.targetProcess != null && this.targetProcess.HasExited)
			{
				this.someBoolean = false;
				this.슟.슖();
				this.슐();
				this.targetProcess = null;
			}
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x0000C69C File Offset: 0x0000A89C
		private void 슎()
		{
			ThreadStart start = new ThreadStart(this.슼);
			this.식 = new Thread(start);
			this.식.IsBackground = true;
			this.식.Start();
		}

		// Token: 0x060001FA RID: 506 RVA: 0x0000C6DC File Offset: 0x0000A8DC
		private void 슆()
		{
			ThreadStart start = new ThreadStart(this.싻);
			this.슆 = new Thread(start);
			this.슆.IsBackground = true;
			this.슆.Start();
		}

		// Token: 0x060001FB RID: 507 RVA: 0x0000C71C File Offset: 0x0000A91C
		private void 슇()
		{
			ThreadStart start = new ThreadStart(this.슱);
			this.슖 = new Thread(start);
			this.슖.IsBackground = true;
			this.슖.Start();
		}

		// Token: 0x060001FC RID: 508 RVA: 0x0000C75C File Offset: 0x0000A95C
		private void StartScreenshotThread()
		{
			ThreadStart start = new ThreadStart(this.ScreenshotThread);
			this.슺 = new Thread(start);
			this.슺.IsBackground = true;
			this.슺.Start();
		}

		// Token: 0x060001FD RID: 509 RVA: 0x0000C79C File Offset: 0x0000A99C
		private void 슠()
		{
			ThreadStart start = new ThreadStart(this.슴);
			this.슮 = new Thread(start);
			this.슮.IsBackground = true;
			this.슮.Start();
		}

		// Token: 0x060001FE RID: 510 RVA: 0x0000C7DC File Offset: 0x0000A9DC
		private void 싓()
		{
			ThreadStart start = new ThreadStart(this.싄);
			this.슭 = new Thread(start);
			this.슭.IsBackground = true;
			this.슭.Start();
		}

		// Token: 0x060001FF RID: 511 RVA: 0x0000C81C File Offset: 0x0000AA1C
		private void 슔()
		{
			ThreadStart start = new ThreadStart(this.싚);
			this.슠 = new Thread(start);
			this.슠.IsBackground = true;
			this.슠.Start();
		}

		// Token: 0x06000200 RID: 512 RVA: 0x0000C85C File Offset: 0x0000AA5C
		private void 식()
		{
			ThreadStart start = new ThreadStart(this.슍);
			this.슎 = new Thread(start);
			this.슎.IsBackground = true;
			this.슎.Start();
		}

		// Token: 0x06000201 RID: 513 RVA: 0x0000C89C File Offset: 0x0000AA9C
		private void 슭()
		{
			ThreadStart start = new ThreadStart(this.슢);
			this.슟 = new Thread(start);
			this.슟.IsBackground = true;
			this.슟.Start();
		}

		// Token: 0x06000202 RID: 514 RVA: 0x0000C8DC File Offset: 0x0000AADC
		private void 슖(string A_1)
		{
			FormRelated3.슟 슟 = new FormRelated3.슟();
			슟.슟 = this;
			슟.슟 = A_1;
			ThreadStart start = new ThreadStart(슟.슟);
			this.싓 = new Thread(start);
			this.싓.IsBackground = true;
			this.싓.Start();
		}

		// Token: 0x06000203 RID: 515 RVA: 0x0000C92C File Offset: 0x0000AB2C
		private void 슗()
		{
			ThreadStart start = new ThreadStart(this.싶);
			this.슇 = new Thread(start);
			this.슇.IsBackground = true;
			this.슇.Start();
		}

		// Token: 0x06000204 RID: 516 RVA: 0x0000C96C File Offset: 0x0000AB6C
		private void 슲()
		{
			ThreadStart start = new ThreadStart(this.슕);
			this.슔 = new Thread(start);
			this.슔.IsBackground = true;
			this.슔.Start();
		}

		// Token: 0x06000205 RID: 517 RVA: 0x00003D13 File Offset: 0x00001F13
		private int RandomInteger(int A_1, int A_2)
		{
			return new Random().Next(A_1, A_2);
		}

		// Token: 0x06000206 RID: 518 RVA: 0x0000C9AC File Offset: 0x0000ABAC
		private void SetScreenshotThread()
		{
			if (this.IsGameAlreadyRunning(this.stringProcessName) && this._AC_ScreenshotInterface.ProcessLonge(this.targetProcess, this.matchId) && this.슟.슖() && !this.슟)
			{
				this.슟 = true;
				this.StartScreenshotThread();
			}
		}

		// Token: 0x06000207 RID: 519 RVA: 0x00003D21 File Offset: 0x00001F21
		private void AC_ScreenshotInit()
		{
			if (this.IsGameAlreadyRunning(this.stringProcessName))
			{
				this._AC_ScreenshotInterface.LongeProcess(this.matchId, this.targetProcess);
			}
		}

		// Token: 0x06000208 RID: 520 RVA: 0x00003D48 File Offset: 0x00001F48
		private void 슉()
		{
			if (this.IsGameAlreadyRunning(this.stringProcessName))
			{
				this._AC_BindDetectionInterface.Target(this.targetProcess, this.matchId);
			}
		}

		// Token: 0x06000209 RID: 521 RVA: 0x00003D6F File Offset: 0x00001F6F
		private void 슒()
		{
			if (this.IsGameAlreadyRunning(this.stringProcessName))
			{
				this._AC_ScreenRecordingInterface.슟(this.matchId, this.targetProcess.MainWindowHandle);
			}
		}

		// Token: 0x0600020A RID: 522 RVA: 0x00003D9B File Offset: 0x00001F9B
		private void 싥()
		{
			if (this.IsGameAlreadyRunning(this.stringProcessName))
			{
				this.슟.Target(this.targetProcess, this.matchId);
			}
		}

		// Token: 0x0600020B RID: 523 RVA: 0x00003DC2 File Offset: 0x00001FC2
		private void 슚()
		{
			if (this.IsGameAlreadyRunning(this.stringProcessName))
			{
				this.슟.슟(this.targetProcess, this.matchId);
			}
		}

		// Token: 0x0600020C RID: 524 RVA: 0x00003DE9 File Offset: 0x00001FE9
		private void 슟(bool A_1)
		{
			if (this.IsGameAlreadyRunning(this.stringProcessName))
			{
				this._AC_MainInterface.슟(this.targetProcess, this.matchId, A_1);
			}
		}

		// Token: 0x0600020D RID: 525 RVA: 0x00003E11 File Offset: 0x00002011
		private void 슖(bool A_1)
		{
			if (this.IsGameAlreadyRunning(this.stringProcessName))
			{
				this.슟.슟(this.targetProcess, this.matchId, A_1);
			}
		}

		// Token: 0x0600020E RID: 526 RVA: 0x0000CA04 File Offset: 0x0000AC04
		private void 슐()
		{
			if (this.슟 != null)
			{
				this.슟(this, EventArgs.Empty);
				this.슟 = false;
				this.슟.슖(this.슖);
				try
				{
					this.슻();
				}
				catch (Exception)
				{
				}
			}
		}

		// Token: 0x0600020F RID: 527 RVA: 0x0000CA60 File Offset: 0x0000AC60
		private void 슻()
		{
			try
			{
				this.슟.Abort();
			}
			catch (Exception)
			{
			}
			try
			{
				this.슺.Abort();
			}
			catch (Exception)
			{
			}
			try
			{
				this.슖.Abort();
			}
			catch (Exception)
			{
			}
			try
			{
				this.슇.Abort();
			}
			catch (Exception)
			{
			}
			if (this.슆 != null)
			{
				try
				{
					this.슆.Abort();
				}
				catch (Exception)
				{
				}
			}
			try
			{
				this.슎.Abort();
			}
			catch (Exception)
			{
			}
			try
			{
				this.싓.Abort();
			}
			catch (Exception)
			{
			}
			try
			{
				this.슮.Abort();
			}
			catch (Exception)
			{
			}
			try
			{
				this.슠.Abort();
			}
			catch (Exception)
			{
			}
			try
			{
				this.슔.Abort();
			}
			catch (Exception)
			{
			}
			if (this.식 != null)
			{
				try
				{
					this.식.Abort();
				}
				catch (Exception)
				{
				}
			}
			if (this.슭 != null)
			{
				try
				{
					this.슭.Abort();
				}
				catch (Exception)
				{
				}
			}
		}

		// Token: 0x06000210 RID: 528 RVA: 0x00003E39 File Offset: 0x00002039
		[CompilerGenerated]
		private void 슼()
		{
			Thread.Sleep(this.2000);
			this.슟.슟(this.targetProcess);
		}

		// Token: 0x06000211 RID: 529 RVA: 0x0000CBE4 File Offset: 0x0000ADE4
		[CompilerGenerated]
		private void 싻()
		{
			Thread.Sleep(this.5000);
			while (this.someBoolean)
			{
				this.슟.TargetProcess(this.targetProcess);
				Thread.Sleep(this.1 * this.60 * this.1000);
			}
		}

		// Token: 0x06000212 RID: 530 RVA: 0x0000CC30 File Offset: 0x0000AE30
		[CompilerGenerated]
		private void 슱()
		{
			new Stopwatch();
			Thread.Sleep(this.60000);
			this.SetScreenshotThread();
			while (this.someBoolean)
			{
				int millisecondsTimeout = this.RandomInteger(this.9, this.15) * this.60 * this.1000;
				this.SetScreenshotThread();
				Thread.Sleep(millisecondsTimeout);
			}
		}

		// Token: 0x06000213 RID: 531 RVA: 0x0000CC8C File Offset: 0x0000AE8C
		[CompilerGenerated]
		private void ScreenshotThread()
		{
			Thread.Sleep(this.4000);
			while (this.someBoolean)
			{
				int millisecondsTimeout = this.RandomInteger(this.9, this.15) * this.60 * this.1000;
				this.AC_ScreenshotInit();
				Thread.Sleep(millisecondsTimeout);
			}
		}

		// Token: 0x06000214 RID: 532 RVA: 0x0000CCDC File Offset: 0x0000AEDC
		[CompilerGenerated]
		private void 슴()
		{
			Thread.Sleep(this.1 * this.60 * this.1000);
			while (this.someBoolean)
			{
				this.슉();
				Thread.Sleep(this.RandomInteger(this.5, this.10) * this.60 * this.1000);
			}
		}

		// Token: 0x06000215 RID: 533 RVA: 0x0000CD38 File Offset: 0x0000AF38
		[CompilerGenerated]
		private void 싄()
		{
			Thread.Sleep(this.25000);
			while (this.someBoolean)
			{
				this.슒();
				Thread.Sleep(this.RandomInteger(this.17, this.25) * this.60 * this.1000);
			}
		}

		// Token: 0x06000216 RID: 534 RVA: 0x0000CD88 File Offset: 0x0000AF88
		[CompilerGenerated]
		private void 싚()
		{
			Thread.Sleep(this.2 * this.60 * this.1000);
			while (this.someBoolean)
			{
				this.싥();
				Thread.Sleep(this.RandomInteger(this.5, this.슗) * this.60 * this.1000);
			}
		}

		// Token: 0x06000217 RID: 535 RVA: 0x00003E57 File Offset: 0x00002057
		[CompilerGenerated]
		private void 슍()
		{
			Thread.Sleep(this.60000);
			while (this.someBoolean)
			{
				this.슚();
				Thread.Sleep(this.5 * this.60 * this.1000);
			}
		}

		// Token: 0x06000218 RID: 536 RVA: 0x00003E8D File Offset: 0x0000208D
		[CompilerGenerated]
		private void 슢()
		{
			while (this.someBoolean)
			{
				this.슟.슟(this.matchId, VersionAndHashing.슟);
				Thread.Sleep(this.1 * this.240 * this.1000);
			}
		}

		// Token: 0x06000219 RID: 537 RVA: 0x0000CDE4 File Offset: 0x0000AFE4
		[CompilerGenerated]
		private void 싶()
		{
			Stopwatch stopwatch = new Stopwatch();
			Thread.Sleep(this.30sec);
			this.슟(true);
			Thread.Sleep(this.1000);
			while (this.someBoolean)
			{
				stopwatch.Start();
				bool flag = (int)stopwatch.Elapsed.TotalMinutes == this.RandomInteger(this.9, this.15);
				this.슟(flag);
				if (flag)
				{
					stopwatch.Reset();
				}
				Thread.Sleep(this.5000);
			}
		}

		// Token: 0x0600021A RID: 538 RVA: 0x0000CE64 File Offset: 0x0000B064
		[CompilerGenerated]
		private void 슕()
		{
			Stopwatch stopwatch = new Stopwatch();
			Thread.Sleep(this.30sec);
			while (this.someBoolean)
			{
				stopwatch.Start();
				bool flag = (int)stopwatch.Elapsed.TotalMinutes == this.sevenMinutes;
				this.슖(flag);
				if (flag)
				{
					stopwatch.Reset();
				}
				Thread.Sleep(this.4sec);
			}
		}

		// Token: 0x0400016D RID: 365
		private readonly int 1000 = 1000;

		// Token: 0x0400016E RID: 366
		private Process targetProcess;

		// Token: 0x0400016F RID: 367
		private string stringProcessName = "";

		// Token: 0x04000170 RID: 368
		private readonly int 3000 = 3000;

		// Token: 0x04000171 RID: 369
		private readonly int 3 = 3;

		// Token: 0x04000172 RID: 370
		private readonly int 2000 = 2000;

		// Token: 0x04000173 RID: 371
		private readonly int 25000 = 25000;

		// Token: 0x04000174 RID: 372
		private bool 슟;

		// Token: 0x04000175 RID: 373
		private readonly int 10000 = 10000;

		// Token: 0x04000176 RID: 374
		private readonly Authentication 슟;

		// Token: 0x04000177 RID: 375
		private bool someBoolean;

		// Token: 0x04000178 RID: 376
		private Thread 슟;

		// Token: 0x04000179 RID: 377
		private readonly int sevenMinutes = 7;

		// Token: 0x0400017A RID: 378
		private readonly int 30sec = 30000;

		// Token: 0x0400017B RID: 379
		private readonly int 4000 = 40000;

		// Token: 0x0400017C RID: 380
		private readonly int 60000 = 60000;

		// Token: 0x0400017D RID: 381
		private long matchId;

		// Token: 0x0400017E RID: 382
		private Thread 슖;

		// Token: 0x0400017F RID: 383
		private readonly AC_MainInterface _AC_MainInterface;

		// Token: 0x04000180 RID: 384
		private readonly int 5 = 5;

		// Token: 0x04000181 RID: 385
		private string 슖 = "";

		// Token: 0x04000182 RID: 386
		private readonly int 20000 = 20000;

		// Token: 0x04000183 RID: 387
		private readonly AC_ScreenshotInterface _AC_ScreenshotInterface;

		// Token: 0x04000184 RID: 388
		private readonly int 슗 = 8;

		// Token: 0x04000185 RID: 389
		private Thread 슺;

		// Token: 0x04000186 RID: 390
		private readonly AC_BindDetectionInterface _AC_BindDetectionInterface;

		// Token: 0x04000187 RID: 391
		private readonly int 1 = 1;

		// Token: 0x04000188 RID: 392
		private readonly HWID_Interface _HWID_Interface;

		// Token: 0x04000189 RID: 393
		private Thread 슎;

		// Token: 0x0400018A RID: 394
		private readonly int 2 = 2;

		// Token: 0x0400018B RID: 395
		private readonly 슚 슟;

		// Token: 0x0400018C RID: 396
		private readonly 싚 슟;

		// Token: 0x0400018D RID: 397
		private Thread 슆;

		// Token: 0x0400018E RID: 398
		private readonly int 60 = 60;

		// Token: 0x0400018F RID: 399
		private readonly int 17 = 17;

		// Token: 0x04000190 RID: 400
		private readonly int 150 = 150;

		// Token: 0x04000191 RID: 401
		private readonly 슻 슟;

		// Token: 0x04000192 RID: 402
		private readonly int 250 = 250;

		// Token: 0x04000193 RID: 403
		private readonly int 25 = 25;

		// Token: 0x04000194 RID: 404
		private readonly AC_CvarCheckInterface 슟;

		// Token: 0x04000195 RID: 405
		private Thread 슇;

		// Token: 0x04000196 RID: 406
		private readonly 슱 슟;

		// Token: 0x04000197 RID: 407
		private readonly int 10 = 10;

		// Token: 0x04000198 RID: 408
		private Thread 슮;

		// Token: 0x04000199 RID: 409
		private readonly 슼 슟;

		// Token: 0x0400019A RID: 410
		private readonly int 9 = 9;

		// Token: 0x0400019B RID: 411
		private readonly AC_MemoryCheckInterface 슟;

		// Token: 0x0400019C RID: 412
		private readonly 슲 슟;

		// Token: 0x0400019D RID: 413
		private readonly int 15 = 15;

		// Token: 0x0400019E RID: 414
		private readonly int 240 = 240;

		// Token: 0x0400019F RID: 415
		private Thread 슠;

		// Token: 0x040001A0 RID: 416
		private readonly AC_WeirdCvarCheckInterface 슟;

		// Token: 0x040001A1 RID: 417
		private readonly AC_ScreenRecordingInterface _AC_ScreenRecordingInterface;

		// Token: 0x040001A2 RID: 418
		private readonly int 5000 = 5000;

		// Token: 0x040001A3 RID: 419
		private readonly int 1500 = 1500;

		// Token: 0x040001A4 RID: 420
		private readonly int 4sec = 4000;

		// Token: 0x040001A5 RID: 421
		private Thread 싓;

		// Token: 0x040001A6 RID: 422
		private Thread 슔;

		// Token: 0x040001A7 RID: 423
		private Thread 식;

		// Token: 0x040001A8 RID: 424
		private Thread 슭;

		// Token: 0x040001A9 RID: 425
		[CompilerGenerated]
		private EventHandler 슟;

		// Token: 0x0200005E RID: 94
		[CompilerGenerated]
		private sealed class 슟
		{
			// Token: 0x0600021C RID: 540 RVA: 0x0000CEC8 File Offset: 0x0000B0C8
			internal void 슟()
			{
				this.슟._AC_MainInterface.슟(this.슟.matchId, this.슟, this.슟.슖);
				this.슟._AC_MainInterface.슟(this.슟.슖, this.슟, this.슟.matchId);
				this.슟._AC_MainInterface.슖(this.슟.슖, this.슟, this.슟.matchId);
			}

			// Token: 0x040001AA RID: 426
			public FormRelated3 슟;

			// Token: 0x040001AB RID: 427
			public string 슟;
		}
	}
}
