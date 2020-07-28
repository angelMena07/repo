using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TareaMovilITIC92.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace TareaMovilITIC92
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private IList<Tarea> tareas = new ObservableCollection<Tarea>();
        private TareaManager manager = new TareaManager();
        public MainPage()
        {
            BindingContext = tareas;
            InitializeComponent();
            Refresh();
        }

        async void OnRefresh(object sender, EventArgs e)
        {
            Refresh();
        }

        async private void Refresh()
        {
            var tareasCollection = await manager.GetAll();
            tareas.Clear();
            foreach (Tarea tarea in tareasCollection)
            {
                tareas.Add(tarea);
            }
        }

        async private void OnAddTarea(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddTarea(manager));
        }

        async private void OnUpdateTarea(object sender, EventArgs e)
        {
            var mi = sender as MenuItem;
            var item = mi.CommandParameter as Tarea;
            await Navigation.PushModalAsync(new UpdateTarea(manager, item.Id, item.Titulo, item.Detalle, item.Lugar, item.Fecha));
        }

        async private void OnDeleteTarea(object sender, EventArgs e)
        {
            var mi = sender as MenuItem;
            var item = mi.CommandParameter as Tarea;
            await manager.Delete(item.Id);
            Refresh();
        }
    }
}
