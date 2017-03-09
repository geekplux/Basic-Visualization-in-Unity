using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


[Serializable]
public class POIStats
{
    public POIStat[] Items;
}

[Serializable]
public class POIStat
{
    public string category;
    public int count;
}


public class BarChart : MonoBehaviour {

    public Material axisMate;
    public Material barMate;

    // Use this for initialization
    void Start () {
        GameObject barChartCanvas = GameObject.Find("BarChartCanvas");
        new Axis("bottom", barChartCanvas, axisMate).render();
        new Axis("left", barChartCanvas, axisMate).render();

        string poiStatString = Resources.Load<TextAsset>(Path.Combine("data", "poi_stat")).text;
        string poiStatText = "{\"Items\":" + poiStatString + "}";
        POIStats poiStats = JsonUtility.FromJson<POIStats>(poiStatText);
        int len = poiStats.Items.Length;
        float[] values = new float[len];

        for (int j = 0; j < len; ++j)
        {
            values[j] = poiStats.Items[j].count;
        }

        var trans = barChartCanvas.GetComponent<RectTransform>();
        float width = trans.rect.size.x;
        float height = trans.rect.size.y;
        float w = width - config.AXIS_MARGIN * 2;
        float h = height - config.AXIS_MARGIN * 2;
        float interval = Utils.interval(len, w);
        float[] extentData = Utils.dataExtent(values, h);

        for (int i = 0; i < len; ++i)
        {
            Vector2[] points = new Vector2[2];
            points[0] = new Vector2((i + 1) * interval - (width + interval) / 2 + config.AXIS_MARGIN, extentData[i] - h / 2);
            points[1] = new Vector2((i + 1) * interval - (width + interval) / 2 + config.AXIS_MARGIN, -h / 2);
            Rect.CreateBarChart(points, barChartCanvas, barMate);
        }
    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
