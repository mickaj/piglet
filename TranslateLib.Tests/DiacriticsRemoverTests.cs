using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TranslateLib.Tests
{
    public class DiacriticsRemoverTests
    {
        private string _sampleString = "ĄąĆćĘęŁłŃńÓóŚśŻżŹź";
        private string _sampleResultString = "AaCcEeLlNnOoSsZzZz";

        private DiacriticsRemover _remover = new DiacriticsRemover();

        [Fact]
        public void TestRemover()
        {
            string result = _remover.Remove(_sampleString);
            Assert.Equal(_sampleResultString, result);
        }
    }
}
