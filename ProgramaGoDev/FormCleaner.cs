using System.Windows.Forms;

namespace ProgramaGoDev
{
    class FormCleaner
    {
        public static void Clear(Control control)
        {
            foreach (Control item in control.Controls)
            {
                if (item.HasChildren)
                {
                    Clear(item);
                }
                if (item is TextBoxBase)
                {
                    TextBoxBase Item = (TextBoxBase)item;
                    Item.Clear();
                }
            }
        }
    }
}
