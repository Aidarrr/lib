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
    public partial class InputForm : Form
    {
        string tableName;
        DBUtils dBUtils;

        public InputForm(string tableName, DBUtils dBUtils)
        {
            InitializeComponent();
            this.tableName = tableName;
            this.dBUtils = dBUtils;
        }

        private void applyBtn_Click(object sender, EventArgs e)
        {
            string userInputText = userInput.Text;
            if (!isValidInput(userInputText))
            {
                InputFormGeneralData.isValidInput = false;
                this.Close();
                return;
            }

            InputFormGeneralData.isValidInput = true;
            InputFormGeneralData.requestedId = userInputText;
            this.Close();
        }

        private bool isValidInput(string userInputText)
        {
            if (!isValueNumber(userInputText))
                return false;
            if (!isRowWithIdExist(userInputText))
                return false;
            return true;
        }

        private bool isRowWithIdExist(string userInputText)
        {
            int rowIndex = -1;
            var rows = tableForUser.Rows;
            for (int i = 0; i < rows.Count - 1; i++)
            {
                if (rows[i].Cells[0].Value.ToString().Equals(userInputText))
                {
                    rowIndex = rows[i].Index;
                    break;
                }
            }

            if (rowIndex == -1)
                return false;
            return true;
        }

        private bool isValueNumber(string value)
        {
            int n;
            bool isNumeric = int.TryParse(value, out n);
            return isNumeric;
        }


        private void InputForm_Load(object sender, EventArgs e)
        {
            messageForUserLbl.Text = "Введите id из таблицы " + tableName;
            dBUtils.getDataFromDB(tableForUser, "SELECT * FROM " + tableName);
        }
    }
}
