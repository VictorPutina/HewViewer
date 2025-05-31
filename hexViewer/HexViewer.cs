using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ASC_Hex_Viewer
{
    public class HexViewer
    {
        public List<byte[]> ReadBytes(string filePath, int lineLength, int maxBytes)
        {
            var result = new List<byte[]>();

            using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                int totalRead = 0;
                while (totalRead < maxBytes)
                {
                    byte[] buffer = new byte[lineLength];
                    int bytesRead = fs.Read(buffer, 0, lineLength);

                    if (bytesRead == 0)
                        break;

                    if (bytesRead < lineLength)
                    {
                        Array.Resize(ref buffer, bytesRead);
                    }

                    result.Add(buffer);
                    totalRead += bytesRead;
                }
            }

            return result;
        }

        public string DisplayLine(byte[] line, int index, int totalLines)
        {
            StringBuilder hex = new StringBuilder();
            StringBuilder ascii = new StringBuilder();

            foreach (byte b in line)
            {
                hex.AppendFormat("{0:X2} ", b);
                ascii.Append(b >= 32 && b <= 126 ? (char)b : '.');
            }

            return $"{index:D4}: {hex.ToString().PadRight(48)} {ascii}";
        }
    }
}
