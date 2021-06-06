using System;

namespace OnlineBookingAggregatorApp.Core
{
    public class ParentEnumAttribute : Attribute
    {
        private string[] _names;

        public ParentEnumAttribute(params string[] names)
        {
            _names = names;
        }
    }
}