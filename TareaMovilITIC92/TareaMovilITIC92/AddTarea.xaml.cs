﻿using System;
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
    public partial class AddTarea : ContentPage
    {
        private TareaManager manager;
        public AddTarea(TareaManager manager)
        {
            InitializeComponent();
            this.manager = manager;
        }

        public async void OnSaveTarea(object sender, EventArgs e)
        {
            await manager.Add(txtTitulo.Text, txtDetalle.Text, txtMateria.Text, txtFecha.Text);
        }
    }
}