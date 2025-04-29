namespace djahuacoTS2
{
    public partial class LoginPage : ContentPage
    {
        string[] usuarios = { "Carlos", "Ana", "Jose" };
        string[] claves = { "carlos123", "ana123", "jose123" };

        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string user = entryUsuario.Text?.Trim();
            string pass = entryClave.Text;

            for (int i = 0; i < usuarios.Length; i++)
            {
                if (user == usuarios[i] && pass == claves[i])
                {
                    await DisplayAlert("Bienvenido", $"Hola {user}, bienvenido al sistema.", "OK");
                    await Navigation.PushAsync(new MainPage());
                    return;
                }
            }

            await DisplayAlert("Error", "Usuario o contraseña incorrectos.", "Intentar nuevamente");
        }
    }
}
