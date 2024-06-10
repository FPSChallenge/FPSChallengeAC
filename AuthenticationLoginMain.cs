using System;
using System.IO;
using FPSCAnticheat.Shared.DTO;
using FPSCAnticheat.Shared.Models.Login;
using Newtonsoft.Json;

namespace FPSAC
{
	// Token: 0x0200005F RID: 95
	public class AuthenticationLoginMain : AuthenticationLoginMainInterface
	{
		// Token: 0x0600021D RID: 541 RVA: 0x00003EC8 File Offset: 0x000020C8
		public AuthenticationLoginMain(Authentication A_1, AuthenticationRelatedInterface A_2, AuthenticationCrypticInterface A_3)
		{
			this.슟 = A_1;
			this.슟 = A_2;
			this.슟 = A_3;
		}

		// Token: 0x0600021E RID: 542 RVA: 0x0000CF5C File Offset: 0x0000B15C
		public LoginDataDTO 슟(LoginModel A_1)
		{
			LoginDataDTO loginDataDTO = this.슟.슟(A_1);
			if (loginDataDTO.Success)
			{
				loginDataDTO.Username = A_1.PlayerName;
				loginDataDTO.StayLoggedIn = A_1.StayLoggedIn;
				this.슟.슟(loginDataDTO);
				string text = JsonConvert.SerializeObject(loginDataDTO);
				this.슟(text);
			}
			return loginDataDTO;
		}

		// Token: 0x0600021F RID: 543 RVA: 0x00003EFC File Offset: 0x000020FC
		public LoginDataDTO 슖()
		{
			return this.슟.슟();
		}

		// Token: 0x06000220 RID: 544 RVA: 0x00003F09 File Offset: 0x00002109
		public void 슺()
		{
			if (File.Exists(this.슟))
			{
				File.Delete(this.슟);
			}
			this.슟.슟(null);
		}

		// Token: 0x06000221 RID: 545 RVA: 0x00003F2F File Offset: 0x0000212F
		public void 슟(HardwareDTO A_1)
		{
			this.슟.슟(A_1);
		}

		// Token: 0x06000222 RID: 546 RVA: 0x0000CFB4 File Offset: 0x0000B1B4
		public LoginDataDTO 슟()
		{
			LoginDataDTO loginDataDTO = this.슟.슟();
			if (loginDataDTO != null && this.슟.슟() && !this.슟.슖())
			{
				return null;
			}
			return loginDataDTO;
		}

		// Token: 0x06000223 RID: 547 RVA: 0x00003F3D File Offset: 0x0000213D
		public void 슟(string A_1)
		{
			this.슟.슟(A_1);
		}

		// Token: 0x06000224 RID: 548 RVA: 0x00003F4B File Offset: 0x0000214B
		public VersionDTO 슎()
		{
			return this.슟.슺();
		}

		// Token: 0x040001AC RID: 428
		private string 슟 = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\FPSCAC\\data";

		// Token: 0x040001AD RID: 429
		private readonly Authentication 슟;

		// Token: 0x040001AE RID: 430
		private readonly AuthenticationRelatedInterface 슟;

		// Token: 0x040001AF RID: 431
		private readonly AuthenticationCrypticInterface 슟;
	}
}
