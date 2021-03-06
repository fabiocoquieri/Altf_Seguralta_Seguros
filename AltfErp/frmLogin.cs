﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AltfErp
{
    public partial class frmLogin : Form
    {
        Boolean valida;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void Login()
        {
            valida = MetodosSql.ChecaLogin(txtLogin.Text, txtSenha.Text);

            if (valida)
            {
                string sql = String.Format(@"SELECT NOME, USUARIO FROM LOGIN WHERE USUARIO = '{0}'", txtLogin.Text);
                string nome = MetodosSql.GetField(sql, "NOME");
                string usuario = MetodosSql.GetField(sql, "USUARIO");

                frmPrincipal frm = new frmPrincipal(nome, usuario);
                frm.FormClosed += (s, args) => this.Close();
                frm.bhiVersao.Caption = lblVersao.Text;
                frm.Show();
                this.Visible = false;


            }
            else
            {
                MessageBox.Show("Usuário ou Senha inválidos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void btnLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Login();
            }
        }
                

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                Login();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
