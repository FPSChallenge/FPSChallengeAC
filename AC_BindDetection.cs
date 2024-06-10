using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using FPSCAnticheat.Shared.Models.Upload;

namespace FPSAC
{
	// Token: 0x02000021 RID: 33
	public class AC_BindDetection : AC_BindDetectionInterface
	{
		// Token: 0x060000DC RID: 220
		[DllImport("kernel32.dll")]
		public static extern IntPtr OpenProcess(uint, int, uint);

		// Token: 0x060000DD RID: 221
		[DllImport("kernel32.dll")]
		public static extern int ReadProcessMemory(IntPtr, IntPtr, [Out] byte[], uint, ref uint);

		// Token: 0x060000DE RID: 222
		[DllImport("kernel32.dll")]
		public static extern uint GetLastError();

		// Token: 0x060000DF RID: 223
		[DllImport("kernel32.dll")]
		public static extern void SetLastError(uint);

		// Token: 0x060000E0 RID: 224 RVA: 0x0000370A File Offset: 0x0000190A
		public AC_BindDetection(Authentication A_1)
		{
			this.ListSomething = new List<string>();
			this.AuthSomething = A_1;
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00006954 File Offset: 0x00004B54
		public void GetPlayerInput(Process A_1, long A_2)
		{
			if (this.SomeLong != A_2)
			{
				this.SomeLong = A_2;
				this.ListSomething.Clear();
			}
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = false;
			int offset = 209372908;
			IntPtr intPtr = A_1.MainModule.BaseAddress + offset;
			IntPtr intPtr2 = AC_BindDetection.OpenProcess(16U, 1, (uint)A_1.Id);
			if (intPtr2.ToInt32() == 0)
			{
				return;
			}
			uint num = 0U;
			bool flag2 = true;
			int num2 = 0;
			IntPtr intPtr3 = (IntPtr)BitConverter.ToInt32(this.ReadTarget(intPtr2, intPtr, 4U, ref num), 0);
			while (flag2)
			{
				AC_BindDetection.슺 슺 = new AC_BindDetection.슺();
				IntPtr intPtr4 = intPtr3;
				intPtr4 += num2 * 3 * 4;
				byte[] array = this.ReadTarget(intPtr2, intPtr4, 370U, ref num);
				string @string = new ASCIIEncoding().GetString(array);
				string text = this.EmptyCharOperation(@string);
				슺.슟 = this.BindDetection(text);
				if (슺.슟.Item1 && !this.ListSomething.Any(new Func<string, bool>(슺.슟)))
				{
					this.ListSomething.Add(슺.슟.Item2);
					stringBuilder.Append(슺.슟.Item2);
					flag = true;
				}
				if (array.All(new Func<byte, bool>(AC_BindDetection.슖.슟.슟)))
				{
					flag2 = false;
				}
				num2++;
			}
			if (flag)
			{
				string @base = this.ConvertToBase64String(stringBuilder.ToString());
				UploadModel uploadModel = new UploadModel
				{
					Type = 슮.슟.슺,
					Payload = new Payload
					{
						Base64 = @base,
						MatchId = A_2
					}
				};
				this.AuthSomething.슟(uploadModel).Wait();
			}
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00006B08 File Offset: 0x00004D08
		public Tuple<bool, string> BindDetection(string A_1)
		{
			bool item = false;
			string[] array = A_1.Split(Environment.NewLine, StringSplitOptions.None);
			StringBuilder stringBuilder = new StringBuilder();
			foreach (string text in array)
			{
				string text2 = text.ToLower();
				if (text2.Contains(AC_BindDetectionTable.attack) && text2.Contains(AC_BindDetectionTable.wait))
				{
					stringBuilder.Append(text + Environment.NewLine);
					item = true;
				}
				if (text2.Contains(AC_BindDetectionTable.weapnext) && text2.Contains(AC_BindDetectionTable.wait))
				{
					stringBuilder.Append(text + Environment.NewLine);
					item = true;
				}
				if (text2.Contains(AC_BindDetectionTable.melee) && text2.Contains(AC_BindDetectionTable.openscriptmenu))
				{
					stringBuilder.Append(text + Environment.NewLine);
					item = true;
				}
				if (text2.Contains(AC_BindDetectionTable.reload) && text2.Contains(AC_BindDetectionTable.wait))
				{
					stringBuilder.Append(text + Environment.NewLine);
					item = true;
				}
				if (text2.Contains(AC_BindDetectionTable.forward) && text2.Contains(AC_BindDetectionTable.wait))
				{
					stringBuilder.Append(text + Environment.NewLine);
					item = true;
				}
				if (text2.Contains(AC_BindDetectionTable.frag) && text2.Contains(AC_BindDetectionTable.wait))
				{
					stringBuilder.Append(text + Environment.NewLine);
					item = true;
				}
				if (text2.Contains(AC_BindDetectionTable.smoke) && text2.Contains(AC_BindDetectionTable.wait))
				{
					stringBuilder.Append(text + Environment.NewLine);
					item = true;
				}
				if (text2.Contains(AC_BindDetectionTable.gostand) && text2.Contains(AC_BindDetectionTable.wait))
				{
					stringBuilder.Append(text + Environment.NewLine);
					item = true;
				}
				if (text2.Contains(AC_BindDetectionTable.sprint) && text2.Contains(AC_BindDetectionTable.wait))
				{
					stringBuilder.Append(text + Environment.NewLine);
					item = true;
				}
				if (text2.Contains(AC_BindDetectionTable.vstr))
				{
					stringBuilder.Append(text + Environment.NewLine);
					item = true;
				}
			}
			return new Tuple<bool, string>(item, stringBuilder.ToString());
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00003724 File Offset: 0x00001924
		private string ConvertToBase64String(string A_1)
		{
			return Convert.ToBase64String(Encoding.UTF8.GetBytes(A_1));
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00003736 File Offset: 0x00001936
		private string EmptyCharOperation(string A_1)
		{
			return A_1.Split(new string[]
			{
				"\0"
			}, StringSplitOptions.None)[0];
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x00006D34 File Offset: 0x00004F34
		public byte[] ReadTarget(IntPtr A_1, IntPtr A_2, uint A_3, ref uint A_4)
		{
			byte[] array = new byte[A_3];
			AC_BindDetection.ReadProcessMemory(A_1, A_2, array, A_3, ref A_4);
			return array;
		}

		// Token: 0x040000A5 RID: 165
		private readonly Authentication AuthSomething;

		// Token: 0x040000A6 RID: 166
		public List<string> ListSomething;

		// Token: 0x040000A7 RID: 167
		public long SomeLong;

		// Token: 0x02000022 RID: 34
		[Flags]
		public enum SomeEnum
		{
			// Token: 0x040000A9 RID: 169
			16flag = 16,
			// Token: 0x040000AA RID: 170
			32flag = 32,
			// Token: 0x040000AB RID: 171
			8flag = 8
		}

		// Token: 0x02000023 RID: 35
		[CompilerGenerated]
		[Serializable]
		private sealed class 슖
		{
			// Token: 0x060000E8 RID: 232 RVA: 0x0000375B File Offset: 0x0000195B
			internal bool 슟(byte A_1)
			{
				return A_1 == 0;
			}

			// Token: 0x040000AC RID: 172
			public static readonly AC_BindDetection.슖 슟 = new AC_BindDetection.슖();

			// Token: 0x040000AD RID: 173
			public static Func<byte, bool> 슟;
		}

		// Token: 0x02000024 RID: 36
		[CompilerGenerated]
		private sealed class 슺
		{
			// Token: 0x060000EA RID: 234 RVA: 0x00003761 File Offset: 0x00001961
			internal bool 슟(string A_1)
			{
				return A_1 == this.슟.Item2;
			}

			// Token: 0x040000AE RID: 174
			public Tuple<bool, string> 슟;
		}
	}
}
