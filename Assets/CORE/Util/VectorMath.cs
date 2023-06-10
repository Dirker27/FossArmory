using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class VectorMath {

    /**
     * Performs a rotation using the 2D rotation matrix
     *   https://math.stackexchange.com/questions/1098168/about-rotating-a-vector-around-the-unit-circle-and-its-new-coordinates
     */
    public static Vector2 Rotate2D(float thetaDegrees, Vector2 offset) {
        float offsetX = (offset.x * Mathf.Cos(thetaDegrees)) - (offset.y * Mathf.Sin(thetaDegrees));
        float offsetY = (offset.x * Mathf.Sin(thetaDegrees)) + (offset.y * Mathf.Cos(thetaDegrees));

        return new Vector2(offsetX, offsetY);
    }
}
