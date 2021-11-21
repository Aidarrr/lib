using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrariesClient
{
    class LibraryTable : Table
    {
        DBUtils dBUtils;

        public LibraryTable(DBUtils dBUtils)
        {
            this.dBUtils = dBUtils;
        }

        public override Dictionary<string, string> getNewRowDataFromUser()
        {
            Dictionary<string, string> fieldsForInsert = new Dictionary<string, string>();
            getStandardInput(fieldsForInsert);
            getFormInput(fieldsForInsert);
            if (!InputFormGeneralData.isValidInput)
                return null;

            return fieldsForInsert;
        }

        private void getStandardInput(Dictionary<string, string> fieldsForInsert)
        {
            string windowName = "Ввод данных в таблицу \"Библиотеки\"";
            fieldsForInsert["name"] = Interaction.InputBox("Введите название библиотеки", windowName, "");
        }

        private void getFormInput(Dictionary<string, string> fieldsForInsert)
        {
            InputForm formForAddress = new InputForm("address", dBUtils);
            formForAddress.ShowDialog();
            if (!InputFormGeneralData.isValidInput)
                return;
            fieldsForInsert["address_id"] = InputFormGeneralData.requestedId;
        }
    }
}
