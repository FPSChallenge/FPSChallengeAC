using System;
using System.Threading.Tasks;
using FPSCAnticheat.Shared.DTO;
using FPSCAnticheat.Shared.Models.Heartbeat;
using FPSCAnticheat.Shared.Models.Login;
using FPSCAnticheat.Shared.Models.Upload;

namespace FPSAC
{
	// Token: 0x02000057 RID: 87
	public interface Authentication
	{
		// Token: 0x060001CD RID: 461
		Task 슟(UploadModel);

		// Token: 0x060001CE RID: 462
		LoginDataDTO 슟(LoginModel);

		// Token: 0x060001CF RID: 463
		bool 슟();

		// Token: 0x060001D0 RID: 464
		bool 슖();

		// Token: 0x060001D1 RID: 465
		void 슟(HeartBeatModel);

		// Token: 0x060001D2 RID: 466
		VersionDTO 슺();
	}
}
