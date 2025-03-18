// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI;

public sealed class EmbeddedControlStyle : FormStyle
{
    internal EmbeddedControlStyle(Formium formium, Control container) : base(formium)
    {
        Container = container;
    }

    public Control Container { get; }

    protected internal override bool HasSystemTitleBar { get; set; } = false;
    protected internal override bool UseBrowserHitTest { get; set; } = false;
    protected internal override bool AsEmbeddedControl => false;

    public override CreateHostWindowDelegate CreateHostWindow()
    {
        return () =>
        {
            var window = new EmbeddedInControlWindow(this, Container);

            return window;
        };
    }

    protected internal override void OverwriteHostWindowProperties(Form form)
    {

    }
}

public static class EmbeddedControlStyleExtension
{
    public static EmbeddedControlStyle UseAsEmbedded(this WindowStyleBuilder builder, Control container)
    {
        return new EmbeddedControlStyle(builder.FormiumInstance, container);
    }
}