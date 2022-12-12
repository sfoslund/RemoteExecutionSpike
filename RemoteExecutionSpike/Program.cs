using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Interop.UIAutomationCore;
using Interop.UIAutomationClient;
using Windows.UI.UIAutomation.Core;

namespace RemoteExecutionSpike
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        private static void TraditionalExecution()
        {
            IUIAutomation uia = new CUIAutomation8();
            //var elements = TraditionalElementsFromProcessId(pid, uia);
            //Console.WriteLine();
        }

        // TODO
        //public static IList<IUIAutomationElement> TraditionalElementsFromProcessId(int pid, IUIAutomation uia)
        //{
        //    IUIAutomationElement root = null;
        //    IList<IUIAutomationElement> matchingElements;

        //    try
        //    {
        //        // check whether process exists first.
        //        // if not, it will throw an ArgumentException
        //        using (var proc = Process.GetProcessById(pid))
        //        {
        //            root = uia.GetRootElement();
        //            matchingElements = dataContext.A11yAutomation.FindProcessMatchingChildrenOrGrandchildren(root, pid);
        //        }
        //    }
        //    finally
        //    {
        //        if (root != null)
        //        {
        //            Marshal.ReleaseComObject(root);
        //        }
        //    }

        //    return matchingElements;
        //}

        private static void RemoteExecution()
        {
            //AutomationRemoteOperation op = new AutomationRemoteOperation();
            CoreAutomationRemoteOperation coreOp = new CoreAutomationRemoteOperation();
        }
    }
}