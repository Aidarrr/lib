using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrariesClient
{
    class ShowingView
    {
        RepetitionService repetitionService;
        DBUtils dBUtils;
        DataGridView data;

        public ShowingView(DBUtils dBUtils, DataGridView data)
        {
            this.dBUtils = dBUtils;
            repetitionService = new RepetitionService(dBUtils);
            this.data = data;
        }

        public void showView(string viewName)
        {
            var argsForView = getArgsForView(viewName);
            Dictionary<string, int> argsWithId = new Dictionary<string, int>();

            if (argsForView != null)
            {
                argsWithId = changeNameToId(argsForView);
                if (argsWithId == null)
                {
                    showErrorMessage();
                    return;
                }
            }

            var setScripts = ViewsSQLScripts.getSetScripts(argsWithId);
            runSetScripts(setScripts);

            var openViewScript = ViewsSQLScripts.getOpenViewScript(viewName);
            dBUtils.getDataFromDB(data, openViewScript);
            dBUtils.queryForShowingCurrentTable = openViewScript;
        }

        private Dictionary<string, int> changeNameToId(Dictionary<string, string> argsForView)
        {
            Dictionary<string, int> argsWithIds = new Dictionary<string, int>();
            foreach (var arg in argsForView)
            {
                int id = getIdByName(arg.Key, arg.Value);
                if (id == -1)
                    return null;

                argsWithIds[arg.Key] = id;
            }

            return argsWithIds;
        }

        private int getIdByName(string tableName, string fieldName)
        {
            if (tableName == "@idlib")
                return repetitionService.getIdOfLibrary(fieldName);
            if (tableName == "@idtopic")
                return repetitionService.getIdOfTopic(fieldName);
            return repetitionService.getIdOfPublisher(fieldName);
        }

        private void showErrorMessage()
        {
            MessageBox.Show("Введенные данные отсутствуют в таблицах",
                            "Запрос не выполнен",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.DefaultDesktopOnly);
        }

        private void runSetScripts(List<string> setScripts)
        {
            foreach (var script in setScripts)
            {
                MySqlCommand command = new MySqlCommand(script, dBUtils.MySqlConnection);
                command.ExecuteNonQuery();
            }
        }

        private Dictionary<string, string> getArgsForView(string viewName)
        {
            Dictionary<string, string> args =  new Dictionary<string, string>();

            if (viewName == "get_books_by_topic")
            {
                args["@idtopic"] = Interaction.InputBox("Введите название жанра", "Входные данные для отчета", "");
                args["@idlib"] = Interaction.InputBox("Введите название библиотеки", "Входные данные для отчета", "");
            }
            if(viewName == "libraries_publisher_books_qt")
            {
                args["@idpublisher"] = Interaction.InputBox("Введите наименования издателя", "Входные данные для отчета", "");
            }

            return args;
        }
    }
}
