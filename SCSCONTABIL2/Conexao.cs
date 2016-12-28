using System;
using MySql.Data.MySqlClient;

namespace SCSCONTABIL2
{
    class Conexao
    {
        public MySqlConnection con = new MySqlConnection("SERVER=localhost;DATABASE=scs;UID=root;PASSWORD=;");

        public void abrir()
        {
            try
            {
                con.Open();
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro.ToString());
                fechar();
            }
        }

        public void fechar()
        {
            try
            {
                con.Close();
            }
            catch (Exception erro)
            {

            }
        }
    }
}
