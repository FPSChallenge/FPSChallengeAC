using System;
using System.Diagnostics;

namespace FPSAC
{
	// Token: 0x02000020 RID: 32
	public class TargetProcessArch : 슲
	{
		// Token: 0x060000DA RID: 218 RVA: 0x00006918 File Offset: 0x00004B18
		public void SetProcessorAffinity(Process A_1)
		{
			try
			{
				A_1.ProcessorAffinity = (IntPtr)((1 << Environment.ProcessorCount) - 1);
			}
			catch (Exception)
			{
			}
		}
	}
}
