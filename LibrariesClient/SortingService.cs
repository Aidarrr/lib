using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrariesClient
{
    class SortingService
    {
        DBUtils dBUtils;
        DataGridView data;

        public SortingService(DBUtils dBUtils, DataGridView data)
        {
            this.dBUtils = dBUtils;
            this.data = data;
        }

        public void showSortedTable(string columnName, bool isDescending)
        {
            if (!isColumnPresent(columnName))
                return;

            string queryWithoutSorting = dBUtils.queryForShowingCurrentTable;
            string queryWithSorting = getQueryWithSorting(queryWithoutSorting, columnName, isDescending);

            dBUtils.getDataFromDB(data, queryWithSorting);
        }

        private bool isColumnPresent(string columnName)
        {
            return ((DataTable)data.DataSource).Columns.Contains(columnName);
        }

        private string getQueryWithSorting(string queryWithoutSorting, string columnName, bool isDescending)
        {
            string queryWithSorting = queryWithoutSorting + " ORDER BY " + columnName;

            if (isDescending)
                queryWithSorting += " DESC";

            return queryWithSorting;
        }

        public void cancelSorting()
        {
            dBUtils.getDataFromDB(data, dBUtils.queryForShowingCurrentTable);
        }
    }
}
