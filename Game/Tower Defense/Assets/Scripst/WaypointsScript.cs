using System.Collections.Generic;
using UnityEngine;

public class WaypointsScript : MonoBehaviour
{
    public static Transform[] points;
    public static List<Transform> waypoints = new List<Transform>();

    private void Awake()
    {
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
}
