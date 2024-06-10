using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using FPSCAnticheat.Shared.DTO;
using FPSCAnticheat.Shared.Models.Login;

namespace FPSAC
{
	// Token: 0x0200005C RID: 92
	public class FormRelated2 : Window, IComponentConnector
	{
		// Token: 0x060001DC RID: 476 RVA: 0x0000B7B0 File Offset: 0x000099B0
		[CompilerGenerated]
		public void 슟(EventHandler A_1)
		{
			EventHandler eventHandler = this.슟;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value = (EventHandler)Delegate.Combine(eventHandler2, A_1);
				eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.슟, value, eventHandler2);
			}
			while (eventHandler != eventHandler2);
		}

		// Token: 0x060001DD RID: 477 RVA: 0x0000B7E8 File Offset: 0x000099E8
		[CompilerGenerated]
		public void 슖(EventHandler A_1)
		{
			EventHandler eventHandler = this.슟;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value = (EventHandler)Delegate.Remove(eventHandler2, A_1);
				eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.슟, value, eventHandler2);
			}
			while (eventHandler != eventHandler2);
		}

		// Token: 0x060001DE RID: 478 RVA: 0x00003C06 File Offset: 0x00001E06
		public FormRelated2()
		{
			this.InitializeComponent();
		}

		// Token: 0x060001DF RID: 479 RVA: 0x00003C14 File Offset: 0x00001E14
		public FormRelated2(AuthenticationLoginMainInterface A_1) : this()
		{
			this.슟 = A_1;
			base.WindowStartupLocation = WindowStartupLocation.CenterScreen;
			this.슟.IsChecked = new bool?(true);
			this.슟 = this.슟.슟();
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x00003C4C File Offset: 0x00001E4C
		public LoginDataDTO 슟()
		{
			if (this.슟 != null && this.슟.StayLoggedIn)
			{
				return this.슟;
			}
			return null;
		}

		// Token: 0x060001E1 RID: 481 RVA: 0x0000318C File Offset: 0x0000138C
		private void 슟(object A_1, MouseButtonEventArgs A_2)
		{
			if (A_2.ChangedButton == MouseButton.Left)
			{
				base.DragMove();
			}
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x0000B820 File Offset: 0x00009A20
		private void 슟(object A_1, RoutedEventArgs A_2)
		{
			LoginModel loginModel = new LoginModel
			{
				PlayerName = this.슟.Text,
				Password = this.슟.Password.Trim(),
				StayLoggedIn = this.슟.IsChecked.Value
			};
			if (string.IsNullOrEmpty(loginModel.PlayerName) || string.IsNullOrEmpty(loginModel.Password))
			{
				this.슖();
				return;
			}
			this.슺();
			LoginDataDTO loginDataDTO = this.슟.슟(loginModel);
			if (loginDataDTO.Success)
			{
				this.슎();
				return;
			}
			if (loginDataDTO.Banned)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(51, 5);
				defaultInterpolatedStringHandler.AppendLiteral("You have been banned! ");
				defaultInterpolatedStringHandler.AppendFormatted(Environment.NewLine);
				defaultInterpolatedStringHandler.AppendLiteral("Reason: ");
				defaultInterpolatedStringHandler.AppendFormatted(loginDataDTO.BanReason);
				defaultInterpolatedStringHandler.AppendLiteral(" ");
				defaultInterpolatedStringHandler.AppendFormatted(Environment.NewLine);
				defaultInterpolatedStringHandler.AppendFormatted(Environment.NewLine);
				defaultInterpolatedStringHandler.AppendLiteral("Ban will expire on: ");
				defaultInterpolatedStringHandler.AppendFormatted(loginDataDTO.BanExpireDate.ToShortDateString());
				MessageBox.Show(defaultInterpolatedStringHandler.ToStringAndClear(), "Banned", MessageBoxButton.OK, MessageBoxImage.Hand);
				Application.Current.Shutdown();
				return;
			}
			if (loginDataDTO.ErrorMessage != null)
			{
				MessageBox.Show(loginDataDTO.ErrorMessage ?? "", "Offline", MessageBoxButton.OK, MessageBoxImage.Exclamation);
				return;
			}
			this.슖();
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x0000B990 File Offset: 0x00009B90
		private void 슖()
		{
			Brush borderBrush = new SolidColorBrush(Colors.Red);
			this.슟.BorderBrush = borderBrush;
			this.슟.BorderBrush = borderBrush;
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x0000B9C0 File Offset: 0x00009BC0
		private void 슺()
		{
			Brush borderBrush = new SolidColorBrush(Colors.White);
			this.슟.BorderBrush = borderBrush;
			this.슟.BorderBrush = borderBrush;
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x00003C6B File Offset: 0x00001E6B
		private void 슎()
		{
			if (this.슟 != null)
			{
				this.슟(this, EventArgs.Empty);
				base.Close();
			}
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x00003200 File Offset: 0x00001400
		private void 슖(object A_1, RoutedEventArgs A_2)
		{
			base.Close();
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x00003208 File Offset: 0x00001408
		private void 슺(object A_1, RoutedEventArgs A_2)
		{
			base.WindowState = WindowState.Minimized;
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x0000B9F0 File Offset: 0x00009BF0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.5.0")]
		public void InitializeComponent()
		{
			if (this.슟)
			{
				return;
			}
			this.슟 = true;
			Uri resourceLocator = new Uri("/FPSChallenge Anticheat;V3.0.2.0;component/screens/loginwindow.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x0000BA20 File Offset: 0x00009C20
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.5.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.슟(int A_1, object A_2)
		{
			switch (A_1)
			{
			case 1:
				((FormRelated2)A_2).MouseDown += this.슟;
				return;
			case 2:
				this.슟 = (TextBox)A_2;
				return;
			case 3:
				this.슟 = (PasswordBox)A_2;
				return;
			case 4:
				this.슟 = (CheckBox)A_2;
				return;
			case 5:
				this.슟 = (Button)A_2;
				this.슟.Click += this.슟;
				return;
			case 6:
				this.슖 = (Button)A_2;
				this.슖.Click += this.슖;
				return;
			case 7:
				this.슺 = (Button)A_2;
				this.슺.Click += this.슺;
				return;
			default:
				this.슟 = true;
				return;
			}
		}

		// Token: 0x04000163 RID: 355
		[CompilerGenerated]
		private EventHandler 슟;

		// Token: 0x04000164 RID: 356
		private AuthenticationLoginMainInterface 슟;

		// Token: 0x04000165 RID: 357
		public LoginDataDTO 슟;

		// Token: 0x04000166 RID: 358
		internal TextBox 슟;

		// Token: 0x04000167 RID: 359
		internal PasswordBox 슟;

		// Token: 0x04000168 RID: 360
		internal CheckBox 슟;

		// Token: 0x04000169 RID: 361
		internal Button 슟;

		// Token: 0x0400016A RID: 362
		internal Button 슖;

		// Token: 0x0400016B RID: 363
		internal Button 슺;

		// Token: 0x0400016C RID: 364
		private bool 슟;
	}
}
