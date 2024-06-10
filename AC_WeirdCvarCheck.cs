using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using FPSCAnticheat.Shared.Models.Upload;

namespace FPSAC
{
	// Token: 0x02000028 RID: 40
	public class AC_WeirdCvarCheck : AC_WeirdCvarCheckInterface
	{
		// Token: 0x060000F7 RID: 247 RVA: 0x000037B3 File Offset: 0x000019B3
		[CompilerGenerated]
		public List<Tuple<string, int, int, int>> 슟()
		{
			return this.슟;
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x000037BB File Offset: 0x000019BB
		[CompilerGenerated]
		public void 슟(List<Tuple<string, int, int, int>> A_1)
		{
			this.슟 = A_1;
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x000037C4 File Offset: 0x000019C4
		[CompilerGenerated]
		public List<string> 슖()
		{
			return this.슟;
		}

		// Token: 0x060000FA RID: 250 RVA: 0x000037CC File Offset: 0x000019CC
		[CompilerGenerated]
		public void 슟(List<string> A_1)
		{
			this.슟 = A_1;
		}

		// Token: 0x060000FB RID: 251 RVA: 0x000037D5 File Offset: 0x000019D5
		[CompilerGenerated]
		public string 슺()
		{
			return this.슟;
		}

		// Token: 0x060000FC RID: 252 RVA: 0x000037DD File Offset: 0x000019DD
		[CompilerGenerated]
		public void 슟(string A_1)
		{
			this.슟 = A_1;
		}

		// Token: 0x060000FD RID: 253 RVA: 0x000037E6 File Offset: 0x000019E6
		[CompilerGenerated]
		public long 슎()
		{
			return this.슟;
		}

		// Token: 0x060000FE RID: 254 RVA: 0x000037EE File Offset: 0x000019EE
		[CompilerGenerated]
		public void 슟(long A_1)
		{
			this.슟 = A_1;
		}

		// Token: 0x060000FF RID: 255 RVA: 0x000037F7 File Offset: 0x000019F7
		[CompilerGenerated]
		public int[] 슆()
		{
			return this.슟;
		}

		// Token: 0x06000100 RID: 256 RVA: 0x000037FF File Offset: 0x000019FF
		[CompilerGenerated]
		public void 슟(int[] A_1)
		{
			this.슟 = A_1;
		}

		// Token: 0x06000101 RID: 257 RVA: 0x0000730C File Offset: 0x0000550C
		public AC_WeirdCvarCheck(Authentication A_1, 슐 A_2, AC_ScreenshotInterface A_3, 슼 A_4)
		{
			this.슟(new List<Tuple<string, int, int, int>>());
			this.슟(new List<string>());
			this.슟 = A_1;
			this.슟 = A_2;
			this.슟 = A_3;
			this.슟 = A_4;
			this.슇();
		}

		// Token: 0x06000102 RID: 258 RVA: 0x00007370 File Offset: 0x00005570
		public void 슇()
		{
			this.슟().Add(new Tuple<string, int, int, int>("sv_cheats", 25543776, 1, 1));
			this.슟().Add(new Tuple<string, int, int, int>("g_compassShowEnemies", 20075856, 1, 1));
			this.슟().Add(new Tuple<string, int, int, int>("compassEnemyFootstepEnabled", 7612888, 1, 1));
			this.슟().Add(new Tuple<string, int, int, int>("cg_hudGrenadeIconMaxRangeFrag", 7636528, 250, 4));
			this.슟().Add(new Tuple<string, int, int, int>("cg_hudGrenadeIconMaxRangeFlash", 9200404, 500, 4));
			this.슟().Add(new Tuple<string, int, int, int>("perk_bulletPenetrationMultiplier", 7564176, 2, 4));
			this.슟().Add(new Tuple<string, int, int, int>("bullet_penetrationMinFxDist", 7540372, 30, 4));
			this.슟().Add(new Tuple<string, int, int, int>("compassEnemyFootstepMaxRange", 7612828, 500, 4));
			this.슟().Add(new Tuple<string, int, int, int>("compassEnemyFootstepMinSpeed", 7612956, 140, 4));
			this.슟().Add(new Tuple<string, int, int, int>("compassEnemyFootstepMaxZ", 7612916, 100, 4));
			this.슟().Add(new Tuple<string, int, int, int>("cg_footsteps", 9200448, 0, 1));
			this.슟().Add(new Tuple<string, int, int, int>("r_fullbright", 223778432, 1, 1));
		}

		// Token: 0x06000103 RID: 259 RVA: 0x000074E0 File Offset: 0x000056E0
		public void 슟(Process A_1, long A_2, bool A_3)
		{
			AC_WeirdCvarCheck.슟 슟 = new AC_WeirdCvarCheck.슟();
			슟.슟 = A_1;
			슟.슟 = this;
			슟.슟 = A_2;
			if (this.슎() != 슟.슟)
			{
				this.슖().Clear();
				this.슟(슟.슟);
				this.슟.슟(false);
			}
			if (A_3)
			{
				this.슖().Clear();
			}
			if (this.슟.슟() && !this.슟(슟.슟))
			{
				Parallel.ForEach<Tuple<string, int, int, int>>(this.슟(), new Action<Tuple<string, int, int, int>>(슟.슟));
			}
		}

		// Token: 0x06000104 RID: 260 RVA: 0x0000757C File Offset: 0x0000577C
		private void 슟(Process A_1, long A_2, string A_3, int A_4)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(22, 2);
			defaultInterpolatedStringHandler.AppendLiteral("cvar: ");
			defaultInterpolatedStringHandler.AppendFormatted(A_3);
			defaultInterpolatedStringHandler.AppendLiteral(" has a value of ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(A_4);
			string text = defaultInterpolatedStringHandler.ToStringAndClear();
			if (!this.슖().Contains(text))
			{
				this.슟(A_1, A_2);
				this.슖().Add(text);
				this.슖(text);
			}
		}

		// Token: 0x06000105 RID: 261 RVA: 0x00003808 File Offset: 0x00001A08
		private void 슟(Process A_1, long A_2)
		{
			this.슟.ProcessLonge(A_1, A_2);
			if (this.슟.슖())
			{
				this.슟.LongeProcess(A_2, A_1);
			}
		}

		// Token: 0x06000106 RID: 262 RVA: 0x000075F0 File Offset: 0x000057F0
		public void 슖(string A_1)
		{
			string @base = this.슺(A_1);
			UploadModel uploadModel = new UploadModel
			{
				Type = 슮.슟.싖,
				Payload = new Payload
				{
					Base64 = @base,
					MatchId = this.슎()
				}
			};
			this.슟.슟(uploadModel).Wait();
		}

		// Token: 0x06000107 RID: 263
		[DllImport("kernel32.dll", EntryPoint = "OpenProcess")]
		public static extern IntPtr 슟(int, bool, int);

		// Token: 0x06000108 RID: 264
		[DllImport("kernel32.dll", EntryPoint = "ReadProcessMemory")]
		public static extern bool 슟(int, int, byte[], int, ref int);

		// Token: 0x06000109 RID: 265 RVA: 0x00003724 File Offset: 0x00001924
		private string 슺(string A_1)
		{
			return Convert.ToBase64String(Encoding.UTF8.GetBytes(A_1));
		}

		// Token: 0x0600010A RID: 266 RVA: 0x00007644 File Offset: 0x00005844
		private bool 슟(Process A_1)
		{
			bool result;
			try
			{
				foreach (int num in this.슆())
				{
					IntPtr value = AC_WeirdCvarCheck.슟(2035711, false, A_1.Id);
					int num2 = 0;
					byte[] array2 = new byte[1];
					AC_WeirdCvarCheck.슟((int)value, num, array2, array2.Length, ref num2);
					if (array2[0] != 0)
					{
						return false;
					}
				}
				result = true;
			}
			catch (Exception)
			{
				result = true;
			}
			return result;
		}

		// Token: 0x040000B7 RID: 183
		private Authentication 슟;

		// Token: 0x040000B8 RID: 184
		private 슐 슟;

		// Token: 0x040000B9 RID: 185
		private AC_ScreenshotInterface 슟;

		// Token: 0x040000BA RID: 186
		private 슼 슟;

		// Token: 0x040000BB RID: 187
		[CompilerGenerated]
		private List<Tuple<string, int, int, int>> 슟;

		// Token: 0x040000BC RID: 188
		[CompilerGenerated]
		private List<string> 슟;

		// Token: 0x040000BD RID: 189
		[CompilerGenerated]
		private string 슟;

		// Token: 0x040000BE RID: 190
		[CompilerGenerated]
		private long 슟;

		// Token: 0x040000BF RID: 191
		[CompilerGenerated]
		private int[] 슟 = new int[]
		{
			7660796,
			7660784,
			7660792
		};

		// Token: 0x040000C0 RID: 192
		private const int 슟 = 2035711;

		// Token: 0x02000029 RID: 41
		[CompilerGenerated]
		private sealed class 슟
		{
			// Token: 0x0600010C RID: 268 RVA: 0x000076C4 File Offset: 0x000058C4
			internal void 슟(Tuple<string, int, int, int> A_1)
			{
				try
				{
					IntPtr value = AC_WeirdCvarCheck.슟(2035711, false, this.슟.Id);
					int num = 0;
					byte[] array = new byte[4];
					AC_WeirdCvarCheck.슟((int)value, A_1.Item2, array, array.Length, ref num);
					int num2 = 0;
					IntPtr value2 = (IntPtr)BitConverter.ToInt32(array, 0);
					byte[] array2 = new byte[4];
					AC_WeirdCvarCheck.슟((int)value, (int)value2, array2, array2.Length, ref num2);
					IntPtr value3 = (IntPtr)BitConverter.ToInt32(array2, 0);
					int num3 = 0;
					byte[] array3 = new byte[A_1.Item1.Length];
					AC_WeirdCvarCheck.슟((int)value, (int)value3, array3, array3.Length, ref num3);
					string @string = new ASCIIEncoding().GetString(array3);
					if (A_1.Item1 != @string)
					{
						string text = "cvar: " + A_1.Item1 + " has a value of cvar name of " + @string;
						if (!this.슟.슖().Contains(text))
						{
							this.슟.슖().Add(text);
							this.슟.슖(text);
						}
					}
					IntPtr value4 = (IntPtr)BitConverter.ToInt32(array, 0) + 12;
					int num4 = 0;
					byte[] array4 = new byte[A_1.Item4];
					AC_WeirdCvarCheck.슟((int)value, (int)value4, array4, array4.Length, ref num4);
					if (A_1.Item4 == 1)
					{
						int num5 = (int)array4[0];
						if (num5 == A_1.Item3)
						{
							this.슟.슟(this.슟, this.슟, A_1.Item1, num5);
						}
					}
					else
					{
						int num5 = (int)BitConverter.ToSingle(array4, 0);
						if (num5 != A_1.Item3 && num5 != 0)
						{
							this.슟.슟(this.슟, this.슟, A_1.Item1, num5);
						}
					}
				}
				catch (Exception)
				{
				}
			}

			// Token: 0x040000C1 RID: 193
			public Process 슟;

			// Token: 0x040000C2 RID: 194
			public AC_WeirdCvarCheck 슟;

			// Token: 0x040000C3 RID: 195
			public long 슟;
		}
	}
}
