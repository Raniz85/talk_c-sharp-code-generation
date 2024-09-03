using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Codegen.Tests;

public static class CodeGenExtensions
{
    public static IDictionary<string, string> RunSourceGenerator(this IIncrementalGenerator generator,
        string sourceCode)
    {
        var driver = CSharpGeneratorDriver.Create(generator);

        var compilation = CSharpCompilation.Create(nameof(CodeGenExtensions),
            [CSharpSyntaxTree.ParseText(sourceCode),],
            [MetadataReference.CreateFromFile(typeof(object).Assembly.Location),]);

        var runResult = driver.RunGenerators(compilation).GetRunResult();

        return runResult.GeneratedTrees
            .ToDictionary(tree => tree.FilePath, tree => tree.GetText().ToString());
    }
    
}