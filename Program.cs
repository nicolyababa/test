using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;



namespace HelloApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите ссылку: ");
            string url = Console.ReadLine();       // вводим имя
        }

        // <summary>
        /// Отправка GET-запроса на сторонние сервисы.
        /// </summary>
        /// <param name="url">Url адрес с параметрами куда отправляем запрос</param>
        /// <returns>Код страницы в строковом формате.</returns>
        public string SendGetRequest(string url)
        {
            var webRequest = (System.Net.HttpWebRequest)WebRequest.Create(url);

            var result = string.Empty;
            using (var response = (HttpWebResponse)webRequest.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    if (stream != null)
                    {
                        using (var streamReader = new StreamReader(stream))
                        {
                            result = streamReader.ReadToEnd();
                        }
                    }
                }
            }

            return result;
       