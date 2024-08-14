using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Formation : MonoBehaviour
{
    public int gridSizeX = 10;
    public int gridSizeY = 2;


    public float gridOffsetX = 1;
    public float gridOffsetY = 1;

    public List<Vector3> gridList = new List<Vector3>();
    public List<EnemyFormation> enemyList = new List<EnemyFormation>();

    public float maxMoveOffsetX = 5f;
    float curPosX;
    Vector3 startPositon;
    public float speed = 1f;
    int derection = -1;
    public int div = 4;

    [System.Serializable]
    public class EnemyFormation
    {
        public int index;
        public float xPos;
        public float yPos;
        public GameObject enemy;

        public EnemyFormation(int _index, float _xPos, float _yPos, GameObject _enemy)
        {
            index = _index;
            xPos = _xPos;
            yPos = _yPos;
            enemy = _enemy;
        }
        


    }
    // Start is called before the first frame update
    void Start()
    {
        startPositon = transform.position;
        curPosX = transform.position.x;
        CreateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Vector3 GetVector(int ID)
    {
        return transform.position + gridList[ID];
    }

    void CreateGrid()
    {
        gridList.Clear();
        int num = 0;
        for (int i = 0; i < gridSizeX; i++)
        {
            for (int j = 0; j < gridSizeY; j++)
            {
                float x = (gridOffsetX + gridOffsetX * 2 * (num / div)) * Mathf.Pow(-1, num % 2 + 1);
                float y = gridOffsetY * ((num % div) / 2);

                Vector3 vec = new Vector3(transform.position.x + x, transform.position.y + y, 0);
               
                num++;
                gridList.Add(vec);
            }
        }
    }


    private void OnDrawGizmos()
    {
        gridList.Clear();
        int num = 0;
        for(int i=0; i < gridSizeX; i++)
        {
            for(int j=0; j < gridSizeY; j++)
            {
                float x = (gridOffsetX + gridOffsetX * 2 * (num / div)) * Mathf.Pow(-1, num % 2 + 1);
                float y = gridOffsetY * ((num % div) / 2);

                Vector3 vec = new Vector3(transform.position.x + x, transform.position.y + y, 0);
                Handles.Label(vec, num.ToString());
                num++;
                gridList.Add(vec);
            }
        }
    }
}
