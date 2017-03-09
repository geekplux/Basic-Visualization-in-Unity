using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static float[] dataExtent(float[] data, float height)
    {
        float max = 0f;
        float min = 0f;
        float[] results = new float[data.Length];

        for (int i = 0, len = data.Length; i < len; ++i)
        {
            if (data[i] > max) max = data[i];
            if (data[i] < min) min = data[i];
        }

        float h = max - min;

        for (int i = 0, len = data.Length; i < len; ++i)
        {
            results[i] = (data[i] - min) / h * height;
        }

        return results;
    }

    public static float interval(float length, float width)
    {
        return width / length;
    }
}
