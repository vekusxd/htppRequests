using Dadata.Model;
using System.ComponentModel.DataAnnotations;
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
                int choice;

                PeopleList peopleList = new PeopleList();
                while (true)
                {
                    Console.WriteLine("---Поиск информации о человеке---");
                    Console.WriteLine("1 - добавить человека");
                    Console.WriteLine("2 - отобразить список людей");
                    Console.WriteLine("3 - выйти и сохранить результат");
                    Console.Write("Ваш выбор: ");
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch(choice)
                    {
                        case 1:
                            Console.WriteLine("Введите номер");
                            string n = Console.ReadLine();
                            
                            People personToAdd = new People();

                            //оператор и номер
                            string[] number = { n };
                            var numberResponce = await httpClient.PostAsJsonAsync("https://cleaner.dadata.ru/api/v1/clean/phone", number);
                            var numberResult = await numberResponce.Content.ReadFromJsonAsync<List<NumberInfo>>();


                            foreach (var item in numberResult)
                            {
                                personToAdd.Number = item.Phone;
                                personToAdd.Country = item.Country;
                                personToAdd.Operator = item.Provider;
                            }

                            //инициалы по ИНН
                            Console.WriteLine("Введите инн");
                            string inn = Console.ReadLine();
                            var response = await httpClient.PostAsJsonAsync("http://suggestions.dadata.ru/suggestions/api/4_1/rs/findById/party", new Request { Query = inn });

                            personToAdd.INN = inn;
                            var result = await response.Content.ReadFromJsonAsync<InnInfo>();


                            //Имя в правильном формате и пол человека
                            string[] names = { result.Suggestions[0].Data.Management.Name };
                            var response2 = await httpClient.PostAsJsonAsync("https://cleaner.dadata.ru/api/v1/clean/name", names);
                            var resul2t = await response2.Content.ReadFromJsonAsync<List<PrettyName>>();

                            foreach (var item in resul2t)
                            {
                                personToAdd.Initials = item.Result;
                                personToAdd.Gender = item.Gender;
                            }

                            peopleList.append(personToAdd);
                            break;
                        case 2:
                            peopleList.displayAll();
                            break;
                        case 3:
                            peopleList.saveAll();
                            return;
                        default:
                            Console.WriteLine("Введите корректный запрос!");
                            break;
                    }
                }


             }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

