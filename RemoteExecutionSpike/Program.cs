using Interop.UIAutomationCore;
using Interop.UIAutomationClient;
using Windows.UI.UIAutomation.Core;
using Windows.UI.UIAutomation;


namespace RemoteExecutionSpike
{
    internal class Program
    {
        private static int instructionId = 0;

        static void Main(string[] args)
        {
            RemoteExecution();
        }

        // TODO example: https://github.com/microsoft/Microsoft-UI-UIAutomation/blob/f36cdb687fae4a397fc39f941ea5a7281211f3cf/src/UIAutomation/Microsoft.UI.UIAutomation/AutomationRemoteOperation.cpp#L302
        private static void RemoteExecution()
        {
            // TODO how to specify pid? https://github.com/microsoft/Microsoft-UI-UIAutomation/blob/f36cdb687fae4a397fc39f941ea5a7281211f3cf/src/UIAutomation/FunctionalTests/WinRTBuilderTests.cpp
            CoreAutomationRemoteOperation coreOp = new CoreAutomationRemoteOperation();
            ImportElement(coreOp);
            var instructions = GetInstructions();
            var executionResult = coreOp.Execute(instructions); // performs a blocking cross-process call
            Console.WriteLine("Execution status: " + executionResult.Status);
        }

        private static void ImportElement(CoreAutomationRemoteOperation coreOp)
        {
            IUIAutomation uia = new CUIAutomation8();
            var focusedElement = uia.GetFocusedElement();
            Console.WriteLine("Focused element: " + focusedElement.CurrentName);

            var element = focusedElement as object as AutomationElement;
            var elementId = new AutomationRemoteOperationOperandId(instructionId);
            instructionId++;

            Console.WriteLine("Importing element");
            coreOp.ImportElement(elementId, element); // TODO throws-> accessing protected memory
            Console.WriteLine("Import element finished");
        }

        private static byte[] GetInstructions()
        {
            return new byte[1024]; // TODO
        }
    }
}