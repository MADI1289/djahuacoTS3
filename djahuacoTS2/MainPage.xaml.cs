namespace djahuacoTS2
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCalcularClicked(object sender, EventArgs e)
        {
            try
            {
                string nombre = pickerEstudiante.SelectedItem?.ToString() ?? "Sin nombre";
                double seg1 = double.Parse(notaSeg1.Text);
                double ex1 = double.Parse(examen1.Text);
                double seg2 = double.Parse(notaSeg2.Text);
                double ex2 = double.Parse(examen2.Text);

                // Validación de rango
                if (seg1 > 10 || ex1 > 10 || seg2 > 10 || ex2 > 10 || seg1 < 0 || ex1 < 0 || seg2 < 0 || ex2 < 0)
                {
                    await DisplayAlert("Error", "Las notas deben estar entre 0 y 10.", "OK");
                    return;
                }

                double parcial1 = (seg1 * 0.3) + (ex1 * 0.2);
                double parcial2 = (seg2 * 0.3) + (ex2 * 0.2);
                double notaFinal = parcial1 + parcial2;

                string estado = notaFinal switch
                {
                    >= 7 => "APROBADO",
                    >= 5 => "COMPLEMENTARIO",
                    _ => "REPROBADO"
                };

                string fecha = fechaPicker.Date.ToString("dd/MM/yyyy");

                await DisplayAlert("Resultado", $"Nombre: {nombre}\nFecha: {fecha}\n" +
                                    $"Nota Parcial 1: {parcial1:F2}\n" +
                                    $"Nota Parcial 2: {parcial2:F2}\n" +
                                    $"Nota Final: {notaFinal:F2}\n" +
                                    $"Estado: {estado}", "OK");
            }
            catch
            {
                await DisplayAlert("Error", "Por favor, asegúrate de llenar todos los campos con datos válidos.", "OK");
            }
        }

    }
}