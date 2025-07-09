using Proyecto3.Views;
namespace Proyecto3;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute("AgregarTransaccionPage", typeof(AgregarTransaccionPage));

	}
}
