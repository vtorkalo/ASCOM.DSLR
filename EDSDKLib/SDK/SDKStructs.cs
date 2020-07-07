using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace EOSDigital.SDK
{
    /// <summary>
    /// Point
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Point
    {
        /// <summary>
        /// X Coordinate
        /// </summary>
        public int X;
        /// <summary>
        /// Y Coordinate
        /// </summary>
        public int Y;

        /// <summary>
        /// Creates a new instance of the <see cref="Point"/> struct
        /// </summary>
        /// <param name="X">X Coordinate</param>
        /// <param name="Y">Y Coordinate</param>
        public Point(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }


        /// <summary>
        /// Determines whether the specified <see cref="Point"/>s are equal to each other.
        /// </summary>
        /// <param name="x">The first <see cref="Point"/></param>
        /// <param name="y">The second <see cref="Point"/></param>
        /// <returns>True if the <see cref="Point"/>s are equal; otherwise, false</returns>
        public static bool operator ==(Point x, Point y)
        {
            return x.X == y.X && x.Y == y.Y;
        }

        /// <summary>
        /// Determines whether the specified <see cref="Point"/>s are unequal to each other.
        /// </summary>
        /// <param name="x">The first <see cref="Point"/></param>
        /// <param name="y">The second <see cref="Point"/></param>
        /// <returns>True if the <see cref="Point"/>s are unequal; otherwise, false</returns>
        public static bool operator !=(Point x, Point y)
        {
            return !(x == y);
        }

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="Point"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="Point"/></param>
        /// <returns>true if the specified <see cref="object"/> is equal to the current <see cref="Point"/>; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            return obj is Point && this == (Point)obj;
        }

        /// <summary>
        /// Serves as a hash function for a <see cref="Point"/>.
        /// </summary>
        /// <returns>A hash code for the current <see cref="Point"/></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = (int)2166136261;
                hash *= 16777619 ^ X.GetHashCode();
                hash *= 16777619 ^ Y.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return string.Concat(X, ";", Y);
        }
    }

    /// <summary>
    /// Size
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Size
    {
        /// <summary>
        /// Width
        /// </summary>
        public int Width;
        /// <summary>
        /// Height
        /// </summary>
        public int Height;

        /// <summary>
        /// Creates a new instance of the <see cref="Size"/> struct
        /// </summary>
        public Size(int Width, int Height)
        {
            this.Width = Width;
            this.Height = Height;
        }


        /// <summary>
        /// Determines whether the specified <see cref="Size"/>s are equal to each other.
        /// </summary>
        /// <param name="x">The first <see cref="Size"/></param>
        /// <param name="y">The second <see cref="Size"/></param>
        /// <returns>True if the <see cref="Size"/>s are equal; otherwise, false</returns>
        public static bool operator ==(Size x, Size y)
        {
            return x.Width == y.Width && x.Height == y.Height;
        }

        /// <summary>
        /// Determines whether the specified <see cref="Size"/>s are unequal to each other.
        /// </summary>
        /// <param name="x">The first <see cref="Size"/></param>
        /// <param name="y">The second <see cref="Size"/></param>
        /// <returns>True if the <see cref="Size"/>s are unequal; otherwise, false</returns>
        public static bool operator !=(Size x, Size y)
        {
            return !(x == y);
        }

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="Size"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="Size"/></param>
        /// <returns>true if the specified <see cref="object"/> is equal to the current <see cref="Size"/>; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            return obj is Size && this == (Size)obj;
        }

        /// <summary>
        /// Serves as a hash function for a <see cref="Size"/>.
        /// </summary>
        /// <returns>A hash code for the current <see cref="Size"/></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = (int)2166136261;
                hash *= 16777619 ^ Width.GetHashCode();
                hash *= 16777619 ^ Height.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return string.Concat(Width, ";", Height);
        }
    }

    /// <summary>
    /// Rectangle
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Rectangle
    {
        /// <summary>
        /// X Coordinate
        /// </summary>
        public int X;
        /// <summary>
        /// Y Coordinate
        /// </summary>
        public int Y;
        /// <summary>
        /// Width of the rectangle
        /// </summary>
        public int Width;
        /// <summary>
        /// Height of the rectangle
        /// </summary>
        public int Height;

        /// <summary>
        /// Creates a new instance of the <see cref="Rectangle"/> struct
        /// </summary>
        /// <param name="Width">Width of the rectangle</param>
        /// <param name="Height">Height of the rectangle</param>
        public Rectangle(int Width, int Height)
            : this(0, 0, Width, Height)
        { }

        /// <summary>
        /// Creates a new instance of the <see cref="Rectangle"/> struct
        /// </summary>
        /// <param name="X">X Coordinate</param>
        /// <param name="Y">Y Coordinate</param>
        /// <param name="Width">Width of the rectangle</param>
        /// <param name="Height">Height of the rectangle</param>
        public Rectangle(int X, int Y, int Width, int Height)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
        }


        /// <summary>
        /// Determines whether the specified <see cref="Rectangle"/>s are equal to each other.
        /// </summary>
        /// <param name="x">The first <see cref="Rectangle"/></param>
        /// <param name="y">The second <see cref="Rectangle"/></param>
        /// <returns>True if the <see cref="Rectangle"/>s are equal; otherwise, false</returns>
        public static bool operator ==(Rectangle x, Rectangle y)
        {
            return x.X == y.X && x.Y == y.Y && x.Width == y.Width && x.Height == y.Height;
        }

        /// <summary>
        /// Determines whether the specified <see cref="Rectangle"/>s are unequal to each other.
        /// </summary>
        /// <param name="x">The first <see cref="Rectangle"/></param>
        /// <param name="y">The second <see cref="Rectangle"/></param>
        /// <returns>True if the <see cref="Rectangle"/>s are unequal; otherwise, false</returns>
        public static bool operator !=(Rectangle x, Rectangle y)
        {
            return !(x == y);
        }

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="Rectangle"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="Rectangle"/></param>
        /// <returns>true if the specified <see cref="object"/> is equal to the current <see cref="Rectangle"/>; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            return obj is Rectangle && this == (Rectangle)obj;
        }

        /// <summary>
        /// Serves as a hash function for a <see cref="Size"/>.
        /// </summary>
        /// <returns>A hash code for the current <see cref="Size"/></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = (int)2166136261;
                hash *= 16777619 ^ X.GetHashCode();
                hash *= 16777619 ^ Y.GetHashCode();
                hash *= 16777619 ^ Width.GetHashCode();
                hash *= 16777619 ^ Height.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return string.Concat(X, ";", Y, ";", Width, ";", Height);
        }
    }

    /// <summary>
    /// Rational
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Rational
    {
        /// <summary>
        /// Numerator of the rational number
        /// </summary>
        public int Numerator;
        /// <summary>
        /// Denominator of the rational number
        /// </summary>
        public int Denominator;


        /// <summary>
        /// Calculates the value as double
        /// </summary>
        /// <param name="val">The given Rational value</param>
        /// <returns>The Rational as double</returns>
        public static implicit operator double(Rational val)
        {
            return val.Numerator / (double)val.Denominator;
        }

        /// <summary>
        /// Calculates the value as decimal
        /// </summary>
        /// <param name="val">The given Rational value</param>
        /// <returns>The Rational as decimal</returns>
        public static implicit operator decimal(Rational val)
        {
            return val.Numerator / (decimal)val.Denominator;
        }

        /// <summary>
        /// Determines whether the specified <see cref="Rational"/>s are equal to each other.
        /// </summary>
        /// <param name="x">The first <see cref="Rational"/></param>
        /// <param name="y">The second <see cref="Rational"/></param>
        /// <returns>True if the <see cref="Rational"/>s are equal; otherwise, false</returns>
        public static bool operator ==(Rational x, Rational y)
        {
            return x.Numerator == y.Numerator && x.Denominator == y.Denominator;
        }

        /// <summary>
        /// Determines whether the specified <see cref="Rational"/>s are unequal to each other.
        /// </summary>
        /// <param name="x">The first <see cref="Rational"/></param>
        /// <param name="y">The second <see cref="Rational"/></param>
        /// <returns>True if the <see cref="Rational"/>s are unequal; otherwise, false</returns>
        public static bool operator !=(Rational x, Rational y)
        {
            return !(x == y);
        }

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="Rational"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="Rational"/></param>
        /// <returns>true if the specified <see cref="object"/> is equal to the current <see cref="Rational"/>; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            return obj is Rational && this == (Rational)obj;
        }

        /// <summary>
        /// Serves as a hash function for a <see cref="Rational"/>.
        /// </summary>
        /// <returns>A hash code for the current <see cref="Rational"/></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = (int)2166136261;
                hash *= 16777619 ^ Numerator.GetHashCode();
                hash *= 16777619 ^ Denominator.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return Numerator + "/" + Denominator;
        }
    }

    /// <summary>
    /// Time
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Time
    {
        /// <summary>
        /// Year component
        /// </summary>
        public int Year;
        /// <summary>
        /// Month component
        /// </summary>
        public int Month;
        /// <summary>
        /// Day component
        /// </summary>
        public int Day;
        /// <summary>
        /// Hour component
        /// </summary>
        public int Hour;
        /// <summary>
        /// Minute component
        /// </summary>
        public int Minute;
        /// <summary>
        /// Second component
        /// </summary>
        public int Second;
        /// <summary>
        /// Milliseconds component
        /// </summary>
        public int Milliseconds;

        /// <summary>
        /// Creates a new instance of the <see cref="Time"/> struct
        /// </summary>
        /// <param name="Year">Year component</param>
        /// <param name="Month">Month component</param>
        /// <param name="Day">Day component</param>
        public Time(int Year, int Month, int Day)
            : this(Year, Month, Day, 0, 0, 0, 0)
        { }

        /// <summary>
        /// Creates a new instance of the <see cref="Time"/> struct
        /// </summary>
        /// <param name="Year">Year component</param>
        /// <param name="Month">Month component</param>
        /// <param name="Day">Day component</param>
        /// <param name="Hour">Hour component</param>
        public Time(int Year, int Month, int Day, int Hour)
            : this(Year, Month, Day, Hour, 0, 0, 0)
        { }

        /// <summary>
        /// Creates a new instance of the <see cref="Time"/> struct
        /// </summary>
        /// <param name="Year">Year component</param>
        /// <param name="Month">Month component</param>
        /// <param name="Day">Day component</param>
        /// <param name="Hour">Hour component</param>
        /// <param name="Minute">Minute component</param>
        public Time(int Year, int Month, int Day, int Hour, int Minute)
            : this(Year, Month, Day, Hour, Minute, 0, 0)
        { }

        /// <summary>
        /// Creates a new instance of the <see cref="Time"/> struct
        /// </summary>
        /// <param name="Year">Year component</param>
        /// <param name="Month">Month component</param>
        /// <param name="Day">Day component</param>
        /// <param name="Hour">Hour component</param>
        /// <param name="Minute">Minute component</param>
        /// <param name="Second">Second component</param>
        public Time(int Year, int Month, int Day, int Hour, int Minute, int Second)
            : this(Year, Month, Day, Hour, Minute, Second, 0)
        { }

        /// <summary>
        /// Creates a new instance of the <see cref="Time"/> struct
        /// </summary>
        /// <param name="Year">Year component</param>
        /// <param name="Month">Month component</param>
        /// <param name="Day">Day component</param>
        /// <param name="Hour">Hour component</param>
        /// <param name="Minute">Minute component</param>
        /// <param name="Second">Second component</param>
        /// <param name="Milliseconds">Milliseconds component</param>
        public Time(int Year, int Month, int Day, int Hour, int Minute, int Second, int Milliseconds)
        {
            this.Year = Year;
            this.Month = Month;
            this.Day = Day;
            this.Hour = Hour;
            this.Minute = Minute;
            this.Second = Second;
            this.Milliseconds = Milliseconds;
        }


        /// <summary>
        /// Implicitly converts <see cref="Time"/> to <see cref="DateTime"/>
        /// /// </summary>
        /// <param name="t">The <see cref="Time"/> to convert</param>
        /// <returns>The <see cref="DateTime"/></returns>
        public static implicit operator DateTime(Time t)
        {
            return new DateTime(t.Year, t.Month, t.Day, t.Hour, t.Minute, t.Second, t.Milliseconds);
        }

        /// <summary>
        /// Implicitly converts <see cref="DateTime"/> to <see cref="Time"/>
        /// </summary>
        /// <param name="t">The <see cref="DateTime"/> to convert</param>
        /// <returns>The <see cref="Time"/></returns>
        public static implicit operator Time(DateTime t)
        {
            return new Time(t.Year, t.Month, t.Day, t.Hour, t.Minute, t.Second, t.Millisecond);
        }

        /// <summary>
        /// Determines whether the specified <see cref="Time"/>s are equal to each other.
        /// </summary>
        /// <param name="x">The first <see cref="Time"/></param>
        /// <param name="y">The second <see cref="Time"/></param>
        /// <returns>True if the <see cref="Time"/>s are equal; otherwise, false</returns>
        public static bool operator ==(Time x, Time y)
        {
            return x.Year == y.Year && x.Month == y.Month && x.Day == y.Day && x.Hour == y.Hour
                && x.Minute == y.Minute && x.Second == y.Second && x.Milliseconds == y.Milliseconds;
        }

        /// <summary>
        /// Determines whether the specified <see cref="Time"/>s are unequal to each other.
        /// </summary>
        /// <param name="x">The first <see cref="Time"/></param>
        /// <param name="y">The second <see cref="Time"/></param>
        /// <returns>True if the <see cref="Time"/>s are unequal; otherwise, false</returns>
        public static bool operator !=(Time x, Time y)
        {
            return !(x == y);
        }

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="Time"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="Time"/></param>
        /// <returns>true if the specified <see cref="object"/> is equal to the current <see cref="Time"/>; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            return obj is Time && this == (Time)obj;
        }

        /// <summary>
        /// Serves as a hash function for a <see cref="Time"/>.
        /// </summary>
        /// <returns>A hash code for the current <see cref="Time"/></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = (int)2166136261;
                hash *= 16777619 ^ Year.GetHashCode();
                hash *= 16777619 ^ Month.GetHashCode();
                hash *= 16777619 ^ Day.GetHashCode();
                hash *= 16777619 ^ Hour.GetHashCode();
                hash *= 16777619 ^ Minute.GetHashCode();
                hash *= 16777619 ^ Second.GetHashCode();
                hash *= 16777619 ^ Milliseconds.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return ((DateTime)this).ToString();
        }
    }

    /// <summary>
    /// Device Info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DeviceInfo
    {
        /// <summary>
        /// Name of port
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CanonSDK.MAX_NAME)]
        public string PortName;
        /// <summary>
        /// Name of device
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CanonSDK.MAX_NAME)]
        public string DeviceDescription;
        /// <summary>
        /// Device Sub-type
        /// </summary>
        public DeviceSubType DeviceSubType;
        private uint Reserved;

        /// <summary>
        /// Determines whether the specified <see cref="DeviceInfo"/>s are equal to each other.
        /// </summary>
        /// <param name="x">The first <see cref="DeviceInfo"/></param>
        /// <param name="y">The second <see cref="DeviceInfo"/></param>
        /// <returns>True if the <see cref="DeviceInfo"/>s are equal; otherwise, false</returns>
        public static bool operator ==(DeviceInfo x, DeviceInfo y)
        {
            return x.PortName == y.PortName && x.DeviceDescription == y.DeviceDescription && x.DeviceSubType == y.DeviceSubType;
        }

        /// <summary>
        /// Determines whether the specified <see cref="DeviceInfo"/>s are unequal to each other.
        /// </summary>
        /// <param name="x">The first <see cref="DeviceInfo"/></param>
        /// <param name="y">The second <see cref="DeviceInfo"/></param>
        /// <returns>True if the <see cref="DeviceInfo"/>s are unequal; otherwise, false</returns>
        public static bool operator !=(DeviceInfo x, DeviceInfo y)
        {
            return !(x == y);
        }

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="DeviceInfo"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="DeviceInfo"/></param>
        /// <returns>true if the specified <see cref="object"/> is equal to the current <see cref="DeviceInfo"/>; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            return obj is DeviceInfo && this == (DeviceInfo)obj;
        }

        /// <summary>
        /// Serves as a hash function for a <see cref="DeviceInfo"/>.
        /// </summary>
        /// <returns>A hash code for the current <see cref="DeviceInfo"/></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = (int)2166136261;
                hash *= 16777619 ^ PortName.GetHashCode();
                hash *= 16777619 ^ DeviceDescription.GetHashCode();
                hash *= 16777619 ^ DeviceSubType.GetHashCode();
                return hash;
            }
        }
    }

    /// <summary>
    /// Volume Info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct VolumeInfo
    {
        /// <summary>
        /// Type of storage
        /// </summary>
        public int StorageType;
        /// <summary>
        /// Accessibility
        /// </summary>
        public FileAccess Access;
        /// <summary>
        /// Maximum capacity
        /// </summary>
        public long MaxCapacity;
        /// <summary>
        /// Free space on volume in bytes
        /// </summary>
        public long FreeSpaceInBytes;
        /// <summary>
        /// Label/name of the volume
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CanonSDK.MAX_NAME)]
        public string VolumeLabel;

        /// <summary>
        /// Determines whether the specified <see cref="VolumeInfo"/>s are equal to each other.
        /// </summary>
        /// <param name="x">The first <see cref="VolumeInfo"/></param>
        /// <param name="y">The second <see cref="VolumeInfo"/></param>
        /// <returns>True if the <see cref="VolumeInfo"/>s are equal; otherwise, false</returns>
        public static bool operator ==(VolumeInfo x, VolumeInfo y)
        {
            return x.StorageType == y.StorageType && x.Access == y.Access && x.MaxCapacity == y.MaxCapacity
                && x.FreeSpaceInBytes == y.FreeSpaceInBytes && x.VolumeLabel == y.VolumeLabel;
        }

        /// <summary>
        /// Determines whether the specified <see cref="VolumeInfo"/>s are unequal to each other.
        /// </summary>
        /// <param name="x">The first <see cref="VolumeInfo"/></param>
        /// <param name="y">The second <see cref="VolumeInfo"/></param>
        /// <returns>True if the <see cref="VolumeInfo"/>s are unequal; otherwise, false</returns>
        public static bool operator !=(VolumeInfo x, VolumeInfo y)
        {
            return !(x == y);
        }

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="VolumeInfo"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="VolumeInfo"/></param>
        /// <returns>true if the specified <see cref="object"/> is equal to the current <see cref="VolumeInfo"/>; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            return obj is VolumeInfo && this == (VolumeInfo)obj;
        }

        /// <summary>
        /// Serves as a hash function for a <see cref="VolumeInfo"/>.
        /// </summary>
        /// <returns>A hash code for the current <see cref="VolumeInfo"/></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = (int)2166136261;
                hash *= 16777619 ^ StorageType.GetHashCode();
                hash *= 16777619 ^ Access.GetHashCode();
                hash *= 16777619 ^ MaxCapacity.GetHashCode();
                hash *= 16777619 ^ FreeSpaceInBytes.GetHashCode();
                hash *= 16777619 ^ VolumeLabel.GetHashCode();
                return hash;
            }
        }
    }

    /// <summary>
    /// DirectoryItem Info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DirectoryItemInfo
    {
        /// <summary>
        /// Size of directory item
        /// </summary>
        public int Size
        {
            get { return (int)Size64; }
        }

        /// <summary>
        /// Size of directory item (as long)
        /// </summary>
        public long Size64;
        /// <summary>
        /// Marker if it's a folder or a file
        /// </summary>
        public bool IsFolder;
        /// <summary>
        /// Group ID
        /// </summary>
        public int GroupID;
        /// <summary>
        /// Option
        /// </summary>
        public int Option;
        /// <summary>
        /// File name
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CanonSDK.MAX_NAME)]
        public string FileName;
        /// <summary>
        /// Format
        /// </summary>
        public TargetImageType Format;
        /// <summary>
        /// Date time
        /// </summary>
        public int DateTime;

        /// <summary>
        /// Determines whether the specified <see cref="DirectoryItemInfo"/>s are equal to each other.
        /// </summary>
        /// <param name="x">The first <see cref="DirectoryItemInfo"/></param>
        /// <param name="y">The second <see cref="DirectoryItemInfo"/></param>
        /// <returns>True if the <see cref="DirectoryItemInfo"/>s are equal; otherwise, false</returns>
        public static bool operator ==(DirectoryItemInfo x, DirectoryItemInfo y)
        {
            return x.Size == y.Size && x.IsFolder == y.IsFolder && x.GroupID == y.GroupID && x.Option == y.Option
                && x.FileName == y.FileName && x.Format == y.Format && x.DateTime == y.DateTime;
        }

        /// <summary>
        /// Determines whether the specified <see cref="DirectoryItemInfo"/>s are unequal to each other.
        /// </summary>
        /// <param name="x">The first <see cref="DirectoryItemInfo"/></param>
        /// <param name="y">The second <see cref="DirectoryItemInfo"/></param>
        /// <returns>True if the <see cref="DirectoryItemInfo"/>s are unequal; otherwise, false</returns>
        public static bool operator !=(DirectoryItemInfo x, DirectoryItemInfo y)
        {
            return !(x == y);
        }

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="DirectoryItemInfo"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="DirectoryItemInfo"/></param>
        /// <returns>true if the specified <see cref="object"/> is equal to the current <see cref="DirectoryItemInfo"/>; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            return obj is DirectoryItemInfo && this == (DirectoryItemInfo)obj;
        }

        /// <summary>
        /// Serves as a hash function for a <see cref="DirectoryItemInfo"/>.
        /// </summary>
        /// <returns>A hash code for the current <see cref="DirectoryItemInfo"/></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = (int)2166136261;
                hash *= 16777619 ^ Size.GetHashCode();
                hash *= 16777619 ^ IsFolder.GetHashCode();
                hash *= 16777619 ^ GroupID.GetHashCode();
                hash *= 16777619 ^ Option.GetHashCode();
                hash *= 16777619 ^ FileName.GetHashCode();
                hash *= 16777619 ^ Format.GetHashCode();
                hash *= 16777619 ^ DateTime.GetHashCode();
                return hash;
            }
        }
    }

    /// <summary>
    /// DirectoryItemInfo struct for SDK versions &lt;3.4
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct DirectoryItemInfo_3_4
    {
        public int Size;
        public bool IsFolder;
        public int GroupID;
        public int Option;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CanonSDK.MAX_NAME)]
        public string FileName;
        public TargetImageType Format;
        public int DateTime;

        public DirectoryItemInfo ToCurrent()
        {
            return new DirectoryItemInfo
            {
                Size64 = Size,
                IsFolder = IsFolder,
                GroupID = GroupID,
                Option = Option,
                FileName = FileName,
                DateTime = DateTime,
            };
        }
    }

    /// <summary>
    /// Image Info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ImageInfo
    {
        /// <summary>
        /// Width of image
        /// </summary>
        public int Width;
        /// <summary>
        /// Height of image
        /// </summary>
        public int Height;
        /// <summary>
        /// Number of channels
        /// </summary>
        public int NumOfComponents;
        /// <summary>
        /// Bitdepth of channels
        /// </summary>
        public int ComponentDepth;
        /// <summary>
        /// Effective size of image
        /// </summary>
        public Rectangle EffectiveRect;
        private uint Reserved1;
        private uint Reserved2;


        /// <summary>
        /// Determines whether the specified <see cref="ImageInfo"/>s are equal to each other.
        /// </summary>
        /// <param name="x">The first <see cref="ImageInfo"/></param>
        /// <param name="y">The second <see cref="ImageInfo"/></param>
        /// <returns>True if the <see cref="ImageInfo"/>s are equal; otherwise, false</returns>
        public static bool operator ==(ImageInfo x, ImageInfo y)
        {
            return x.Width == y.Width && x.Height == y.Height && x.NumOfComponents == y.NumOfComponents
                && x.ComponentDepth == y.ComponentDepth && x.EffectiveRect == y.EffectiveRect;
        }

        /// <summary>
        /// Determines whether the specified <see cref="ImageInfo"/>s are unequal to each other.
        /// </summary>
        /// <param name="x">The first <see cref="ImageInfo"/></param>
        /// <param name="y">The second <see cref="ImageInfo"/></param>
        /// <returns>True if the <see cref="ImageInfo"/>s are unequal; otherwise, false</returns>
        public static bool operator !=(ImageInfo x, ImageInfo y)
        {
            return !(x == y);
        }

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="ImageInfo"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="ImageInfo"/></param>
        /// <returns>true if the specified <see cref="object"/> is equal to the current <see cref="ImageInfo"/>; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            return obj is ImageInfo && this == (ImageInfo)obj;
        }

        /// <summary>
        /// Serves as a hash function for a <see cref="ImageInfo"/>.
        /// </summary>
        /// <returns>A hash code for the current <see cref="ImageInfo"/></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = (int)2166136261;
                hash *= 16777619 ^ Width.GetHashCode();
                hash *= 16777619 ^ Height.GetHashCode();
                hash *= 16777619 ^ NumOfComponents.GetHashCode();
                hash *= 16777619 ^ ComponentDepth.GetHashCode();
                hash *= 16777619 ^ EffectiveRect.GetHashCode();
                return hash;
            }
        }
    }

    /// <summary>
    /// SaveImage Setting
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SaveImageSetting
    {
        /// <summary>
        /// Quality of Jpeg file (1-10)
        /// </summary>
        public int JPEGQuality;
        /// <summary>
        /// Pointer to ICC profile stream
        /// </summary>
        public IntPtr ICCProfileStream;
        private uint Reserved;


        /// <summary>
        /// Determines whether the specified <see cref="SaveImageSetting"/>s are equal to each other.
        /// </summary>
        /// <param name="x">The first <see cref="SaveImageSetting"/></param>
        /// <param name="y">The second <see cref="SaveImageSetting"/></param>
        /// <returns>True if the <see cref="SaveImageSetting"/>s are equal; otherwise, false</returns>
        public static bool operator ==(SaveImageSetting x, SaveImageSetting y)
        {
            return x.JPEGQuality == y.JPEGQuality && x.ICCProfileStream == y.ICCProfileStream;
        }

        /// <summary>
        /// Determines whether the specified <see cref="SaveImageSetting"/>s are unequal to each other.
        /// </summary>
        /// <param name="x">The first <see cref="SaveImageSetting"/></param>
        /// <param name="y">The second <see cref="SaveImageSetting"/></param>
        /// <returns>True if the <see cref="SaveImageSetting"/>s are unequal; otherwise, false</returns>
        public static bool operator !=(SaveImageSetting x, SaveImageSetting y)
        {
            return !(x == y);
        }

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="SaveImageSetting"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="SaveImageSetting"/></param>
        /// <returns>true if the specified <see cref="object"/> is equal to the current <see cref="SaveImageSetting"/>; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            return obj is SaveImageSetting && this == (SaveImageSetting)obj;
        }

        /// <summary>
        /// Serves as a hash function for a <see cref="SaveImageSetting"/>.
        /// </summary>
        /// <returns>A hash code for the current <see cref="SaveImageSetting"/></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = (int)2166136261;
                hash *= 16777619 ^ JPEGQuality.GetHashCode();
                hash *= 16777619 ^ ICCProfileStream.GetHashCode();
                return hash;
            }
        }
    }

    /// <summary>
    /// Property Description
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PropertyDesc
    {
        /// <summary>
        /// Form
        /// </summary>
        public int Form;
        /// <summary>
        /// Accessibility
        /// </summary>
        public int Access;
        /// <summary>
        /// Number of elements
        /// </summary>
        public int NumElements;
        /// <summary>
        /// Array of all elements
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public int[] PropDesc;


        /// <summary>
        /// Determines whether the specified <see cref="PropertyDesc"/>s are equal to each other.
        /// </summary>
        /// <param name="x">The first <see cref="PropertyDesc"/></param>
        /// <param name="y">The second <see cref="PropertyDesc"/></param>
        /// <returns>True if the <see cref="PropertyDesc"/>s are equal; otherwise, false</returns>
        public static bool operator ==(PropertyDesc x, PropertyDesc y)
        {
            return x.Form == y.Form && x.Access == y.Access && x.NumElements == y.NumElements && x.PropDesc.SequenceEqual(y.PropDesc);
        }

        /// <summary>
        /// Determines whether the specified <see cref="PropertyDesc"/>s are unequal to each other.
        /// </summary>
        /// <param name="x">The first <see cref="PropertyDesc"/></param>
        /// <param name="y">The second <see cref="PropertyDesc"/></param>
        /// <returns>True if the <see cref="PropertyDesc"/>s are unequal; otherwise, false</returns>
        public static bool operator !=(PropertyDesc x, PropertyDesc y)
        {
            return !(x == y);
        }

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="PropertyDesc"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="PropertyDesc"/></param>
        /// <returns>true if the specified <see cref="object"/> is equal to the current <see cref="PropertyDesc"/>; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            return obj is PropertyDesc && this == (PropertyDesc)obj;
        }

        /// <summary>
        /// Serves as a hash function for a <see cref="Time"/>.
        /// </summary>
        /// <returns>A hash code for the current <see cref="Time"/></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = (int)2166136261;
                hash *= 16777619 ^ Form.GetHashCode();
                hash *= 16777619 ^ Access.GetHashCode();
                hash *= 16777619 ^ NumElements.GetHashCode();
                hash *= 16777619 ^ PropDesc.GetHashCode();
                return hash;
            }
        }
    }

    /// <summary>
    /// Picture Style Description
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PictureStyleDesc
    {
        /// <summary>
        /// Contrast; Range: -4 to 4
        /// </summary>
        public int Contrast;
        /// <summary>
        /// Sharpness; Range: 0 to 7
        /// </summary>
        public int Sharpness;
        /// <summary>
        /// Saturation; Range: -4 to 4
        /// </summary>
        public int Saturation;
        /// <summary>
        /// ColorTone; Range: -4 to 4
        /// </summary>
        public int ColorTone;
        /// <summary>
        /// Filter Effect
        /// </summary>
        public FilterEffect FilterEffect;
        /// <summary>
        /// Toning Effect
        /// </summary>
        public ToningEffect ToningEffect;
        /// <summary>
        /// Sharp Fineness
        /// </summary>
        public int SharpFineness;
        /// <summary>
        /// Sharp Threshold
        /// </summary>
        public int SharpThreshold;

        /// <summary>
        /// Creates a new instance of the <see cref="PictureStyleDesc"/> struct
        /// </summary>
        /// <param name="Contrast">Range: -4 to 4</param>
        /// <param name="Sharpness">Range: 0 to 7</param>
        /// <param name="Saturation">Range: -4 to 4</param>
        /// <param name="ColorTone">Range: -4 to 4</param>
        /// <param name="FilterEffect">Filter Effect</param>
        /// <param name="ToningEffect">Toning Effect</param>
        public PictureStyleDesc(int Contrast, int Sharpness, int Saturation, int ColorTone, int FilterEffect, int ToningEffect)
        {
            this.Contrast = Math.Min(4, Math.Max(-4, Contrast));
            this.Sharpness = Math.Min(7, Math.Max(0, Sharpness));
            this.Saturation = Math.Min(4, Math.Max(-4, Saturation));
            this.ColorTone = Math.Min(4, Math.Max(-4, ColorTone));
            this.FilterEffect = (FilterEffect)FilterEffect;
            this.ToningEffect = (ToningEffect)ToningEffect;
            SharpFineness = 0;
            SharpThreshold = 0;
        }


        /// <summary>
        /// Determines whether the specified <see cref="PictureStyleDesc"/>s are equal to each other.
        /// </summary>
        /// <param name="x">The first <see cref="PictureStyleDesc"/></param>
        /// <param name="y">The second <see cref="PictureStyleDesc"/></param>
        /// <returns>True if the <see cref="PictureStyleDesc"/>s are equal; otherwise, false</returns>
        public static bool operator ==(PictureStyleDesc x, PictureStyleDesc y)
        {
            return x.Contrast == y.Contrast && x.Sharpness == y.Sharpness && x.Saturation == y.Saturation && x.ColorTone == y.ColorTone
                && x.FilterEffect == y.FilterEffect && x.ToningEffect == y.ToningEffect;
        }

        /// <summary>
        /// Determines whether the specified <see cref="PictureStyleDesc"/>s are unequal to each other.
        /// </summary>
        /// <param name="x">The first <see cref="PictureStyleDesc"/></param>
        /// <param name="y">The second <see cref="PictureStyleDesc"/></param>
        /// <returns>True if the <see cref="PictureStyleDesc"/>s are unequal; otherwise, false</returns>
        public static bool operator !=(PictureStyleDesc x, PictureStyleDesc y)
        {
            return !(x == y);
        }

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="PictureStyleDesc"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="PictureStyleDesc"/></param>
        /// <returns>true if the specified <see cref="object"/> is equal to the current <see cref="PictureStyleDesc"/>; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            return obj is PictureStyleDesc && this == (PictureStyleDesc)obj;
        }

        /// <summary>
        /// Serves as a hash function for a <see cref="PictureStyleDesc"/>.
        /// </summary>
        /// <returns>A hash code for the current <see cref="PictureStyleDesc"/></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = (int)2166136261;
                hash *= 16777619 ^ Contrast.GetHashCode();
                hash *= 16777619 ^ Sharpness.GetHashCode();
                hash *= 16777619 ^ Saturation.GetHashCode();
                hash *= 16777619 ^ ColorTone.GetHashCode();
                hash *= 16777619 ^ FilterEffect.GetHashCode();
                hash *= 16777619 ^ ToningEffect.GetHashCode();
                return hash;
            }
        }
    }

    /// <summary>
    /// PictureStyleDesc struct for SDK versions &lt;3.2
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct PictureStyleDesc_3_2
    {
        public int Contrast;
        public int Sharpness;
        public int Saturation;
        public int ColorTone;
        public FilterEffect FilterEffect;
        public ToningEffect ToningEffect;

        public PictureStyleDesc ToCurrent()
        {
            return new PictureStyleDesc
            {
                Contrast = Contrast,
                Sharpness = Sharpness,
                Saturation = Saturation,
                ColorTone = ColorTone,
                FilterEffect = FilterEffect,
                ToningEffect = ToningEffect,
            };
        }
    }

    /// <summary>
    /// Focus Point
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct FocusPoint
    {
        /// <summary>
        /// <para>Invalid AF frame: 0</para>
        /// <para>Valid AF frame: 1</para>
        /// <para>Note: There are as many valid AF frames as the number in
        /// FrameNumber. Usually, AF frames are recorded consecutively, starting with 0.</para>
        /// <para>Note: AF frame coordinates and the array number for storage vary by model.</para>
        /// </summary>
        public int Valid;
        /// <summary>
        /// <para>Selected AF frame: 0</para>
        /// <para>Unselected AF frame: 1</para>
        /// </summary>
        public int Selected;
        /// <summary>
        /// <para>In focus: 1</para>
        /// <para>Out of focus: 0</para>
        /// </summary>
        public int JustFocus;
        /// <summary>
        /// Upper-left and lower-right coordinates of the AF frame
        /// </summary>
        public Rectangle Rectangle;
        private uint Reserved;


        /// <summary>
        /// Determines whether the specified <see cref="FocusPoint"/>s are equal to each other.
        /// </summary>
        /// <param name="x">The first <see cref="FocusPoint"/></param>
        /// <param name="y">The second <see cref="FocusPoint"/></param>
        /// <returns>True if the <see cref="FocusPoint"/>s are equal; otherwise, false</returns>
        public static bool operator ==(FocusPoint x, FocusPoint y)
        {
            return x.Valid == y.Valid && x.Selected == y.Selected && x.JustFocus == y.JustFocus && x.Rectangle == y.Rectangle;
        }

        /// <summary>
        /// Determines whether the specified <see cref="FocusPoint"/>s are unequal to each other.
        /// </summary>
        /// <param name="x">The first <see cref="FocusPoint"/></param>
        /// <param name="y">The second <see cref="FocusPoint"/></param>
        /// <returns>True if the <see cref="FocusPoint"/>s are unequal; otherwise, false</returns>
        public static bool operator !=(FocusPoint x, FocusPoint y)
        {
            return !(x == y);
        }

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="FocusPoint"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="FocusPoint"/></param>
        /// <returns>true if the specified <see cref="object"/> is equal to the current <see cref="FocusPoint"/>; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            return obj is FocusPoint && this == (FocusPoint)obj;
        }

        /// <summary>
        /// Serves as a hash function for a <see cref="Time"/>.
        /// </summary>
        /// <returns>A hash code for the current <see cref="Time"/></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = (int)2166136261;
                hash *= 16777619 ^ Valid.GetHashCode();
                hash *= 16777619 ^ Selected.GetHashCode();
                hash *= 16777619 ^ JustFocus.GetHashCode();
                hash *= 16777619 ^ Rectangle.GetHashCode();
                return hash;
            }
        }
    }

    /// <summary>
    /// Focus Info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct FocusInfo
    {
        /// <summary>
        /// The upper-left coordinates of the image, as well as the width and height
        /// </summary>
        public Rectangle ImageRectangle;
        /// <summary>
        /// AF frame number
        /// </summary>
        public int PointNumber;
        /// <summary>
        /// Detailed information about focus points
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public FocusPoint[] FocusPoints;
        /// <summary>
        /// Execute Mode
        /// </summary>
        public int ExecuteMode;


        /// <summary>
        /// Determines whether the specified <see cref="FocusInfo"/>s are equal to each other.
        /// </summary>
        /// <param name="x">The first <see cref="FocusInfo"/></param>
        /// <param name="y">The second <see cref="FocusInfo"/></param>
        /// <returns>True if the <see cref="FocusInfo"/>s are equal; otherwise, false</returns>
        public static bool operator ==(FocusInfo x, FocusInfo y)
        {
            return x.ImageRectangle == y.ImageRectangle && x.PointNumber == y.PointNumber
                && x.FocusPoints.SequenceEqual(y.FocusPoints) && x.ExecuteMode == y.ExecuteMode;
        }

        /// <summary>
        /// Determines whether the specified <see cref="FocusInfo"/>s are unequal to each other.
        /// </summary>
        /// <param name="x">The first <see cref="FocusInfo"/></param>
        /// <param name="y">The second <see cref="FocusInfo"/></param>
        /// <returns>True if the <see cref="FocusInfo"/>s are unequal; otherwise, false</returns>
        public static bool operator !=(FocusInfo x, FocusInfo y)
        {
            return !(x == y);
        }

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="FocusInfo"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="FocusInfo"/></param>
        /// <returns>true if the specified <see cref="object"/> is equal to the current <see cref="FocusInfo"/>; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            return obj is FocusInfo && this == (FocusInfo)obj;
        }

        /// <summary>
        /// Serves as a hash function for a <see cref="FocusInfo"/>.
        /// </summary>
        /// <returns>A hash code for the current <see cref="FocusInfo"/></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = (int)2166136261;
                hash *= 16777619 ^ ImageRectangle.GetHashCode();
                hash *= 16777619 ^ PointNumber.GetHashCode();
                hash *= 16777619 ^ FocusPoints.GetHashCode();
                hash *= 16777619 ^ ExecuteMode.GetHashCode();
                return hash;
            }
        }
    }

    /// <summary>
    /// User WhiteBalance (PC set1,2,3); User ToneCurve; User PictureStyle dataset
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct UsersetData
    {
        /// <summary>
        /// Marker if data is valid
        /// </summary>
        public int Valid;
        /// <summary>
        /// Size of data
        /// </summary>
        public int DataSize;
        /// <summary>
        /// Caption
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string Caption;
        /// <summary>
        /// Data
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public byte[] Data;


        /// <summary>
        /// Determines whether the specified <see cref="UsersetData"/>s are equal to each other.
        /// </summary>
        /// <param name="x">The first <see cref="UsersetData"/></param>
        /// <param name="y">The second <see cref="UsersetData"/></param>
        /// <returns>True if the <see cref="UsersetData"/>s are equal; otherwise, false</returns>
        public static bool operator ==(UsersetData x, UsersetData y)
        {
            return x.Valid == y.Valid && x.DataSize == y.DataSize && x.Caption == y.Caption && x.Data.SequenceEqual(y.Data);
        }

        /// <summary>
        /// Determines whether the specified <see cref="UsersetData"/>s are unequal to each other.
        /// </summary>
        /// <param name="x">The first <see cref="UsersetData"/></param>
        /// <param name="y">The second <see cref="UsersetData"/></param>
        /// <returns>True if the <see cref="UsersetData"/>s are unequal; otherwise, false</returns>
        public static bool operator !=(UsersetData x, UsersetData y)
        {
            return !(x == y);
        }

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="UsersetData"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="UsersetData"/></param>
        /// <returns>true if the specified <see cref="object"/> is equal to the current <see cref="UsersetData"/>; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            return obj is UsersetData && this == (UsersetData)obj;
        }

        /// <summary>
        /// Serves as a hash function for a <see cref="UsersetData"/>.
        /// </summary>
        /// <returns>A hash code for the current <see cref="UsersetData"/></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = (int)2166136261;
                hash *= 16777619 ^ Valid.GetHashCode();
                hash *= 16777619 ^ DataSize.GetHashCode();
                hash *= 16777619 ^ Caption.GetHashCode();
                hash *= 16777619 ^ Data.GetHashCode();
                return hash;
            }
        }
    }

    /// <summary>
    /// Capacity
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public struct Capacity
    {
        /// <summary>
        /// Number of free clusters on the HD
        /// </summary>
        public int NumberOfFreeClusters;
        /// <summary>
        /// Bytes per HD sector
        /// </summary>
        public int BytesPerSector;
        /// <summary>
        /// Reset flag
        /// </summary>
        public bool Reset;

        /// <summary>
        /// Creates a new instance of the <see cref="Capacity"/> struct
        /// </summary>
        /// <param name="BytesPerSector">Bytes per HD sector</param>
        /// <param name="NumberOfFreeClusters">Number of free clusters on the HD</param>
        /// <param name="Reset"></param>
        public Capacity(int NumberOfFreeClusters, int BytesPerSector, bool Reset)
        {
            this.NumberOfFreeClusters = NumberOfFreeClusters;
            this.BytesPerSector = BytesPerSector;
            this.Reset = Reset;
        }


        /// <summary>
        /// Determines whether the specified <see cref="Capacity"/>s are equal to each other.
        /// </summary>
        /// <param name="x">The first <see cref="Capacity"/></param>
        /// <param name="y">The second <see cref="Capacity"/></param>
        /// <returns>True if the <see cref="Capacity"/>s are equal; otherwise, false</returns>
        public static bool operator ==(Capacity x, Capacity y)
        {
            return x.NumberOfFreeClusters == y.NumberOfFreeClusters && x.BytesPerSector == y.BytesPerSector && x.Reset == y.Reset;
        }

        /// <summary>
        /// Determines whether the specified <see cref="Capacity"/>s are unequal to each other.
        /// </summary>
        /// <param name="x">The first <see cref="Capacity"/></param>
        /// <param name="y">The second <see cref="Capacity"/></param>
        /// <returns>True if the <see cref="Capacity"/>s are unequal; otherwise, false</returns>
        public static bool operator !=(Capacity x, Capacity y)
        {
            return !(x == y);
        }

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="Capacity"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="Capacity"/></param>
        /// <returns>true if the specified <see cref="object"/> is equal to the current <see cref="Capacity"/>; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            return obj is Capacity && this == (Capacity)obj;
        }

        /// <summary>
        /// Serves as a hash function for a <see cref="Capacity"/>.
        /// </summary>
        /// <returns>A hash code for the current <see cref="Capacity"/></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = (int)2166136261;
                hash *= 16777619 ^ NumberOfFreeClusters.GetHashCode();
                hash *= 16777619 ^ BytesPerSector.GetHashCode();
                hash *= 16777619 ^ Reset.GetHashCode();
                return hash;
            }
        }
    }

    /// <summary>
    /// MyMenu Items
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MyMenuItems
    {
        /// <summary>
        /// Menu Item 1
        /// </summary>
        public MyMenuID MenuItem1;
        /// <summary>
        /// Menu Item 2
        /// </summary>
        public MyMenuID MenuItem2;
        /// <summary>
        /// Menu Item 3
        /// </summary>
        public MyMenuID MenuItem3;
        /// <summary>
        /// Menu Item 4
        /// </summary>
        public MyMenuID MenuItem4;
        /// <summary>
        /// Menu Item 5
        /// </summary>
        public MyMenuID MenuItem5;
        /// <summary>
        /// Menu Item 6
        /// </summary>
        public MyMenuID MenuItem6;

        /// <summary>
        /// Creates a new instance of the <see cref="MyMenuItems"/> struct
        /// </summary>
        /// <param name="items">Array of items (max length is 6)</param>
        /// <exception cref="ArgumentNullException">The array of given items is null</exception>
        public MyMenuItems(params MyMenuID[] items)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));

            MenuItem1 = MenuItem2 = MenuItem3 = MenuItem4 = MenuItem5 = MenuItem6 = MyMenuID.NotSet;

            if (items.Length > 0) MenuItem1 = items[0];
            if (items.Length > 1) MenuItem2 = items[1];
            if (items.Length > 2) MenuItem3 = items[2];
            if (items.Length > 3) MenuItem4 = items[3];
            if (items.Length > 4) MenuItem5 = items[4];
            if (items.Length > 5) MenuItem6 = items[5];
        }


        /// <summary>
        /// Determines whether the specified <see cref="MyMenuItems"/>s are equal to each other.
        /// </summary>
        /// <param name="x">The first <see cref="MyMenuItems"/></param>
        /// <param name="y">The second <see cref="MyMenuItems"/></param>
        /// <returns>True if the <see cref="MyMenuItems"/>s are equal; otherwise, false</returns>
        public static bool operator ==(MyMenuItems x, MyMenuItems y)
        {
            return x.MenuItem1 == y.MenuItem1
                && x.MenuItem2 == y.MenuItem2
                && x.MenuItem3 == y.MenuItem3
                && x.MenuItem4 == y.MenuItem4
                && x.MenuItem5 == y.MenuItem5
                && x.MenuItem6 == y.MenuItem6;
        }

        /// <summary>
        /// Determines whether the specified <see cref="MyMenuItems"/>s are unequal to each other.
        /// </summary>
        /// <param name="x">The first <see cref="MyMenuItems"/></param>
        /// <param name="y">The second <see cref="MyMenuItems"/></param>
        /// <returns>True if the <see cref="MyMenuItems"/>s are unequal; otherwise, false</returns>
        public static bool operator !=(MyMenuItems x, MyMenuItems y)
        {
            return !(x == y);
        }

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="MyMenuItems"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="MyMenuItems"/></param>
        /// <returns>true if the specified <see cref="object"/> is equal to the current <see cref="MyMenuItems"/>; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            return obj is MyMenuItems && this == (MyMenuItems)obj;
        }

        /// <summary>
        /// Serves as a hash function for a <see cref="MyMenuItems"/>.
        /// </summary>
        /// <returns>A hash code for the current <see cref="MyMenuItems"/></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = (int)2166136261;
                hash *= 16777619 ^ MenuItem1.GetHashCode();
                hash *= 16777619 ^ MenuItem2.GetHashCode();
                hash *= 16777619 ^ MenuItem3.GetHashCode();
                hash *= 16777619 ^ MenuItem4.GetHashCode();
                hash *= 16777619 ^ MenuItem5.GetHashCode();
                hash *= 16777619 ^ MenuItem6.GetHashCode();
                return hash;
            }
        }
    }
}
