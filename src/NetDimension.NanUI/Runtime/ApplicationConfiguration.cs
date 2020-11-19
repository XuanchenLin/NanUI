using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Caliburn.Light;

namespace NetDimension.NanUI
{
    internal sealed class ApplicationConfiguration
    {

        public Func<ApplicationContext, Formium> UseMainWindow { get; internal set; }

        public Func<ApplicationContext> UseApplicationContext { get; internal set; }

        public Action<Runtime, IDictionary<string, object>>[] UseExtensions { get; internal set; } = new Action<Runtime, IDictionary<string, object>>[5];

        internal ApplicationConfiguration()
        {

        }
    }
}