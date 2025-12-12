using System;
using System.Numerics;
using MessagePack;

namespace HECSFramework.Core
{
    [MessagePackObject, Serializable]
    public partial struct Vector2IntSerialize : IEquatable<Vector2IntSerialize>
    {
        [Key(0)]
        public int X;
        [Key(1)]
        public int Y;

        [MessagePack.SerializationConstructor]
        public Vector2IntSerialize(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Vector2IntSerialize(Vector2 vector2)
        {
            X = (int)vector2.X;
            Y = (int)vector2.Y;
        }

        public Vector2 AsNumericsVector()
            => new Vector2(X, Y);

        public Vector3 AsNumericsVector3()
            => new Vector3(X, 0, Y);

        public override string ToString()
            => $"({X}, {Y})";

        [IgnoreMember]
        public static Vector2IntSerialize Zero => new Vector2IntSerialize(0, 0);

        [IgnoreMember]
        public static Vector2IntSerialize One => new Vector2IntSerialize(1, 1);

        public bool Equals(Vector2IntSerialize other)
            => X.Equals(other.X) && Y.Equals(other.Y);

        public override int GetHashCode()
        {
            int hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }

        public static Vector2IntSerialize operator -(Vector2IntSerialize left, Vector2IntSerialize right)
        {
            return new Vector2IntSerialize(left.X - right.X, left.Y - right.Y);
        }
        public static Vector2IntSerialize operator +(Vector2IntSerialize left, Vector2IntSerialize right)
        {
            return new Vector2IntSerialize(left.X + right.X, left.Y + right.Y);
        }
        public static Vector2IntSerialize operator *(Vector2IntSerialize source, int value)
        {
            return new Vector2IntSerialize(source.X * value, source.Y * value);
        }
        public static Vector2IntSerialize operator /(Vector2IntSerialize source, int value)
        {
            return new Vector2IntSerialize(source.X / value, source.Y / value);
        }
    }
}