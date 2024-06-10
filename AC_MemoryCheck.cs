using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace FPSAC
{
	// Token: 0x0200001E RID: 30
	public class AC_MemoryCheck : AC_MemoryCheckInterface
	{
		// Token: 0x060000D2 RID: 210
		[DllImport("kernel32.dll")]
		public static extern IntPtr OpenProcess(uint, int, uint);

		// Token: 0x060000D3 RID: 211
		[DllImport("kernel32.dll")]
		public static extern int ReadProcessMemory(IntPtr, IntPtr, [Out] byte[], uint, ref uint);

		// Token: 0x060000D4 RID: 212
		[DllImport("kernel32.dll")]
		public static extern uint GetLastError();

		// Token: 0x060000D5 RID: 213
		[DllImport("kernel32.dll")]
		public static extern void SetLastError(uint);

		// Token: 0x060000D6 RID: 214 RVA: 0x00006864 File Offset: 0x00004A64
		public void 슟(Process A_1)
		{
			int offset = 219584140;
			IntPtr intPtr = A_1.MainModule.BaseAddress + offset;
			IntPtr intPtr2 = AC_MemoryCheck.OpenProcess(16U, 1, (uint)A_1.Id);
			if (intPtr2.ToInt32() == 0)
			{
				return;
			}
			IntPtr intPtr3 = (IntPtr)AC_MemoryCheck.Check(intPtr2, intPtr) + 12;
			if (AC_MemoryCheck.Check(intPtr2, intPtr3) > 1)
			{
				A_1.Kill();
			}
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x000068C8 File Offset: 0x00004AC8
		public static int Check(IntPtr A_0, IntPtr A_1)
		{
			uint num = 0U;
			byte[] array = new byte[4];
			AC_MemoryCheck.ReadProcessMemory(A_0, A_1, array, (uint)array.Length, ref num);
			return BitConverter.ToInt32(array, 0);
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x000068F4 File Offset: 0x00004AF4
		public byte[] Check2(IntPtr A_1, IntPtr A_2, uint A_3, ref uint A_4)
		{
			byte[] array = new byte[A_3];
			AC_MemoryCheck.ReadProcessMemory(A_1, A_2, array, A_3, ref A_4);
			return array;
		}

		// Token: 0x0200001F RID: 31
		[Flags]
		public enum 슟
		{
			// Token: 0x040000A2 RID: 162
			슟 = 16,
			// Token: 0x040000A3 RID: 163
			슖 = 32,
			// Token: 0x040000A4 RID: 164
			슺 = 8
		}
	}
}
