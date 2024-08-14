using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rocket : MonoBehaviour
{
    [SerializeField] private GameObject rocketImage;
    [SerializeField] private ParticleSystem explodeEffect;
    [SerializeField] private float speed;
    private Transform target=null;
    public float rotateSpeed = 200f; // Rotation speed of the missile
    public float searchRadius = 100f; // Adjust according to your game needs
    public float stopDistance = 0.1f;
    private bool isActive;
    private bool isCollision = false;


    private void OnEnable()
    {
        isActive = true;
        FindNearestEnemy();
    }


    private void OnDisable()
    {
        isActive = false;
    }


    private void Update()
    {
        if (isCollision == true)
        {
            return;
        }
        if (isActive && target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            float distance = Vector3.Distance(transform.position, target.position);


            // Rotate towards the target
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
            Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);


            // Move towards the target if not yet reached
            if (distance > stopDistance)
            {
                transform.position += transform.up * speed * Time.deltaTime;
            }
            else
            {
                transform.position = target.position;
                isActive = false;
            }
        }
        else
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
    }


    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }


    void FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float closestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;


        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);


            if (distanceToEnemy < closestDistance && distanceToEnemy <= searchRadius)
            {
                closestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }


        if (nearestEnemy != null)
        {
            target = nearestEnemy.transform;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isCollision == true)
        {
            return;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            isCollision = true;
            rocketImage.SetActive(false);
            explodeEffect.Play();
            Debug.Log("viên đạn đã va chạm với game object có nhãn Enemy");
            GameManager.Instance.CheckNextMap();
            ScoreManager.Instance.addScore(2);
            Destroy(collision.gameObject);
            Destroy(this.gameObject, explodeEffect.duration);
            Debug.Log("đã xóa vật thể này");

        }
    }


}
