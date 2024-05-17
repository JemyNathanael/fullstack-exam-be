using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Collections;

namespace CGV.Entities
{
    public static class ConverterProvider
    {
        public static ValueConverter<bool, BitArray> BoolToBitArray()
        {
            return new ValueConverter<bool, BitArray>(
                value => new BitArray(new[] { value }),
                value => value.Get(0));
        }
    }
}
