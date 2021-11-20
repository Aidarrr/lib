using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrariesClient
{
    class RadioButtonsOperators
    {
        public RadioButton less;
        public RadioButton lessOrEqual;
        public RadioButton greater;
        public RadioButton greaterOrEqual;
        public RadioButton equal;

        public RadioButtonsOperators(RadioButton less, RadioButton lessOrEqual, RadioButton greater, RadioButton greaterOrEqual, RadioButton equal)
        {
            this.less = less;
            this.lessOrEqual = lessOrEqual;
            this.greater = greater;
            this.greaterOrEqual = greaterOrEqual;
            this.equal = equal;
        }

        public void checkEqualButton()
        {
            var checkedButton = getCheckedRadioButton();
            checkedButton.Checked = false;

            equal.Checked = true;
        }

        public string getCheckedOperator()
        {
            if (less.Checked)
                return less.Text;
            if (lessOrEqual.Checked)
                return lessOrEqual.Text;
            if (greater.Checked)
                return greater.Text;
            if (greaterOrEqual.Checked)
                return greaterOrEqual.Text;
            return equal.Text;
        }

        public RadioButton getCheckedRadioButton()
        {
            if (less.Checked)
                return less;
            if (lessOrEqual.Checked)
                return lessOrEqual;
            if (greater.Checked)
                return greater;
            if (greaterOrEqual.Checked)
                return greaterOrEqual;
            return equal;
        }
    }
}
