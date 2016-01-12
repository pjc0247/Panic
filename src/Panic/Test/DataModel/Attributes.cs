using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

namespace Panic.Test.DataModel
{
    [AttributeUsage(AttributeTargets.Field)]
    public class DataModelContract : Attribute
    {
        internal virtual void Validate(FieldInfo field)
        {
        }
    }

    /// <summary>
    /// NotNull + NotEmpty
    /// </summary>
    public class Required : DataModelContract
    {
        internal override void Validate(FieldInfo field)
        {
            // from NotNull
            if (field.FieldType.IsValueType &&
                Nullable.GetUnderlyingType(field.FieldType) == null)
            {
                throw new InvalidContractUsageException("");
            }

            // from NotEmpty
            if (field.FieldType != typeof(string))
                throw new InvalidContractUsageException("");
        }
    }

    public class NotNull : DataModelContract
    {
        internal override void Validate(FieldInfo field)
        {
            if (field.FieldType.IsValueType &&
                Nullable.GetUnderlyingType(field.FieldType) == null)
            {
                throw new InvalidContractUsageException("");
            }
        }
    }

    public class NotEmpty : DataModelContract
    {
        internal override void Validate(FieldInfo field)
        {
            if (field.FieldType != typeof(string))
                throw new InvalidContractUsageException("");
        }
    }

    public class StringRange : DataModelContract
    {
        public int Min { get; private set; }
        public int Max { get; private set; }

        public StringRange() { }
        public StringRange(int min, int max)
        {
            Min = min;
            Max = max;
        }

        internal override void Validate(FieldInfo field)
        {
            if (field.FieldType != typeof(string))
                throw new InvalidContractUsageException("");
        }
    }
}
