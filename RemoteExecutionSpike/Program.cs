using Interop.UIAutomationCore;
using Interop.UIAutomationClient;
using Windows.UI.UIAutomation.Core;

namespace RemoteExecutionSpike
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TraditionalExecution();
            RemoteExecution();
        }

        private static void TraditionalExecution()
        {
            IUIAutomation uia = new CUIAutomation8();
        }

        private static void RemoteExecution()
        {
            CoreAutomationRemoteOperation coreOp = new CoreAutomationRemoteOperation();
        }
    }
}