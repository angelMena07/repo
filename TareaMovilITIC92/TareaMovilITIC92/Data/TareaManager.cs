﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TareaMovilITIC92.Data
{
   
        public class TareaManager
        {
            const string url = "http://192.168.0.102:3000/tareas/";

            public async Task<IEnumerable<Tarea>> GetAll()
            {
                HttpClient client = new HttpClient();
                string result = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<IEnumerable<Tarea>>(result);
            }

        public async Task<Tarea> Add(string titulo, string detalle, string valor, string fechaentrega)
        {
            Tarea tarea = new Tarea()
            {
                Titulo = titulo,
                Detalle = detalle,
                Valor = valor,
                FechaEntrega = fechaentrega,
            };

            HttpClient client = new HttpClient();
            var response = await client.PostAsync(url,
                new StringContent(
                    JsonConvert.SerializeObject(tarea),
                    Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<Tarea>(
                await response.Content.ReadAsStringAsync());
        }
        public async Task<Tarea> Update(string titulo, string detalle, string valor, string fechaentrega, string itemIndex)
        {
            Tarea tarea = new Tarea()
            {
                Titulo = titulo,
                Detalle = detalle,
                Valor = valor,
                FechaEntrega = fechaentrega,
            };
            HttpClient client = new HttpClient();
            var response = await client.PutAsync(url + itemIndex,
                new StringContent(
                    JsonConvert.SerializeObject(tarea),
                    Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<Tarea>(
                response.Content.ReadAsStringAsync().Result);


        }
        public async Task DeleteTareaAsync(string itemIndex)
        {
            HttpClient client = new HttpClient();
            await client.DeleteAsync(string.Concat(url, itemIndex));

        }

        internal Task Add(object text1, object text2, object tex3, object text4)
        {
            throw new NotImplementedException();

        }
        internal Task Update(object text1, object text2, object text3, object text4, string itemIndex)
        {
            throw new NotImplementedException();

        }






    }

}
