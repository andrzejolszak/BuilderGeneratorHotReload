namespace BuilderGenerator
{
    public class Templates
    {
        public string GeneratedAttribute { get; set; } = "[GeneratedCode(\"BuilderGenerator\", \"1.0\")]";

        public string PropertyTemplate { get; set; } = @"        public Lazy<{{PropertyType}}> {{PropertyName}} = new Lazy<{{PropertyType}}>(() => default({{PropertyType}}));";

        public string BuildMethodTemplate { get; set; } = @"
        {{GeneratedAttribute}}
        public override {{ClassFullName}} Build()
        {
            if (Object?.IsValueCreated != true)
            {
                Object = new Lazy<{{ClassFullName}}>(() => 
                {
                    var result = new {{ClassFullName}} 
                    {
{{Setters}}
                    };

                    return result;
                });

                if (PostProcessAction != null)
                {
                    PostProcessAction(Object.Value);
                }
            }

            return Object.Value;
        }";

        public string BuildMethodSetterTemplate { get; set; } = "                        {{PropertyName}} = {{PropertyName}}.Value,";

        public string WithPostProcessActionTemplate { get; set; } = @"
        {{GeneratedAttribute}}
        public {{BuilderName}} WithPostProcessAction(Action<{{ClassFullName}}> action)
        {
            PostProcessAction = action;

            return this;
        }

        {{GeneratedAttribute}}
        public T WithPostProcessAction<T>(Action<{{ClassFullName}}> action) where T : {{BuilderName}}
        {
            PostProcessAction = action;

            return (T)this;
        }";

        public string WithMethodTemplate { get; set; } = @"
        {{GeneratedAttribute}}
        public {{BuilderName}} With{{PropertyName}}({{PropertyType}} value)
        {
            return With{{PropertyName}}(() => value);
        }

        {{GeneratedAttribute}}
        public {{BuilderName}} With{{PropertyName}}(Func<{{PropertyType}}> func)
        {
            {{PropertyName}} = new Lazy<{{PropertyType}}>(func);
            return this;
        }

        {{GeneratedAttribute}}
        public {{BuilderName}} Without{{PropertyName}}()
        {                    
            {{PropertyName}} = new Lazy<{{PropertyType}}>(() => default({{PropertyType}}));
            return this;
        }";


        public string BuilderClassTemplate { get; set; } =
            @"// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the data builder generator tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using BuilderGenerator;
{{UsingBlock}}

namespace {{Namespace}}
{
    {{GeneratedAttribute}}
    public partial class {{BuilderName}} : BuilderGenerator.Builder<{{ClassFullName}}>
    {
        public Action<{{ClassFullName}}> PostProcessAction { get; set; }
{{Properties}}
{{BuildMethod}}
{{WithMethods}}
    }
}";
    }
}