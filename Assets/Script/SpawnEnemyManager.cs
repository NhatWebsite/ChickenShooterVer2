using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyManager : MonoBehaviour
{
    [SerializeField] GameObject EnemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpanwEnemy(10));
    }

    // Update is called once per frame
    private IEnumerator SpanwEnemy(int quatity)
    {
        for (int i = 0; i < quatity; i++)
        {
            yield return new WaitForSeconds(0.2f);

            GameObject Enemy = Instantiate(EnemyPrefab, this.transform);
            Enemy.SetActive(true);
        }


    }
}
