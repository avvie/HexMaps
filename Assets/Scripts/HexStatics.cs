using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HexStatics{

    public const float outerRadius = 10f;
    public static float innerRadius = outerRadius * (Mathf.Sqrt(3) / 2);

    public const float solidFactor = 0.75f;
    public const float blendFactor = 1f - solidFactor;

    //orientation with point up
    static Vector3[] corners = {
        new Vector3(0, 0, outerRadius),
        new Vector3(innerRadius, 0, 0.5f * outerRadius),
        new Vector3(innerRadius, 0, -0.5f * outerRadius),
        new Vector3(0, 0, -outerRadius),
        new Vector3(-innerRadius, 0, -0.5f * outerRadius),
        new Vector3(-innerRadius, 0, 0.5f * outerRadius),
        new Vector3(0, 0, outerRadius)
    };

    public static Vector3 GetFirstCorner(HexDirection direction) {
        return corners[(int)direction];
    }

    public static Vector3 GetSecondCorner(HexDirection direction) {
        return corners[(int)direction + 1];
    }

    public static Vector3 GetFirstSolidCorner(HexDirection direction) {
        return corners[(int)direction] * solidFactor;
    }

    public static Vector3 GetSecondSolidCorner(HexDirection direction) {
        return corners[(int)direction + 1] * solidFactor;
    }
}
