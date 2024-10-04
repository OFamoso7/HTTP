using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace HTTP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ReqList();
            ReqUnica();


        }

        static void ReqUnica()
        {
            Console.WriteLine("|Digite um ID: |");
            string id = Console.ReadLine();
            var requisicao = WebRequest.Create("https://jsonplaceholder.typicode.com/todos/"+id);
            requisicao.Method = "GET";
            //recebendo a resposta da requisição
            var resposta = requisicao.GetResponse();
            //passa a resposta pra estrura using para tratar ela
            using (resposta)
            {
                //cria uma stream de dados e recebe os dados que a requisição mandou 
                var stream = resposta.GetResponseStream();
                //passou a resposta pro leitor
                StreamReader leitor = new StreamReader(stream);
                object dados = leitor.ReadToEnd();
                //transformou a resposta em string e exibiu
                Console.WriteLine(dados.ToString());

                Tarefa tarefa = JsonConvert.DeserializeObject<Tarefa>(dados.ToString());


                tarefa.Exibir();

                //fechou o stream
                stream.Close();
                resposta.Close();

            }
        }

        static void ReqList()
        {
            //fazendo requisição
            var requisicao = WebRequest.Create("https://jsonplaceholder.typicode.com/todos");
            requisicao.Method = "GET";
            //recebendo a resposta da requisição
            var resposta = requisicao.GetResponse();
            //passa a resposta pra estrura using para tratar ela
            using (resposta)
            {
                //cria uma stream de dados e recebe os dados que a requisição mandou 
                var stream = resposta.GetResponseStream();
                //passou a resposta pro leitor
                StreamReader leitor = new StreamReader(stream);
                object dados = leitor.ReadToEnd();
                //transformou a resposta em string e exibiu
                Console.WriteLine(dados.ToString());

                List<Tarefa> tarefas = JsonConvert.DeserializeObject<List<Tarefa>>(dados.ToString());

                foreach (Tarefa tarefa in tarefas)
                {
                    tarefa.Exibir();
                }
                //fechou o stream
                stream.Close();
                resposta.Close();


            }
        }
    }
}
