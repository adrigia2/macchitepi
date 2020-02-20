using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientBancomat
{
    class Cliente
    {
        public void Attività()
        {
            try
            {
                String msgOut;
                Console.Write("Inserire frase da rendere maiuscola: ");
                msgOut = Console.ReadLine();
                byte[] bufOut = System.Text.Encoding.ASCII.GetBytes(msgOut); //blocco di byte da inviare
                TcpClient c = new TcpClient(Dns.GetHostName(), 10100); //richiesta connessione con host
                                                                       //del server(localhost) porta 10101
                NetworkStream st = c.GetStream(); //stream per transito dati
                st.Write(bufOut, 0, bufOut.Length); //invio dati
                byte[] bufIn = new Byte[256];
                String msgIn = String.Empty;
                Int32 bytes = st.Read(bufIn, 0, bufIn.Length); //blocco di byte ricevuti
                msgIn = System.Text.Encoding.ASCII.GetString(bufIn, 0, bytes);
                Console.WriteLine("Frase ricevuta dal server (in maiuscolo): " + msgIn);
                Console.Write("Premere un tasto per terminare...");
                Console.ReadKey();
                st.Close();
                c.Close();
            }
            catch (ArgumentNullException e) //hostname è null
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e) //connessione fallita
            {
                Console.WriteLine("SocketException: {0}", e);
            }
        }
    }
}
