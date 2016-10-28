using System;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using NUnit.Framework;

namespace EpubReader.Test
{
    [TestFixture]
    public class EpubReader31Test
    {
        string projectDir;
        [SetUp]
        public void Setup()
        {
            projectDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        [Test]
        public async Task Epub()
        {
            using (var fs = GetFile("TestContent/Epub31/moby-dick-31-html.epub"))
            {
                var epubReader = new EpubReader();
                epubReader.Reader(fs);
            }
        }

        private Stream GetFile(string fileName)
        {
            return File.Open(Path.Combine(projectDir, fileName), FileMode.Open, FileAccess.Read, FileShare.Read);
        }
    }
}
