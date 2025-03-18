// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI.Forms;

public sealed class WindowStyleBuilder
{
    public Formium FormiumInstance { get; }

    public Control? ContainerControl { get; set; }

    internal WindowStyleBuilder(Formium formium, Control? containerControl = null)
    {
        FormiumInstance = formium;
        ContainerControl = containerControl;

    }


}

