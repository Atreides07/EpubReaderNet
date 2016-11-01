using System;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using EpubReader.EpubModel;
using NUnit.Framework;
using Should;

namespace EpubReader.Test
{
    [TestFixture]
    public class EpubReader31Test
    {
        private static readonly object[] TestCaseSource = {
            new object[] {  "TestContent/Epub31/moby-dick-31-html.epub", (EpubContent epub) => { epub.RootFiles.Count},1}
        };

        string projectDir;
        [SetUp]
        public void Setup()
        {
            projectDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        [TestCaseSource(nameof(TestCaseSource))]
        public async Task Epub(string fileName, Func<EpubContent,object> func, object expectedValue)
        {
            using (var fs = GetFile(fileName))
            {
                var epubReader = new EpubReader();
                var epubContent=epubReader.Reader(fs);
                Assert.AreEqual(expectedValue,func(epubContent));
            }
        }

        private Stream GetFile(string fileName)
        {
            return File.Open(Path.Combine(projectDir, fileName), FileMode.Open, FileAccess.Read, FileShare.Read);
        }
    }
}
