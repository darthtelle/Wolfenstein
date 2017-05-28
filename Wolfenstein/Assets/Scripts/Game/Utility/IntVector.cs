using UnityEngine;
using System.Collections;

[System.Serializable]
public class IntVector2
{
	public int x;
	public int y;

	public IntVector2(int x, int y)
	{
		this.x = x;
		this.y = y;
	}

	public static IntVector2 operator +(IntVector2 a, IntVector2 b)
	{
		return new IntVector2(a.x + b.x, a.y + b.y);
	}

	public static IntVector2 operator +(IntVector2 a, Vector2 b)
	{
		return new IntVector2(a.x + (int)b.x, a.y + (int)b.y);
	}

	public static IntVector2 operator -(IntVector2 a, IntVector2 b)
	{
		return new IntVector2(a.x - b.x, a.y - b.y);
	}

	public static IntVector2 operator -(IntVector2 a, Vector2 b)
	{
		return new IntVector2(a.x - (int)b.x, a.y - (int)b.y);
	}

	public static IntVector2 operator *(IntVector2 a, int b)
	{
		return new IntVector2(a.x * b, a.y * b);
	}

	public static bool operator ==(IntVector2 a, IntVector2 b)
	{
		if(System.Object.ReferenceEquals(a, b))
		{
			return true;
		}

		if(((object)a ==  null) || ((object)b ==  null))
		{
			return false;
		}

		return ((a.x == b.x) && (a.y == b.y));
	}

	public static bool operator !=(IntVector2 a, IntVector2 b)
	{
		return !(a == b);
	}

	public override string ToString()
	{
		return string.Concat("(", x, ", ", y, ")");
	}

	public override bool Equals(object obj)
	{
		if(obj == null)
		{
			return false;
		}

		IntVector2 vector = (IntVector2)obj;
		if((System.Object)vector == null)
		{
			return false;
		}

		return ((x == vector.x) && (y == vector.y));
	}

	public bool Equals(IntVector2 vector)
	{
		if((object)vector == null)
		{
			return false;
		}

		return ((x == vector.x) && (y == vector.y)); 
	}

	public override int GetHashCode()
	{
		return x ^ y;
	}
}
