using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using FPSCAnticheat.Shared.DTO;
using FPSCAnticheat.Shared.Models.Upload;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace FPSAC
{
	// Token: 0x0200002E RID: 46
	public class MatchHandler : 슻
	{
		// Token: 0x06000123 RID: 291
		[DllImport("kernel32.dll")]
		public static extern IntPtr OpenProcess(uint, int, uint);

		// Token: 0x06000124 RID: 292
		[DllImport("kernel32.dll")]
		public static extern int ReadProcessMemory(IntPtr, IntPtr, [Out] byte[], uint, ref uint);

		// Token: 0x06000125 RID: 293
		[DllImport("kernel32.dll")]
		public static extern uint GetLastError();

		// Token: 0x06000126 RID: 294
		[DllImport("kernel32.dll")]
		public static extern void SetLastError(uint);

		// Token: 0x06000127 RID: 295 RVA: 0x00003897 File Offset: 0x00001A97
		public MatchHandler(Authentication A_1, 슐 A_2)
		{
			this.슟 = new JsonSerializerSettings
			{
				ContractResolver = new CamelCasePropertyNamesContractResolver()
			};
			this.슟 = A_1;
			this.슟 = A_2;
		}

		// Token: 0x06000128 RID: 296 RVA: 0x00007ED0 File Offset: 0x000060D0
		public void 슟(Process A_1, long A_2)
		{
			if (this.슟 != A_2)
			{
				this.슟 = A_2;
				this.슟 = null;
			}
			this.슟 = false;
			int offset = 3451208;
			int offset2 = 5598600;
			int offset3 = 17475749;
			int offset4 = 12579440;
			IntPtr baseAddress = A_1.MainModule.BaseAddress;
			IntPtr intPtr = baseAddress + offset;
			IntPtr intPtr2 = baseAddress + offset2;
			IntPtr intPtr3 = baseAddress + offset3;
			IntPtr intPtr4 = baseAddress + offset4;
			IntPtr intPtr5 = MatchHandler.OpenProcess(16U, 1, (uint)A_1.Id);
			if (intPtr5.ToInt32() == 0)
			{
				return;
			}
			uint num = 0U;
			byte[] bytes = this.ReadMemory(intPtr5, intPtr, 100U, ref num);
			byte[] bytes2 = this.ReadMemory(intPtr5, intPtr2, 100U, ref num);
			byte[] bytes3 = this.ReadMemory(intPtr5, intPtr3, 100U, ref num);
			byte[] bytes4 = this.ReadMemory(intPtr5, intPtr4, 100U, ref num);
			ASCIIEncoding asciiencoding = new ASCIIEncoding();
			string @string = asciiencoding.GetString(bytes);
			string string2 = asciiencoding.GetString(bytes2);
			string string3 = asciiencoding.GetString(bytes3);
			string string4 = asciiencoding.GetString(bytes4);
			string text = this.슟(@string);
			string text2 = this.슟(string2);
			string text3 = this.슟(string3);
			string text4 = this.슟(string4);
			if (text4 != "ui_mp" && this.슟 == null)
			{
				this.슟 = new MatchInfoDTO();
				this.슟.ServerName = text;
				this.슟.ServerIp = text2;
				if (this.슟.ServerIp != "localhost" && !this.슟.ServerIp.Contains(".dm1"))
				{
					this.슟.슟(true);
				}
				else
				{
					this.슟.슟(false);
				}
				this.슟.InGameName = text3;
				this.슟.MapName = text4;
				this.슟 = true;
			}
			if (!string.IsNullOrEmpty(text))
			{
				MatchInfoDTO matchInfoDTO = this.슟;
				if (((matchInfoDTO != null) ? matchInfoDTO.ServerName : null) != null && !this.슟.ServerName.Equals(text))
				{
					this.슟.ServerName = ((text.Length <= 127) ? text : text.Substring(0, 127));
					this.슟 = true;
				}
			}
			if (!string.IsNullOrEmpty(text2))
			{
				MatchInfoDTO matchInfoDTO2 = this.슟;
				if (((matchInfoDTO2 != null) ? matchInfoDTO2.ServerIp : null) != null && !this.슟.ServerIp.Equals(text2))
				{
					this.슟.ServerIp = ((text2.Length <= 63) ? text2 : text2.Substring(0, 63));
					if (this.슟.ServerIp != "localhost" && !this.슟.ServerIp.Contains(".dm1"))
					{
						this.슟.슟(true);
					}
					else
					{
						this.슟.슟(false);
					}
					this.슟 = true;
				}
			}
			if (!string.IsNullOrEmpty(text3))
			{
				MatchInfoDTO matchInfoDTO3 = this.슟;
				if (((matchInfoDTO3 != null) ? matchInfoDTO3.InGameName : null) != null && !this.슟.InGameName.Equals(text3))
				{
					this.슟.InGameName = ((text3.Length <= 31) ? text3 : text3.Substring(0, 31));
					this.슟 = true;
				}
			}
			if (!string.IsNullOrEmpty(text4))
			{
				MatchInfoDTO matchInfoDTO4 = this.슟;
				if (((matchInfoDTO4 != null) ? matchInfoDTO4.MapName : null) != null && !this.슟.MapName.Equals(text4))
				{
					this.슟.MapName = ((text4.Length <= 31) ? text4 : text4.Substring(0, 31));
					this.슟 = true;
				}
			}
			if (text4 != "ui_mp" && this.슟)
			{
				string s = JsonConvert.SerializeObject(this.슟, this.슟);
				string @base = Convert.ToBase64String(Encoding.UTF8.GetBytes(s));
				UploadModel uploadModel = new UploadModel
				{
					Type = 슮.슟.슇,
					Payload = new Payload
					{
						Base64 = @base,
						MatchId = A_2
					}
				};
				this.슟.슟(uploadModel).Wait();
			}
		}

		// Token: 0x06000129 RID: 297 RVA: 0x000082D0 File Offset: 0x000064D0
		public byte[] ReadMemory(IntPtr A_1, IntPtr A_2, uint A_3, ref uint A_4)
		{
			byte[] array = new byte[A_3];
			MatchHandler.ReadProcessMemory(A_1, A_2, array, A_3, ref A_4);
			return array;
		}

		// Token: 0x0600012A RID: 298 RVA: 0x000082F4 File Offset: 0x000064F4
		public static int 슟(IntPtr A_0, IntPtr A_1)
		{
			uint num = 0U;
			byte[] array = new byte[4];
			MatchHandler.ReadProcessMemory(A_0, A_1, array, (uint)array.Length, ref num);
			return BitConverter.ToInt32(array, 0);
		}

		// Token: 0x0600012B RID: 299 RVA: 0x00008320 File Offset: 0x00006520
		private string 슟(string A_1)
		{
			string text = A_1.Split(new string[]
			{
				"\0"
			}, StringSplitOptions.None).FirstOrDefault<string>();
			if (text.Contains('\\'))
			{
				text = text.Split('\\', StringSplitOptions.None).Last<string>();
			}
			if (text.Contains("\u0015"))
			{
				text = text.Split("\u0015", StringSplitOptions.None).Last<string>();
				text = text.Substring(0, text.Length - 1);
			}
			return text;
		}

		// Token: 0x040000CC RID: 204
		private Authentication 슟;

		// Token: 0x040000CD RID: 205
		private 슐 슟;

		// Token: 0x040000CE RID: 206
		private MatchInfoDTO 슟;

		// Token: 0x040000CF RID: 207
		private bool 슟;

		// Token: 0x040000D0 RID: 208
		private JsonSerializerSettings 슟;

		// Token: 0x040000D1 RID: 209
		public long 슟;

		// Token: 0x0200002F RID: 47
		[Flags]
		public enum 슟
		{
			// Token: 0x040000D3 RID: 211
			슟 = 16,
			// Token: 0x040000D4 RID: 212
			슖 = 32,
			// Token: 0x040000D5 RID: 213
			슺 = 8
		}
	}
}
