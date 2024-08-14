using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Bullet : MonoBehaviour
{

    // Start is called before the first frame update
    public float speed = 5f; // Tốc độ di chuyển của viên đạn
    // Giá trị y tối đa trước khi viên đạn bị destroy
    /*public float moveX, moveY;
    public bool shoot;
*/



    private void Start()
    {
       
    }

    void Update()
    {
        // Di chuyển viên đạn lên trên
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        // Kiểm tra nếu viên đạn vượt quá giá trị y tối đa

    }
    void DestroyBullet()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("viên đạn đã va chạm với game object có nhãn Enemy");
            GameManager.Instance.CheckNextMap();
            ScoreManager.Instance.addScore(2);
            Destroy(collision.gameObject);
            Debug.Log("đã xóa vật thể này");
            
        }
        

    }

    private void OnBecameInvisible()
    {

        Destroy(gameObject);
    }
}
