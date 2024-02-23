using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace htppRequests
{

    internal class Program
    {
        static HttpClient httpClient = new HttpClient();

        static async Task Main(string[] args)
        {
            try
            {
                Encoding utf8 = new UTF8Encoding(true);

                httpClient.DefaultRequestHeaders.Add("Authorization", "Token 9545f999ad7543f4b4ab67a5932b881f71877b25");
                httpClient.DefaultRequestHeaders.Add("X-Secret", "b54b9183bd8177902650b63c1cc05356da696643");
                //httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
               // httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");


                string[] number = { "89375226311" };

                string sNumber = "89375226311";

                string query = JsonSerializer.Serialize(number);

                string Squery = JsonSerializer.Serialize(sNumber);

                Dictionary<string, string[]> dictQuery = new Dictionary<string, string[]>();
                dictQuery["phone"] = number;

                string serialized = JsonSerializer.Serialize(dictQuery);

                //  Console.WriteLine(query);

                //  Console.WriteLine(Squery);

                //   Console.WriteLine(serialized);

                var response = await httpClient.PostAsJsonAsync("https://cleaner.dadata.ru/api/v1/clean/phone",number);

                //   Console.WriteLine(response);
                //  Console.WriteLine(response.RequestMessage);
                //  Console.WriteLine(response);

                var message = await response.Content.ReadAsStringAsync();

                Console.WriteLine(response);
                Console.WriteLine(message);

                //var response = await httpClient.GetFromJsonAsync("https://htmlweb.ru/json/mnp/phone/79375226311", );

                // var responce = await httpClient.GetAsync("https://htmlweb.ru/json/mnp/phone/79375226311?api_key=a1558f2d5fcb40e583377ca96255998a");
                // object? data  = await httpClient.GetFromJsonAsync<PhoneInfo>("https://htmlweb.ru/json/mnp/phone/79375226311?api_key=a1558f2d5fcb40e583377ca96255998a");

                //  if(data is PhoneInfo phone)
                //  {
                //       Console.WriteLine(phone);
                //   }

                //   Console.WriteLine();
                //
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
