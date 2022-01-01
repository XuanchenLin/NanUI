public static class ControlExtensions
{
    public static void InvokeIfRequired(this Control control, Action action)
    {
        if (control.InvokeRequired)
        {
            try
            {
                control.Invoke(new MethodInvoker(action));
            }
            catch
            {

            }
        }
        else
        {
            action.Invoke();
        }
    }

    public static Action<T> Debounce<T>(this Action<T> func, int milliseconds = 300)
    {
        var last = 0;
        return arg =>
        {
            var current = Interlocked.Increment(ref last);
            Task.Delay(milliseconds).ContinueWith(task =>
            {
                if (current == last)
                    func(arg);
                task.Dispose();
            });
        };
    }

    public static Action Debounce(this Action func, int milliseconds = 300)
    {
        var last = 0;
        return () =>
        {
            var current = Interlocked.Increment(ref last);
            Task.Delay(milliseconds).ContinueWith(task =>
            {
                if (current == last)
                    func.Invoke();

                task.Dispose();
            });
        };
    }

}



