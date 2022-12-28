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

            var instructions = GetInstructions();
            var pinndeObj = GCHandle.Alloc(instructions, GCHandleType.Pinned);
            IntPtr dataPointer = (nint)pinndeObj;

            // Unhandled exception. System.Runtime.InteropServices.COMException (0x8000FFFF): Catastrophic failure (0x8000FFFF (E_UNEXPECTED))
            var executionResult = coreOp.Execute(instructions);//dataPointer as object as byte[]);
            Console.WriteLine("Execution status: " + executionResult.Status);
        }

        private static byte[] GetInstructions()
        {
            byte[] arr = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x4c, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x4d, 0x00, 0x00, 0x00, 0x03, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00 };
            return arr;
        }
    }
}