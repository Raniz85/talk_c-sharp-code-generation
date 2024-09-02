using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Codegen.Tests.Utils;

public static class GeneratorHelpers
{

    public static IDictionary<string, string> RunSourceGenerator(this IIncrementalGenerator generator, string sourceCode)
    {
        var driver = CSharpGeneratorDriver.Create(generator);

        // Create a compilation with the provided source code 
        var compilation = CSharpCompilation.Create(nameof(GeneratorHelpers),
            new[] { CSharpSyntaxTree.ParseText(sourceCode) },
            new[]
            {
                // To support 'System.Attribute' inheritance, add reference to 'System.Private.CoreLib'.
                MetadataReference.CreateFromFile(typeof(object).Assembly.Location)
            });

        // Run generators and retrieve all results.
        var runResult = driver.RunGenerators(compilation).GetRunResult();

        // Map the generated file names to their source code and return that
        return runResult.GeneratedTrees
            .Where(tree => !tree.FilePath.EndsWith("DbTestAttribute.generated.cs"))
            .ToDictionary(tree => tree.FilePath, tree => tree.GetText().ToString());
    }
}