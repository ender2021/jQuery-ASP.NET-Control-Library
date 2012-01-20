using System;
using System.Collections.Generic;
using System.Text;

namespace jQuery.NET.Utility
{
    public class NetJson : Dictionary<string, object>
    {
        /// <summary>
        /// Name of the JSON object
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Constructs an empty JSON object with no name or values: {}
        /// </summary>
        public NetJson()
        {
        }

        /// <summary>
        /// Constructs an empty JSON object with a name mapped to
        /// an empty JSON object: {"name": {}}
        /// </summary>
        /// <param name="name">Name mapped to the JSON object</param>
        public NetJson(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Constructs an anonymous JSON object containing only one key-value
        /// pair: {"key": value}
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public NetJson(string key, object value)
        {
            Add(key, value);
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            bool isNamed = !String.IsNullOrEmpty(Name);

            if (isNamed)
            {
                output.AppendFormat(@"{{""{0}"":{{", Name);
            }
            else
            {
                output.Append("{");
            }

            bool firstKey = true;
            foreach (string key in Keys)
            {
                if (!firstKey)
                {
                    output.Append(",");
                }

                output.AppendFormat(@"""{0}"":{1}", key, GetJsonValue(this[key]));

                firstKey = false;
            }

            output.Append(isNamed ? "}}" : "}");

            return output.ToString();
        }

        private static string GetJsonValue(object value)
        {
            if (value is Boolean)
            {
                return value.ToString().ToLower();
            }

            if (value is String)
            {
                return String.Format(@"""{0}""", value);
            }

            if (value is Array)
            {
                Array valueArray = (Array)value;
                StringBuilder output = new StringBuilder("[");

                bool firstItem = true;
                foreach (object item in valueArray)
                {
                    if (!firstItem)
                    {
                        output.Append(",");
                    }

                    output.Append(GetJsonValue(item));

                    firstItem = false;
                }

                output.Append("]");
                return output.ToString();
            }

            return value.ToString();
        }
    }
}