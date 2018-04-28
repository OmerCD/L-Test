using System.Windows.Controls;

namespace LTest.Classes
{
    public class UserControlClass
    {
       public static void ControlAdd(Grid grd, UserControl usrControl)
        {
            if (grd.Children.Count>0)
            {
                grd.Children.Clear();
                grd.Children.Add(usrControl);
            }
            else
            {
                grd.Children.Add(usrControl);
            }
        }
    }
}
