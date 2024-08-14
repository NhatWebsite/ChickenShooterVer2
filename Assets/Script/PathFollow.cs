using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollow : MonoBehaviour
{
    public Color pathColor = Color.blue;

    Transform[] objArray;
    [Range(1, 20)] public int lineDensity = 1;
    int overload;

    public List<Transform> PathFollowObjList = new List<Transform>();
    public List<Vector3> bezierObjList = new List<Vector3>();

   
    // Start is called before the first frame update
    void Start()
    {
        CreatePlayerMoment();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = pathColor;
        PathFollowObjList.Clear();

        objArray = GetComponentsInChildren<Transform>();
        //all children in to the list
        foreach (Transform obj in objArray)
        {
            if (obj != this.transform)
            {
                PathFollowObjList.Add(obj);
            }
        }

        //draw the obj
        for (int i = 0; i < PathFollowObjList.Count; i++)
        {
            Vector3 position = PathFollowObjList[i].position;
            if (i > 0)
            {
                Vector3 previous = PathFollowObjList[i - 1].position;
                Gizmos.DrawLine(previous, position);
                Gizmos.DrawWireSphere(position, 0.3f);
            }
        }
        if (PathFollowObjList.Count % 2 == 0)
        {
            PathFollowObjList.Add(PathFollowObjList[PathFollowObjList.Count - 1]);
            overload = 2;
        }
        else
        {
            PathFollowObjList.Add(PathFollowObjList[PathFollowObjList.Count - 1]);
            PathFollowObjList.Add(PathFollowObjList[PathFollowObjList.Count - 1]);
            overload = 3;
        }

        bezierObjList.Clear();
        Vector3 lineStart = PathFollowObjList[0].position;
        for (int i = 0; i < PathFollowObjList.Count - overload; i += 2)
        {
            for (int j = 0; j < lineDensity; j++)
            {
                Vector3 endLine = GetPoint(PathFollowObjList[i].position, PathFollowObjList[i + 1].position, PathFollowObjList[i + 2].position, j / (float)lineDensity);
                Gizmos.color = Color.green;
                Gizmos.DrawLine(lineStart, endLine);

                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(lineStart, 0.1f);

                lineStart = endLine;

                bezierObjList.Add(lineStart);

            }

        }
    }
    Vector3 GetPoint(Vector3 p0, Vector3 p1, Vector3 p2, float t)
    {
        return Vector3.Lerp(Vector3.Lerp(p0, p1, t), Vector3.Lerp(p1, p2, t), t);
    }
    void CreatePlayerMoment()
    {
        Gizmos.color = pathColor;
        PathFollowObjList.Clear();

        objArray = GetComponentsInChildren<Transform>();
        //all children in to the list
        foreach (Transform obj in objArray)
        {
            if (obj != this.transform)
            {
                PathFollowObjList.Add(obj);
            }
        }

        //draw the obj
        for (int i = 0; i < PathFollowObjList.Count; i++)
        {
            Vector3 position = PathFollowObjList[i].position;
            if (i > 0)
            {
                Vector3 previous = PathFollowObjList[i - 1].position;

            }
        }
        if (PathFollowObjList.Count % 2 == 0)
        {
            PathFollowObjList.Add(PathFollowObjList[PathFollowObjList.Count - 1]);
            overload = 2;
        }
        else
        {
            PathFollowObjList.Add(PathFollowObjList[PathFollowObjList.Count - 1]);
            PathFollowObjList.Add(PathFollowObjList[PathFollowObjList.Count - 1]);
            overload = 3;
        }

        bezierObjList.Clear();
        Vector3 lineStart = PathFollowObjList[0].position;
        for (int i = 0; i < PathFollowObjList.Count - overload; i += 2)
        {
            for (int j = 0; j < lineDensity; j++)
            {
                Vector3 endLine = GetPoint(PathFollowObjList[i].position, PathFollowObjList[i + 1].position, PathFollowObjList[i + 2].position, j / (float)lineDensity);


                lineStart = endLine;

                bezierObjList.Add(lineStart);

            }

        }
    }
}
