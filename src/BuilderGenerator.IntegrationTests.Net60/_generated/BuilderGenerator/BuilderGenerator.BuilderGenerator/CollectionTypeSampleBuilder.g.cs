#nullable disable

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by BuilderGenerator at 2023-11-22T00:07:28 in 16.4896ms.
// </auto-generated>
//------------------------------------------------------------------------------
using System.CodeDom.Compiler;
using BuilderGenerator.IntegrationTests.Core.Models.Entities;

namespace BuilderGenerator.IntegrationTests.Net60.Builders
{
    public partial class CollectionTypeSampleBuilder : BuilderGenerator.Builder<BuilderGenerator.IntegrationTests.Core.Models.Entities.CollectionTypesSample>
    {
        public System.Lazy<string[]> ReadWriteArray = new System.Lazy<string[]>(() => default(string[]));
        public System.Lazy<System.Collections.Generic.ICollection<string>> ReadWriteCollection = new System.Lazy<System.Collections.Generic.ICollection<string>>(() => default(System.Collections.Generic.ICollection<string>));
        public System.Lazy<System.Collections.Generic.IEnumerable<string>> ReadWriteEnumerable = new System.Lazy<System.Collections.Generic.IEnumerable<string>>(() => default(System.Collections.Generic.IEnumerable<string>));
        public System.Lazy<System.Collections.Generic.HashSet<string>> ReadWriteHashSet = new System.Lazy<System.Collections.Generic.HashSet<string>>(() => default(System.Collections.Generic.HashSet<string>));
        public System.Lazy<System.Collections.Generic.List<string>> ReadWriteList = new System.Lazy<System.Collections.Generic.List<string>>(() => default(System.Collections.Generic.List<string>));

        public override BuilderGenerator.IntegrationTests.Core.Models.Entities.CollectionTypesSample Build()
        {
            if (Object?.IsValueCreated != true)
            {
                Object = new System.Lazy<BuilderGenerator.IntegrationTests.Core.Models.Entities.CollectionTypesSample>(() =>
                {
                    var result = new BuilderGenerator.IntegrationTests.Core.Models.Entities.CollectionTypesSample
                    {
                        ReadWriteArray = ReadWriteArray.Value,
                        ReadWriteCollection = ReadWriteCollection.Value,
                        ReadWriteEnumerable = ReadWriteEnumerable.Value,
                        ReadWriteHashSet = ReadWriteHashSet.Value,
                        ReadWriteList = ReadWriteList.Value,
                    };

                    return result;
                });

                PostProcess(Object.Value);
            }

            return Object.Value;
        }

        public CollectionTypeSampleBuilder WithReadWriteArray(string[] value)
        {
            return WithReadWriteArray(() => value);
        }

        public CollectionTypeSampleBuilder WithReadWriteArray(System.Func<string[]> func)
        {
            ReadWriteArray = new System.Lazy<string[]>(func);
            return this;
        }

        public CollectionTypeSampleBuilder WithoutReadWriteArray()
        {
            ReadWriteArray = new System.Lazy<string[]>(() => default(string[]));
            return this;
        }

        public CollectionTypeSampleBuilder WithReadWriteCollection(System.Collections.Generic.ICollection<string> value)
        {
            return WithReadWriteCollection(() => value);
        }

        public CollectionTypeSampleBuilder WithReadWriteCollection(System.Func<System.Collections.Generic.ICollection<string>> func)
        {
            ReadWriteCollection = new System.Lazy<System.Collections.Generic.ICollection<string>>(func);
            return this;
        }

        public CollectionTypeSampleBuilder WithoutReadWriteCollection()
        {
            ReadWriteCollection = new System.Lazy<System.Collections.Generic.ICollection<string>>(() => default(System.Collections.Generic.ICollection<string>));
            return this;
        }

        public CollectionTypeSampleBuilder WithReadWriteEnumerable(System.Collections.Generic.IEnumerable<string> value)
        {
            return WithReadWriteEnumerable(() => value);
        }

        public CollectionTypeSampleBuilder WithReadWriteEnumerable(System.Func<System.Collections.Generic.IEnumerable<string>> func)
        {
            ReadWriteEnumerable = new System.Lazy<System.Collections.Generic.IEnumerable<string>>(func);
            return this;
        }

        public CollectionTypeSampleBuilder WithoutReadWriteEnumerable()
        {
            ReadWriteEnumerable = new System.Lazy<System.Collections.Generic.IEnumerable<string>>(() => default(System.Collections.Generic.IEnumerable<string>));
            return this;
        }

        public CollectionTypeSampleBuilder WithReadWriteHashSet(System.Collections.Generic.HashSet<string> value)
        {
            return WithReadWriteHashSet(() => value);
        }

        public CollectionTypeSampleBuilder WithReadWriteHashSet(System.Func<System.Collections.Generic.HashSet<string>> func)
        {
            ReadWriteHashSet = new System.Lazy<System.Collections.Generic.HashSet<string>>(func);
            return this;
        }

        public CollectionTypeSampleBuilder WithoutReadWriteHashSet()
        {
            ReadWriteHashSet = new System.Lazy<System.Collections.Generic.HashSet<string>>(() => default(System.Collections.Generic.HashSet<string>));
            return this;
        }

        public CollectionTypeSampleBuilder WithReadWriteList(System.Collections.Generic.List<string> value)
        {
            return WithReadWriteList(() => value);
        }

        public CollectionTypeSampleBuilder WithReadWriteList(System.Func<System.Collections.Generic.List<string>> func)
        {
            ReadWriteList = new System.Lazy<System.Collections.Generic.List<string>>(func);
            return this;
        }

        public CollectionTypeSampleBuilder WithoutReadWriteList()
        {
            ReadWriteList = new System.Lazy<System.Collections.Generic.List<string>>(() => default(System.Collections.Generic.List<string>));
            return this;
        }
    }
}
