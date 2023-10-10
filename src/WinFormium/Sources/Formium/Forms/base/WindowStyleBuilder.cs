// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.Forms;

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

