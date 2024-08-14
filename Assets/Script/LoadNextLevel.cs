using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : MonoBehaviour
{
    public float delaySecond = 2;
    public string nameScene = "Level 2";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "")
        {
            collision.gameObject.SetActive(false);
            
        }
    }

}
