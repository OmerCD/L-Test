using Xamarin.Forms;
using Client.M_CustomControls;
using Client.Droid.Renderers;
using Xamarin.Forms.Platform.Android;
using RadialProgress;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(RadialProgressBar), typeof(RadialProgressControlRenderer))]

namespace Client.Droid.Renderers
{
    public class RadialProgressControlRenderer : ViewRenderer<RadialProgressBar, RadialProgressView>
    {
        RadialProgressView progressView;
        public RadialProgressControlRenderer()
        {
            progressView = new RadialProgressView(Forms.Context);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<RadialProgressBar> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || this.Element == null)
                return;

            if (e.OldElement != null)
                e.OldElement.PropertyChanged -= Element_PropertyChanged;

            if (this.Element != null)
                Element.PropertyChanged += Element_PropertyChanged;

            var element = (RadialProgressBar)Element;

            progressView.Value = element.Value;
            progressView.MaxValue = element.Maximum;
            progressView.MinValue = element.Minimum;
            progressView.LabelHidden = element.LabelHidden;
            progressView.ProgressColor = element.ProgressColor.ToAndroid();

            SetNativeControl(progressView);
        }

        private void Element_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == RadialProgressBar.MaximumProperty.PropertyName)
            {
                progressView.MaxValue = Element.Maximum;
            }
            else if (e.PropertyName == RadialProgressBar.MinimumProperty.PropertyName)
            {
                progressView.MinValue = Element.Minimum;
            }
            else if (e.PropertyName == RadialProgressBar.ValueProperty.PropertyName)
            {
                progressView.Value = Element.Value;
            }
            else if (e.PropertyName == RadialProgressBar.LabelHiddenProperty.PropertyName)
            {
                progressView.LabelHidden = Element.LabelHidden;
            }
            else if (e.PropertyName == RadialProgressBar.ProgressColorProperty.PropertyName)
            {
                progressView.ProgressColor = Element.ProgressColor.ToAndroid();
            }
        }
    }
}