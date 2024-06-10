using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using FPSCAnticheat.Shared.Models.Upload;
using Newtonsoft.Json;

namespace FPSAC
{
	// Token: 0x02000030 RID: 48
	public class AC_Main : AC_MainInterface
	{
		// Token: 0x0600012C RID: 300 RVA: 0x000038C3 File Offset: 0x00001AC3
		public AC_Main(Authentication A_1)
		{
			this.AuthRelated = A_1;
		}

		// Token: 0x0600012D RID: 301 RVA: 0x00008394 File Offset: 0x00006594
		public void Main(Process A_1, long A_2, bool A_3)
		{
			List<string> list = new List<string>();
			List<string> list2 = new List<string>();
			List<string> list3 = new List<string>();
			List<string> list4 = new List<string>();
			if (this.SomeLong != A_2)
			{
				this.SomeLong = A_2;
				this.SomeList2.Clear();
				this.SomeList.Clear();
				this.SomeList2.Clear();
			}
			if (A_3)
			{
				this.ProcessesMonitoringRelated(A_1, list, list2);
			}
			this.WMIListAllProcesses(list3, list4);
			if (this.SomeBool2)
			{
				List<string> list5 = list;
				int index = 0;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(11, 1);
				defaultInterpolatedStringHandler.AppendLiteral("total game:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.SomeInt2);
				list5.Insert(index, defaultInterpolatedStringHandler.ToStringAndClear());
				string text = JsonConvert.SerializeObject(list);
				string @base = this.ConvertToBase64String(text);
				UploadModel uploadModel = new UploadModel
				{
					Type = 슮.슟.슮,
					Payload = new Payload
					{
						Base64 = @base,
						MatchId = A_2
					}
				};
				this.AuthRelated.슟(uploadModel).Wait();
				string text2 = JsonConvert.SerializeObject(list2);
				@base = this.ConvertToBase64String(text2);
				UploadModel uploadModel2 = new UploadModel
				{
					Type = 슮.슟.슔,
					Payload = new Payload
					{
						Base64 = @base,
						MatchId = A_2
					}
				};
				this.AuthRelated.슟(uploadModel2).Wait();
				list.Clear();
				this.SomeBool2 = false;
			}
			if (this.SomeBool)
			{
				List<string> list6 = list3;
				int index2 = 0;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 1);
				defaultInterpolatedStringHandler.AppendLiteral("total:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.SomeInt);
				list6.Insert(index2, defaultInterpolatedStringHandler.ToStringAndClear());
				string text3 = JsonConvert.SerializeObject(list3);
				string base2 = this.ConvertToBase64String(text3);
				UploadModel uploadModel3 = new UploadModel
				{
					Type = 슮.슟.식,
					Payload = new Payload
					{
						Base64 = base2,
						MatchId = A_2
					}
				};
				this.AuthRelated.슟(uploadModel3).Wait();
				string text4 = JsonConvert.SerializeObject(list4);
				base2 = this.ConvertToBase64String(text4);
				UploadModel uploadModel4 = new UploadModel
				{
					Type = 슮.슟.슔,
					Payload = new Payload
					{
						Base64 = base2,
						MatchId = A_2
					}
				};
				this.AuthRelated.슟(uploadModel4).Wait();
				list3.Clear();
				this.SomeBool = false;
			}
		}

		// Token: 0x0600012E RID: 302 RVA: 0x000085D0 File Offset: 0x000067D0
		public void GameSelectionResult(string A_1, string A_2, long A_3)
		{
			try
			{
				if (!(A_2 == "Call of Duty 4"))
				{
					if (A_2 == "Call of Duty 2")
					{
						this.CoD2Operations(A_1, A_3);
					}
				}
				else
				{
					this.CoD4Operations(A_1, A_3);
				}
			}
			catch (Exception ex)
			{
				string @base = this.ConvertToBase64String("Error:" + A_1 + " " + ex.ToString());
				UploadModel uploadModel = new UploadModel
				{
					Type = 슮.슟.슭,
					Payload = new Payload
					{
						Base64 = @base,
						MatchId = A_3
					}
				};
				this.AuthRelated.슟(uploadModel).Wait();
			}
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00008678 File Offset: 0x00006878
		private void CoD2Operations(string A_1, long A_2)
		{
			AC_Main.슆 슆 = new AC_Main.슆();
			슆.슟 = Path.GetDirectoryName(A_1);
			try
			{
				if (슆.슟.Length > 0)
				{
					string text = JsonConvert.SerializeObject(Directory.GetFiles(슆.슟, "*", SearchOption.AllDirectories).Where(new Func<string, bool>(AC_Main.슎.슟.슟)).ToList<string>().Where(new Func<string, bool>(AC_Main.슎.슟.슖)).ToList<string>().Select(new Func<string, string>(슆.슟)).ToList<string>());
					string @base = this.ConvertToBase64String(text);
					UploadModel uploadModel = new UploadModel
					{
						Type = 슮.슟.슭,
						Payload = new Payload
						{
							Base64 = @base,
							MatchId = A_2
						}
					};
					this.AuthRelated.슟(uploadModel).Wait();
				}
				else
				{
					string base2 = this.ConvertToBase64String("Error:" + A_1);
					UploadModel uploadModel2 = new UploadModel();
					uploadModel2.Type = 슮.슟.슭;
					uploadModel2.Payload = new Payload
					{
						Base64 = base2,
						MatchId = A_2
					};
				}
			}
			catch (UnauthorizedAccessException)
			{
				List<string> list = new List<string>();
				DirectoryInfo directoryInfo = new DirectoryInfo(슆.슟);
				foreach (FileInfo fileInfo in directoryInfo.GetFiles("*".ToLower(), SearchOption.TopDirectoryOnly))
				{
					list.Add(fileInfo.FullName);
				}
				DirectoryInfo[] directories = directoryInfo.GetDirectories();
				try
				{
					DirectoryInfo[] array = directories;
					for (int i = 0; i < array.Length; i++)
					{
						foreach (FileInfo fileInfo2 in array[i].GetFiles("*".ToLower(), SearchOption.AllDirectories))
						{
							list.Add(fileInfo2.FullName);
						}
					}
				}
				catch (Exception)
				{
				}
				string text2 = JsonConvert.SerializeObject(list.Where(new Func<string, bool>(AC_Main.슎.슟.슺)).ToList<string>().Where(new Func<string, bool>(AC_Main.슎.슟.슎)).ToList<string>().Select(new Func<string, string>(슆.슖)).ToList<string>());
				string base3 = this.ConvertToBase64String(text2);
				UploadModel uploadModel3 = new UploadModel
				{
					Type = 슮.슟.슭,
					Payload = new Payload
					{
						Base64 = base3,
						MatchId = A_2
					}
				};
				this.AuthRelated.슟(uploadModel3).Wait();
			}
		}

		// Token: 0x06000130 RID: 304 RVA: 0x0000894C File Offset: 0x00006B4C
		private void CoD4Operations(string A_1, long A_2)
		{
			AC_Main.슇 슇 = new AC_Main.슇();
			슇.슟 = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\CallofDuty4MW\\";
			if (Directory.Exists(슇.슟))
			{
				string text = JsonConvert.SerializeObject(Directory.GetFiles(슇.슟, "*", SearchOption.AllDirectories).Where(new Func<string, bool>(AC_Main.슎.슟.슆)).ToList<string>().Where(new Func<string, bool>(AC_Main.슎.슟.슇)).ToList<string>().Select(new Func<string, string>(슇.슟)).ToList<string>());
				string @base = this.ConvertToBase64String(text);
				UploadModel uploadModel = new UploadModel
				{
					Type = 슮.슟.슭,
					Payload = new Payload
					{
						Base64 = @base,
						MatchId = A_2
					}
				};
				this.AuthRelated.슟(uploadModel).Wait();
			}
			else
			{
				string base2 = this.ConvertToBase64String("Error:" + 슇.슟);
				UploadModel uploadModel2 = new UploadModel();
				uploadModel2.Type = 슮.슟.슭;
				uploadModel2.Payload = new Payload
				{
					Base64 = base2,
					MatchId = A_2
				};
			}
			슇.슖 = Path.GetDirectoryName(A_1);
			try
			{
				if (슇.슖.Length > 0)
				{
					string text2 = JsonConvert.SerializeObject(Directory.GetFiles(슇.슖, "*", SearchOption.AllDirectories).Where(new Func<string, bool>(AC_Main.슎.슟.슮)).ToList<string>().Where(new Func<string, bool>(AC_Main.슎.슟.슠)).ToList<string>().Select(new Func<string, string>(슇.슖)).ToList<string>());
					string base3 = this.ConvertToBase64String(text2);
					UploadModel uploadModel3 = new UploadModel
					{
						Type = 슮.슟.슭,
						Payload = new Payload
						{
							Base64 = base3,
							MatchId = A_2
						}
					};
					this.AuthRelated.슟(uploadModel3).Wait();
				}
				else
				{
					string base4 = this.ConvertToBase64String("Error:" + A_1);
					UploadModel uploadModel4 = new UploadModel();
					uploadModel4.Type = 슮.슟.슭;
					uploadModel4.Payload = new Payload
					{
						Base64 = base4,
						MatchId = A_2
					};
				}
			}
			catch (UnauthorizedAccessException)
			{
				List<string> list = new List<string>();
				DirectoryInfo directoryInfo = new DirectoryInfo(슇.슖);
				foreach (FileInfo fileInfo in directoryInfo.GetFiles("*".ToLower(), SearchOption.TopDirectoryOnly))
				{
					list.Add(fileInfo.FullName);
				}
				DirectoryInfo[] directories = directoryInfo.GetDirectories();
				try
				{
					DirectoryInfo[] array = directories;
					for (int i = 0; i < array.Length; i++)
					{
						foreach (FileInfo fileInfo2 in array[i].GetFiles("*".ToLower(), SearchOption.AllDirectories))
						{
							list.Add(fileInfo2.FullName);
						}
					}
				}
				catch (Exception)
				{
				}
				string text3 = JsonConvert.SerializeObject(list.Where(new Func<string, bool>(AC_Main.슎.슟.싓)).ToList<string>().Where(new Func<string, bool>(AC_Main.슎.슟.슔)).ToList<string>().Select(new Func<string, string>(슇.슺)).ToList<string>());
				string base5 = this.ConvertToBase64String(text3);
				UploadModel uploadModel5 = new UploadModel
				{
					Type = 슮.슟.슭,
					Payload = new Payload
					{
						Base64 = base5,
						MatchId = A_2
					}
				};
				this.AuthRelated.슟(uploadModel5).Wait();
			}
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00008D4C File Offset: 0x00006F4C
		public void GameSelectionRelated(long A_1, string A_2, string A_3)
		{
			try
			{
				if (!(A_2 == "Call of Duty 4"))
				{
					if (A_2 == "Call of Duty 2")
					{
						this.CoD2Operations2(A_1, A_3);
					}
				}
				else
				{
					this.CoD4Operations2(A_1);
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000132 RID: 306 RVA: 0x00008D9C File Offset: 0x00006F9C
		private void CoD4Operations2(long A_1)
		{
			string text = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\CallofDuty4MW\\players\\profiles";
			if (Directory.Exists(text))
			{
				string path = text + "\\active.txt";
				if (File.Exists(path))
				{
					string str = File.ReadAllText(path);
					string path2 = text + "\\" + str + "\\config_mp.cfg";
					if (File.Exists(path2))
					{
						string @base = Convert.ToBase64String(File.ReadAllBytes(path2));
						UploadModel uploadModel = new UploadModel
						{
							Type = 슮.슟.슠,
							Payload = new Payload
							{
								Base64 = @base,
								MatchId = A_1
							}
						};
						this.AuthRelated.슟(uploadModel).Wait();
						return;
					}
				}
				else
				{
					string[] directories = Directory.GetDirectories(text);
					if (directories.Count<string>() > 0)
					{
						string path3 = directories[0] + "\\config_mp.cfg";
						if (File.Exists(path3))
						{
							string base2 = Convert.ToBase64String(File.ReadAllBytes(path3));
							UploadModel uploadModel2 = new UploadModel
							{
								Type = 슮.슟.슠,
								Payload = new Payload
								{
									Base64 = base2,
									MatchId = A_1
								}
							};
							this.AuthRelated.슟(uploadModel2).Wait();
						}
					}
				}
			}
		}

		// Token: 0x06000133 RID: 307 RVA: 0x00008EBC File Offset: 0x000070BC
		private void CoD2Operations2(long A_1, string A_2)
		{
			string text = Path.GetDirectoryName(A_2) + "\\main\\players";
			if (Directory.Exists(text))
			{
				string path = text + "\\active.txt";
				if (File.Exists(path))
				{
					string str = File.ReadAllText(path);
					string path2 = text + "\\" + str + "\\config_mp.cfg";
					if (File.Exists(path2))
					{
						string @base = Convert.ToBase64String(File.ReadAllBytes(path2));
						UploadModel uploadModel = new UploadModel
						{
							Type = 슮.슟.슠,
							Payload = new Payload
							{
								Base64 = @base,
								MatchId = A_1
							}
						};
						this.AuthRelated.슟(uploadModel).Wait();
						return;
					}
				}
				else
				{
					string[] directories = Directory.GetDirectories(text);
					if (directories.Count<string>() > 0)
					{
						string path3 = directories[0] + "\\config_mp.cfg";
						if (File.Exists(path3))
						{
							string base2 = Convert.ToBase64String(File.ReadAllBytes(path3));
							UploadModel uploadModel2 = new UploadModel
							{
								Type = 슮.슟.슠,
								Payload = new Payload
								{
									Base64 = base2,
									MatchId = A_1
								}
							};
							this.AuthRelated.슟(uploadModel2).Wait();
						}
					}
				}
			}
		}

		// Token: 0x06000134 RID: 308 RVA: 0x00008FD8 File Offset: 0x000071D8
		public void GameSelectedAction(string A_1, string A_2, long A_3)
		{
			try
			{
				if (!(A_2 == "Call of Duty 4"))
				{
					if (A_2 == "Call of Duty 2")
					{
						this.CheckHashes(A_1, A_3);
					}
				}
				else
				{
					this.HashComparing(A_1, A_3);
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000135 RID: 309 RVA: 0x00009028 File Offset: 0x00007228
		private void HashComparing(string A_1, long A_2)
		{
			byte[] array = this.ReadFileHashAndCompute(A_1);
			string text = this.SomeParsing(array);
			if (text != VersionAndHashing.슖)
			{
				string @base = this.ConvertToBase64String("Missmatch:" + A_1 + " " + text);
				UploadModel uploadModel = new UploadModel
				{
					Type = 슮.슟.슗,
					Payload = new Payload
					{
						Base64 = @base,
						MatchId = A_2
					}
				};
				this.AuthRelated.슟(uploadModel).Wait();
			}
		}

		// Token: 0x06000136 RID: 310 RVA: 0x000090A4 File Offset: 0x000072A4
		private void CheckHashes(string A_1, long A_2)
		{
			byte[] array = this.ReadFileHashAndCompute(A_1);
			string text = this.SomeParsing(array);
			bool flag = false;
			if (text == VersionAndHashing.슺)
			{
				flag = true;
			}
			if (text == VersionAndHashing.슎)
			{
				flag = true;
			}
			if (!flag)
			{
				string @base = this.ConvertToBase64String("Missmatch:" + A_1 + " " + text);
				UploadModel uploadModel = new UploadModel
				{
					Type = 슮.슟.슗,
					Payload = new Payload
					{
						Base64 = @base,
						MatchId = A_2
					}
				};
				this.AuthRelated.슟(uploadModel).Wait();
			}
		}

		// Token: 0x06000137 RID: 311 RVA: 0x00007A70 File Offset: 0x00005C70
		private byte[] ReadFileHashAndCompute(string A_1)
		{
			HashAlgorithm hashAlgorithm = SHA256.Create();
			byte[] array = File.ReadAllBytes(A_1);
			byte[] array2 = new byte[array.Length - 288];
			Array.Copy(array, 288, array2, 0, array2.Length);
			return hashAlgorithm.ComputeHash(array2);
		}

		// Token: 0x06000138 RID: 312 RVA: 0x00009138 File Offset: 0x00007338
		private string GetHashes(string A_1)
		{
			string result;
			using (MD5 md = MD5.Create())
			{
				using (FileStream fileStream = File.OpenRead(A_1))
				{
					result = BitConverter.ToString(md.ComputeHash(fileStream)).Replace("-", "").ToLowerInvariant();
				}
			}
			return result;
		}

		// Token: 0x06000139 RID: 313 RVA: 0x00007B58 File Offset: 0x00005D58
		public string SomeParsing(byte[] A_1)
		{
			string text = "";
			foreach (byte b in A_1)
			{
				text += b.ToString("x2");
			}
			return text;
		}

		// Token: 0x0600013A RID: 314 RVA: 0x000091A8 File Offset: 0x000073A8
		private void ProcessesMonitoringRelated(Process A_1, List<string> A_2, List<string> A_3)
		{
			try
			{
				List<AC_Main.슺> list = new List<AC_Main.슺>();
				IntPtr[] array = new IntPtr[0];
				int num = 0;
				AC_Main.슖.EnumProcessModulesEx(A_1.Handle, array, 0, out num, 3U);
				int num2 = num / IntPtr.Size;
				array = new IntPtr[num2];
				if (AC_Main.슖.EnumProcessModulesEx(A_1.Handle, array, num, out num, 3U))
				{
					for (int i = 0; i < num2; i++)
					{
						try
						{
							StringBuilder stringBuilder = new StringBuilder(1024);
							AC_Main.슖.GetModuleFileNameEx(A_1.Handle, array[i], stringBuilder, 1024U);
							StringBuilder stringBuilder2 = new StringBuilder(1024);
							AC_Main.슖.GetMappedFileNameA(A_1.Handle, array[i], stringBuilder2, 1024U);
							StringBuilder stringBuilder3 = new StringBuilder(1024);
							AC_Main.슖.GetModuleBaseName(A_1.Handle, array[i], stringBuilder3, 1024U);
							string hashes = this.GetHashes(stringBuilder.ToString());
							string fileName = Path.GetFileName(stringBuilder.ToString());
							string fileName2 = Path.GetFileName(stringBuilder2.ToString());
							string fileName3 = Path.GetFileName(stringBuilder3.ToString());
							AC_Main.슖.슟 슟 = default(AC_Main.슖.슟);
							AC_Main.슖.GetModuleInformation(A_1.Handle, array[i], out 슟, (uint)(IntPtr.Size * array.Length));
							AC_Main.슺 item = new AC_Main.슺(fileName, fileName2, fileName3, 슟.슟, 슟.슟, hashes);
							list.Add(item);
						}
						catch (Exception)
						{
						}
					}
				}
				this.SomeInt2 = 0;
				foreach (AC_Main.슺 슺 in list)
				{
					try
					{
						if (!this.SomeList2.Contains(슺.슟()))
						{
							this.SomeInt2++;
							this.SomeList2.Add(슺.슟());
							A_2.Add(string.Concat(new string[]
							{
								슺.슟(),
								" ",
								슺.슺(),
								" ",
								슺.슖()
							}));
							A_3.Add(슺.슇());
							string a = 슺.슟().ToLower();
							if (a == "owclient.dll" || a == "owexplorer.dll" || a == "graphics-hook32.dll" || a == "gameoverlayrenderer.dll" || a == "d3d9.dll")
							{
								this.OverlayChecking(슺.슟(), A_1);
							}
							this.SomeBool2 = true;
						}
					}
					catch (Exception)
					{
					}
				}
				foreach (object obj in A_1.Modules)
				{
					ProcessModule processModule = (ProcessModule)obj;
					try
					{
						if (!this.SomeList2.Contains(processModule.ModuleName))
						{
							this.SomeInt2++;
							this.SomeList2.Add(processModule.ModuleName);
							A_2.Append(processModule.ModuleName);
							this.SomeBool2 = true;
						}
					}
					catch (Exception)
					{
					}
				}
			}
			catch (Exception ex)
			{
				string @base = this.ConvertToBase64String("Error reading processes: " + ex.ToString());
				UploadModel uploadModel = new UploadModel
				{
					Type = 슮.슟.슮,
					Payload = new Payload
					{
						Base64 = @base,
						MatchId = this.SomeLong
					}
				};
				this.AuthRelated.슟(uploadModel).Wait();
			}
		}

		// Token: 0x0600013B RID: 315 RVA: 0x000095A4 File Offset: 0x000077A4
		private void OverlayChecking(string A_1, Process A_2)
		{
			try
			{
				foreach (object obj in A_2.Modules)
				{
					ProcessModule processModule = (ProcessModule)obj;
					if (processModule.ModuleName == A_1)
					{
						string value = (processModule != null) ? processModule.FileName : null;
						string text;
						if (processModule == null)
						{
							text = null;
						}
						else
						{
							FileVersionInfo fileVersionInfo = processModule.FileVersionInfo;
							text = ((fileVersionInfo != null) ? fileVersionInfo.FileVersion : null);
						}
						string value2 = text;
						string text2;
						if (processModule == null)
						{
							text2 = null;
						}
						else
						{
							FileVersionInfo fileVersionInfo2 = processModule.FileVersionInfo;
							text2 = ((fileVersionInfo2 != null) ? fileVersionInfo2.FileDescription : null);
						}
						string value3 = text2;
						string text3;
						if (processModule == null)
						{
							text3 = null;
						}
						else
						{
							FileVersionInfo fileVersionInfo3 = processModule.FileVersionInfo;
							text3 = ((fileVersionInfo3 != null) ? fileVersionInfo3.ProductName : null);
						}
						string value4 = text3;
						bool? value5 = (processModule != null) ? new bool?(processModule.FileVersionInfo.IsPatched) : null;
						string text4;
						if (processModule == null)
						{
							text4 = null;
						}
						else
						{
							FileVersionInfo fileVersionInfo4 = processModule.FileVersionInfo;
							text4 = ((fileVersionInfo4 != null) ? fileVersionInfo4.OriginalFilename : null);
						}
						string value6 = text4;
						int moduleMemorySize = processModule.ModuleMemorySize;
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(23, 7);
						defaultInterpolatedStringHandler.AppendLiteral("Overlay ");
						defaultInterpolatedStringHandler.AppendFormatted(value);
						defaultInterpolatedStringHandler.AppendLiteral(" , ");
						defaultInterpolatedStringHandler.AppendFormatted(value2);
						defaultInterpolatedStringHandler.AppendLiteral(" , ");
						defaultInterpolatedStringHandler.AppendFormatted(value3);
						defaultInterpolatedStringHandler.AppendLiteral(", ");
						defaultInterpolatedStringHandler.AppendFormatted(value4);
						defaultInterpolatedStringHandler.AppendLiteral(", ");
						defaultInterpolatedStringHandler.AppendFormatted<bool?>(value5);
						defaultInterpolatedStringHandler.AppendLiteral(" , ");
						defaultInterpolatedStringHandler.AppendFormatted(value6);
						defaultInterpolatedStringHandler.AppendLiteral(", ");
						defaultInterpolatedStringHandler.AppendFormatted<int>(moduleMemorySize);
						string @base = this.ConvertToBase64String(defaultInterpolatedStringHandler.ToStringAndClear());
						UploadModel uploadModel = new UploadModel
						{
							Type = 슮.슟.슲,
							Payload = new Payload
							{
								Base64 = @base,
								MatchId = this.SomeLong
							}
						};
						this.AuthRelated.슟(uploadModel).Wait();
					}
				}
			}
			catch (Exception value7)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(24, 2);
				defaultInterpolatedStringHandler.AppendLiteral("Error reading overlay ");
				defaultInterpolatedStringHandler.AppendFormatted(A_1);
				defaultInterpolatedStringHandler.AppendLiteral(", ");
				defaultInterpolatedStringHandler.AppendFormatted<Exception>(value7);
				string base2 = this.ConvertToBase64String(defaultInterpolatedStringHandler.ToStringAndClear());
				UploadModel uploadModel2 = new UploadModel
				{
					Type = 슮.슟.슲,
					Payload = new Payload
					{
						Base64 = base2,
						MatchId = this.SomeLong
					}
				};
				this.AuthRelated.슟(uploadModel2).Wait();
			}
		}

		// Token: 0x0600013C RID: 316 RVA: 0x00009848 File Offset: 0x00007A48
		private void WMIListAllProcesses(List<string> A_1, List<string> A_2)
		{
			this.SomeInt = 0;
			try
			{
				using (ManagementObjectCollection managementObjectCollection = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Process").Get())
				{
					foreach (ManagementBaseObject managementBaseObject in managementObjectCollection)
					{
						ManagementObject managementObject = (ManagementObject)managementBaseObject;
						PropertyData propertyData = managementObject.Properties["Caption"];
						List<string> someList = this.SomeList;
						string item;
						if (propertyData == null)
						{
							item = null;
						}
						else
						{
							object value = propertyData.Value;
							item = ((value != null) ? value.ToString() : null);
						}
						if (!someList.Contains(item))
						{
							if (propertyData.Value != null)
							{
								this.SomeInt++;
								this.SomeList.Add(propertyData.Value.ToString());
								A_1.Add(propertyData.Value.ToString());
							}
							PropertyData propertyData2 = managementObject.Properties["ExecutablePath"];
							if (propertyData2.Value != null)
							{
								string text = propertyData2.Value.ToString();
								if (File.Exists(text))
								{
									string hashes = this.GetHashes(text);
									A_2.Add(hashes);
								}
							}
							this.SomeBool = true;
						}
					}
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x0600013D RID: 317 RVA: 0x000099C0 File Offset: 0x00007BC0
		private void ListSomeModules(StringBuilder A_1)
		{
			this.SomeInt3 = 0;
			foreach (object obj in Process.GetCurrentProcess().Modules)
			{
				ProcessModule processModule = (ProcessModule)obj;
				if (!this.SomeList2.Contains(processModule.ModuleName))
				{
					try
					{
						this.SomeInt3++;
						this.SomeList2.Add(processModule.ModuleName);
						A_1.Append(processModule.ModuleName);
						this.SomeBool3 = true;
					}
					catch (Exception)
					{
					}
				}
			}
		}

		// Token: 0x0600013E RID: 318 RVA: 0x00003724 File Offset: 0x00001924
		private string ConvertToBase64String(string A_1)
		{
			return Convert.ToBase64String(Encoding.UTF8.GetBytes(A_1));
		}

		// Token: 0x040000D6 RID: 214
		private readonly Authentication AuthRelated;

		// Token: 0x040000D7 RID: 215
		public List<string> SomeList2 = new List<string>();

		// Token: 0x040000D8 RID: 216
		public List<string> SomeList = new List<string>();

		// Token: 0x040000D9 RID: 217
		public List<string> SomeList2 = new List<string>();

		// Token: 0x040000DA RID: 218
		public long SomeLong;

		// Token: 0x040000DB RID: 219
		public bool SomeBool2;

		// Token: 0x040000DC RID: 220
		public bool SomeBool;

		// Token: 0x040000DD RID: 221
		public bool SomeBool3;

		// Token: 0x040000DE RID: 222
		public int SomeInt2;

		// Token: 0x040000DF RID: 223
		public int SomeInt;

		// Token: 0x040000E0 RID: 224
		public int SomeInt3;

		// Token: 0x02000031 RID: 49
		public class 슟
		{
			// Token: 0x0600013F RID: 319 RVA: 0x000038F3 File Offset: 0x00001AF3
			[CompilerGenerated]
			public string 슟()
			{
				return this.슟;
			}

			// Token: 0x06000140 RID: 320 RVA: 0x000038FB File Offset: 0x00001AFB
			[CompilerGenerated]
			public void 슟(string A_1)
			{
				this.슟 = A_1;
			}

			// Token: 0x040000E1 RID: 225
			[CompilerGenerated]
			private string 슟;
		}

		// Token: 0x02000032 RID: 50
		public class 슖
		{
			// Token: 0x06000142 RID: 322
			[DllImport("psapi.dll")]
			public static extern uint GetModuleBaseName(IntPtr, IntPtr, [Out] StringBuilder, [MarshalAs(UnmanagedType.U4)] [In] uint);

			// Token: 0x06000143 RID: 323
			[DllImport("psapi.dll")]
			public static extern bool EnumProcessModulesEx(IntPtr, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U4)] [In] [Out] IntPtr[], int, [MarshalAs(UnmanagedType.U4)] out int, uint);

			// Token: 0x06000144 RID: 324
			[DllImport("psapi.dll")]
			public static extern uint GetModuleFileNameEx(IntPtr, IntPtr, [Out] StringBuilder, [MarshalAs(UnmanagedType.U4)] [In] uint);

			// Token: 0x06000145 RID: 325
			[DllImport("psapi.dll")]
			public static extern uint GetProcessImageFileNameA(IntPtr, IntPtr, [Out] StringBuilder, [MarshalAs(UnmanagedType.U4)] [In] uint);

			// Token: 0x06000146 RID: 326
			[DllImport("psapi.dll")]
			public static extern uint GetMappedFileNameA(IntPtr, IntPtr, [Out] StringBuilder, [MarshalAs(UnmanagedType.U4)] [In] uint);

			// Token: 0x06000147 RID: 327
			[DllImport("psapi.dll", SetLastError = true)]
			public static extern bool GetModuleInformation(IntPtr, IntPtr, out AC_Main.슖.슟, uint);

			// Token: 0x02000033 RID: 51
			public struct 슟
			{
				// Token: 0x040000E2 RID: 226
				public IntPtr 슟;

				// Token: 0x040000E3 RID: 227
				public uint 슟;

				// Token: 0x040000E4 RID: 228
				public IntPtr 슖;
			}

			// Token: 0x02000034 RID: 52
			internal enum 슖
			{
				// Token: 0x040000E6 RID: 230
				슟,
				// Token: 0x040000E7 RID: 231
				슖,
				// Token: 0x040000E8 RID: 232
				슺,
				// Token: 0x040000E9 RID: 233
				슎
			}
		}

		// Token: 0x02000035 RID: 53
		public class 슺
		{
			// Token: 0x06000149 RID: 329 RVA: 0x00003904 File Offset: 0x00001B04
			public 슺(string A_1, string A_2, string A_3, IntPtr A_4, uint A_5, string A_6)
			{
				this.슟(A_1);
				this.슖(A_2);
				this.슟(A_4);
				this.슺(A_3);
				this.슟(A_5);
				this.슎(A_6);
			}

			// Token: 0x0600014A RID: 330 RVA: 0x00003939 File Offset: 0x00001B39
			[CompilerGenerated]
			public string 슟()
			{
				return this.슟;
			}

			// Token: 0x0600014B RID: 331 RVA: 0x00003941 File Offset: 0x00001B41
			[CompilerGenerated]
			public void 슟(string A_1)
			{
				this.슟 = A_1;
			}

			// Token: 0x0600014C RID: 332 RVA: 0x0000394A File Offset: 0x00001B4A
			[CompilerGenerated]
			public string 슖()
			{
				return this.슖;
			}

			// Token: 0x0600014D RID: 333 RVA: 0x00003952 File Offset: 0x00001B52
			[CompilerGenerated]
			public void 슖(string A_1)
			{
				this.슖 = A_1;
			}

			// Token: 0x0600014E RID: 334 RVA: 0x0000395B File Offset: 0x00001B5B
			[CompilerGenerated]
			public string 슺()
			{
				return this.슺;
			}

			// Token: 0x0600014F RID: 335 RVA: 0x00003963 File Offset: 0x00001B63
			[CompilerGenerated]
			public void 슺(string A_1)
			{
				this.슺 = A_1;
			}

			// Token: 0x06000150 RID: 336 RVA: 0x0000396C File Offset: 0x00001B6C
			[CompilerGenerated]
			public IntPtr 슎()
			{
				return this.슟;
			}

			// Token: 0x06000151 RID: 337 RVA: 0x00003974 File Offset: 0x00001B74
			[CompilerGenerated]
			public void 슟(IntPtr A_1)
			{
				this.슟 = A_1;
			}

			// Token: 0x06000152 RID: 338 RVA: 0x0000397D File Offset: 0x00001B7D
			[CompilerGenerated]
			public uint 슆()
			{
				return this.슟;
			}

			// Token: 0x06000153 RID: 339 RVA: 0x00003985 File Offset: 0x00001B85
			[CompilerGenerated]
			public void 슟(uint A_1)
			{
				this.슟 = A_1;
			}

			// Token: 0x06000154 RID: 340 RVA: 0x0000398E File Offset: 0x00001B8E
			[CompilerGenerated]
			public string 슇()
			{
				return this.슎;
			}

			// Token: 0x06000155 RID: 341 RVA: 0x00003996 File Offset: 0x00001B96
			[CompilerGenerated]
			public void 슎(string A_1)
			{
				this.슎 = A_1;
			}

			// Token: 0x040000EA RID: 234
			[CompilerGenerated]
			private string 슟;

			// Token: 0x040000EB RID: 235
			[CompilerGenerated]
			private string 슖;

			// Token: 0x040000EC RID: 236
			[CompilerGenerated]
			private string 슺;

			// Token: 0x040000ED RID: 237
			[CompilerGenerated]
			private IntPtr 슟;

			// Token: 0x040000EE RID: 238
			[CompilerGenerated]
			private uint 슟;

			// Token: 0x040000EF RID: 239
			[CompilerGenerated]
			private string 슎;
		}

		// Token: 0x02000036 RID: 54
		[CompilerGenerated]
		[Serializable]
		private sealed class 슎
		{
			// Token: 0x06000158 RID: 344 RVA: 0x000039AB File Offset: 0x00001BAB
			internal bool 슟(string A_1)
			{
				return !A_1.Contains(".dm_1");
			}

			// Token: 0x06000159 RID: 345 RVA: 0x000039BB File Offset: 0x00001BBB
			internal bool 슖(string A_1)
			{
				return !A_1.Contains(".jpg");
			}

			// Token: 0x0600015A RID: 346 RVA: 0x000039AB File Offset: 0x00001BAB
			internal bool 슺(string A_1)
			{
				return !A_1.Contains(".dm_1");
			}

			// Token: 0x0600015B RID: 347 RVA: 0x000039BB File Offset: 0x00001BBB
			internal bool 슎(string A_1)
			{
				return !A_1.Contains(".jpg");
			}

			// Token: 0x0600015C RID: 348 RVA: 0x000039AB File Offset: 0x00001BAB
			internal bool 슆(string A_1)
			{
				return !A_1.Contains(".dm_1");
			}

			// Token: 0x0600015D RID: 349 RVA: 0x000039BB File Offset: 0x00001BBB
			internal bool 슇(string A_1)
			{
				return !A_1.Contains(".jpg");
			}

			// Token: 0x0600015E RID: 350 RVA: 0x000039AB File Offset: 0x00001BAB
			internal bool 슮(string A_1)
			{
				return !A_1.Contains(".dm_1");
			}

			// Token: 0x0600015F RID: 351 RVA: 0x000039BB File Offset: 0x00001BBB
			internal bool 슠(string A_1)
			{
				return !A_1.Contains(".jpg");
			}

			// Token: 0x06000160 RID: 352 RVA: 0x000039AB File Offset: 0x00001BAB
			internal bool 싓(string A_1)
			{
				return !A_1.Contains(".dm_1");
			}

			// Token: 0x06000161 RID: 353 RVA: 0x000039BB File Offset: 0x00001BBB
			internal bool 슔(string A_1)
			{
				return !A_1.Contains(".jpg");
			}

			// Token: 0x040000F0 RID: 240
			public static readonly AC_Main.슎 슟 = new AC_Main.슎();

			// Token: 0x040000F1 RID: 241
			public static Func<string, bool> 슟;

			// Token: 0x040000F2 RID: 242
			public static Func<string, bool> 슖;

			// Token: 0x040000F3 RID: 243
			public static Func<string, bool> 슺;

			// Token: 0x040000F4 RID: 244
			public static Func<string, bool> 슎;

			// Token: 0x040000F5 RID: 245
			public static Func<string, bool> 슆;

			// Token: 0x040000F6 RID: 246
			public static Func<string, bool> 슇;

			// Token: 0x040000F7 RID: 247
			public static Func<string, bool> 슮;

			// Token: 0x040000F8 RID: 248
			public static Func<string, bool> 슠;

			// Token: 0x040000F9 RID: 249
			public static Func<string, bool> 싓;

			// Token: 0x040000FA RID: 250
			public static Func<string, bool> 슔;
		}

		// Token: 0x02000037 RID: 55
		[CompilerGenerated]
		private sealed class 슆
		{
			// Token: 0x06000163 RID: 355 RVA: 0x000039CB File Offset: 0x00001BCB
			internal string 슟(string A_1)
			{
				return A_1.Replace(this.슟, "");
			}

			// Token: 0x06000164 RID: 356 RVA: 0x000039CB File Offset: 0x00001BCB
			internal string 슖(string A_1)
			{
				return A_1.Replace(this.슟, "");
			}

			// Token: 0x040000FB RID: 251
			public string 슟;
		}

		// Token: 0x02000038 RID: 56
		[CompilerGenerated]
		private sealed class 슇
		{
			// Token: 0x06000166 RID: 358 RVA: 0x000039DE File Offset: 0x00001BDE
			internal string 슟(string A_1)
			{
				return A_1.Replace(this.슟, "");
			}

			// Token: 0x06000167 RID: 359 RVA: 0x000039F1 File Offset: 0x00001BF1
			internal string 슖(string A_1)
			{
				return A_1.Replace(this.슖, "");
			}

			// Token: 0x06000168 RID: 360 RVA: 0x000039F1 File Offset: 0x00001BF1
			internal string 슺(string A_1)
			{
				return A_1.Replace(this.슖, "");
			}

			// Token: 0x040000FC RID: 252
			public string 슟;

			// Token: 0x040000FD RID: 253
			public string 슖;
		}
	}
}
