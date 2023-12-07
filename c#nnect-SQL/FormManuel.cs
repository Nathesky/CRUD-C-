using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace c_nnect_SQL
{
    public partial class FormManuel : Form
    {
        public FormManuel()
        {
            InitializeComponent();
        }

        private void FormManuel_Load(object sender, EventArgs e)
        {
            axAcroPDF1.LoadFile("memes.pdf");
        }

        private void axAcroPDF1_Enter(object sender, EventArgs e)
        {

        }
    }
}
