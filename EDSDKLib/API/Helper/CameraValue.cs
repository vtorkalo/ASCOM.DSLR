using EOSDigital.SDK;

namespace EOSDigital.API
{
    /// <summary>
    /// Stores a camera value
    /// </summary>
    public class CameraValue
    {
        /// <summary>
        /// The value as a string
        /// </summary>
        public string StringValue { get; protected set; }
        /// <summary>
        /// The value as an UInt
        /// </summary>
        public int IntValue { get; protected set; }
        /// <summary>
        /// The value as a double
        /// </summary>
        public double DoubleValue { get; protected set; }
        /// <summary>
        /// The property ID of this value
        /// </summary>
        public PropertyID ValueType { get; protected set; }

        /// <summary>
        /// Creates a new instance of the <see cref="CameraValue"/> class
        /// </summary>
        protected CameraValue()
        {
            ValueType = PropertyID.Unknown;
            StringValue = "N/A";
            IntValue = unchecked((int)0xFFFFFFFF);
            DoubleValue = 0.0;
        }

        /// <summary>
        /// Creates a new camera value
        /// </summary>
        /// <param name="Value">The value as a string</param>
        /// <param name="ValueType">The property ID of the value</param>
        public CameraValue(string Value, PropertyID ValueType)
            : this()
        {
            this.ValueType = ValueType;
            StringValue = Value;
            switch (ValueType)
            {
                case PropertyID.Av:
                    IntValue = AvValues.GetValue(Value).IntValue;
                    DoubleValue = AvValues.GetValue(Value).DoubleValue;
                    break;
                case PropertyID.Tv:
                    IntValue = TvValues.GetValue(Value).IntValue;
                    DoubleValue = TvValues.GetValue(Value).DoubleValue;
                    break;
                case PropertyID.ISO:
                    IntValue = ISOValues.GetValue(Value).IntValue;
                    DoubleValue = ISOValues.GetValue(Value).DoubleValue;
                    break;
                case PropertyID.ColorTemperature:
                    int utmp;
                    IntValue = (int.TryParse(Value, out utmp)) ? utmp : 5600;
                    DoubleValue = utmp;
                    break;
                case PropertyID.AEMode:
                    IntValue = AEModeValues.GetValue(Value).IntValue;
                    DoubleValue = AEModeValues.GetValue(Value).DoubleValue;
                    break;
                case PropertyID.MeteringMode:
                    IntValue = MeteringModeValues.GetValue(Value).IntValue;
                    DoubleValue = MeteringModeValues.GetValue(Value).DoubleValue;
                    break;
                case PropertyID.ExposureCompensation:
                    IntValue = ExpCompValues.GetValue(Value).IntValue;
                    DoubleValue = ExpCompValues.GetValue(Value).DoubleValue;
                    break;
            }
        }

        /// <summary>
        /// Creates a new camera value
        /// </summary>
        /// <param name="Value">The value as an uint</param>
        /// <param name="ValueType">The property ID of the value</param>
        public CameraValue(int Value, PropertyID ValueType)
            : this()
        {
            this.ValueType = ValueType;
            IntValue = Value;
            switch (ValueType)
            {
                case PropertyID.Av:
                    StringValue = AvValues.GetValue(Value).StringValue;
                    DoubleValue = AvValues.GetValue(Value).DoubleValue;
                    break;
                case PropertyID.Tv:
                    StringValue = TvValues.GetValue(Value).StringValue;
                    DoubleValue = TvValues.GetValue(Value).DoubleValue;
                    break;
                case PropertyID.ISO:
                    StringValue = ISOValues.GetValue(Value).StringValue;
                    DoubleValue = ISOValues.GetValue(Value).DoubleValue;
                    break;
                case PropertyID.ColorTemperature:
                    StringValue = Value.ToString();
                    DoubleValue = Value;
                    break;
                case PropertyID.AEMode:
                    StringValue = AEModeValues.GetValue(Value).StringValue;
                    DoubleValue = AEModeValues.GetValue(Value).DoubleValue;
                    break;
                case PropertyID.MeteringMode:
                    StringValue = MeteringModeValues.GetValue(Value).StringValue;
                    DoubleValue = MeteringModeValues.GetValue(Value).DoubleValue;
                    break;
                case PropertyID.ExposureCompensation:
                    StringValue = ExpCompValues.GetValue(Value).StringValue;
                    DoubleValue = ExpCompValues.GetValue(Value).DoubleValue;
                    break;
            }
        }

        /// <summary>
        /// Creates a new camera value
        /// </summary>
        /// <param name="Value">The value as a double</param>
        /// <param name="ValueType">The property ID of the value</param>
        public CameraValue(double Value, PropertyID ValueType)
            : this()
        {
            this.ValueType = ValueType;
            DoubleValue = Value;
            switch (ValueType)
            {
                case PropertyID.Av:
                    StringValue = AvValues.GetValue(Value).StringValue;
                    IntValue = AvValues.GetValue(Value).IntValue;
                    break;
                case PropertyID.Tv:
                    StringValue = TvValues.GetValue(Value).StringValue;
                    IntValue = TvValues.GetValue(Value).IntValue;
                    break;
                case PropertyID.ISO:
                    StringValue = ISOValues.GetValue(Value).StringValue;
                    IntValue = ISOValues.GetValue(Value).IntValue;
                    break;
                case PropertyID.ColorTemperature:
                    StringValue = Value.ToString("F0");
                    IntValue = (int)Value;
                    break;
                case PropertyID.AEMode:
                    StringValue = AEModeValues.GetValue(Value).StringValue;
                    IntValue = AEModeValues.GetValue(Value).IntValue;
                    break;
                case PropertyID.MeteringMode:
                    StringValue = MeteringModeValues.GetValue(Value).StringValue;
                    IntValue = MeteringModeValues.GetValue(Value).IntValue;
                    break;
                case PropertyID.ExposureCompensation:
                    StringValue = ExpCompValues.GetValue(Value).StringValue;
                    IntValue = ExpCompValues.GetValue(Value).IntValue;
                    break;
            }
        }

        internal CameraValue(string SValue, int IValue, double DValue)
        {
            ValueType = PropertyID.Unknown;
            StringValue = SValue;
            IntValue = IValue;
            DoubleValue = DValue;
        }

        internal CameraValue(string SValue, int IValue, double DValue, PropertyID ValueType)
        {
            this.ValueType = ValueType;
            StringValue = SValue;
            IntValue = IValue;
            DoubleValue = DValue;
        }

        /// <summary>
        /// Determines whether the specified <see cref="CameraValue"/>s are equal to each other.
        /// </summary>
        /// <param name="x">The first <see cref="CameraValue"/></param>
        /// <param name="y">The second <see cref="CameraValue"/></param>
        /// <returns>True if the <see cref="CameraValue"/>s are equal; otherwise, false</returns>
        public static bool operator ==(CameraValue x, CameraValue y)
        {
            // If both are null, or both are same instance, return true.
            if (object.ReferenceEquals(x, y)) return true;

            // If one is null, but not both, return false.
            if ((object)x == null || (object)y == null) return false;

            return x.IntValue == y.IntValue && x.ValueType == y.ValueType;
        }
        /// <summary>
        /// Determines whether the specified <see cref="CameraValue"/>s are unequal to each other.
        /// </summary>
        /// <param name="x">The first <see cref="CameraValue"/></param>
        /// <param name="y">The second <see cref="CameraValue"/></param>
        /// <returns>True if the <see cref="CameraValue"/>s are unequal; otherwise, false</returns>
        public static bool operator !=(CameraValue x, CameraValue y)
        {
            return !(x == y);
        }
        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="CameraValue"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="CameraValue"/></param>
        /// <returns>true if the specified <see cref="object"/> is equal to the current <see cref="CameraValue"/>; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            // If objects have different types, return false.
            if (obj.GetType() != GetType()) return false;

            // If both are null, or both are same instance, return true.
            if (object.ReferenceEquals(this, obj)) return true;

            CameraValue cv = obj as CameraValue;
            if (cv == null) return false;

            return IntValue == cv.IntValue && ValueType == cv.ValueType;
        }
        /// <summary>
        /// Serves as a hash function for a <see cref="CameraValue"/>.
        /// </summary>
        /// <returns>A hash code for the current <see cref="CameraValue"/></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = (int)2166136261;
                hash *= 16777619 ^ IntValue.GetHashCode();
                hash *= 16777619 ^ ValueType.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// Implicitly converts the camera value to an int
        /// </summary>
        /// <param name="x">The camera value to convert</param>
        /// <returns>The int representing the camera value</returns>
        public static implicit operator int(CameraValue x)
        {
            return x.IntValue;
        }

        /// <summary>
        /// Implicitly converts the camera value to a string
        /// </summary>
        /// <param name="x">The camera value to convert</param>
        /// <returns>The string representing the camera value</returns>
        public static implicit operator string(CameraValue x)
        {
            return x.StringValue;
        }

        /// <summary>
        /// Implicitly converts the camera value to a double
        /// </summary>
        /// <param name="x">The camera value to convert</param>
        /// <returns>The double representing the camera value</returns>
        public static implicit operator double(CameraValue x)
        {
            return x.DoubleValue;
        }

        /// <summary>
        /// Returns a string that represents the current <see cref="CameraValue"/>.
        /// </summary>
        /// <returns>A string that represents the current <see cref="CameraValue"/>.</returns>
        public override string ToString()
        {
            return StringValue;
        }
    }
}
