using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMomentVer2 : MonoBehaviour
{

    public float moveSpeed = 1000f;

    private Rigidbody2D rb;
    private Camera mainCamera;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        FollowMouse();
    }

    private void FollowMouse()
    {
        /*Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = (mousePosition - rb.position).normalized;
        float distance = Vector2.Distance(mousePosition, rb.position);
        rb.MovePosition(Vector2.MoveTowards(rb.position, mousePosition, moveSpeed * Time.deltaTime));*/

        Vector3 mousePosition = Input.mousePosition;

        // Kiểm tra giá trị mousePosition
        if (mousePosition.x < 0 || mousePosition.x > Screen.width || mousePosition.y < 0 || mousePosition.y > Screen.height)
        {
            Debug.LogWarning("Mouse position is out of screen bounds");
            return;
        }

        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
        worldPosition.z = 0; // Đảm bảo rằng đối tượng không di chuyển trên trục z

        // Di chuyển đối tượng tới vị trí chuột với tốc độ cố định
        rb.MovePosition(Vector2.MoveTowards(rb.position, worldPosition, moveSpeed * Time.deltaTime));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Barrier"))
        {
            Debug.Log("may bay đã va chạm với game object có nhãn Barrier");
            HeartManager.Instantce.MinusHeart(-1);



        }
        else 
        {
            Debug.Log("may bay đã va chạm với game object có nhãn enemy");
            HeartManager.Instantce.MinusHeart(-1);



        }


    }





}
