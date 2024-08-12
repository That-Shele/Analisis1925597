namespace Analisis1925597
{
    public partial class MainPage : ContentPage
    {
        private readonly LocalDbService _localDBService;
        private int _editEdadId;

        public MainPage(LocalDbService dbService)
        {
            InitializeComponent();
            _localDBService = dbService;
            Task.Run(async () => listview.ItemsSource = await _localDBService.GetEdades());
        }

        private async void listview_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var edad = (Edades)e.Item;
            var action = await DisplayActionSheet("Acciones", "Cancelar", null, "Editar", "Eliminar");

            switch (action)
            {
                case "Editar":
                    _editEdadId = edad.Id;
                    entryAnnio.Text = edad.Annio;
                    labelEdad.Text = edad.Edad;
                    break;

                case "Eliminar":
                    await _localDBService.Delete(edad);
                    listview.ItemsSource = await _localDBService.GetEdades();
                    break;
            }
        }

        private async void edadBtn_Clicked(object sender, EventArgs e)
        {
            var edad = (Convert.ToInt32(DateTime.Now.Year) - Convert.ToInt32(entryAnnio.Text)).ToString();
            if (_editEdadId == 0)
            {
                //Agrega resultado
                await _localDBService.Create(new Edades
                {
                    Annio = entryAnnio.Text,
                    Edad = edad + " Años"
                });
            }
            else
            {
                //Edita resultado
                await _localDBService.Update(new Edades
                {
                    Id = _editEdadId,
                    Annio = entryAnnio.Text,
                    Edad = edad + " Años"
                });
                _editEdadId = 0;
            }

            entryAnnio.Text = string.Empty;
            labelEdad.Text = string.Empty;
            listview.ItemsSource = await _localDBService.GetEdades();
        }
    }

}
