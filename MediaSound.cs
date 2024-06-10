using System;
using System.Media;
using System.Reflection;

namespace FPSAC
{
	// Token: 0x02000042 RID: 66
	public class MediaSound : 싚
	{
		// Token: 0x0600018D RID: 397 RVA: 0x00003A81 File Offset: 0x00001C81
		public void 슟()
		{
			new SoundPlayer(Assembly.GetExecutingAssembly().GetManifestResourceStream("FPSCAnticheat.Services.Sounds.started.wav")).Play();
		}

		// Token: 0x0600018E RID: 398 RVA: 0x00003A9C File Offset: 0x00001C9C
		public void 슖()
		{
			new SoundPlayer(Assembly.GetExecutingAssembly().GetManifestResourceStream("FPSCAnticheat.Services.Sounds.stopped.wav")).Play();
		}
	}
}
