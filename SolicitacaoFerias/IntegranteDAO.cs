using System;
using Integrante;

namespace SolicitacaoFerias.VisualWebPart1
{

    public class IntegranteDAO : IDisposable
    {
        private IDbConnection conexao;

        public IntegranteDAO()
        {
            this.conexao = new SqlConnection("Data Source=udc0-sql-ins02;Initial Catalog=Gerencial;User ID=_spdbgerencial;Password=_spdbgerencial");
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
                Integrante p = new Produto();
                p.Id = Convert.ToInt32(resultado["Id"]);
                p.Nome = Convert.ToString(resultado["Nome"]);
                p.Categoria = Convert.ToString(resultado["Categoria"]);
                p.Preco = Convert.ToDouble(resultado["Preco"]);
                lista.Add(p);
            }
            resultado.Close();

            return lista;
        }
    }
}

