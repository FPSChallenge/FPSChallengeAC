using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FPSCAnticheat.Shared.DTO;
using FPSCAnticheat.Shared.Models.Heartbeat;
using FPSCAnticheat.Shared.Models.Login;
using FPSCAnticheat.Shared.Models.Upload;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace FPSAC
{
	// Token: 0x02000039 RID: 57
	public class Authentication : Authentication
	{
		// Token: 0x06000169 RID: 361 RVA: 0x00003A04 File Offset: 0x00001C04
		public Authentication(AuthenticationRelatedInterface A_1, AuthenticationCrypticInterface A_2)
		{
			this.슟 = A_1;
			this.슟 = A_2;
			this.슟 = new JsonSerializerSettings
			{
				ContractResolver = new CamelCasePropertyNamesContractResolver()
			};
		}

		// Token: 0x0600016A RID: 362 RVA: 0x00009A74 File Offset: 0x00007C74
		public Task 슟(UploadModel A_1)
		{
			Authentication.슖 슖;
			슖.슟 = AsyncTaskMethodBuilder.Create();
			슖.슟 = this;
			슖.슟 = A_1;
			슖.슟 = -1;
			슖.슟.Start<Authentication.슖>(ref 슖);
			return 슖.슟.Task;
		}

		// Token: 0x0600016B RID: 363 RVA: 0x00009AC0 File Offset: 0x00007CC0
		public LoginDataDTO 슟(LoginModel A_1)
		{
			LoginDataDTO result2;
			using (HttpClient httpClient = new HttpClient())
			{
				try
				{
					A_1.VersionGuid = VersionAndHashing.슟;
					StringContent content = new StringContent(JsonConvert.SerializeObject(A_1, this.슟), Encoding.UTF8, "application/json");
					HttpResponseMessage result = httpClient.PostAsync(this.슟 + "/api/login", content).Result;
					if (result.IsSuccessStatusCode)
					{
						LoginDataDTO loginDataDTO = JsonConvert.DeserializeObject<LoginDataDTO>(result.Content.ReadAsStringAsync().Result);
						loginDataDTO.Success = true;
						result2 = loginDataDTO;
					}
					else if (result.StatusCode == HttpStatusCode.Forbidden)
					{
						LoginDataDTO loginDataDTO2 = JsonConvert.DeserializeObject<LoginDataDTO>(result.Content.ReadAsStringAsync().Result);
						loginDataDTO2.Success = false;
						result2 = loginDataDTO2;
					}
					else
					{
						result2 = new LoginDataDTO
						{
							Success = false
						};
					}
				}
				catch (Exception)
				{
					result2 = new LoginDataDTO
					{
						Success = false,
						ErrorMessage = "Anticheat seems to be offline"
					};
				}
			}
			return result2;
		}

		// Token: 0x0600016C RID: 364 RVA: 0x00009BBC File Offset: 0x00007DBC
		public VersionDTO 슺()
		{
			VersionDTO result2;
			try
			{
				if (this.슟())
				{
					this.슖();
				}
				using (HttpClient httpClient = new HttpClient())
				{
					httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.슟.슟().Access_token);
					HttpResponseMessage result = httpClient.GetAsync(this.슟 + "/api/version").Result;
					if (result.IsSuccessStatusCode)
					{
						VersionDTO versionDTO = JsonConvert.DeserializeObject<VersionDTO>(result.Content.ReadAsStringAsync().Result);
						versionDTO.Success = true;
						result2 = versionDTO;
					}
					else if (result.StatusCode == HttpStatusCode.Forbidden)
					{
						VersionDTO versionDTO2 = JsonConvert.DeserializeObject<VersionDTO>(result.Content.ReadAsStringAsync().Result);
						versionDTO2.Success = false;
						result2 = versionDTO2;
					}
					else
					{
						result2 = new VersionDTO
						{
							Success = false,
							Logout = true
						};
					}
				}
			}
			catch (Exception)
			{
				result2 = new VersionDTO
				{
					Success = false,
					Logout = true
				};
			}
			return result2;
		}

		// Token: 0x0600016D RID: 365 RVA: 0x00009CC8 File Offset: 0x00007EC8
		public void 슟(HeartBeatModel A_1)
		{
			try
			{
				if (this.슟())
				{
					this.슖();
				}
				StringContent content = new StringContent(JsonConvert.SerializeObject(A_1, this.슟), Encoding.UTF8, "application/json");
				using (HttpClient httpClient = new HttpClient())
				{
					httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.슟.슟().Access_token);
					HttpResponseMessage result = httpClient.PostAsync(this.슟 + "/api/heartbeat", content).Result;
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x0600016E RID: 366 RVA: 0x00009D78 File Offset: 0x00007F78
		public bool 슖()
		{
			bool result2;
			try
			{
				using (HttpClient httpClient = new HttpClient())
				{
					httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.슟.슟().Refresh_token);
					StringContent content = new StringContent("", Encoding.UTF8, "application/json");
					HttpResponseMessage result = httpClient.PostAsync(this.슟 + "/api/refresh", content).Result;
					if (result.IsSuccessStatusCode)
					{
						this.슟.슟().IsRefreshing = true;
						LoginDataDTO loginDataDTO = JsonConvert.DeserializeObject<LoginDataDTO>(result.Content.ReadAsStringAsync().Result);
						this.슟.슟().Access_token = loginDataDTO.Access_token;
						this.슟.슟().Refresh_token = loginDataDTO.Refresh_token;
						this.슟.슟().Expires_in = loginDataDTO.Expires_in;
						string text = JsonConvert.SerializeObject(this.슟.슟());
						this.슟.슟(text);
						result2 = true;
					}
					else
					{
						result2 = false;
					}
				}
			}
			catch (Exception)
			{
				result2 = false;
			}
			return result2;
		}

		// Token: 0x0600016F RID: 367 RVA: 0x00009EC8 File Offset: 0x000080C8
		private Task 슟(string A_1)
		{
			Authentication.슟 슟;
			슟.슟 = AsyncTaskMethodBuilder.Create();
			슟.슟 = this;
			슟.슟 = A_1;
			슟.슟 = -1;
			슟.슟.Start<Authentication.슟>(ref 슟);
			return 슟.슟.Task;
		}

		// Token: 0x06000170 RID: 368 RVA: 0x00009F14 File Offset: 0x00008114
		public bool 슟()
		{
			DateTime t = this.슟.슟().ExpireTime.Value.AddMinutes(-5.0);
			return DateTime.Now > t;
		}

		// Token: 0x06000171 RID: 369 RVA: 0x00003724 File Offset: 0x00001924
		public string 슖(string A_1)
		{
			return Convert.ToBase64String(Encoding.UTF8.GetBytes(A_1));
		}

		// Token: 0x040000FE RID: 254
		public string 슟 = "https://anticheat.fpschallenge.eu";

		// Token: 0x040000FF RID: 255
		private AuthenticationRelatedInterface 슟;

		// Token: 0x04000100 RID: 256
		private AuthenticationCrypticInterface 슟;

		// Token: 0x04000101 RID: 257
		private JsonSerializerSettings 슟;
	}
}
