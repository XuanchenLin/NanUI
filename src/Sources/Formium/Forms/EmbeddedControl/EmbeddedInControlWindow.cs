// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI


namespace NetDimension.NanUI;
partial class _FackUnusedClass
{

}

internal class EmbeddedInControlWindow : StandardWindowForm
{
    public EmbeddedControlStyle Style { get; }
    public Control ContainerControl { get; }


    public EmbeddedInControlWindow(EmbeddedControlStyle style, Control container) : base(false, false)
    {
        Style = style;
        ContainerControl = container;
        FormBorderStyle = FormBorderStyle.None;
        ShowInTaskbar = false;
        TopMost = false;
        TopLevel = false;
        TopLevel = false;
        Parent = container;
        Dock = DockStyle.Fill;
        ContainerControl.Controls.Add(this);

        container.HandleCreated+=(_,_)=>Show();
    }


}
