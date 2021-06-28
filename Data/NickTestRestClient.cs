using System;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;


namespace blazor_experiment.Data
{
    public class NickTestRestClient
    {

        public Task<string> MakeWebRequestToMockNodeServer()
        {

            //Wrap in an async thingy 
            return Task<string>.Factory.StartNew(() =>
            {
                WebRequest request = WebRequest.Create("http://localhost:9002/readDatabase");
                WebResponse response = request.GetResponse();

                Stream responseStream = response.GetResponseStream();
                StreamReader readerStream = new StreamReader(responseStream, System.Text.Encoding.GetEncoding("utf-8"));

                string json = readerStream.ReadToEnd();
                readerStream.Close();

                var jo = JsonDocument.Parse(json);
                Console.Write(jo);
                return json;
            });

        }
    }
}
