using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrariesClient
{
    class Filter
    {
        RadioButtonsOperators operators;
        DataGridView data;
        DBUtils dBUtils;

        public Filter(RadioButtonsOperators operators, DataGridView data, DBUtils dBUtils)
        {
            this.operators = operators;
            this.data = data;
            this.dBUtils = dBUtils;
        }

        public void showTableWithFilter(string columnName, string value)
        {
            if (!isColumnPresent(columnName))
                return;
            if (value == "")
                return;
            string oper = getOperator(value);

            string queryWithoutFilter = dBUtils.queryForShowingCurrentTable;

            string queryWithFilter = generateQueryWithFilter(queryWithoutFilter, columnName, oper, value);
            dBUtils.getDataFromDB(data, queryWithFilter);
        }

        private string generateQueryWithFilter(string queryWithoutFilter, string columnName, string oper, string value)
        {
            if (!isValueNumber(value))
                value = changeToValidStringSQLValue(value);

            string queryWithFilter = "SELECT * FROM (" + queryWithoutFilter + ") as initTable WHERE " + columnName + oper + value;
            return queryWithFilter;
        }

        private bool isColumnPresent(string columnName)
        {
            return ((DataTable)data.DataSource).Columns.Contains(columnName);
        }

        private string getOperator(string value)
        {
            if (!isValueNumber(value))
            {
                checkEqualOperator();
                return getCheckedOperator();
            }

            return getCheckedOperator();
        }

        private bool isValueNumber(string value)
        {
            int n;
            bool isNumeric = int.TryParse(value, out n);
            return isNumeric;
        }

        private string changeToValidStringSQLValue(string value)
        {
            return "'" + value + "'";
        }

        private void checkEqualOperator()
        {
            operators.checkEqualButton();
        }

        private string getCheckedOperator()
        {
            return operators.getCheckedOperator();
        }

        public void cancelFilter()
        {
            dBUtils.getDataFromDB(data, dBUtils.queryForShowingCurrentTable);
        }
    }
}
