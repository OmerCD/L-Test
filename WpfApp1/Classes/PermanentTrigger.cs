
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace ltest.Classes
{
    class PermanentTrigger
    {
        public void Change(DockPanel dockPanel, Button clickedButton)
        {
            Style contentMenu = Application.Current.FindResource("ContentMenuButton") as Style;
            Style contentMenuStyled = Application.Current.FindResource("ContentMenuButtonTrigger") as Style;
            Style menuTextBlock = Application.Current.FindResource("MenuTextBlock") as Style;
            Style menuTextBlockStyled = Application.Current.FindResource("MenuTextBlockStyled") as Style;
            TextBlock textBlock;

            foreach (var item in dockPanel.Children)
            {
                if (item is Button button)
                {
                    button.Style =  contentMenu;
                    textBlock = (TextBlock)button.Content;
                    textBlock.Style = menuTextBlock;
                }
                textBlock = (TextBlock)clickedButton.Content;
                textBlock.Style = menuTextBlockStyled;
                clickedButton.Style = contentMenuStyled;
            }
        }

        public void ChangeStack(StackPanel stackPanel, Button clickedButton)
        {
            Style iconBox = Application.Current.FindResource("IconBox") as Style;
            Style iconBoxStyled = Application.Current.FindResource("IconBoxStyled") as Style;
            Style ustMenuLabel = Application.Current.FindResource("UstMenuLabel") as Style;
            Style ustMenuLabelStyled = Application.Current.FindResource("UstMenuLabelStyled") as Style;
            Style menuButton = Application.Current.FindResource("MenuButton") as Style;
            Style menuButtonStyled = Application.Current.FindResource("MenuButtonStyled") as Style;
            DockPanel dockPanel;
            foreach (var item in stackPanel.Children)
            {
                if (item is Button button)
                {
                    button.Style = menuButton;
                    if (item is DockPanel)
                    {
                        dockPanel = (DockPanel)button.Content;
                        foreach (var buttonItem in dockPanel.Children)
                        {
                            if (buttonItem is Rectangle rectangle)
                            {
                                rectangle.Style = iconBox;
                            }
                            if (buttonItem is Label label)
                            {
                                label.Style = ustMenuLabel;
                            }
                        }
                    }
                }

                ////label = (Label)clickedButton.Content;
                ////label.Style = ustMenuLabelStyled;
                ////rectangle = (Rectangle)clickedButton.Content;
                ////rectangle.Style = iconBoxStyled;
                //clickedButton.Style = menuButtonStyled;
                //dockPanel = (DockPanel)clickedButton.Content;
                //Rectangle rectangleClicked = (Rectangle)dockPanel.Children[0];
                //Label labelClicked = (Label)dockPanel.Children[1];
                //rectangleClicked.Style = iconBoxStyled;
                //labelClicked.Style = ustMenuLabelStyled;
            }
        }
    }
}
