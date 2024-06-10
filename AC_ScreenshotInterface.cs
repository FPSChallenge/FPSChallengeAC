using System;
using System.Diagnostics;

namespace FPSAC
{
	// Token: 0x02000059 RID: 89
	public interface AC_ScreenshotInterface
	{
		// Token: 0x060001D7 RID: 471
		bool ProcessLonge(Process, long);

		// Token: 0x060001D8 RID: 472
		void LongeProcess(long, Process);
	}
}
