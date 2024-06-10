using System;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using FPSCAnticheat.Shared.DTO;
using FPSCAnticheat.Shared.Models.Upload;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace FPSAC
{
	// Token: 0x0200002A RID: 42
	public class HWID : HWID_Interface
	{
		// Token: 0x0600010D RID: 269 RVA: 0x00003832 File Offset: 0x00001A32
		public HWID(Authentication A_1, 슼 A_2)
		{
			this.슟 = A_1;
			this.슟 = A_2;
			this.슟 = new JsonSerializerSettings
			{
				ContractResolver = new CamelCasePropertyNamesContractResolver()
			};
		}

		// Token: 0x0600010E RID: 270 RVA: 0x000078B8 File Offset: 0x00005AB8
		public HardwareDTO 슟()
		{
			HardwareDTO hardwareDTO = new 슭().슟().슟(this.슟("Win32_Processor", "ProcessorId"), this.슟("Win32_Processor", "Name")).슖(this.슟("Win32_BIOS", "Manufacturer"), this.슟("Win32_BIOS", "ReleaseDate")).슟(this.슟("Win32_VideoController", "Name")).슺(this.슟("Win32_BaseBoard", "Manufacturer"), this.슟("Win32_BaseBoard", "Product")).슎(this.슟("Win32_DiskDrive", "SerialNumber"), this.슟("Win32_DiskDrive", "Model")).슆(this.슺(), this.슖()).슇(Environment.UserName, this.슎()).슖();
			hardwareDTO = this.슟(hardwareDTO);
			this.슖(hardwareDTO);
			return hardwareDTO;
		}

		// Token: 0x0600010F RID: 271 RVA: 0x000079B0 File Offset: 0x00005BB0
		private HardwareDTO 슟(HardwareDTO A_1)
		{
			A_1.Hwid = this.슟(string.Concat(new string[]
			{
				"CPU >> ",
				A_1.ProcessorId,
				"\nMOTHERBOARD >> ",
				A_1.MotherBoardModel,
				"\nMAC >> ",
				A_1.MacAddress
			}), A_1);
			return A_1;
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00007A0C File Offset: 0x00005C0C
		private void 슖(HardwareDTO A_1)
		{
			string s = JsonConvert.SerializeObject(A_1, this.슟);
			string @base = Convert.ToBase64String(Encoding.UTF8.GetBytes(s));
			UploadModel uploadModel = new UploadModel
			{
				Type = 슮.슟.슎,
				Payload = new Payload
				{
					Base64 = @base,
					MatchId = 0L
				}
			};
			this.슟.슟(uploadModel).Wait();
		}

		// Token: 0x06000111 RID: 273 RVA: 0x00007A70 File Offset: 0x00005C70
		private byte[] 슟(string A_1)
		{
			HashAlgorithm hashAlgorithm = SHA256.Create();
			byte[] array = File.ReadAllBytes(A_1);
			byte[] array2 = new byte[array.Length - 288];
			Array.Copy(array, 288, array2, 0, array2.Length);
			return hashAlgorithm.ComputeHash(array2);
		}

		// Token: 0x06000112 RID: 274 RVA: 0x00007AAC File Offset: 0x00005CAC
		private string 슟(byte[] A_1)
		{
			string text = string.Empty;
			for (int i = 0; i < A_1.Length; i++)
			{
				byte b = A_1[i];
				int num = (int)(b & 15);
				int num2 = b >> 4 & 15;
				text = ((num2 <= 9) ? (text + num2.ToString()) : (text + ((char)(num2 - 10 + 65)).ToString()));
				text = ((num <= 9) ? (text + num.ToString()) : (text + ((char)(num - 10 + 65)).ToString()));
				if (i + 1 != A_1.Length && (i + 1) % 2 == 0)
				{
					text += "-";
				}
			}
			return text;
		}

		// Token: 0x06000113 RID: 275 RVA: 0x00007B58 File Offset: 0x00005D58
		public string 슖(byte[] A_1)
		{
			string text = "";
			foreach (byte b in A_1)
			{
				text += b.ToString("x2");
			}
			return text;
		}

		// Token: 0x06000114 RID: 276 RVA: 0x00007B94 File Offset: 0x00005D94
		private string 슟(string A_1, HardwareDTO A_2)
		{
			MD5 md = new MD5CryptoServiceProvider();
			byte[] bytes = new ASCIIEncoding().GetBytes(A_1);
			return this.슺(md.ComputeHash(bytes));
		}

		// Token: 0x06000115 RID: 277 RVA: 0x00007BC0 File Offset: 0x00005DC0
		private string 슺(byte[] A_1)
		{
			string text = string.Empty;
			for (int i = 0; i < A_1.Length; i++)
			{
				byte b = A_1[i];
				int num = (int)(b & 15);
				int num2 = b >> 4 & 15;
				if (num2 > 9)
				{
					text += ((char)(num2 - 10 + 65)).ToString();
				}
				else
				{
					text += num2.ToString();
				}
				if (num > 9)
				{
					text += ((char)(num - 10 + 65)).ToString();
				}
				else
				{
					text += num.ToString();
				}
				if (i + 1 != A_1.Length && (i + 1) % 2 == 0)
				{
					text += "-";
				}
			}
			return text;
		}

		// Token: 0x06000116 RID: 278 RVA: 0x00007C6C File Offset: 0x00005E6C
		private string 슟(string A_1, string A_2)
		{
			string text = "";
			foreach (ManagementBaseObject managementBaseObject in new ManagementClass(A_1).GetInstances())
			{
				ManagementObject managementObject = (ManagementObject)managementBaseObject;
				if (text == "")
				{
					try
					{
						if (managementObject[A_2] != null)
						{
							text = managementObject[A_2].ToString();
						}
						break;
					}
					catch
					{
					}
				}
			}
			return text;
		}

		// Token: 0x06000117 RID: 279 RVA: 0x00007CF8 File Offset: 0x00005EF8
		private string 슖()
		{
			string result;
			using (WebClient webClient = new WebClient())
			{
				try
				{
					IpDTO ipDTO = JsonConvert.DeserializeObject<IpDTO>(webClient.DownloadString("https://api.myip.com/"));
					result = ipDTO.Ip + " " + ipDTO.Country;
				}
				catch (Exception)
				{
					result = "Cant get ip!";
				}
			}
			return result;
		}

		// Token: 0x06000118 RID: 280 RVA: 0x00007D68 File Offset: 0x00005F68
		private string 슺()
		{
			return NetworkInterface.GetAllNetworkInterfaces().Where(new Func<NetworkInterface, bool>(HWID.슟.슟.슟)).Select(new Func<NetworkInterface, string>(HWID.슟.슟.슖)).FirstOrDefault<string>();
		}

		// Token: 0x06000119 RID: 281 RVA: 0x00007DC8 File Offset: 0x00005FC8
		private string 슎()
		{
			switch (this.슟.슟())
			{
			case 슮.슖.슟:
				return "Unknown";
			case 슮.슖.슖:
				return "Windows_2000";
			case 슮.슖.슺:
				return "Windows_XP";
			case 슮.슖.슎:
				return " Windows_Vista";
			case 슮.슖.슆:
				return "Windows_7";
			case 슮.슖.슇:
				return "Windows_8";
			case 슮.슖.슮:
				return "Windows_8_1";
			case 슮.슖.슠:
				return "Windows_10";
			default:
				return "Unknown";
			}
		}

		// Token: 0x040000C4 RID: 196
		private readonly Authentication 슟;

		// Token: 0x040000C5 RID: 197
		private readonly 슼 슟;

		// Token: 0x040000C6 RID: 198
		private JsonSerializerSettings 슟;

		// Token: 0x0200002B RID: 43
		[CompilerGenerated]
		[Serializable]
		private sealed class 슟
		{
			// Token: 0x0600011C RID: 284 RVA: 0x00007E40 File Offset: 0x00006040
			internal bool 슟(NetworkInterface A_1)
			{
				return A_1.OperationalStatus == OperationalStatus.Up && A_1.NetworkInterfaceType != NetworkInterfaceType.Loopback && A_1.NetworkInterfaceType != NetworkInterfaceType.Tunnel && A_1.NetworkInterfaceType != (NetworkInterfaceType)53 && !A_1.Name.StartsWith("vEthernet") && !A_1.Description.Contains("Hyper-v");
			}

			// Token: 0x0600011D RID: 285 RVA: 0x0000386A File Offset: 0x00001A6A
			internal string 슖(NetworkInterface A_1)
			{
				return A_1.GetPhysicalAddress().ToString();
			}

			// Token: 0x040000C7 RID: 199
			public static readonly HWID.슟 슟 = new HWID.슟();

			// Token: 0x040000C8 RID: 200
			public static Func<NetworkInterface, bool> 슟;

			// Token: 0x040000C9 RID: 201
			public static Func<NetworkInterface, string> 슟;
		}
	}
}
