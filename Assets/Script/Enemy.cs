using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    bool movingRight = true;
    Vector3 localScale;
     private PathHolder pathHolder;
    private Transform slotPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        localScale = transform.localScale;
    }
    public void InitData(PathHolder pathHolder, Transform slotPosition)
    {
        this.pathHolder = pathHolder;
        this.slotPosition = slotPosition;
        MoveFollowPath();
    }
    // Update is called once per frame
    public  void MoveFollowPath() 
    {
        transform.DOPath(pathHolder.GetWayPoint(), 5f,PathType.CatmullRom).SetEase(Ease.Linear).OnComplete(()=>
        {
            transform.DOMove(slotPosition.position, 2f);
        });

    }
    private void Update()
    {
        if (transform.position.x > 7) movingRight = false;
        if (transform.position.x < -7) movingRight = true;
    }
    private void FixedUpdate()
    {
        if (movingRight) moveRight();
        else
            moveLeft();
    }
     void moveRight()
    {
        localScale.x = -1;
        transform.transform.localScale = localScale;
        rb.velocity = new Vector2(5, 0);
    }
    void moveLeft()
    {
        localScale.x = 1;
        transform.transform.localScale = localScale;
        rb.velocity = new Vector2(-5, 0);
    }


}
