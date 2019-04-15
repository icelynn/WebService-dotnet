using System;

namespace WebServices.Types
{
    /// <summary>
    /// An alternative class used to handle the null value situation by replacing it by "N/A".
    /// </summary>
    public struct Text
    {
        private readonly String _value;

        public Text(String value)
        {
            if (!IsValid(value))
                throw new ArgumentException("value");
            this._value = value;
        }

        public static implicit operator Text(String value)
        {
            return new Text(value);
        }

        public static implicit operator String(Text text)
        {
            return text._value;
        }

        public static Boolean operator ==(Text a, Text b)
        {
            return a.Equals(b);
        }

        public static Boolean operator !=(Text a, Text b)
        {
            return !(a == b);
        }

        public Boolean Equals(Text other)
        {
            return Equals(this._value, other._value);
        }

        public override Boolean Equals(object obj)
        {
            if ((obj == null) || (obj.GetType() != typeof(Text)))
            {
                return false;
            }
            return Equals((Text)obj);
        }

        public override int GetHashCode()
        {
            return this._value != null ? this._value.GetHashCode() : String.Empty.GetHashCode();
        }

        public override String ToString()
        {
            return this._value != null ? this._value : "N/A";
        }

        public static Boolean IsValid(String value)
        {
            return !String.IsNullOrEmpty(value);
        }

        public static readonly Text Empty = new Text();
    }
}
