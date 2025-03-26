using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using System.Data.OleDb;
using Microsoft.Win32;

namespace Sistema_2I_03
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btn_consultar_Click(object sender, EventArgs e)
        {
            string strCon = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\joão\bd_22_banco.mdb";

            try
            {

                if (txt_Id.Text != string.Empty)
                {
                    //Declarar objetos de Classe de Conexão
                    OleDbConnection conectar = new OleDbConnection(strCon);
                    //Abrir Objeto de Conexão com Banco de Dados criada acima;
                    conectar.Open();

                    //Mondando a String (concatenando) com os objetos do Formulário 
                    string strSQL = "SELECT * FROM contatos WHERE (ID =" + txt_Id.Text + ")";

                    //Criar o Objeto com a classe de Command (comando) para armazenar a Instrução / Comando SQL
                    OleDbCommand comandoSQL = new OleDbCommand(strSQL, conectar);
                    //Criar objeto DbDataReader
                    DbDataReader lerRegistro = comandoSQL.ExecuteReader();

                    //Metodo Read(): Informe um "boolean" "True" (exite Registro) e "False" (Não Existe Registro),
                    //Possibilita Ler o Proximo Regsitro de uma Tabela (Enquanto for True, Se existir registro)

                    if (lerRegistro.Read())
                    {
                        //Populando Objetos do Form com Dados do Registro Lido (lerRegistro)
                        txt_Nome.Text = lerRegistro.GetString(1);
                        txt_telefone.Text = lerRegistro.GetString(2);
                        txt_email.Text = lerRegistro.GetString(3);
                        txt_Cidade.Text = lerRegistro.GetString(4);
                        txt_UF.Text = lerRegistro.GetString(5);

                        if (DialogResult.No == MessageBox.Show("Deseja Editar Registro?", "Sistema Informa",
                                               MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                               MessageBoxDefaultButton.Button2))
                        {
                            //Limpar Objetos do Formulário
                            LimparDados();

                        }
                        else
                        {
                            //Habilitar botões
                            btn_excluir.Enabled = true;
                            btn_alterar.Enabled = true;

                            //Desabilitando Campo CPF
                            txt_Id.Enabled = false;
                        }


                    }
                    else
                    {
                        MessageBox.Show("Identificador " + txt_Id.Text + " Não Localizado!!!", "Sistema Informa");
                        txt_Id.Focus();
                    }



                    //Fechar Conexão
                    conectar.Close();

                }
                else
                {
                    MessageBox.Show("Preencher o campo Identificador (ID)!!!");
                }

                //Votar Cursor para o Objeto de Formulario
                txt_Id.Focus();


            }

            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void LimparDados()
        {
            txt_Id.Clear();
            txt_Nome.Clear();
            txt_telefone.Clear();
            txt_email.Clear();
            txt_Cidade.Clear();
            txt_UF.Clear();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            btn_alterar.Enabled = false;
            btn_excluir.Enabled = false;
        }

        private void Btn_inserir_Click(object sender, EventArgs e)
        {
            string strCon = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\joão\bd_22_banco.mdb";

            try
            {
                if (txt_Nome.Text != string.Empty)
                {
                    //Declarar objetos de Classe de Conexão
                    OleDbConnection conectar = new OleDbConnection(strCon);
                    //Abrir Objeto de Conexão com Banco de Dados criada acima;
                    conectar.Open();

                    //Montando a variavel tipo String "strSQL" de Leitura de Dados (concatenando) com os objetos do Formulário
                    string strSQL = "SELECT * FROM contatos WHERE (nome =" + "'" + txt_Nome.Text + "')";

                    //Criar o Objeto com a classe de Command (comando) para armazenar a Instrução / Comando SQL
                    OleDbCommand comandoSQL = new OleDbCommand(strSQL, conectar);

                    DbDataReader lerRegistro = comandoSQL.ExecuteReader();

                    //Metodo Read(): Informe um "boolean" "True" (exite Registro) e "False" (Não Existe Registro),
                    //Possibilita Ler o Proximo Registro de uma Tabela (Enquanto for True, Se existir registro)

                    if (lerRegistro.Read())
                    {
                        MessageBox.Show("Contato (nome) já Existe!!!", "Sistema Informa");
                    }
                    else
                    {
                        //Montando a variavel tipo String "strSQL" de Inserção dos Dados (concatenando) com os objetos do Formulário 
                        strSQL = "INSERT INTO contatos (nome,telefone,email,cidade,UF) " +
                                  "VALUES (" +
                                  "'" + txt_Nome.Text + "'," +
                                  "'" + txt_telefone.Text + "'," +
                                  "'" + txt_email.Text + "'," +
                                  "'" + txt_Cidade.Text + "'," +
                                  "'" + txt_UF.Text + "')";

                        //Observe que as MaskTextBox ao utilizar o caracer "." ele inverte para "," (vice-versa)

                        //Criar o Objeto com a classe de Command (comando) para armazenar a Instrução / Comando SQL
                        //comandoSQL já é uma Classe OleDbCommand, portanto só precisamos Instacia-lá
                        comandoSQL = new OleDbCommand(strSQL, conectar);

                        //Executando 
                        comandoSQL.ExecuteNonQuery();
                        MessageBox.Show("Registro Inserido com Sucesso...", "Sistema Informa");

                        //Limpar Objetos do Formulário
                        LimparDados();

                    }

                    //Fechar Conexão
                    conectar.Close();

                }
                else
                {
                    MessageBox.Show("Preencher pelo menos o campo NOME!!!");
                }

                //Votar Cursor para o Objeto de Formulario
                txt_Nome.Focus();


            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }

        }

    }
    }

