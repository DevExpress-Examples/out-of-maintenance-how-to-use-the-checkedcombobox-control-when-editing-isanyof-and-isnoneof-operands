using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace B217847Example
{
    public class DataTableHelper
    {
        public static void GetDataTable(DataTable table)
        {
            DataRow Row1 = table.NewRow();
            Row1["Number"] = 23;
            Row1["Name"] = "Mike";
            Row1["Date"] = new DateTime(2012, 9, 18);
            table.Rows.Add(Row1);

            DataRow Row2 = table.NewRow();
            Row2["Number"] = 12;
            Row2["Name"] = "Jon";
            Row2["Date"] = new DateTime(2012, 9, 19);
            table.Rows.Add(Row2);

            DataRow Row3 = table.NewRow();
            Row3["Number"] = 1;
            Row3["Name"] = "Bill";
            Row3["Date"] = new DateTime(2012, 9, 20);
            table.Rows.Add(Row3);

            DataRow Row4 = table.NewRow();
            Row4["Number"] = 121;
            Row4["Name"] = "Bruce";
            Row4["Date"] = new DateTime(2012, 9, 21);
            table.Rows.Add(Row4);

            DataRow Row5 = table.NewRow();
            Row5["Number"] = 132;
            Row5["Name"] = "Lex";
            Row5["Date"] = new DateTime(2012, 9, 22);
            table.Rows.Add(Row5);
        }
    }
}
