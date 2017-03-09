using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axis {
    private string orien;
    private GameObject parent;
    private Material material;
    private Vector2 startPoint;
    private Vector2 endPoint;

    public Axis(string orien, GameObject parent, Material material)
    {
        this.orien = orien;
        this.parent = parent;
        this.material = material;
        calcPosition();
    }

    // calculate the position by orien
    private void calcPosition()
    {
        var trans = parent.GetComponent<RectTransform>();
        var size = trans.rect.size;
        var center = trans.rect.center;
        float h = size.y / 2 - config.AXIS_MARGIN;
        float w = size.x / 2 - config.AXIS_MARGIN;

        switch (orien)
        {
            case "top":
                {
                    startPoint = new Vector2(-w, h);
                    endPoint = new Vector2(w, h);
                    break;
                }
            case "bottom":
                {
                    startPoint = new Vector2(-w, -h);
                    endPoint = new Vector2(w, -h);
                    break;
                }
            case "left":
                {
                    startPoint = new Vector2(-w, h);
                    endPoint = new Vector2(-w, -h);
                    break;
                }
            case "right":
                {
                    startPoint = new Vector2(w, h);
                    endPoint = new Vector2(w, -h);
                    break;
                }
        }
    }

    public void render()
    {
        Rect.CreateAxis(new[]
        {
            startPoint,
            endPoint,
        }, GameObject.Find(parent.name +"/Panel"), material);
    }
}
