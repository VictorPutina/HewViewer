using System;

namespace ASC_Hex_Viewer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var hexViewer = new HexViewer();

            while (true)
            {
                Console.Write("Enter filename: ");
                string filePath = Console.ReadLine() ?? "";

                Console.Write("Enter line length: ");
                if (!int.TryParse(Console.ReadLine(), out int lineLength) || lineLength <= 0)
                {
                    Console.WriteLine("Invalid line length. Try again.");
                    continue;
                }

                try
                {
                    var lines = hexViewer.ReadBytes(filePath, lineLength, 4096);

                    for (int i = 0; i < lines.Count; i++)
                    {
                        Console.WriteLine(hexViewer.DisplayLine(lines[i], i, lines.Count));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                Console.WriteLine("Press any key to try again...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
