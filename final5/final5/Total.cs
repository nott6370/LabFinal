using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace final5
{
    public static class Total
    {
        public static int CalculateSum(DataGridView dataGridView, int columnIndex)
        {
            int sum = 0;
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                int value;
                if (int.TryParse(row.Cells[columnIndex].Value?.ToString(), out value))
                {
                    sum += value;
                }
            }
            return sum;
        }
    }
}
