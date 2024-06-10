using System;
using FPSCAnticheat.Shared.DTO;
using FPSCAnticheat.Shared.Models.Login;

namespace FPSAC
{
	// Token: 0x02000061 RID: 97
	public interface AuthenticationLoginMainInterface
	{
		// Token: 0x0600022B RID: 555
		LoginDataDTO 슟(LoginModel);

		// Token: 0x0600022C RID: 556
		LoginDataDTO 슟();

		// Token: 0x0600022D RID: 557
		LoginDataDTO 슖();

		// Token: 0x0600022E RID: 558
		void 슺();

		// Token: 0x0600022F RID: 559
		void 슟(string);

		// Token: 0x06000230 RID: 560
		void 슟(HardwareDTO);

		// Token: 0x06000231 RID: 561
		VersionDTO 슎();
	}
}
