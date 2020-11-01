using System;
using System.Collections.Generic;
using System.Text;
using Xilium.CefGlue;

namespace NetDimension.NanUI
{
    internal sealed class ActionTask : CefTask
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActionTask"/> class.
        /// </summary>
        /// <param name="action">
        /// The action.
        /// </param>
        public ActionTask(Action action)
        {
            Action = action;
        }

        /// <summary>
        /// The execute.
        /// </summary>
        protected override void Execute()
        {
            Action();
            Action = null;
        }

        /// <summary>
        /// Gets or sets the action.
        /// </summary>
        private Action Action { get; set; }
    }
}
