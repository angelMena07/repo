using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TareaMovilITIC92.Data
{
   
        public class TareaManager
        {
            const string url = "http://192.168.1.72:3000/tareas/";

            public async Task<IEnumerable<Tarea>> GetAll()
            {
                HttpClient client = new HttpClient();
                string result = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<IEnumerable<Tarea>>(result);
            }
        }
    
}
