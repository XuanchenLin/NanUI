using NetDimension.Shiva;
using System.Drawing;

namespace NetDimension.NanUI.HostWindow
{
    public sealed class AcrylicWindowStyle : WindowStyleBase
    {
        private FramelessHostWindow Host { get; }

        public AcrylicWindowStyle(Formium formium)
            : base(formium)
        {
            Host = (FramelessHostWindow)formium.FormHostWindow;
        }

        public ShadowEffect ShadowEffect
        {
            get => Host.ShadowEffect;
            set => Host.ShadowEffect = value;
        }

        public CornerStyle CornerStyle
        {
            get => Host.CornerStyle;
            set => Host.CornerStyle = value;
        }

        public Color ShadowColor
        {
            get => Host.ShadowColor;
            set => Host.ShadowColor = value;
        }

        public Color? InactiveShadowColor
        {
            set => Host.InactiveShadowColor = value;
            get => Host?.InactiveShadowColor;
        }
    }
}
