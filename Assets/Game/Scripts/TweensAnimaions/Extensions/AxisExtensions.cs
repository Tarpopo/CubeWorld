using System;
using UnityEngine;
using UnityEngine.Animations;

public static class AxisExtensions
{
    public static Vector3 AddAxis(this Vector3 vector, Axis axis, float value)
    {
        _ = axis switch
        {
            Axis.X => vector.x = value,
            Axis.Y => vector.y = value,
            Axis.Z => vector.z = value,
            _ => throw new ArgumentOutOfRangeException(nameof(axis), axis, null)
        };
        return vector;
    }

    public static Vector3 AxisVector(this Axis axis, Vector3 vector, float value)
    {
        _ = axis switch
        {
            Axis.X => vector.x = value,
            Axis.Y => vector.y = value,
            Axis.Z => vector.z = value,
            _ => throw new ArgumentOutOfRangeException(nameof(axis), axis, null)
        };
        return vector;
    }

    public static float GetAxisValue(this Axis axis, Vector3 vector)
    {
        return axis switch
        {
            Axis.X => vector.x,
            Axis.Y => vector.y,
            Axis.Z => vector.z,
            _ => throw new ArgumentOutOfRangeException(nameof(axis), axis, null)
        };
    }
}