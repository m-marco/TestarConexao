using FirebirdSql.Data.FirebirdClient;
using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;

namespace TestarConexao
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FbConnection conexao = new FbConnection(@$"User={txtUsuario.Text}; Password={txtSenha.Text}; Database={txtDatabase.Text}; DataSource={txtHost.Text}; Port=3050; Dialect=3; Charset=NONE; Role=; Connection lifetime=15; Pooling=true; MinPoolSize=0; MaxPoolSize=50; Packet Size=8192; ServerType=0");
                var command = conexao.CreateCommand();
                await conexao.OpenAsync();
                Interaction.MsgBox("Conexão testada com sucesso", MsgBoxStyle.Information);
            }
            catch (Exception erro)
            {
                Interaction.MsgBox($@"Message: {erro.Message}
                                      InnerException: {erro.InnerException}", MsgBoxStyle.Critical, "Erro");
            }
        }
    }
}
