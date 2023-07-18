using UnityEngine;

public class IsometricVectorConverter
{
    public static Vector2 RotateVector2(Vector2 vector, float radian)
    {
        float cos = Mathf.Cos(radian);
        float sin = Mathf.Sin(radian);
        float x = (vector.x * cos) - (vector.y * sin);
        float y = (vector.x * sin) + (vector.y * cos);
        // Debug.Log(
        //     $"before : ${vector.x}, ${vector.y} and radian : ${radian}, and after: ${x}, ${y}"
        // );
        return new Vector2(x, y);
    }

    public static Vector3 RotateVector3(Vector3 vector, float radian)
    {
        float cos = Mathf.Cos(radian);
        float sin = Mathf.Sin(radian);
        float x = (vector.x * cos) - (vector.z * sin);
        float z = (vector.x * sin) + (vector.z * cos);
        return new Vector3(x, 0, z);
    }
}
