using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float enemySpawnIniterval;
    public float waveSpawnInterval;
    int currentWave;
    public GameObject smallEnemyPrefab;
    public GameObject midEnemyPrefab;
    public GameObject bossEnemyPrefab;

    int smallEnemyID = 0;
    int midEnemyID = 0;
    int bossEnemyID = 0;

    //for diving
    public bool canDive;

    public Formation smallEnemyFormation;//for all small enemy
    public Formation midEnemyFormation;
    public Formation bossEnemyFormation;
    

    [System.Serializable]

    public class Wave
    {
        public int enemySmallAmount;//amount of small enemy to spawn
        public int enemyMidAmount;
        public int enemyBossAmount;
        
        public GameObject[] pathPrefab;
    }

    public List<Wave> wavelist = new List<Wave>();
    List<PathFollow> activePathList = new List<PathFollow>();

    List<GameObject> spawnedEnemies = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartSpawn", 3f);
    }

    IEnumerator SpawnWaves()
    {
        while (currentWave<wavelist.Count)
        {
            for(int i=0; i < wavelist[currentWave].pathPrefab.Length; i++)
            {
                GameObject newPathobj = Instantiate(wavelist[currentWave].pathPrefab[i],transform.position, Quaternion.identity) as GameObject;
                PathFollow newPath = newPathobj.GetComponent<PathFollow>();
                activePathList.Add(newPath);


            }

            //small enemy
            for(int i = 0; i < wavelist[currentWave].enemySmallAmount; i++)
            {
                GameObject smallEnemy = Instantiate(smallEnemyPrefab, transform.position, Quaternion.identity) as GameObject;
                EnemyBehevious smallEnemyBehavior = smallEnemy.GetComponent<EnemyBehevious>();

                smallEnemyBehavior.SpawnSetup(activePathList[Random.Range(0, activePathList.Count)],smallEnemyID,smallEnemyFormation);
                smallEnemyID++;

                spawnedEnemies.Add(smallEnemy);

                yield return new WaitForSeconds(enemySpawnIniterval);
            }
            //mid enemy
            for (int i = 0; i < wavelist[currentWave].enemyMidAmount; i++)
            {
                GameObject midEnemy = Instantiate(midEnemyPrefab, transform.position, Quaternion.identity) as GameObject;
                EnemyBehevious midEnemyBehavior = midEnemy.GetComponent<EnemyBehevious>();

                midEnemyBehavior.SpawnSetup(activePathList[Random.Range(0, activePathList.Count)], midEnemyID, midEnemyFormation);
                midEnemyID++;

                spawnedEnemies.Add(midEnemy);

                yield return new WaitForSeconds(enemySpawnIniterval);
            }
            //boss enemy
            
            for (int i = 0; i < wavelist[currentWave].enemyBossAmount; i++)
            {
                GameObject bossEnemy = Instantiate(bossEnemyPrefab, transform.position, Quaternion.identity) as GameObject;
                EnemyBehevious bossEnemyBehavior = bossEnemy.GetComponent<EnemyBehevious>();

                bossEnemyBehavior.SpawnSetup(activePathList[Random.Range(0, activePathList.Count)], bossEnemyID, bossEnemyFormation);
                bossEnemyID++;

                spawnedEnemies.Add(bossEnemy);

                yield return new WaitForSeconds(enemySpawnIniterval);
            }
            yield return new WaitForSeconds(waveSpawnInterval);
            currentWave++;
            foreach(PathFollow p in activePathList)
            {
                Destroy(p.gameObject);

            }
            activePathList.Clear();

        }
    }

    void StartSpawn()
    {
        StartCoroutine(SpawnWaves());
        CancelInvoke("StartSpawn");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
