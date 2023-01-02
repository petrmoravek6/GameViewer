using clientUI.ServerApi.Model.Converter;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace clientUI.ServerApi
{
    public class CrudRequester<ID, TYPE, DTO>
    {
        protected readonly string basePath;
        protected readonly string parameter;
        protected static readonly HttpClient client = new HttpClient();
        protected readonly IConverter<TYPE, DTO> converter;

        public CrudRequester(string basePath, string parameter, IConverter<TYPE, DTO> converter)
        {
            this.basePath = basePath;
            this.parameter = parameter;
            this.converter = converter;
        }

        public List<TYPE> GetAll()
        {
            var responseString = Task.Run(async () => await client.GetStringAsync($"{basePath}/{parameter}")).Result;
            var dtoList = JsonConvert.DeserializeObject<List<DTO>>(responseString);
            return dtoList.Select(dto => converter.ToEntity(dto)).ToList();
        }

        public TYPE Get(ID id)
        {
            if (id is null)
            {
                throw new ArgumentNullException("id");
            }
            var responseString = client.GetStringAsync($"{basePath}/{parameter}/{id}").Result;
            var dto = JsonConvert.DeserializeObject<DTO>(responseString);
            return converter.ToEntity(dto);
        }

        public TYPE Post(TYPE entity)
        {
            string json = JsonConvert.SerializeObject(converter.ToDto(entity));
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = client.PostAsync($"{basePath}/{parameter}", data).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error during posting. STATUS CODE: " + response.StatusCode);
            }
            var responseString = response.Content.ReadAsStringAsync().Result;
            var responseDto = JsonConvert.DeserializeObject<DTO>(responseString);
            return converter.ToEntity(responseDto);
        }

        public void Put(TYPE entity, ID id)
        {
            if (id is null)
            {
                throw new ArgumentNullException("id");
            }
            string json = JsonConvert.SerializeObject(converter.ToDto(entity));
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = client.PutAsync($"{basePath}/{parameter}/{id}", data).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error during puting. STATUS CODE: " + response.StatusCode);
            }
        }

        public void Delete(ID id)
        {
            if (id is null)
            {
                throw new ArgumentNullException("id");
            }
            client.DeleteAsync($"{basePath}/{parameter}/{id}");
        }
    }
}
