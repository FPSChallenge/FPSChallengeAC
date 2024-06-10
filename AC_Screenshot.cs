using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using FPSCAnticheat.Shared.Models.Upload;
using SharpDX;
using SharpDX.Direct3D11;
using SharpDX.DXGI;

namespace FPSAC
{
	// Token: 0x0200003C RID: 60
	public class AC_Screenshot : AC_ScreenshotInterface
	{
		// Token: 0x06000176 RID: 374
		[DllImport("user32.dll")]
		private static extern bool EnumDisplaySettings(string, int, ref AC_Screenshot.슖);

		// Token: 0x06000177 RID: 375 RVA: 0x0000A374 File Offset: 0x00008574
		public AC_Screenshot(Authentication A_1)
		{
			this.슟 = A_1;
			this.슟 = new EncoderParameters(1);
			this.슟 = new EncoderParameter(this.슟, 70L);
		}

		// Token: 0x06000178 RID: 376 RVA: 0x0000A3F4 File Offset: 0x000085F4
		public bool 슟(Process A_1, long A_2)
		{
			this.슟(false);
			AC_Screenshot.슺.슟 슟 = default(AC_Screenshot.슺.슟);
			if (AC_Screenshot.boolGetForeGroundWindows(A_1.MainWindowHandle))
			{
				AC_Screenshot.슺.GetWindowRect(A_1.MainWindowHandle, ref 슟);
				int num = 슟.슺 - 슟.슟;
				int num2 = 슟.슎 - 슟.슖;
				if (num > 0 && num2 > 0)
				{
					DateTime now = DateTime.Now;
					int hour = now.Hour;
					int minute = now.Minute;
					Bitmap bitmap = new Bitmap(num, num2, PixelFormat.Format32bppArgb);
					using (Graphics graphics = Graphics.FromImage(bitmap))
					{
						graphics.CopyFromScreen(슟.슟, 슟.슖, 0, 0, new Size(num, num2), CopyPixelOperation.SourceCopy);
						using (MemoryStream memoryStream = new MemoryStream())
						{
							Tuple<int, int> tuple = this.슟(bitmap.Height, bitmap.Width);
							Bitmap bitmap2 = new Bitmap(bitmap, new Size(tuple.Item1, tuple.Item2));
							ImageCodecInfo encoder = this.슟("image/jpeg");
							this.슟.Param[0] = this.슟;
							if (!this.슟(bitmap2))
							{
								this.슎 = 0;
								this.슟(this.슖, bitmap2);
								bitmap2.Save(memoryStream, encoder, this.슟);
								string @base = Convert.ToBase64String(memoryStream.ToArray());
								UploadModel uploadModel = new UploadModel
								{
									Type = 슮.슟.슖,
									Payload = new Payload
									{
										Base64 = @base,
										MatchId = A_2
									}
								};
								this.슟.슟(uploadModel).Wait();
							}
							else
							{
								this.슎++;
							}
						}
					}
				}
			}
			return this.슎 > 3;
		}

		// Token: 0x06000179 RID: 377 RVA: 0x0000A5E8 File Offset: 0x000087E8
		private bool 슟(Bitmap A_1)
		{
			Rectangle rect = new Rectangle(0, 0, A_1.Width, A_1.Height);
			BitmapData bitmapData = A_1.LockBits(rect, ImageLockMode.ReadWrite, A_1.PixelFormat);
			IntPtr scan = bitmapData.Scan0;
			int num = bitmapData.Stride * A_1.Height;
			byte[] array = new byte[num];
			Marshal.Copy(scan, array, 0, num);
			bool result = true;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] != array[i % 4])
				{
					result = false;
					break;
				}
			}
			A_1.UnlockBits(bitmapData);
			return result;
		}

		// Token: 0x0600017A RID: 378 RVA: 0x0000A66C File Offset: 0x0000886C
		private Tuple<int, int> 슟(int A_1, int A_2)
		{
			if (A_2 >= this.슟 && A_1 >= this.슖)
			{
				this.슟 = new EncoderParameter(this.슟, 70L);
				double num = (double)this.슟 / (double)A_2;
				double num2 = (double)this.슖 / (double)A_1;
				double num3 = (num < num2) ? num : num2;
				int item = Convert.ToInt32((double)A_1 * num3);
				return new Tuple<int, int>(Convert.ToInt32((double)A_2 * num3), item);
			}
			this.슟 = new EncoderParameter(this.슟, 90L);
			return new Tuple<int, int>(A_2, A_1);
		}

		// Token: 0x0600017B RID: 379
		[DllImport("user32.dll")]
		public static extern bool PrintWindow(IntPtr, IntPtr, uint);

		// Token: 0x0600017C RID: 380
		[DllImport("user32.dll")]
		public static extern IntPtr GetWindowDC(IntPtr);

		// Token: 0x0600017D RID: 381
		[DllImport("user32.dll", SetLastError = true)]
		private static extern IntPtr FindWindow(string, string);

		// Token: 0x0600017E RID: 382 RVA: 0x0000A6F4 File Offset: 0x000088F4
		public Bitmap GetBitMap(IntPtr A_1)
		{
			Rectangle rectangle = Rectangle.Empty;
			using (Graphics graphics = Graphics.FromHdc(AC_Screenshot.GetWindowDC(A_1)))
			{
				rectangle = Rectangle.Round(graphics.VisibleClipBounds);
			}
			Bitmap bitmap = new Bitmap(rectangle.Width, rectangle.Height);
			Graphics graphics2 = Graphics.FromImage(bitmap);
			IntPtr hdc = graphics2.GetHdc();
			try
			{
				AC_Screenshot.PrintWindow(A_1, hdc, 0U);
			}
			finally
			{
				graphics2.ReleaseHdc(hdc);
			}
			return bitmap;
		}

		// Token: 0x0600017F RID: 383 RVA: 0x0000A784 File Offset: 0x00008984
		private ImageCodecInfo 슟(string A_1)
		{
			ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
			for (int i = 0; i < imageEncoders.Length; i++)
			{
				if (imageEncoders[i].MimeType == A_1)
				{
					return imageEncoders[i];
				}
			}
			return null;
		}

		// Token: 0x06000180 RID: 384
		[DllImport("dwmapi.dll")]
		protected static extern uint DwmEnableComposition(uint);

		// Token: 0x06000181 RID: 385 RVA: 0x0000A7BC File Offset: 0x000089BC
		public bool 슟(bool A_1)
		{
			bool result;
			try
			{
				if (A_1)
				{
					AC_Screenshot.DwmEnableComposition(this.슖);
				}
				if (!A_1)
				{
					AC_Screenshot.DwmEnableComposition(this.슟);
				}
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000182 RID: 386
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool SetForegroundWindow(IntPtr);

		// Token: 0x06000183 RID: 387
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool IsIconic(IntPtr);

		// Token: 0x06000184 RID: 388
		[DllImport("user32.dll", EntryPoint = "ShowWindow")]
		internal static extern bool ShowWIndows(IntPtr, AC_Screenshot.슟);

		// Token: 0x06000185 RID: 389
		[DllImport("user32.dll", EntryPoint = "GetForegroundWindow")]
		internal static extern IntPtr GetForeGroundWindow();

		// Token: 0x06000186 RID: 390 RVA: 0x00003A57 File Offset: 0x00001C57
		internal static bool boolGetForeGroundWindows(IntPtr A_0)
		{
			return A_0 == AC_Screenshot.GetForeGroundWindow();
		}

		// Token: 0x06000187 RID: 391 RVA: 0x0000A804 File Offset: 0x00008A04
		public void 슟(long A_1, Process A_2)
		{
			try
			{
				if (AC_Screenshot.boolGetForeGroundWindows(A_2.MainWindowHandle))
				{
					AC_Screenshot.슎 슎 = new AC_Screenshot.슎();
					AC_Screenshot.슺.슟 슟 = default(AC_Screenshot.슺.슟);
					AC_Screenshot.슺.GetWindowRect(A_2.MainWindowHandle, ref 슟);
					int num = 슟.슺 - 슟.슟;
					int num2 = 슟.슎 - 슟.슖;
					슎.슟 = Screen.FromHandle(A_2.MainWindowHandle);
					if (슎.슟 != null)
					{
						Factory1 factory = new Factory1();
						foreach (Adapter1 adapter in factory.Adapters1)
						{
							SharpDX.Direct3D11.Device device = new SharpDX.Direct3D11.Device(adapter);
							IEnumerable<Output> outputs = adapter.Outputs;
							Func<Output, bool> predicate;
							if ((predicate = 슎.슟) == null)
							{
								predicate = (슎.슟 = new Func<Output, bool>(슎.슟));
							}
							Output output = outputs.Where(predicate).FirstOrDefault<Output>();
							if (output != null)
							{
								Output1 output2 = output.QueryInterface<Output1>();
								int num3 = output.Description.DesktopBounds.Right - output.Description.DesktopBounds.Left;
								int num4 = output.Description.DesktopBounds.Bottom - output.Description.DesktopBounds.Top;
								if (num == num3 && num2 == num4 && num4 < num3)
								{
									Texture2DDescription texture2DDescription = default(Texture2DDescription);
									texture2DDescription.CpuAccessFlags = CpuAccessFlags.Read;
									texture2DDescription.BindFlags = BindFlags.None;
									texture2DDescription.Format = Format.B8G8R8A8_UNorm;
									texture2DDescription.Width = num3;
									texture2DDescription.Height = num4;
									texture2DDescription.OptionFlags = ResourceOptionFlags.None;
									texture2DDescription.MipLevels = 1;
									texture2DDescription.ArraySize = 1;
									texture2DDescription.SampleDescription.Count = 1;
									texture2DDescription.SampleDescription.Quality = 0;
									texture2DDescription.Usage = ResourceUsage.Staging;
									Texture2DDescription description = texture2DDescription;
									Texture2D texture2D = new Texture2D(device, description);
									using (OutputDuplication outputDuplication = output2.DuplicateOutput(device))
									{
										try
										{
											Thread.Sleep(2000);
											OutputDuplicateFrameInformation outputDuplicateFrameInformation;
											SharpDX.DXGI.Resource resource;
											if (outputDuplication.TryAcquireNextFrame(5, out outputDuplicateFrameInformation, out resource).Success)
											{
												using (Texture2D texture2D2 = resource.QueryInterface<Texture2D>())
												{
													device.ImmediateContext.CopyResource(texture2D2, texture2D);
												}
												DataBox dataBox = device.ImmediateContext.MapSubresource(texture2D, 0, MapMode.Read, SharpDX.Direct3D11.MapFlags.None);
												using (Bitmap bitmap = new Bitmap(num3, num4, PixelFormat.Format32bppArgb))
												{
													Rectangle rect = new Rectangle(0, 0, num3, num4);
													BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.WriteOnly, bitmap.PixelFormat);
													IntPtr intPtr = dataBox.DataPointer;
													IntPtr intPtr2 = bitmapData.Scan0;
													for (int j = 0; j < num4; j++)
													{
														Utilities.CopyMemory(intPtr2, intPtr, num3 * 4);
														intPtr = IntPtr.Add(intPtr, dataBox.RowPitch);
														intPtr2 = IntPtr.Add(intPtr2, bitmapData.Stride);
													}
													bitmap.UnlockBits(bitmapData);
													device.ImmediateContext.UnmapSubresource(texture2D, 0);
													Tuple<int, int> tuple = this.슟(num4, num3);
													Bitmap bitmap2 = new Bitmap(bitmap, new Size(tuple.Item1, tuple.Item2));
													this.UploadScreenshot(bitmap2, A_1);
												}
												resource.Dispose();
												outputDuplication.ReleaseFrame();
												device.Dispose();
												output.Dispose();
												adapter.Dispose();
											}
										}
										catch (SharpDXException)
										{
										}
									}
								}
							}
						}
						factory.Dispose();
					}
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000188 RID: 392 RVA: 0x0000ABD4 File Offset: 0x00008DD4
		private void UploadScreenshot(Bitmap A_1, long A_2)
		{
			EncoderParameter encoderParameter = this.슟;
			ImageCodecInfo encoder = this.슟("image/jpeg");
			EncoderParameters encoderParameters = new EncoderParameters(1);
			encoderParameters.Param[0] = encoderParameter;
			this.슟(this.슟, A_1);
			using (MemoryStream memoryStream = new MemoryStream())
			{
				A_1.Save(memoryStream, encoder, encoderParameters);
				string @base = Convert.ToBase64String(memoryStream.ToArray());
				UploadModel uploadModel = new UploadModel
				{
					Type = 슮.슟.슖,
					Payload = new Payload
					{
						Base64 = @base,
						MatchId = A_2
					}
				};
				this.슟.슟(uploadModel).Wait();
			}
		}

		// Token: 0x06000189 RID: 393 RVA: 0x0000AC84 File Offset: 0x00008E84
		private Bitmap 슟(string A_1, Bitmap A_2)
		{
			RectangleF layoutRectangle = new RectangleF((float)(A_2.Width - 30), (float)(A_2.Height - 30), 30f, 30f);
			using (Graphics graphics = Graphics.FromImage(A_2))
			{
				graphics.SmoothingMode = SmoothingMode.AntiAlias;
				graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
				graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
				StringFormat format = new StringFormat
				{
					Alignment = StringAlignment.Center,
					LineAlignment = StringAlignment.Center
				};
				graphics.DrawString(A_1, new Font("Arial", 25f), Brushes.DarkGreen, layoutRectangle, format);
				graphics.Flush();
			}
			return A_2;
		}

		// Token: 0x04000110 RID: 272
		private readonly Authentication 슟;

		// Token: 0x04000111 RID: 273
		private Encoder 슟 = Encoder.Quality;

		// Token: 0x04000112 RID: 274
		private EncoderParameters 슟;

		// Token: 0x04000113 RID: 275
		private EncoderParameter 슟;

		// Token: 0x04000114 RID: 276
		private int 슟 = 1600;

		// Token: 0x04000115 RID: 277
		private int 슖 = 900;

		// Token: 0x04000116 RID: 278
		private int 슺 = 70;

		// Token: 0x04000117 RID: 279
		private int 슎;

		// Token: 0x04000118 RID: 280
		private string 슟 = "D";

		// Token: 0x04000119 RID: 281
		private string 슖 = "S";

		// Token: 0x0400011A RID: 282
		public readonly uint 슟;

		// Token: 0x0400011B RID: 283
		public readonly uint 슖 = 1U;

		// Token: 0x0200003D RID: 61
		internal enum 슟 : uint
		{
			// Token: 0x0400011D RID: 285
			슟,
			// Token: 0x0400011E RID: 286
			슖,
			// Token: 0x0400011F RID: 287
			슺,
			// Token: 0x04000120 RID: 288
			슎,
			// Token: 0x04000121 RID: 289
			슆 = 3U,
			// Token: 0x04000122 RID: 290
			슇,
			// Token: 0x04000123 RID: 291
			슮,
			// Token: 0x04000124 RID: 292
			슠,
			// Token: 0x04000125 RID: 293
			싓,
			// Token: 0x04000126 RID: 294
			슔,
			// Token: 0x04000127 RID: 295
			식,
			// Token: 0x04000128 RID: 296
			슭,
			// Token: 0x04000129 RID: 297
			슗
		}

		// Token: 0x0200003E RID: 62
		private struct 슖
		{
			// Token: 0x0400012A RID: 298
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
			public string 슟;

			// Token: 0x0400012B RID: 299
			public short 슟;

			// Token: 0x0400012C RID: 300
			public short 슖;

			// Token: 0x0400012D RID: 301
			public short 슺;

			// Token: 0x0400012E RID: 302
			public short 슎;

			// Token: 0x0400012F RID: 303
			public int 슟;

			// Token: 0x04000130 RID: 304
			public int 슖;

			// Token: 0x04000131 RID: 305
			public int 슺;

			// Token: 0x04000132 RID: 306
			public int 슎;

			// Token: 0x04000133 RID: 307
			public int 슆;

			// Token: 0x04000134 RID: 308
			public short 슆;

			// Token: 0x04000135 RID: 309
			public short 슇;

			// Token: 0x04000136 RID: 310
			public short 슮;

			// Token: 0x04000137 RID: 311
			public short 슠;

			// Token: 0x04000138 RID: 312
			public short 싓;

			// Token: 0x04000139 RID: 313
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
			public string 슖;

			// Token: 0x0400013A RID: 314
			public short 슔;

			// Token: 0x0400013B RID: 315
			public int 슇;

			// Token: 0x0400013C RID: 316
			public int 슮;

			// Token: 0x0400013D RID: 317
			public int 슠;

			// Token: 0x0400013E RID: 318
			public int 싓;

			// Token: 0x0400013F RID: 319
			public int 슔;

			// Token: 0x04000140 RID: 320
			public int 식;

			// Token: 0x04000141 RID: 321
			public int 슭;

			// Token: 0x04000142 RID: 322
			public int 슗;

			// Token: 0x04000143 RID: 323
			public int 슲;

			// Token: 0x04000144 RID: 324
			public int 싖;

			// Token: 0x04000145 RID: 325
			public int 싟;

			// Token: 0x04000146 RID: 326
			public int 슉;

			// Token: 0x04000147 RID: 327
			public int 슒;
		}

		// Token: 0x0200003F RID: 63
		private static class 슺
		{
			// Token: 0x0600018A RID: 394
			[DllImport("user32.dll")]
			public static extern IntPtr GetWindowRect(IntPtr, ref AC_Screenshot.슺.슟);

			// Token: 0x02000040 RID: 64
			public struct 슟
			{
				// Token: 0x04000148 RID: 328
				public int 슟;

				// Token: 0x04000149 RID: 329
				public int 슖;

				// Token: 0x0400014A RID: 330
				public int 슺;

				// Token: 0x0400014B RID: 331
				public int 슎;
			}
		}

		// Token: 0x02000041 RID: 65
		[CompilerGenerated]
		private sealed class 슎
		{
			// Token: 0x0600018C RID: 396 RVA: 0x00003A64 File Offset: 0x00001C64
			internal bool 슟(Output A_1)
			{
				return A_1.Description.DeviceName == this.슟.DeviceName;
			}

			// Token: 0x0400014C RID: 332
			public Screen 슟;

			// Token: 0x0400014D RID: 333
			public Func<Output, bool> 슟;
		}
	}
}
