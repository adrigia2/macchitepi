using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerBancomat
{
    class Program
    {
        static void Main(string[] args)
        {
            //ottiene l'indirizzo ip dell'host specificato (host locale)
            IPAddress[] ip = Dns.GetHostAddresses(Dns.GetHostName());

            //si mette in ascolto in rete per le richieste di connessione dai client
            TcpListener s = new TcpListener(ip[0], 10100);
            //avvia l'ascolto delle richieste di connessione in ingresso
            s.Start();
            //conta i clienti serviti
            int contaClient = 0;
            while (true)
            {
                Console.WriteLine("Sono il SERVER e sono in attesa di connessione...");
                //accetta una richiesta di connessione in sospeso
                TcpClient conn = s.AcceptTcpClient();
                contaClient++; //incremento il numero di client connessi
                Console.WriteLine("Client numero " + contaClient + "connesso!");
                new Server(conn, contaClient); //per ogni richiesta di connessione crea un nuovo thread (vedi
                                               //costruttore classe Server)
            }
        }
    }
}
