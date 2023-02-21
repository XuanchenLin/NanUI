using System.Diagnostics;

using NetDimension.NanUI;

namespace FormiumClientSubprocess;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            MessageBox.Show("Subprocesses should not run without NanUI main process is running.","NanUI Subprocess", MessageBoxButtons.OK, MessageBoxIcon.Information);

            MessageBox.Show("这是 NanUI 示例的子进程示例，需要由主进程调用不可单独运行。", "NanUI 子进程示例", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return;
        }

        WinFormium.CreateRuntimeBuilder(app => {
            app.RegisterJavaScriptWindowBinding(() => new FormiumClient.DemoWindowBinding());
        }).Build().RunAsSubprocess();
    }
}
