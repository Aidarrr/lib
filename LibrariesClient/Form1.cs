using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrariesClient
{
    public partial class Form1 : Form
    {
        DBUtils dbClient = new DBUtils();
        Dictionary<ToolStripMenuItem, string> dictionary = new Dictionary<ToolStripMenuItem, string>();
        string currentTableName;
        Filter filter;
        RadioButtonsOperators operators;
        SortingService sorting;

        public Form1()
        {
            InitializeComponent();
            dbClient.openConnection();

            dictionary[booksMenuStrip] = "book";
            dictionary[libsMenuStrip] = "library";
            dictionary[readersMenuStrip] = "reader";
            dictionary[subsMenuStrip] = "subscription";
            dictionary[topicsMenuStrip] = "topic";
            dictionary[addressesMenuStrip] = "address";
            dictionary[publishersMenuStrip] = "publisher";

            operators = new RadioButtonsOperators(less, lessOrEqual, greater, greaterOrEqual, equal);
            filter = new Filter(operators, dataTable, dbClient);
            sorting = new SortingService(dbClient, dataTable);
        }

        private void издателиToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            currentTableName = "book";
            dbClient.showTableFromDB(dataTable, currentTableName);
        }

        //Show table
        private void menuTables_Click(object sender, EventArgs e)
        {
            currentTableName = dictionary[(ToolStripMenuItem)sender];
            dbClient.showTableFromDB(dataTable, currentTableName);
        }

        private void addRowBtn_Click(object sender, EventArgs e)
        {
            dbClient.addRowToTable(currentTableName);
            dbClient.showTableFromDB(dataTable, currentTableName);
        }

        private void deleteRowBtn_Click(object sender, EventArgs e)
        {
            var idOfSelectedRow = (int)dataTable.SelectedRows[0].Cells[0].Value;
            dbClient.deleteRow(idOfSelectedRow, currentTableName);
            dbClient.showTableFromDB(dataTable, currentTableName);
        }

        private void filterBtn_Click(object sender, EventArgs e)
        {
            filter.showTableWithFilter(colNameInput.Text, conValueInput.Text);
        }

        private void cancelFilterBtn_Click(object sender, EventArgs e)
        {
            filter.cancelFilter();
        }

        private void sortBtn_Click(object sender, EventArgs e)
        {
            bool isDescending = false;
            if (secondSortType.Checked)
                isDescending = true;

            sorting.showSortedTable(colNameForSort.Text, isDescending);
        }

        private void cancelSortBtn_Click(object sender, EventArgs e)
        {
            sorting.cancelSorting();
        }
    }
}
