using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace Client.M_Classes
{
    class TestGoster
    {
        private static int _soru;
        private static int _cevap;

        public StackLayout[] SoruCevapStack;
        public  StackLayout[] SoruStack;
        public StackLayout[,] CevapStack;
        public StackLayout FullStack;

        public Label[] SoruNoLabel;
        public  Label[] SoruLabel;

        public  Label[,] CevapLabel;
        public  CheckBox[,] CevapCheckBoxes;
        public Frame[] CevapFrame;

        public TestGoster(int soru, int cevap)
        {
            _soru = soru;
            _cevap = cevap;

            SoruCevapStack = new StackLayout[_soru];
            SoruStack = new StackLayout[_soru];
            CevapStack = new StackLayout[_soru,_cevap];

            SoruNoLabel = new Label[_soru];
            SoruLabel = new Label[_soru];

            CevapCheckBoxes = new CheckBox[_soru, _cevap];
            CevapLabel = new Label[_soru, _cevap];
            CevapFrame = new Frame[_soru];
        }
        public void ControlCreation()
        {
            for (int i = 0; i < _soru; i++)
            {
                SoruCevapStack[i] = new StackLayout()
                {
                };
                SoruStack[i] = new StackLayout()
                {
                    Orientation=StackOrientation.Horizontal
                };
                SoruNoLabel[i] = new Label()
                {
                    Text = (i + 1).ToString()+". Soru",
                    MinimumWidthRequest=150,
                    //BackgroundColor = Color.CornflowerBlue,
                    TextColor = Color.Black,
                    FontSize=24,
                    HorizontalOptions=LayoutOptions.CenterAndExpand,
                    HorizontalTextAlignment = TextAlignment.Start,
                    VerticalTextAlignment = TextAlignment.Center
                };
                SoruLabel[i] = new Label()
                {
                    //BackgroundColor=Color.LightSkyBlue,
                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas magna ipsum, sagittis eget orci eget, vulputate pretium leo. Cras et elit tortor. Proin quam sem, placerat quis augue eu, consectetur laoreet mauris. Aliquam erat volutpat. Cras cursus sem et posuere efficitur. Integer velit ex, condimentum id volutpat vel, pretium vitae risus metus.",
                    TextColor = Color.Black,                   
                    HorizontalTextAlignment = TextAlignment.Start,
                    VerticalTextAlignment=TextAlignment.Center

                };
                CevapFrame[i] = new Frame()
                {
                    CornerRadius = 10,
                    Margin=new Thickness(5)
                };
                for (int k = 0; k < _cevap; k++)
                {
                    CevapStack[i,k] = new StackLayout()
                    {
                        Orientation = StackOrientation.Horizontal
                    };
                    CevapCheckBoxes[i, k] = new CheckBox()
                    {

                    };
                    CevapLabel[i, k] = new Label()
                    {
                        Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque amet.",
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        Margin = new Thickness(0,2,0,0),
                        TextColor=Color.Black
                    };
                }
            }
            FullStack = new StackLayout();

            //STACKLAYOUTLARA EKLEME 
            for (int i = 0; i < _soru; i++)
            {
                SoruStack[i].Children.Add(SoruNoLabel[i]);
                SoruStack[i].Children.Add(SoruLabel[i]);
                SoruCevapStack[i].Children.Add(SoruStack[i]);
                for (int k = 0; k < _cevap; k++)
                {
                    CevapStack[i,k].Children.Add(CevapCheckBoxes[i, k]);
                    CevapStack[i, k].Children.Add(CevapLabel[i, k]);
                    SoruCevapStack[i].Children.Add(CevapStack[i, k]);
                }
                CevapFrame[i].Content = SoruCevapStack[i];
                FullStack.Children.Add(CevapFrame[i]);                
            };
        }
    }
}


//public void ControlCreation(StackLayout soruDock)//Kontroller Burada Tanımlandı.
//{
//    for (var i = 0; i < _soru; i++)
//    {
//        SoruStack[i] = new StackLayout
//        {
//            Margin = new Thickness(0, 0, 0, 10),
//            HorizontalOptions=LayoutOptions.CenterAndExpand,
//            VerticalOptions=LayoutOptions.CenterAndExpand,
//            Orientation = StackOrientation.Horizontal,
//            WidthRequest = double.NaN
//        };
//        Label[i] = new Label
//        {
//            Text = "Soru " + (i + 1) + ":",
//            WidthRequest = 120,
//            HeightRequest = double.NaN, // Auto için bunu yazdık. Niye acaba?Cevap : Onu öyle yapmışlar. Yapana sormak gerek.
//            BackgroundColor = Color.CornflowerBlue
//        };
//        SoruTextBoxes[i] = new Entry();
//        CevapStack[i] = new StackLayout
//        {
//            HorizontalOptions = LayoutOptions.CenterAndExpand,
//            VerticalOptions = LayoutOptions.CenterAndExpand,
//            Orientation = StackOrientation.Horizontal,
//            Margin = new Thickness(0, 5, 5, 0)
//        };
//        Sp[i] = new BoxView
//        {
//            Margin = new Thickness(0, 10, 0, 10),
//            Color = Color.Black,
//            MinimumWidthRequest = 100,
//            HeightRequest = 2
//        };

//        for (var k = 0; k < _cevap; k++)
//        {
//            CevapCheckBoxes[i, k] = new CheckBox
//            {
//                Margin = new Thickness(0, 5, 0, 5)
//            };
//            CevapTextboxes[i, k] = new Entry
//            {
//                MinimumWidthRequest = 200
//            };

//            Stack3[i] = new StackLayout
//            {
//                Orientation = StackOrientation.Horizontal
//            };

//        }
//    }

//    for (var i = 0; i < _soru; i++) // Kontroller Burada DockPanellere Eklendi.
//    {
//        SoruStack[i].Children.Add(Label[i]);
//        SoruStack[i].Children.Add(SoruTextBoxes[i]);

//        CevapStack[i].Children.Add(CevapCheckBoxes[i, k]);
//        CevapStack[i].Children.Add(CevapTextboxes[i, k]);

//        soruDock.Children.Add(SoruStack[i]);
//        soruDock.Children.Add(CevapStack[i]);

//        for (var k = 0; k < _cevap; k++)
//        {
//            SoruStack[i].Children.Add(Stack3[i]);
//        }
//        CevapStack[i].Children.Add(Sp[i]);
//    }