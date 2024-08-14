using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject rocketPrefab;
    public GameObject bulletPrefab;
    public Transform firePoint; // Điểm xuất phát của đạn
    public float fireRate = 0.5f; // Tốc độ bắn (giây)
    public float rocketRate = 3f; // Tốc độ bắn (giây)
    private float nextFireTime = 0f;
    private float nextRocketTime = 0f;

    private int bulletsFired = 0; // Số lượng đạn đã bắn
    private int bulletsPerShot = 1; // Số lượng đạn mỗi lần bắn
    private const int maxBulletsPerShot = 7; // Số lượng đạn tối đa mỗi lần bắn
    public Transform BulletFolder;


   
    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time > nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            FireBullets();

            // Cập nhật số lượng đạn đã bắn
            bulletsFired++;

            // Điều chỉnh số lượng đạn mỗi lần bắn
            if (bulletsFired % 10 == 0 && bulletsPerShot < maxBulletsPerShot)
            {
                bulletsPerShot++;
            }
        }
        else
        {
            if(Input.GetMouseButton(1)&& Time.time > nextRocketTime)
            {
                nextRocketTime = Time.time + rocketRate;
                FireRocket();

            }
        }
    }
    void FireRocket()
    {
        Instantiate(rocketPrefab, firePoint.position,Quaternion.identity, BulletFolder);
    }
    void FireBullets()
    {
        Debug.Log("ban dan");
        float angleStep = 10f; // Góc lệch giữa các viên đạn
        float startAngle = -(angleStep * (bulletsPerShot - 1)) / 2; // Bắt đầu từ góc âm

        for (int i = 0; i < bulletsPerShot; i++)
        {
            float angle = startAngle + (angleStep * i);
            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation * rotation,BulletFolder);
        }
    }
  
    
}
