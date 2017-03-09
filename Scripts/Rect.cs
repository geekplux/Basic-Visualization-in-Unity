using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Rect {

    private static GameObject creat(Vector2[] points, GameObject parentGameObject, Material material)
    {
        var _object = new GameObject("Line");
        _object.transform.SetParent(parentGameObject.transform);
        var meshFilter = _object.AddComponent<MeshFilter>();
        var meshRenderer = _object.AddComponent<MeshRenderer>();

        meshFilter.sharedMesh = Line.CreateMesh(points, 1f);
        meshFilter.transform.position = meshFilter.transform.parent.position;
        meshRenderer.material = material;
        return _object;
    }

    public static GameObject CreateLine(Vector2[] points, GameObject parentGameObject, Material material)
    {
        return creat(points, parentGameObject, material);
    }


    public static GameObject CreateAxis(Vector2[] points, GameObject parentGameObject, Material material)
    {
        var _object = creat(points, parentGameObject, material);
        _object.transform.localScale = new Vector3(1f, 1f, 1f);
        _object.transform.rotation = parentGameObject.transform.rotation;
        var meshFilter = _object.GetComponent<MeshFilter>();
        meshFilter.sharedMesh = Line.CreateMesh(points, 5f, "xy");
        return _object;
    }

    public static GameObject CreateLineChart(Vector2[] points, GameObject parentGameObject, Material material)
    {
        var _object = creat(points, parentGameObject, material);
        _object.transform.localScale = new Vector3(1f, 1f, 1f);
        _object.transform.rotation = parentGameObject.transform.rotation;
        var meshFilter = _object.GetComponent<MeshFilter>();
        meshFilter.sharedMesh = Line.CreateMesh(points, 2f, "xy");
        return _object;
    }


    public static GameObject CreateBarChart(Vector2[] points, GameObject parentGameObject, Material material)
    {
        var _object = creat(points, parentGameObject, material);
        _object.transform.localScale = new Vector3(1f, 1f, 1f);
        _object.transform.rotation = parentGameObject.transform.rotation;
        var meshFilter = _object.GetComponent<MeshFilter>();
        meshFilter.sharedMesh = Line.CreateMesh(points, 10f, "xy");
        return _object;
    }

    public static GameObject CreatePieChart(Vector2[] points, GameObject parentGameObject, Material material)
    {
        var _object = creat(points, parentGameObject, material);
        _object.transform.localScale = new Vector3(1f, 1f, 1f);
        _object.transform.rotation = parentGameObject.transform.rotation;
        var meshFilter = _object.GetComponent<MeshFilter>();
        meshFilter.sharedMesh = Line.CreateMesh(points, 100f, "xy");
        return _object;
    }

}
