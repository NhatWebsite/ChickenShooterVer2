using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HeartManager : MonoBehaviour
{
    [SerializeField] private int totalHeart;
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private TextMeshProUGUI heartText;
    
    private int currentHeart;
    public static HeartManager Instantce;
    // Start is called before the first frame update

    private void Awake()
    {
        
        Instantce = this;
        currentHeart = totalHeart;

    }
    public void MinusHeart(int amount)
    {
        currentHeart = currentHeart + amount;
        heartText.text = "Heart: " + currentHeart.ToString();
        if (currentHeart == 0)
        {

            GameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
