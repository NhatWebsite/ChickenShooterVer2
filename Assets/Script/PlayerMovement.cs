using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class PlayerMovement : MonoBehaviour
{
    private Vector3 touchDelta;
    private float objectWidth;
    private float objectHeight;
    private Camera cam;
    private Vector3 minCameraPos;
    private Vector3 maxCameraPos;
    float bulletInterval;
    float fireRate = 0.1f;
    float moveSpeed = 2f;

    public GameObject Bullet;
  /*  [SerializeField] private float speed;
    // Update is called once per frame
   private RectTransform rectTransform;
    private Canvas canvas;
*/
    void Start()
    {
        cam = Camera.main;
        objectWidth = GetComponent<Renderer>().bounds.size.x;
        objectHeight = GetComponent<Renderer>().bounds.size.y;
        float cameraWidth = cam.orthographicSize * cam.aspect;
        float cameraHeight = cam.orthographicSize;
        minCameraPos = cam.ViewportToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        maxCameraPos = cam.ViewportToWorldPoint(new Vector3(1, 1, cam.nearClipPlane));
        minCameraPos += new Vector3(objectWidth / 2, objectHeight / 2, 0);
        maxCameraPos -= new Vector3(objectWidth / 2, objectHeight / 2, 0);
        /*rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();*/
    }

    void Update()
    {
        if (isDragged)
        {
           /* FireBullet();*/
        }
        /*if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchDelta = touch.deltaPosition;
            if(touch.phase == TouchPhase.Moved)
            {
                Vector3 newPos = transform.position + touchDelta * Time.deltaTime * moveSpeed;
                newPos.x = Mathf.Clamp(newPos.x, minCameraPos.x, maxCameraPos.x);
                newPos.x = Mathf.Clamp(newPos.y, minCameraPos.y, maxCameraPos.y);
                transform.position = newPos;
                 FireBullet();

            }*/
    }//update
    bool isDragged;
    Vector3 screenPoint;
    Vector3 offset;

    private void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

    }
    private void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition= Camera.main.WorldToScreenPoint(curScreenPoint)+offset;

        isDragged = true;
        transform.position = curPosition;
    }
    private void OnMouseUp()
    {
        isDragged = false;
    }
   /* void FireBullet()
    {
        if(Time.time > bulletInterval)
        {
            
            bulletInterval = Time.time + fireRate;
            GameObject bullet = Instantiate(Bullet, transform.position, Quaternion.identity);
            Bullet bullets = bullet.GetComponent<Bullet>();
            bullets.moveX = 0;
        }
    }*/
    // Lấy vị trí của chuột trong không gian màn hình
    /*Vector3 mousePosition = Input.mousePosition;*/

    // Chuyển đổi vị trí của chuột từ không gian màn hình sang không gian thế giới
    /*Vector2 anchoredPosition;
    RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, mousePosition, canvas.worldCamera, out anchoredPosition);

     // Cập nhật vị trí của RectTransform theo vị trí chuột
     rectTransform.anchoredPosition = anchoredPosition;*/
}
    

