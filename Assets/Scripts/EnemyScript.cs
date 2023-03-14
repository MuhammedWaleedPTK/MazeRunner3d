using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
   public GameObject bullet;    
    public float fireRate = 2;       
    public float speed = 10;          
    public Transform player;
    public Transform Bullets;

    public AudioSource bulletSound;
    GameManager mananger;

    List<GameObject> bullets = new List<GameObject>();
    List<GameObject> activeBullets = new List<GameObject>();

    private float nextFire;           

    void Start()
    {
        mananger= FindObjectOfType<GameManager>();
        for(int i = 0; i < 20; i++)
        {
            GameObject obj = Instantiate(bullet);
            obj.transform.parent =Bullets;

            obj.SetActive(false);
            bullets.Add(obj);
        }
       
        nextFire = Time.time;
    }

    void Update()
    {
     
        transform.LookAt(player);

       
        if (Time.time > nextFire && mananger.isAlive)
        {
           
            bulletSound.Play();
            SpawnBullet();
            nextFire = Time.time + fireRate;
        }
    }
   public void SpawnBullet()
    {
        GameObject obj = GetBullet();
        obj.SetActive(true);
        activeBullets.Add(obj);
        obj.transform.position = transform.position;

        Vector3 direction = player.position - transform.position;


        obj.GetComponent<Rigidbody>().velocity = direction.normalized * speed;

        
    }
    public void DeleteBullet()
    {
       
        activeBullets.RemoveAt(0);
       
    }



    public GameObject GetBullet()
    {
        for (int i = 0; i < bullets.Count; i++)
        {
            if (!bullets[i].activeInHierarchy)
            {
                return bullets[i];
            }
        }
        return null;
    }
}
