using JetBrains.Annotations;
using Microsoft.CodeAnalysis.CSharp;
using NodeComponents;

public class RootNode : Node
{
    //public GameObject AttachmentPoint;

    //private Dictionary<SyntaxNode, GameObject> _nodes = new Dictionary<SyntaxNode, GameObject>();


    // Start is called before the first frame update

    [UsedImplicitly]
    private void Start()
    {
        RootNode = this;

        //    var source =
        //"// Simplistic, yet working C# sample\r\n// Author: Mark Hurley\t(markph@mailcan.com)\r\n// May 30, 2005\r\n\r\nusing System;\r\n\r\nnamespace NinetyNineBottlesOfBeer\r\n{\r\n    /// <summary>\r\n    /// Infamous 99 bottles of beer song in C#.Net\r\n    /// </summary>\r\n    class NinetyNineBottlesOfBeerSong\r\n    {\r\n        /// <summary>\r\n        /// beer verse more beer left\r\n        /// </summary>\r\n        private const string BEER_LYRICS_MORE = @\"\r\n{0} bottle{1} of beer on the wall,\r\n{0} bottle{1} of beer.\r\nTake one down, pass it around,\r\n{2} bottle{3} of beer on the wall.\";\r\n\r\n        /// <summary>\r\n        /// beer verse no more beer left\r\n        /// </summary>\r\n        private const string BEER_LYRICS_NONE = @\"\r\n{0} bottle{1} of beer on the wall,\r\n{0} bottle{1} of beer.\r\nTake one down, pass it around,\r\nNo more bottles of beer on the wall.\";\r\n\r\n        /// <summary>\r\n        /// Determine the proper verse, then merge it with <c>count</c>.\r\n        /// </summary>\r\n        /// <param name=\"count\">Number of bottles remaining.</param>\r\n        /// <returns>Properly formated string verse for song.</returns>\r\n        public string Sing(int count)\r\n        {\r\n            string tmp = \"\";\r\n            if (count == 1)\r\n                return string.Format(BEER_LYRICS_NONE,\r\n                    count,\r\n                    (count == 1) ? \"\" : \"s\");\r\n            else if (count > 0)\r\n                return string.Format(BEER_LYRICS_MORE,\r\n                    count,\r\n                    (count == 1) ? \"\" : \"s\",\r\n                    (count - 1),\r\n                    ((count - 1) == 1) ? \"\" : \"s\");\r\n            else\r\n                tmp = \"\";\r\n\r\n            return tmp;\r\n        }\r\n\r\n        [STAThread]\r\n        static void Main(string[] args)\r\n        {\r\n            NinetyNineBottlesOfBeerSong song = new NinetyNineBottlesOfBeerSong();\r\n\r\n            for (int i = 99; i > 0; i--)\r\n            {\r\n                Console.WriteLine(song.Sing(i));\r\n                Console.ReadLine();\r\n            }\r\n        }\r\n    }\r\n}";
        var source = @"
using System;
class Hello 
{
    static void Main() 
    {
        {}
        {;}
        {;;}
    }
}";

        var code = CodeEditor.Parse(source).GetRoot();

        //var code = new CodeEditor().Gen(source).GetRoot();
        RebuildTree(code);
    }

    public override void InitComponents()
    {
        name = DisplayString;
    }
}