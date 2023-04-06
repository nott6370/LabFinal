using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace final5
{
    public static class Most
    {
            public static void ShowMaxRowValues(DataGridView dataGridView, int targetColumnIndex,
                Label maxRowValueLabel, Label[] otherRowValueLabels)
            {
                int maxColumnIndex = 0;
                int maxValue = 0;
                int maxRowIndex = 0;

                // หาค่ามากที่สุดใน column ที่ต้องการ
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    int value = Convert.ToInt32(dataGridView.Rows[i].Cells[targetColumnIndex].Value);
                    if (value > maxValue)
                    {
                        maxValue = value;
                        maxRowIndex = i;
                    }
                }

                // หา index ของ column นั้นๆ
                for (int j = 0; j < dataGridView.Columns.Count; j++)
                {
                    if (dataGridView.Columns[j].HeaderText == "Column Name")
                    {
                        maxColumnIndex = j;
                        break;
                    }
                }

                // แสดงค่าใน column อื่นๆ ของแถวนั้นๆ
                for (int j = 0; j < dataGridView.Columns.Count; j++)
                {
                    if (j != maxColumnIndex)
                    {
                        string value = dataGridView.Rows[maxRowIndex].Cells[j].Value.ToString();
                        // แสดงค่าใน TextBox หรือ Label ตามที่ต้องการ
                        if (j < otherRowValueLabels.Length)
                        {
                            otherRowValueLabels[j].Text = value;
                        }
                    }
                }

                // แสดงค่าใน column ที่มีค่ามากสุด
                string maxRowValue = dataGridView.Rows[maxRowIndex].Cells[maxColumnIndex].Value.ToString();
                maxRowValueLabel.Text = maxRowValue;
            }
    }
}
