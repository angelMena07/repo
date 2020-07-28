using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TareaMovilITIC92.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TareaMovilITIC92
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateTarea : ContentPage
    {
        private TareaManager manager;
        private long Id;
        public UpdateTarea(TareaManager manager, long id, string titulo, string detalle, string lugar, string fecha)
        {
            InitializeComponent();
            this.manager = manager;
            Id = id;
            txtTitulo.Text = titulo;
            txtDetalle.Text = detalle;
            txtLugar.Text = lugar;
            txtFecha.Text = fecha;

        }

        public async void OnUpdateTarea(object sender, EventArgs e)
        {
            await manager.Update(Id, txtTitulo.Text, txtDetalle.Text, txtLugar.Text, txtFecha.Text);
        }
    }
}