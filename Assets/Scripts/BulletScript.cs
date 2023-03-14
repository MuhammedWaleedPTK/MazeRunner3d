using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private GameManager manager;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "SideWalls")
        {
            

            
            EnemyScript otherScript = FindObjectOfType<EnemyScript>();
            gameObject.SetActive(false);
            otherScript.DeleteBullet();
            
        }
        else if (collision.gameObject.tag == "Player")
        {
            manager = FindObjectOfType<GameManager>();
            manager.GameOver();
        }
    }


}
