using Interop.UIAutomationCore;
using Interop.UIAutomationClient;
using Windows.UI.UIAutomation.Core;
using Windows.UI.UIAutomation;
using System.Runtime.InteropServices;
using System;

namespace RemoteExecutionSpike
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RemoteExecution();
        }

        private static void RemoteExecution()
        {
            CoreAutomationRemoteOperation coreOp = new CoreAutomationRemoteOperation();
            IUIAutomation uia = new CUIAutomation8();
            var focusedElement = uia.GetFocusedElement();
            var name = focusedElement.CurrentName;

            // OPTION 1
            var element = focusedElement as object as AutomationElement; // This is null even when focusedElement is not

            // OPTION 2
            //var pinndeObj = GCHandle.Alloc(focusedElement, GCHandleType.Normal);
            //var ptr = GCHandle.ToIntPtr(pinndeObj);
            // TODO throws-> System.AccessViolationException: 'Attempted to read or write protected memory. This is often an indication that other memory is corrupt.'
            //var element = AutomationElement.FromAbi(ptr); 


            var elementId = new AutomationRemoteOperationOperandId(0);

            // TODO throws-> System.AccessViolationException: 'Attempted to read or write protected memory. This is often an indication that other memory is corrupt.'
            coreOp.ImportElement(elementId, element); 

        }
    }
}