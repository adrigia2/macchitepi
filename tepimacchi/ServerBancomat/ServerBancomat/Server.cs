using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerBancomat
{
    class Server
    {
        private TcpClient dati;
        private int numClient;
        public Server(TcpClient dati, int i)
        {
            this.dati = dati;
            this.numClient = i;
            //thread che si prenderà carico della richiesta del client
            Thread th = new Thread(new ThreadStart(this.Attività));
            th.Start(); //il thread si autolancia
        }
        public void Attività()
        {
            Byte[] buf = new byte[256]; //buffer ricezione messaggio
            String msgIn = null;
            //NetworkStream usato per inviare e rivevere il flusso di dati (byte)
            NetworkStream s = dati.GetStream();
            int i;
            Console.WriteLine("Attivo thread numero " + numClient);
            while ((i = s.Read(buf, 0, buf.Length)) != 0) //legge finchè ci sono dati
            {
                msgIn = System.Text.Encoding.ASCII.GetString(buf, 0, i);
                Console.WriteLine("Frase ricevuta dal client: " + msgIn);
                msgIn = msgIn.ToUpper();
                byte[] msgOut = System.Text.Encoding.ASCII.GetBytes(msgIn);
                s.Write(msgOut, 0, msgOut.Length);
            }
            s.Close();
            dati.Close();

        }
    }
}
