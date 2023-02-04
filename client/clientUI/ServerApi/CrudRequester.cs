using clientUI.ServerApi.Model.Converter;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public IConverter<TYPE, DTO> converter;

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

        public async Task<List<TYPE>> GetAllAsync()
        {
            DateTime time1 = DateTime.Now;
            var responseString = await client.GetStringAsync($"{basePath}/{parameter}");
            DateTime time2 = DateTime.Now;
            await Task.Delay(1000);
            DateTime time3 = DateTime.Now;
            var dtoList = JsonConvert.DeserializeObject<List<DTO>>(responseString);
            DateTime time4 = DateTime.Now;
            // NON ASYNC VARIANT
            // var res =  dtoList.Select(dto => converter.ToEntity(dto)).ToList();
            // ASYNC VARIANT
            var res = await Task.Run(() => { return dtoList.Select(dto => converter.ToEntity(dto)).ToList(); });
            DateTime time5 = DateTime.Now;

            Trace.WriteLine($"timestamp: {time1.Minute}:{time1.Second}:{time1.Millisecond} - before http req");
            Trace.WriteLine($"timestamp: {time2.Minute}:{time2.Second}:{time2.Millisecond} - after http req");
            Trace.WriteLine($"timestamp: {time3.Minute}:{time3.Second}:{time3.Millisecond} - after 1sec delay");
            Trace.WriteLine($"timestamp: {time4.Minute}:{time4.Second}:{time4.Millisecond} - after deserializing");
            Trace.WriteLine($"timestamp: {time5.Minute}:{time5.Second}:{time5.Millisecond} - after converting to entity");

            return res;
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
