using System;
using System.IO;
using System.Linq;
using ICSharpCode.SharpZipLib.GZip;

namespace DataService.Garmin
{
    public class UudecodedUnGZipper
    {
        private readonly string _uuencoded;
        private byte[] _decodedBytes;

        public UudecodedUnGZipper(string uuencoded)
        {
            _uuencoded = uuencoded;
        }

        private static byte[] Decompress(byte[] compressed)
        {
            using (var compressedMemoryStream = new MemoryStream(compressed))
            {
                var gZipInputStream = new GZipInputStream(compressedMemoryStream);
                try
                {
                    using (var unCompressedStream = new MemoryStream())
                    {
                        var noOfBytesReadTotal = 0;
                        const int blockSize = 2048;
                        var byteBlock = new byte[blockSize];
                        while (true)
                        {
                            var noOfBytesRead = gZipInputStream.Read(byteBlock, 0, byteBlock.Length);
                            if (noOfBytesRead <= 0)
                            {
                                break;
                            }
                            noOfBytesReadTotal += noOfBytesRead;
                            unCompressedStream.Write(byteBlock, 0, noOfBytesRead);
                        }
                        var decompressedWithoutTrailingZeros =
                            unCompressedStream.GetBuffer().Take(noOfBytesReadTotal);
                        return decompressedWithoutTrailingZeros.ToArray();
                    }
                }
                finally
                {
                    gZipInputStream.Close();
                }
            }
        }

        private void Decode()
        {
            const int afterActualContentCharCount = 4;
            var indexOfContentAfterBase64Description = _uuencoded.IndexOf("\n") + 1;
            var actualContentLength = _uuencoded.Length -
                                      (afterActualContentCharCount + indexOfContentAfterBase64Description);
            var actualContent = _uuencoded.Substring(indexOfContentAfterBase64Description, actualContentLength);
            _decodedBytes = Convert.FromBase64String(actualContent);
        }

        public byte[] UnGZip()
        {
            Decode();

            var unGZip = Decompress(_decodedBytes);

            return unGZip;
        }
    }
}