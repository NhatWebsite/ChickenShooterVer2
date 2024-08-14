using System;
using System.Collections.Generic;

using UnityEngine;
using DG.Tweening;


public class PathHolder : MonoBehaviour
{
    [SerializeField] private List<GameObject> wayObject;
    [SerializeField] private PathType pathType;

    
    private Vector3[] waypoints;
    private void Awake()
    {
        ConvertWayPoint();
    }
    // Start is called before the first frame update
    private void ConvertWayPoint()
    {
        List<Vector3> wayPointTemp = new List<Vector3>();
        for (int i = 0; i < wayObject.Count; i++)
        {
            wayPointTemp.Add ( wayObject[i].transform.position);
        }

        
            waypoints = wayPointTemp.ToArray();
        
    }
    public Vector3[] GetWayPoint() 
    {
       
        return waypoints;
    }
    


    #region drawPath
    private void OnDrawGizmos()
    {
        ConvertWayPoint();
        if (waypoints == null || waypoints.Length < 2)
            return;

        switch (pathType)
        {
            case PathType.CatmullRom:
                DrawCatmullRomPath();
                break;
            case PathType.CubicBezier:
                DrawCubicBezierPath();
                break;
            case PathType.Linear:
                DrawLinearPath();
                break;
        }
    }

    private void DrawCatmullRomPath()
    {
        Gizmos.color = Color.red;
        List<Vector3> points = GetCatmullRomPoints(waypoints);

        for (int i = 0; i < points.Count - 1; i++)
        {
            Gizmos.DrawLine(points[i], points[i + 1]);
        }
    }

    private List<Vector3> GetCatmullRomPoints(Vector3[] waypoints, int resolution = 10)
    {
        List<Vector3> points = new List<Vector3>();

        for (int i = 0; i < waypoints.Length - 1; i++)
        {
            Vector3 p0 = i == 0 ? waypoints[i] : waypoints[i - 1];
            Vector3 p1 = waypoints[i];
            Vector3 p2 = waypoints[i + 1];
            Vector3 p3 = i == waypoints.Length - 2 ? waypoints[i + 1] : waypoints[i + 2];

            for (int j = 0; j <= resolution; j++)
            {
                float t = j / (float)resolution;
                Vector3 point = GetCatmullRomPosition(t, p0, p1, p2, p3);
                points.Add(point);
            }
        }

        return points;
    }
    private Vector3 GetCatmullRomPosition(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        float t2 = t * t;
        float t3 = t2 * t;

        float b0 = 0.5f * (-t3 + 2.0f * t2 - t);
        float b1 = 0.5f * (3.0f * t3 - 5.0f * t2 + 2.0f);
        float b2 = 0.5f * (-3.0f * t3 + 4.0f * t2 + t);
        float b3 = 0.5f * (t3 - t2);

        return (b0 * p0) + (b1 * p1) + (b2 * p2) + (b3 * p3);
    }
    private void DrawCubicBezierPath()
    {
        Gizmos.color = Color.green;
        List<Vector3> points = GetCubicBezierPoints(waypoints);

        for (int i = 0; i < points.Count - 1; i++)
        {
            Gizmos.DrawLine(points[i], points[i + 1]);
        }
    }

    private List<Vector3> GetCubicBezierPoints(Vector3[] waypoints, int resolution = 10)
    {
        List<Vector3> points = new List<Vector3>();

        for (int i = 0; i < waypoints.Length - 3; i += 3)
        {
            Vector3 p0 = waypoints[i];
            Vector3 p1 = waypoints[i + 1];
            Vector3 p2 = waypoints[i + 2];
            Vector3 p3 = waypoints[i + 3];

            for (int j = 0; j <= resolution; j++)
            {
                float t = j / (float)resolution;
                Vector3 point = GetCubicBezierPosition(t, p0, p1, p2, p3);
                points.Add(point);
            }
        }

        return points;
    }

    private Vector3 GetCubicBezierPosition(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        float ttt = tt * t;
        float uuu = uu * u;

        Vector3 p = uuu * p0;
        p += 3 * uu * t * p1;
        p += 3 * u * tt * p2;
        p += ttt * p3;

        return p;
    }

    private void DrawLinearPath()
    {
        Gizmos.color = Color.blue;

        for (int i = 0; i < waypoints.Length - 1; i++)
        {
            Gizmos.DrawLine(waypoints[i], waypoints[i + 1]);
        }
    }
    #endregion
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
