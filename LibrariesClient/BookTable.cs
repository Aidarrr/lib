using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrariesClient
{
    class BookTable : Table
    {
        DBUtils dBUtils;

        public BookTable(DBUtils dBUtils)
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
            string windowName = "Ввод данных в таблицу \"Книги\"";
            fieldsForInsert["author"] = Interaction.InputBox("Введите ФИО автора", windowName, "");
            fieldsForInsert["title"] = Interaction.InputBox("Введите название книги", windowName, "");
            fieldsForInsert["year"] = Interaction.InputBox("Введите год издания книги", windowName, "");
            fieldsForInsert["quantity"] = Interaction.InputBox("Введите кол-во книг в данной библиотеке", windowName, "");
        }

        private void getFormInput(Dictionary<string, string> fieldsForInsert)
        {
            InputForm formForLibrary = new InputForm("library", dBUtils);
            formForLibrary.ShowDialog();
            if (!InputFormGeneralData.isValidInput)
                return;
            fieldsForInsert["id_library"] = InputFormGeneralData.requestedId;

            InputForm formForTopic = new InputForm("topic", dBUtils);
            formForTopic.ShowDialog();
            if (!InputFormGeneralData.isValidInput)
                return;
            fieldsForInsert["id_topic"] = InputFormGeneralData.requestedId;

            InputForm formForPublisher = new InputForm("publisher", dBUtils);
            formForPublisher.ShowDialog();
            if (!InputFormGeneralData.isValidInput)
                return;
            fieldsForInsert["id_publisher"] = InputFormGeneralData.requestedId;
        }
    }
}
