using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private float remainingTime;
    public GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        remainingTime = 30f;
        StartCoroutine(CountdownTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator CountdownTimer()
    {
        while (remainingTime > 0)
        {
            yield return new WaitForSeconds(1f);
            remainingTime--;
        }
        if (remainingTime <= 0)
        {
            GameOver();
        }
    }
    private void GameOver()

    {
     
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;


    }

}
