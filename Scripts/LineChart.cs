using System;
using UnityEngine;

public class LineChart : MonoBehaviour
{

    public Material axisMate;
    public Material lineMate;

    // Use this for initialization
    void Start()
    {
        GameObject lineChartCanvas = GameObject.Find("LineChartCanvas");
        new Axis("bottom", lineChartCanvas, axisMate).render();
        new Axis("left", lineChartCanvas, axisMate).render();

        Vector2[] points = new Vector2[10];
        float[] data = new float[10];

        System.Random ran = new System.Random();

        for (int i = 0, len = data.Length; i < len; ++i)
        {
            data[i] = ran.Next(10, 100);
        }

        var trans = lineChartCanvas.GetComponent<RectTransform>();
        float width = trans.rect.size.x;
        float height = trans.rect.size.y;
        float w = width - config.AXIS_MARGIN * 2;
        float h = height - config.AXIS_MARGIN * 2;
        float interval = Utils.interval(data.Length, w);
        float[] extentData = Utils.dataExtent(data, h);

        for (int i = 0, len = points.Length; i < len; ++i)
        {
            Vector2 r = new Vector2(i * interval - width / 2 + config.AXIS_MARGIN, extentData[i] - height / 2);
            points[i] = r;
        }

        Rect.CreateLineChart(points, lineChartCanvas, lineMate);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
