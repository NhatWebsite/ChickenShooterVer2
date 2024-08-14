using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtScore;
    private int totalScore;
    
    [SerializeField] private TextMeshProUGUI gameOverText;
    public static ScoreManager Instance;

    private void Awake()
    {
        Instance = this;
    }




    // Start is called before the first frame update
    void Start()
    {
        totalScore = 0;
        
        // là một phương thức nâng cao để gọi hàm CountdownTimer
        // nhằm cho phép đồng hồ chạy song song, tiếp tục đếm khi chuyển qua frame mới và kết thúc ở frame mới khi đạt đúng thời gian


    }

    public void addScore(int Score)
    {
        totalScore = totalScore + Score;
        if (totalScore < 0)
        {
            totalScore = 0;
        }
        txtScore.text = "Score: " + totalScore.ToString();
    }

    public void MultipleScore(int Score)
    {
        totalScore = totalScore * Score;

        txtScore.text = "Score: " + totalScore.ToString();
    }
    /* public void remainTime(float Timer)
     {
        *//* txtScore.text = "score: " + score + " | Time: " + remainTime;*//*
     }*/


    // Update is called once per frame
    
   
    



}
