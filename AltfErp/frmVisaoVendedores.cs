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
    public partial class frmVisaoVendedores : Form
    {
        public frmVisaoVendedores()
        {
            InitializeComponent();
            gridView1.OptionsBehavior.Editable = false;
            grdVisaoVendedores.EmbeddedNavigator.Buttons.Append.Visible = false;
            grdVisaoVendedores.EmbeddedNavigator.Buttons.Remove.Visible = false;
            gridView1.BestFitColumns();
            AtualizaGrid();

        }

        private void AtualizaGrid()
        {
            grdVisaoVendedores.DataSource = MetodosSql.GetDT(@"SELECT * FROM VENDEDORES");
        }



        private void grdVisaoVendedores_DoubleClick(object sender, EventArgs e)
        {
            var rowHandle = gridView1.FocusedRowHandle;
            var obj = gridView1.GetRowCellValue(rowHandle, "IDVENDEDOR");

            if (obj != null)
            {
                frmCadastroVendedores frm = new frmCadastroVendedores(true, obj.ToString());
                frm.ShowDialog();
                AtualizaGrid();
            }
            else
            {
                MessageBox.Show("Por favor, selecione um registro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnNovo_Click_1(object sender, EventArgs e)
        {
            frmCadastroVendedores frm = new frmCadastroVendedores(false, null);
            frm.ShowDialog();
            AtualizaGrid();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var rowHandle = gridView1.FocusedRowHandle;
            var obj = gridView1.GetRowCellValue(rowHandle, "IDVENDEDOR");

            if (obj != null)
            {
                frmCadastroVendedores frm = new frmCadastroVendedores(true, obj.ToString());
                frm.ShowDialog();
                AtualizaGrid();
            }
            else
            {
                MessageBox.Show("Por favor, selecione um registro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var rowHandle = gridView1.FocusedRowHandle;
            var obj = gridView1.GetRowCellValue(rowHandle, "IDVENDEDOR");

            if (obj != null)
            {
                if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja excluir este vendedor?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    string sql = String.Format(@"DELETE FROM VENDEDORES WHERE IDVENDEDOR = '{0}'", obj.ToString());
                    MetodosSql.ExecQuery(sql);
                    AtualizaGrid();
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione um registro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
