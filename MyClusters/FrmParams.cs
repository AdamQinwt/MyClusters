using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyClusters
{
    public partial class FrmParams : Form
    {
        public Dictionary<string, double> extras;
        public FrmParams(Dictionary<string,double> _extras=null)
        {
            InitializeComponent(); 
            if(_extras==null)
            {
                extras = new Dictionary<string, double>(10);
                extras["push"] = 0.03;
                extras["pull"] = 0.5;
                extras["max_iter"] = 200;
                extras["thresh"] = 1;
                extras["add_thresh"] = 0.8;
                extras["prune_interval"] = 5;
                extras["add_interval"] = 3;
                extras["expel"] = 0.5;
                extras["decay"] = 0.9;
                extras["lower_d"] = 0.1;
            }
            else
            {
                extras = _extras;
            }
            setExtras();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            getExtras();
            DialogResult = DialogResult.OK;
        }
        void getExtras()
        {
            foreach(DataGridViewRow row in dgv.Rows)
            {
                try
                {
                    extras[row.Cells[0].Value.ToString()] = double.Parse(row.Cells[1].Value.ToString());
                }
                catch
                {
                    //
                }
            }
        }
        void setExtras()
        {
            dgv.Rows.Clear();
            int indx;
            foreach(string k in extras.Keys)
            {
                indx = dgv.Rows.Add(new DataGridViewRow());
                dgv.Rows[indx].Cells[0].Value = k;
                dgv.Rows[indx].Cells[1].Value = extras[k];
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
