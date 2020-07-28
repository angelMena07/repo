using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace TareaMovilITIC92.Data
{

    public class TareaManager
    {
        const string url = "http://192.168.0.102:3000/tareas";

        public async Task<IEnumerable<Tarea>> GetAll()
        {
            HttpClient client = new HttpClient();
            string result = await client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<IEnumerable<Tarea>>(result);
        }

        public async Task<Tarea> Add(string titulo, string detalle, string materia, string fecha)
        {
            Tarea tarea = new Tarea()
            {
                Titulo = titulo,
                Detalle = detalle,
                Materia = materia,
                Fecha = fecha
            };

            HttpClient client = new HttpClient();
            var response = await client.PostAsync(url,
                new StringContent(
                    JsonConvert.SerializeObject(tarea),
                    Encoding.UTF8, "application/json"));
            return JsonConvert.DeserializeObject<Tarea>(await response.Content.ReadAsStringAsync());
        }

        public async Task<Tarea> Update(long id, string titulo, string detalle, string materia, string fecha)
        {
            Tarea tarea = new Tarea()
            {
                Titulo = titulo,
                Detalle = detalle,
                Materia = materia,
                Fecha = fecha
            };

            HttpClient client = new HttpClient();
            var response = await client.PutAsync(url + "/" + id,
                new StringContent(
                    JsonConvert.SerializeObject(tarea),
                    Encoding.UTF8, "application/json"));
            return JsonConvert.DeserializeObject<Tarea>(await response.Content.ReadAsStringAsync());
        }

        public async Task<Tarea> Delete(long id)
        {
            HttpClient client = new HttpClient();
            var response = await client.DeleteAsync(url + "/" + id);
            return JsonConvert.DeserializeObject<Tarea>(await response.Content.ReadAsStringAsync());
        }
    }

}
