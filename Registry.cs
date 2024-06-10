using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Microsoft.Win32;

namespace FPSAC
{
	// Token: 0x02000045 RID: 69
	public class Registry : 슱
	{
		// Token: 0x0600019C RID: 412 RVA: 0x0000B0F4 File Offset: 0x000092F4
		public bool 슟()
		{
			bool result = false;
			using (RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
			{
				using (RegistryKey registryKey2 = registryKey.OpenSubKey("SOFTWARE\\\\Microsoft\\\\Windows\\\\CurrentVersion\\\\Setup\\\\WindowsFeatures"))
				{
					if (registryKey2 != null)
					{
						result = true;
					}
				}
			}
			using (RegistryKey registryKey3 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32))
			{
				using (RegistryKey registryKey4 = registryKey3.OpenSubKey("SOFTWARE\\\\Microsoft\\\\Windows\\\\CurrentVersion\\\\Setup\\\\WindowsFeatures"))
				{
					if (registryKey4 != null)
					{
						result = true;
					}
				}
			}
			return result;
		}

		// Token: 0x0600019D RID: 413 RVA: 0x0000B1AC File Offset: 0x000093AC
		public bool 슖()
		{
			string text = "SOFTWARE\\Classes\\Installer\\Dependencies";
			using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(text))
			{
				if (registryKey == null)
				{
					return false;
				}
				foreach (string str in registryKey.GetSubKeyNames().Where(new Func<string, bool>(Registry.슟.슟.슟)))
				{
					using (RegistryKey registryKey2 = Registry.LocalMachine.OpenSubKey(text + "\\" + str))
					{
						object value = registryKey2.GetValue("DisplayName");
						string text2 = ((value != null) ? value.ToString() : null) ?? null;
						if (!string.IsNullOrEmpty(text2))
						{
							if (Regex.IsMatch(text2, "C\\+\\+ 2015.*\\(x86\\)"))
							{
								return true;
							}
						}
					}
				}
			}
			return false;
		}

		// Token: 0x0600019E RID: 414 RVA: 0x0000B2BC File Offset: 0x000094BC
		public void 슟(string A_1)
		{
			RegistryKey registryKey = this.슺();
			if (registryKey != null)
			{
				this.슎 = this.슟(registryKey, A_1);
				if (this.슎 != null && this.슎.Contains("DISABLEDXMAXIMIZEDWINDOWEDMODE"))
				{
					string text = this.슎.Replace("DISABLEDXMAXIMIZEDWINDOWEDMODE", "");
					this.슟(A_1, text);
					this.슟 = true;
				}
			}
			RegistryKey registryKey2 = this.슎();
			if (registryKey2 != null)
			{
				this.슆 = this.슟(registryKey2, A_1);
				if (this.슆 != null && this.슆.Contains("DISABLEDXMAXIMIZEDWINDOWEDMODE"))
				{
					string text2 = this.슆.Replace("DISABLEDXMAXIMIZEDWINDOWEDMODE", "");
					this.슖(A_1, text2);
					this.슖 = true;
				}
			}
		}

		// Token: 0x0600019F RID: 415 RVA: 0x00003B03 File Offset: 0x00001D03
		public void 슖(string A_1)
		{
			if (this.슟)
			{
				this.슟(A_1, this.슎);
				this.슖 = false;
			}
			if (this.슖)
			{
				this.슖(A_1, this.슆);
				this.슖 = false;
			}
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x0000B378 File Offset: 0x00009578
		private RegistryKey 슺()
		{
			RegistryKey result;
			try
			{
				if (Environment.Is64BitOperatingSystem)
				{
					RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);
					result = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Layers");
				}
				else
				{
					RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry32);
					result = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Layers");
				}
			}
			catch (UnauthorizedAccessException)
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x0000B3E8 File Offset: 0x000095E8
		private RegistryKey 슎()
		{
			RegistryKey result;
			try
			{
				if (Environment.Is64BitOperatingSystem)
				{
					result = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Layers");
				}
				else
				{
					result = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Layers");
				}
			}
			catch (UnauthorizedAccessException)
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x00003B3D File Offset: 0x00001D3D
		public string 슟(RegistryKey A_1, string A_2)
		{
			return (string)A_1.GetValue(A_2);
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x0000B44C File Offset: 0x0000964C
		public void 슟(string A_1, string A_2)
		{
			try
			{
				if (Environment.Is64BitOperatingSystem)
				{
					RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64).CreateSubKey("Software\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Layers").SetValue(A_1, A_2);
				}
				else
				{
					RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry32).CreateSubKey("Software\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Layers").SetValue(A_1, A_2);
				}
			}
			catch (UnauthorizedAccessException)
			{
			}
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x0000B4B8 File Offset: 0x000096B8
		public void 슖(string A_1, string A_2)
		{
			try
			{
				if (Environment.Is64BitOperatingSystem)
				{
					RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Layers").SetValue(A_1, A_2);
				}
				else
				{
					RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Layers").SetValue(A_1, A_2);
				}
			}
			catch (UnauthorizedAccessException)
			{
			}
		}

		// Token: 0x04000151 RID: 337
		private const string 슟 = "Software\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Layers";

		// Token: 0x04000152 RID: 338
		private const string 슖 = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Layers";

		// Token: 0x04000153 RID: 339
		private const string 슺 = "SOFTWARE\\\\Microsoft\\\\Windows\\\\CurrentVersion\\\\Setup\\\\WindowsFeatures";

		// Token: 0x04000154 RID: 340
		private bool 슟;

		// Token: 0x04000155 RID: 341
		private string 슎 = "";

		// Token: 0x04000156 RID: 342
		private string 슆 = "";

		// Token: 0x04000157 RID: 343
		private bool 슖;

		// Token: 0x02000046 RID: 70
		[CompilerGenerated]
		[Serializable]
		private sealed class 슟
		{
			// Token: 0x060001A7 RID: 423 RVA: 0x00003B57 File Offset: 0x00001D57
			internal bool 슟(string A_1)
			{
				return !A_1.ToLower().Contains("dotnet") && !A_1.ToLower().Contains("microsoft");
			}

			// Token: 0x04000158 RID: 344
			public static readonly Registry.슟 슟 = new Registry.슟();

			// Token: 0x04000159 RID: 345
			public static Func<string, bool> 슟;
		}
	}
}
