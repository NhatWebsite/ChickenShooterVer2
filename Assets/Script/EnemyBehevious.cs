using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehevious : MonoBehaviour
{
    public PathFollow pathToFollow;
    
    public int currentWayPointID = 0;
    public float speed = 2;
    public float reachDestance = 0.1f;
    public float rotationSpeed = 5f;

    float distance;
    public int returnID;
    public enum EnemyState
    {
        ON_PATH,
        FLY_IN,
        IDLE,
        DIVE,

    }
    public EnemyState enemyState;
    public int enemyID;
    public Formation formation;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        switch (enemyState)
        {
            case EnemyState.ON_PATH:
                {
                    MoveOnThePlayerMovement(pathToFollow);
                }
                break;
            case EnemyState.FLY_IN:
                {
                    MoveToFormation();
                }
                break;
            case EnemyState.IDLE:
                {

                }
                break;
            case EnemyState.DIVE:
                {

                }
                break;

        }
        MoveOnThePlayerMovement(pathToFollow);
    }//UPDATE

    void MoveToFormation()
    {
        transform.position = Vector3.MoveTowards(transform.position, formation.GetVector(enemyID), speed * Time.deltaTime);

        Vector3 dir = formation.GetVector(enemyID) - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        //check Distance
        if(Vector3.Distance(transform.position, formation.GetVector(enemyID)) <= 0.001f)
        {
            transform.SetParent(formation.gameObject.transform);
            transform.eulerAngles = Vector3.zero;
            formation.enemyList.Add(new Formation.EnemyFormation(enemyID,transform.localPosition.x,transform.localPosition.y,this.gameObject));

            enemyState = EnemyState.IDLE;
        }
    }

    void MoveOnThePlayerMovement(PathFollow pathToFollow)
    {
       distance = Vector3.Distance(transform.position, pathToFollow.bezierObjList[currentWayPointID]);
        transform.position = Vector3.MoveTowards(transform.position, pathToFollow.bezierObjList[currentWayPointID], speed * Time.deltaTime);

        //ROTATION
        Vector3 dir = pathToFollow.bezierObjList[currentWayPointID] - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        if (distance <= reachDestance)
        {
            currentWayPointID++;
        }
        if (currentWayPointID >= pathToFollow.bezierObjList.Count)
        {
            enemyState = EnemyState.FLY_IN;
            currentWayPointID = returnID;
        }
        
    }
    public void SpawnSetup(PathFollow pathFollow, int ID, Formation _formation)
    {
        pathToFollow = pathFollow;
        enemyID = ID;
        formation = _formation;
    }
}
