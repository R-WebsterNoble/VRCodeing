using System;
using CsGenerator;
using CsGenerator.Definition;
using CsGenerator.Expression;
using CsGenerator.Expression.Operator;
using CsGenerator.Statement;
using CsGenerator.Statement.Loop;
using CsGenerator2;
using NUnit.Framework;

//using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test_EmptyFunctionDefinition()
        {
            var function = new FunctionDefinition(new Function("void", "Test"));

            Assert.AreEqual("public void Test(){}", function.ToString());
        }

        [Test]
        public void Test_EmptyFunctionDefinitionWithReturnType()
        {
            var function = new FunctionDefinition(new Function("string", "Test"));

            Assert.AreEqual("public string Test(){}", function.ToString());
        }

        [Test]
        public void Test_FunctionCall()
        {
            var function = new Function("void", "Test");
            var functionCall = new FunctionCallStatement(function);
            ;

            Assert.AreEqual("Test();", functionCall.ToString());
        }

        [Test]
        public void FunctionDefinitionWithFunctionCallBody()
        {
            var function = new FunctionDefinition(new Function("void", "Test"));
            function.Body.Add(new FunctionCallStatement(new Function("void", "Blah")));

            Assert.AreEqual("public void Test(){Blah();}", function.ToString());
        }

        [Test]
        public void Test_VariableAssignment()
        {
            var variableAssignment =
                new IdentifierAssignmentStatement(
                    new IdentifierAssignment(new Identifier("string", "text", new Expression(1))));

            Assert.AreEqual("string text = 1;", variableAssignment.ToString());
        }

        [Test]
        public void Test_FunctionCallWithVariableAssignmentBody()
        {
            var function = new FunctionDefinition(new Function("void", "Test"));
            function.Body.Add(new IdentifierAssignmentStatement(
                new IdentifierAssignment(new Identifier("string", "identifier", new Expression(1)))));

            Assert.AreEqual("public void Test(){string identifier = 1;}", function.ToString());
        }

        [Test]
        public void Test_EmptyClass()
        {
            var function = new Class("Class");

            Assert.AreEqual("public class Class{}", function.ToString());
        }

        [Test]
        public void Test_ClassWithPropertyBody()
        {
            var @class = new Class("Class");
            @class.Body.Add(new Property("string", "prop"));

            Assert.AreEqual("public class Class{public string prop {get;}}", @class.ToString());
        }

        [Test]
        public void Test_ClassWithFunctionBody()
        {
            var @class = new Class("Class");
            @class.Body.Add(new FunctionDefinition(new Function("void", "Test")));

            Assert.AreEqual("public class Class{public void Test(){}}", @class.ToString());
        }

        [Test]
        public void Test_WhileLoop()
        {
            var whileLoop = new WhileLoop(new Expression("true"));

            Assert.AreEqual("while(true){}", whileLoop.ToString());
        }

        [Test]
        public void HelloWorld()
        {
            var nameSpace = new Namespace("HelloWorld");
            nameSpace.Usings.Add(new Using("System"));
            var @class = new Class("Hello");
            nameSpace.NamespacedItems.Add(@class);
            var main = new FunctionDefinition(new Function("void", "Main"));

            var identifier = new Identifier("string", "hello", new Expression("\"Hello\""));
            main.Body.Add(new IdentifierAssignmentStatement(new IdentifierAssignment(identifier)));

            var whileLoop = new WhileLoop(new Expression("true"));
            whileLoop.Body.Add(new FunctionCallStatement(new Function("void", "Console.WriteLine"),
                new AdditionOperator(identifier, new Expression("\"Rich\""))));
            main.Body.Add(whileLoop);
            @class.Body.Add(main);

            Console.WriteLine();

            var expected = "using System;namespace HelloWorld{public class Hello{public void Main(){string hello = \"Hello\"; while(true){Console.WriteLine(hello+\"Rich\");}}}}";
            Assert.AreEqual(expected,nameSpace.ToString());
        }

        [Test]
        public void BottlesOfBeer()
        {
            var nameSpace = new Namespace("NinetyNineBottlesOfBeer");
            nameSpace.Usings.Add(new Using("System"));
            var @class = new Class("NinetyNineBottlesOfBeerSong");
            nameSpace.NamespacedItems.Add(@class);

            var BEER_LYRICS_MORE = new Identifier("string", "BEER_LYRICS_MORE",
                new Expression(
                    "@\"\r\n{0} bottle{1} of beer on the wall,\r\n{0} bottle{1} of beer.\r\nTake one down, pass it around,\r\n{2} bottle{3} of beer on the wall.\""));
            @class.Body.Add(new IdentifierAssignmentStatement(new IdentifierAssignment(BEER_LYRICS_MORE)));

            var BEER_LYRICS_NONE = new Identifier("string", "BEER_LYRICS_NONE",
                new Expression(
                    "@\"\r\n{0} bottle{1} of beer on the wall,\r\n{0} bottle{1} of beer.\r\nTake one down, pass it around,\r\nNo more bottles of beer on the wall.\""));
            @class.Body.Add(new IdentifierAssignmentStatement(new IdentifierAssignment(BEER_LYRICS_NONE)));


            var identifier = new Identifier("int", "i", new Expression(99));
            var countParam = new Identifier("int", "count", new IdentifierAssignment(identifier));
            var tmp = new Identifier("string", "tmp", new Expression("\"\""));
            var stringFormat = new Function("string", "string.Format");
            var sing = new FunctionDefinition(new Function("string","Sing", countParam))
            {
                Body =
                {
                    new IdentifierAssignmentStatement(new IdentifierAssignment(tmp)),
                    new If(new EqualsOperator(countParam, new Expression(1)))
                    {
                        Body =
                        {
                            new ReturnStatement
                            {
                                Body =
                                {
                                    new FunctionCallExpression(stringFormat,
                                        BEER_LYRICS_MORE,
                                        countParam,
                                        new TurnaryOperator(
                                            new EqualsOperator(countParam, new Expression(1)),
                                            new Expression("\"\""),
                                            new Expression("\"s\""))
                                    )
                                }
                            }
                        }
                    },
                    new If(new GreaterThanOperator(countParam, new Expression(0)))
                    {
                        Body =
                        {
                            new ReturnStatement
                            {
                                Body =
                                {
                                    new FunctionCallExpression(stringFormat,
                                        BEER_LYRICS_NONE,
                                        countParam,
                                        new TurnaryOperator(
                                            new EqualsOperator(countParam, new Expression(1)),
                                            new Expression("\"\""),
                                            new Expression("\"s\"")),
                                        new SubtractionOperator(countParam, new Expression(1)),
                                        new TurnaryOperator(
                                            new EqualsOperator(new SubtractionOperator(countParam, new Expression(1)),
                                                new Expression(1)),
                                            new Expression("\"\""),
                                            new Expression("\"s\""))
                                    )
                                }
                            }
                        }
                    },
                    new Statement(new AssignmentOperator(tmp, new Expression("\"\""))),
                    new ReturnStatement
                    {
                        Body = {tmp}
                    }
                }
            };
            @class.Body.Add(sing);

            var song = new Identifier("NinetyNineBottlesOfBeerSong", "song", new ObjectInitialization(@class));
            var i = new Identifier("int", "i", new Expression(99));
            @class.Body.Add(new FunctionDefinition(new Function("void", "Main"))
            {
                Body =
                {
                    new IdentifierAssignmentStatement(new IdentifierAssignment(song)),
                    new ForLoop(
                        new IdentifierAssignment(i),
                        new LessThanOperator(i, new Expression(0)),
                        new PostfixIncrementUnaryOperator(i)
                    )
                    {
                        Body =
                        {
                            new FunctionCallStatement(new Function("void", "Console.WriteLine"), new MemberAccessOperator(song,new FunctionCallExpression(sing.Function, i)))
                        }
                    }
                }
            });


            //var whileLoop = new WhileLoop( new Expression("true"));
            //whileLoop.Body.Add(new FunctionCallStatement(new Function("void", "Console.WriteLine"), new AdditionOperator(identifier,new Expression("\"Rich\""))));
            //SingDeclaration().Body.Add(whileLoop);
            //@class.Body.Add(SingDeclaration());


            var expected = "using System;namespace NinetyNineBottlesOfBeer{public class NinetyNineBottlesOfBeerSong{string BEER_LYRICS_MORE = @\"\r\n{0} bottle{1} of beer on the wall,\r\n{0} bottle{1} of beer.\r\nTake one down, pass it around,\r\n{2} bottle{3} of beer on the wall.\";string BEER_LYRICS_NONE = @\"\r\n{0} bottle{1} of beer on the wall,\r\n{0} bottle{1} of beer.\r\nTake one down, pass it around,\r\nNo more bottles of beer on the wall.\";public string Sing(int count){string tmp = \"\"; if(count==1){return string.Format(BEER_LYRICS_MORE,count,count==1?\"\":\"s\");} if(count>0){return string.Format(BEER_LYRICS_NONE,count,count==1?\"\":\"s\",count-1,count-1==1?\"\":\"s\");} tmp=\"\"; return tmp;}public void Main(){NinetyNineBottlesOfBeerSong song = new NinetyNineBottlesOfBeerSong(); for(int i = 99;i<0;i++){Console.WriteLine(song.Sing(i));}}}}";
            Assert.AreEqual(expected,nameSpace.ToString());
        }

        [Test]
        public void Test_RoslynCodeEditor()
        {
            new RoslynCodeEditor().Gen();
        }
    }
}