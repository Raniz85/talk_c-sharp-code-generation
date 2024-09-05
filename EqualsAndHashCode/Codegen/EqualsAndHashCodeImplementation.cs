using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Codegen;

public class EqualsAndHashCodeImplementation(ClassDeclarationSyntax cls, SourceProductionContext context, Compilation compilation)
{
    private string ClassName => cls.Identifier.Text;
    private SemanticModel SemanticModel => compilation.GetSemanticModel(cls.SyntaxTree);

    private string? Namespace => SemanticModel.GetDeclaredSymbol(cls) is INamedTypeSymbol classSymbol
        ? classSymbol.ContainingNamespace.ToDisplayString()
        : null;

    private IEnumerable<MemberDeclarationSyntax> Members => cls.Members
        .Where(IsMemberToInclude);

    private bool IsMemberToInclude(MemberDeclarationSyntax member)
    {
        return member switch
        {
            FieldDeclarationSyntax => true,
            PropertyDeclarationSyntax prop => prop.AccessorList?.Accessors.Any() ?? false,
            _ => false,
        };
    }

    private IEnumerable<string> MemberAccessors => Members
        .Select(GetMemberName)
        .Select(member => $"this.{member}");

    private IEnumerable<string> EqualsExpressions => Members
        .Select(member => $"Object.Equals(this.{GetMemberName(member)}, other.{GetMemberName(member)})");

    private static string? GetMemberName(MemberDeclarationSyntax member)
    {
        return member switch
        {
            FieldDeclarationSyntax field => field.Declaration.Variables.FirstOrDefault()?.Identifier.Text,
            PropertyDeclarationSyntax prop => prop.Identifier.Text,
            _ => null,
        };
    }
    

    public void GenerateSourceCode()
    {
        if (Namespace == null)
        {
            return;
        }
        var sourceCode = $@"
// <auto-generated/>

namespace {Namespace};

public partial class {ClassName}
{{
    public bool Equals({ClassName}? other)
    {{
        return other != null && {String.Join(" && ", EqualsExpressions)};
    }}

    public override bool Equals(object other)
    {{
        return other is {ClassName} o && this.Equals(o);
    }}

    public override int GetHashCode()
    {{
        return HashCode.Combine({String.Join(", ", MemberAccessors)});
    }}
}}";
        context.AddSource($"{ClassName}.EqualsAndHashCode", sourceCode);
    }
}