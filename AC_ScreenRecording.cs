using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using FPSCAnticheat.Shared.Models.Upload;
using ScreenRecorderLib;

namespace FPSAC
{
	// Token: 0x02000043 RID: 67
	public class AC_ScreenRecording : AC_ScreenRecordingInterface
	{
		// Token: 0x06000190 RID: 400 RVA: 0x00003AB7 File Offset: 0x00001CB7
		public AC_ScreenRecording(Authentication A_1)
		{
			this.슟 = A_1;
		}

		// Token: 0x06000191 RID: 401 RVA: 0x0000AD30 File Offset: 0x00008F30
		public void 슟(long A_1, IntPtr A_2)
		{
			Recorder recorder = this.슟(A_2);
			recorder.OnRecordingComplete += this.슟;
			recorder.OnRecordingFailed += this.슟;
			MemoryStream memoryStream = new MemoryStream();
			this.슟 = A_1;
			recorder.Record(memoryStream);
			Thread.Sleep(2900);
			recorder.Stop();
			while (!this.슟)
			{
				Thread.Sleep(2000);
			}
			this.슟 = false;
			byte[] array = memoryStream.ToArray();
			if (array.Length != 0)
			{
				string @base = Convert.ToBase64String(array);
				UploadModel uploadModel = new UploadModel
				{
					Type = 슮.슟.싓,
					Payload = new Payload
					{
						Base64 = @base,
						MatchId = A_1
					}
				};
				this.슟.슟(uploadModel).Wait();
				memoryStream.Dispose();
				return;
			}
			string text = "zero bytes so didn't send request";
			string base2 = this.슟(text);
			UploadModel uploadModel2 = new UploadModel
			{
				Type = 슮.슟.싟,
				Payload = new Payload
				{
					Base64 = base2,
					MatchId = this.슟
				}
			};
			this.슟.슟(uploadModel2).Wait();
			memoryStream.Dispose();
		}

		// Token: 0x06000192 RID: 402 RVA: 0x00003AC6 File Offset: 0x00001CC6
		private void 슟(object A_1, RecordingCompleteEventArgs A_2)
		{
			this.슟 = true;
		}

		// Token: 0x06000193 RID: 403 RVA: 0x0000AE50 File Offset: 0x00009050
		private void 슟(object A_1, RecordingFailedEventArgs A_2)
		{
			string error = A_2.Error;
			string @base = this.슟(error);
			UploadModel uploadModel = new UploadModel
			{
				Type = 슮.슟.싟,
				Payload = new Payload
				{
					Base64 = @base,
					MatchId = this.슟
				}
			};
			this.슟.슟(uploadModel).Wait();
		}

		// Token: 0x06000194 RID: 404 RVA: 0x0000AEAC File Offset: 0x000090AC
		private Recorder 슟(IntPtr A_1)
		{
			RecorderOptions recorderOptions = new RecorderOptions();
			recorderOptions.SourceOptions = new SourceOptions
			{
				RecordingSources = new List<RecordingSourceBase>()
			};
			recorderOptions.OutputOptions = new OutputOptions
			{
				RecorderMode = RecorderMode.Video,
				OutputFrameSize = new ScreenSize(720.0, 360.0),
				Stretch = StretchMode.UniformToFill
			};
			recorderOptions.AudioOptions = new AudioOptions
			{
				Bitrate = new AudioBitrate?(AudioBitrate.bitrate_96kbps),
				Channels = new AudioChannels?(AudioChannels.Stereo),
				IsAudioEnabled = new bool?(true)
			};
			recorderOptions.VideoEncoderOptions = new VideoEncoderOptions
			{
				Bitrate = 5500000,
				Framerate = 30,
				IsFixedFramerate = true,
				Encoder = new H264VideoEncoder
				{
					BitrateMode = H264BitrateControlMode.UnconstrainedVBR,
					EncoderProfile = H264Profile.Main
				},
				IsFragmentedMp4Enabled = true,
				IsThrottlingDisabled = false,
				IsHardwareEncodingEnabled = true,
				IsLowLatencyEnabled = true,
				IsMp4FastStartEnabled = false
			};
			recorderOptions.MouseOptions = new MouseOptions
			{
				IsMouseClicksDetected = new bool?(false),
				MouseLeftClickDetectionColor = "#FFFF00",
				MouseRightClickDetectionColor = "#FFFF00",
				MouseClickDetectionRadius = new int?(30),
				MouseClickDetectionDuration = new int?(100),
				IsMousePointerEnabled = new bool?(false),
				MouseClickDetectionMode = MouseDetectionMode.Hook
			};
			recorderOptions.OverlayOptions = new OverLayOptions
			{
				Overlays = new List<RecordingOverlayBase>()
			};
			recorderOptions.SnapshotOptions = new SnapshotOptions
			{
				SnapshotsWithVideo = false,
				SnapshotsIntervalMillis = 1000,
				SnapshotFormat = ImageFormat.PNG,
				SnapshotsDirectory = ""
			};
			recorderOptions.LogOptions = new LogOptions
			{
				IsLogEnabled = false,
				LogFilePath = "recorder.log",
				LogSeverityLevel = LogLevel.Error
			};
			DisplayRecordingSource item = new DisplayRecordingSource(Screen.FromHandle(A_1).DeviceName);
			recorderOptions.SourceOptions.RecordingSources.Add(item);
			return Recorder.CreateRecorder(recorderOptions);
		}

		// Token: 0x06000195 RID: 405 RVA: 0x00003724 File Offset: 0x00001924
		public string 슟(string A_1)
		{
			return Convert.ToBase64String(Encoding.UTF8.GetBytes(A_1));
		}

		// Token: 0x0400014E RID: 334
		private Authentication 슟;

		// Token: 0x0400014F RID: 335
		private bool 슟;

		// Token: 0x04000150 RID: 336
		private long 슟;
	}
}
