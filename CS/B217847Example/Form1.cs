using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace B217847Example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DataTableHelper.GetDataTable(dtTest);
        }

        private void OnFilterAdapterRowFilterChanged(object sender, EventArgs e)
        {
            gridView1.ActiveFilterCriteria = filterAdapter1.RowCriteria;
        }

        private void OnApplyFilterButtonClick(object sender, EventArgs e)
        {
            filterControl1.ApplyFilter();
        }
    }
}
