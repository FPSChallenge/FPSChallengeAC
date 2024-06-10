using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using FPSCAnticheat.Shared.DTO;
using Newtonsoft.Json;

namespace FPSAC
{
	// Token: 0x02000047 RID: 71
	public class AuthenticationCryptic : AuthenticationCrypticInterface
	{
		// Token: 0x060001A8 RID: 424 RVA: 0x00003B80 File Offset: 0x00001D80
		public AuthenticationCryptic(AuthenticationRelatedInterface A_1)
		{
			this.슟 = A_1;
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x0000B524 File Offset: 0x00009724
		public LoginDataDTO 슟()
		{
			if (File.Exists(this.슺 + this.슖))
			{
				byte[] bytes = File.ReadAllBytes(this.슺 + this.슖);
				string @string = Encoding.UTF8.GetString(bytes);
				string value = this.슺(@string);
				JsonConvert.DefaultSettings = new Func<JsonSerializerSettings>(AuthenticationCryptic.슟.슟.슟);
				this.슟.슟(JsonConvert.DeserializeObject<LoginDataDTO>(value));
			}
			return this.슟.슟();
		}

		// Token: 0x060001AA RID: 426 RVA: 0x0000B5B4 File Offset: 0x000097B4
		public void 슟(string A_1)
		{
			string s = this.슖(A_1);
			byte[] bytes = Encoding.UTF8.GetBytes(s);
			if (!Directory.Exists(this.슺))
			{
				Directory.CreateDirectory(this.슺);
			}
			File.WriteAllBytes(this.슺 + this.슖, bytes);
		}

		// Token: 0x060001AB RID: 427 RVA: 0x0000B608 File Offset: 0x00009808
		private string 슖(string A_1)
		{
			Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes("Decvaerhacsadfasdfasw2aertgd", AuthenticationCryptic.슟);
			string result;
			using (RijndaelManaged rijndaelManaged = new RijndaelManaged
			{
				Key = rfc2898DeriveBytes.GetBytes(32),
				IV = rfc2898DeriveBytes.GetBytes(16)
			})
			{
				using (MemoryStream memoryStream = new MemoryStream())
				{
					using (CryptoStream cryptoStream = new CryptoStream(memoryStream, rijndaelManaged.CreateEncryptor(), CryptoStreamMode.Write))
					{
						byte[] bytes = Encoding.UTF8.GetBytes(A_1);
						cryptoStream.Write(bytes, 0, bytes.Length);
						cryptoStream.FlushFinalBlock();
						result = Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
					}
				}
			}
			return result;
		}

		// Token: 0x060001AC RID: 428 RVA: 0x0000B6DC File Offset: 0x000098DC
		private string 슺(string A_1)
		{
			Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes("Decvaerhacsadfasdfasw2aertgd", AuthenticationCryptic.슟);
			string @string;
			using (RijndaelManaged rijndaelManaged = new RijndaelManaged
			{
				Padding = PaddingMode.Zeros,
				Key = rfc2898DeriveBytes.GetBytes(32),
				IV = rfc2898DeriveBytes.GetBytes(16)
			})
			{
				using (MemoryStream memoryStream = new MemoryStream())
				{
					using (CryptoStream cryptoStream = new CryptoStream(memoryStream, rijndaelManaged.CreateDecryptor(), CryptoStreamMode.Write))
					{
						byte[] array = Convert.FromBase64String(A_1);
						cryptoStream.Write(array, 0, array.Length);
						cryptoStream.Flush();
						@string = Encoding.UTF8.GetString(memoryStream.ToArray());
					}
				}
			}
			return @string;
		}

		// Token: 0x0400015A RID: 346
		private const string 슟 = "Decvaerhacsadfasdfasw2aertgd";

		// Token: 0x0400015B RID: 347
		private string 슖 = "data";

		// Token: 0x0400015C RID: 348
		private string 슺 = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\FPSCAC\\";

		// Token: 0x0400015D RID: 349
		private readonly AuthenticationRelatedInterface 슟;

		// Token: 0x0400015E RID: 350
		private static byte[] 슟 = new byte[]
		{
			38,
			25,
			129,
			78,
			160,
			109,
			149,
			52,
			38,
			117,
			100,
			5,
			246
		};

		// Token: 0x02000048 RID: 72
		[CompilerGenerated]
		[Serializable]
		private sealed class 슟
		{
			// Token: 0x060001B0 RID: 432 RVA: 0x00003BD6 File Offset: 0x00001DD6
			[슺(1)]
			internal JsonSerializerSettings 슟()
			{
				return new JsonSerializerSettings
				{
					CheckAdditionalContent = false
				};
			}

			// Token: 0x0400015F RID: 351
			public static readonly AuthenticationCryptic.슟 슟 = new AuthenticationCryptic.슟();

			// Token: 0x04000160 RID: 352
			[슖(new byte[]
			{
				0,
				1
			})]
			public static Func<JsonSerializerSettings> 슟;
		}
	}
}
