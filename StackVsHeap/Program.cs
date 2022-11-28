using System.Runtime.InteropServices;

namespace StackVsHeap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = 1;
            var address = GetObjectMemoryAddress(number);
            Console.WriteLine($"Stack address of the reference type {typeof(int).Name}: {address}");

            Point notDefinedPoint = null;
            address = GetObjectMemoryAddress(notDefinedPoint);
            Console.WriteLine($"Stack address of the reference type {typeof(Point).Name}: {address}");

            Point definedPoint = new Point();
            address = GetObjectMemoryAddress(definedPoint);
            Console.WriteLine($"Stack address of the reference type {typeof(int).Name}: {address}");
        }

        private static IntPtr GetObjectMemoryAddress(object obj)
        {
            var memoryLocator = GCHandle.Alloc(obj, GCHandleType.Pinned);
            var stackAddress = memoryLocator.AddrOfPinnedObject();
            memoryLocator.Free();
            return stackAddress;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    internal class Point
    {
    }
}
