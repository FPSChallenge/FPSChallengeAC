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
	// Token: 0x02000025 RID: 37
	public class AC_CvarCheckInput : AC_CvarCheckInterface
	{
		// Token: 0x060000EB RID: 235
		[DllImport("kernel32.dll")]
		public static extern IntPtr OpenProcess(uint, int, uint);

		// Token: 0x060000EC RID: 236
		[DllImport("kernel32.dll")]
		public static extern int ReadProcessMemory(IntPtr, IntPtr, [Out] byte[], uint, ref uint);

		// Token: 0x060000ED RID: 237
		[DllImport("kernel32.dll")]
		public static extern uint GetLastError();

		// Token: 0x060000EE RID: 238
		[DllImport("kernel32.dll")]
		public static extern void SetLastError(uint);

		// Token: 0x060000EF RID: 239 RVA: 0x00003774 File Offset: 0x00001974
		public AC_CvarCheckInput(Authentication A_1)
		{
			this.SomeList = new List<string>();
			this.AuthRelated = A_1;
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00006D58 File Offset: 0x00004F58
		public void ReadCvarInput(Process A_1, long A_2)
		{
			if (this.SomeLong != A_2)
			{
				this.SomeLong = A_2;
				this.SomeList.Clear();
			}
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = false;
			int offset = 5188064;
			IntPtr intPtr = A_1.MainModule.BaseAddress + offset;
			IntPtr intPtr2 = AC_CvarCheckInput.OpenProcess(16U, 1, (uint)A_1.Id);
			if (intPtr2.ToInt32() == 0)
			{
				return;
			}
			uint num = 0U;
			bool flag2 = true;
			int num2 = 0;
			IntPtr intPtr3 = intPtr;
			while (flag2)
			{
				AC_CvarCheckInput.CheckInputClass checkInputClass = new AC_CvarCheckInput.CheckInputClass();
				byte[] bytes = this.ReadTarget(intPtr2, intPtr3, 280U, ref num);
				intPtr3 += 280;
				string @string = new ASCIIEncoding().GetString(bytes);
				string text = this.StringSplitString(@string);
				checkInputClass.SomeTuple = this.DoCvarCheck(text);
				if (checkInputClass.SomeTuple.Item1 && !this.SomeList.Any(new Func<string, bool>(checkInputClass.SomeBoolean)))
				{
					this.SomeList.Add(checkInputClass.SomeTuple.Item2);
					stringBuilder.Append(checkInputClass.SomeTuple.Item2);
					flag = true;
				}
				if (string.IsNullOrEmpty(text))
				{
					flag2 = false;
				}
				num2++;
			}
			if (flag)
			{
				string @base = AC_CvarCheckInput.ConvertToBase64String(stringBuilder.ToString());
				UploadModel uploadModel = new UploadModel
				{
					Type = 슮.슟.슆,
					Payload = new Payload
					{
						Base64 = @base,
						MatchId = A_2
					}
				};
				this.AuthRelated.슟(uploadModel).Wait();
			}
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00006ED4 File Offset: 0x000050D4
		public Tuple<bool, string> DoCvarCheck(string A_1)
		{
			bool item = false;
			if (!string.IsNullOrEmpty(A_1))
			{
				string[] array = A_1.Split(Environment.NewLine, StringSplitOptions.None);
				StringBuilder stringBuilder = new StringBuilder();
				foreach (string text in array)
				{
					string text2 = text.ToLower();
					if ((text2.First<char>() == '/' || text2.First<char>() == '\\') && text2.Contains(AC_CvarCheckTable.roccat))
					{
						stringBuilder.Append(text + Environment.NewLine);
						item = true;
						break;
					}
					if ((text2.First<char>() == '/' || text2.First<char>() == '\\') && text2.Contains(AC_CvarCheckTable.aimbot))
					{
						stringBuilder.Append(text + Environment.NewLine);
						item = true;
						break;
					}
					if ((text2.First<char>() == '/' || text2.First<char>() == '\\') && text2.Contains(AC_CvarCheckTable.esp))
					{
						stringBuilder.Append(text + Environment.NewLine);
						item = true;
						break;
					}
					if ((text2.First<char>() == '/' || text2.First<char>() == '\\') && text2.Contains(AC_CvarCheckTable.antiban))
					{
						stringBuilder.Append(text + Environment.NewLine);
						item = true;
						break;
					}
					if ((text2.First<char>() == '/' || text2.First<char>() == '\\') && text2.Contains(AC_CvarCheckTable.crosshair))
					{
						stringBuilder.Append(text + Environment.NewLine);
						item = true;
						break;
					}
					if ((text2.First<char>() == '/' || text2.First<char>() == '\\') && text2.Contains(AC_CvarCheckTable.espnade))
					{
						stringBuilder.Append(text + Environment.NewLine);
						item = true;
						break;
					}
					if ((text2.First<char>() == '/' || text2.First<char>() == '\\') && text2.Contains(AC_CvarCheckTable.espname))
					{
						stringBuilder.Append(text + Environment.NewLine);
						item = true;
						break;
					}
					if ((text2.First<char>() == '/' || text2.First<char>() == '\\') && text2.Contains(AC_CvarCheckTable.espbox))
					{
						stringBuilder.Append(text + Environment.NewLine);
						item = true;
						break;
					}
					if ((text2.First<char>() == '/' || text2.First<char>() == '\\') && text2.Contains(AC_CvarCheckTable.fullbright))
					{
						stringBuilder.Append(text + Environment.NewLine);
						item = true;
						break;
					}
					if ((text2.First<char>() == '/' || text2.First<char>() == '\\') && text2.Contains(AC_CvarCheckTable.dz_))
					{
						stringBuilder.Append(text + Environment.NewLine);
						item = true;
						break;
					}
					if ((text2.First<char>() == '/' || text2.First<char>() == '\\') && text2.Contains(AC_CvarCheckTable.wallhack))
					{
						stringBuilder.Append(text + Environment.NewLine);
						item = true;
						break;
					}
					if ((text2.First<char>() == '/' || text2.First<char>() == '\\') && text2.Contains(AC_CvarCheckTable.camps))
					{
						stringBuilder.Append(text + Environment.NewLine);
						item = true;
						break;
					}
					if ((text2.First<char>() == '/' || text2.First<char>() == '\\') && text2.Contains(AC_CvarCheckTable.aim_))
					{
						stringBuilder.Append(text + Environment.NewLine);
						item = true;
						break;
					}
					if ((text2.First<char>() == '/' || text2.First<char>() == '\\') && text2.Contains(AC_CvarCheckTable.333) && text2.Contains(AC_CvarCheckTable.com_maxfps))
					{
						stringBuilder.Append(text + Environment.NewLine);
						item = true;
						break;
					}
					if ((text2.First<char>() == '/' || text2.First<char>() == '\\') && text2.Contains(AC_CvarCheckTable.exec))
					{
						stringBuilder.Append(text + Environment.NewLine);
						item = true;
						break;
					}
				}
				return new Tuple<bool, string>(item, stringBuilder.ToString());
			}
			return new Tuple<bool, string>(item, "");
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x0000378E File Offset: 0x0000198E
		private static string ConvertToBase64String(string A_0)
		{
			return Convert.ToBase64String(Encoding.UTF8.GetBytes(A_0));
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00003736 File Offset: 0x00001936
		private string StringSplitString(string A_1)
		{
			return A_1.Split(new string[]
			{
				"\0"
			}, StringSplitOptions.None)[0];
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x000072E8 File Offset: 0x000054E8
		public byte[] ReadTarget(IntPtr A_1, IntPtr A_2, uint A_3, ref uint A_4)
		{
			byte[] array = new byte[A_3];
			AC_CvarCheckInput.ReadProcessMemory(A_1, A_2, array, A_3, ref A_4);
			return array;
		}

		// Token: 0x040000AF RID: 175
		private readonly Authentication AuthRelated;

		// Token: 0x040000B0 RID: 176
		public long SomeLong;

		// Token: 0x040000B1 RID: 177
		public List<string> SomeList;

		// Token: 0x02000026 RID: 38
		[Flags]
		public enum SomeEnum
		{
			// Token: 0x040000B3 RID: 179
			16flag = 16,
			// Token: 0x040000B4 RID: 180
			32flag = 32,
			// Token: 0x040000B5 RID: 181
			8flag = 8
		}

		// Token: 0x02000027 RID: 39
		[CompilerGenerated]
		private sealed class CheckInputClass
		{
			// Token: 0x060000F6 RID: 246 RVA: 0x000037A0 File Offset: 0x000019A0
			internal bool SomeBoolean(string A_1)
			{
				return A_1 == this.SomeTuple.Item2;
			}

			// Token: 0x040000B6 RID: 182
			public Tuple<bool, string> SomeTuple;
		}
	}
}
