using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolicitacaoFerias
{
    public class IntegranteDAO : IDisposable
    {
        private IDbConnection conexao;

        public IntegranteDAO()
        {
            this.conexao = new SqlConnection("Data Source=server\\instance;Initial Catalog=Database;User ID=user;Password=pass");
            this.conexao.Open();
        }

        public void Dispose()
        {
            this.conexao.Close();
        }

        internal IList<Integrante> Integrantes()
        {
            var lista = new List<Integrante>();

            var selectCmd = conexao.CreateCommand();
            selectCmd.CommandText = "SELECT * FROM Portal";

            var resultado = selectCmd.ExecuteReader();
            while (resultado.Read())
            {
                Integrante integrante = new Integrante();
                integrante.IDIntegrante = Convert.ToString(resultado["ID do Integrante"]);
                integrante.Matricula = Convert.ToString(resultado["Matricula"]);
                integrante.Nome = Convert.ToString(resultado["Nome"]);
                integrante.Cargo = Convert.ToString(resultado["Descrição do Cargo Legal"]);
                integrante.CTPS = Convert.ToString(resultado["CTPS"].ToString()+ "/" + resultado["Série"].ToString());
                integrante.CPF = Convert.ToString(resultado["CPF Integrante"]);
                
               
                lista.Add(integrante);
            }
            resultado.Close();

            return lista;
        }

        internal Integrante getIntegrante(string id, string cpf)
        {
            Integrante integrante = new Integrante();
            
            var selectCmd = conexao.CreateCommand();
            selectCmd.CommandText = "SELECT * FROM Table" + " where [ID do Integrante] ='" + id + "' and [CPF Integrante] = '" + cpf + "' and [Situacao Colaborador] = 'ATIVO'";
            var resultado = selectCmd.ExecuteReader();

            while (resultado.Read())
            {
                integrante.IDIntegrante = Convert.ToString(resultado["ID do Integrante"]);
                integrante.Matricula = Convert.ToString(resultado["Matricula"]);
                integrante.Nome = Convert.ToString(resultado["Nome"]);
                integrante.Cargo = Convert.ToString(resultado["Descrição do Cargo Legal"]);
                integrante.CTPS = Convert.ToString(resultado["CTPS"].ToString() + "/" + resultado["Série"].ToString());
                integrante.CPF = Convert.ToString(resultado["CPF Integrante"]);
                integrante.DataAdmissao = Convert.ToString(resultado["Data Admissao"]);
                integrante.Gerencia = Convert.ToString(resultado["Descrição U#A#"]);

            }

            return integrante;
        }


    }
}
