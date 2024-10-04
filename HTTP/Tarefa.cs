using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTP
{
    internal class Tarefa
    {
        public int userId;
        public int id;
        public string title;
        public bool completed;

        public void Exibir()
        {
            Console.WriteLine("TAREFAS");
            Console.WriteLine($"User id: {userId}");
            Console.WriteLine($"id: {id}");
            Console.WriteLine($"Titulo: {title}");
            Console.WriteLine($"Completou a tarefa?: {completed}");
            Console.WriteLine("");
            Console.WriteLine("=========================================");
        }
    }
}
