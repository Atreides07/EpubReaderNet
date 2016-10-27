using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;

namespace EpubReader.Test
{
    [TestFixture]
    public class EpubReader31Test
    {
        [Test]
        public async Task Epub()
        {
            using (var fs = File.Open("TestContent/Epub31/moby-dick-31-html.epub", FileMode.Open,FileAccess.Read,FileShare.Read))
            {
                var epubReader = new EpubReader();
                var epub=epubReader.Reader(fs);
            }
        }

        
    }
}
