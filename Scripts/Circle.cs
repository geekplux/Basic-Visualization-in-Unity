using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour {

    public Material material;
    public float radius; //半径
    private float angle; //每个相隔多少度
    private float count = 100f;

    void Start () {

        angle = 360 / count;
        Vector2 circlePos = new Vector2();
        Vector2[] line = new Vector2[(int)count + 1];
        for (int i = 0; i <= count; ++i)
        {
            circlePos.x = radius * Mathf.Cos(angle * i * Mathf.Deg2Rad);
            circlePos.y = radius * Mathf.Sin(angle * i * Mathf.Deg2Rad);
            line[i] = new Vector2(circlePos.x, circlePos.y);
        }

        Rect.CreatePieChart(line, GameObject.Find("PieChartCanvas/Panel"), material);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
