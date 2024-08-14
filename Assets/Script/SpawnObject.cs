using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] private Enemy enemyPrefab;
    private PathHolder pathHolder;
    private List<GameObject> slotPositions;
    private int amountEnemy;
    public void Initdata(PathHolder pathHolder, List<GameObject> slotPositions, int amountEnemy)
    {
        this.pathHolder = pathHolder;
        this.slotPositions = slotPositions;
        this.amountEnemy = amountEnemy;
        StartCoroutine(SpawnEnemy());
    }
    public IEnumerator SpawnEnemy()
    {
       
        for(int i=0; i<amountEnemy; i++)
        {
            Enemy enemy = Instantiate(enemyPrefab, this.transform);
            enemy.InitData(pathHolder, slotPositions[i].transform);
            yield return new WaitForSeconds(0.2f);
            
        }
    }
}
