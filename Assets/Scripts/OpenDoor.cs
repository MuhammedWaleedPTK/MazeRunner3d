using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    bool isDoorOpen=false;
    [SerializeField] private float lerpTime = 0.01f;

    public GameManager gameManager;


    private void Update()
    { Vector3 startPos = transform.position;
        Vector3 endPos = new Vector3(transform.position.x, transform.position.y + 10f, transform.position.z);
        
        //transform.position=new Vector3(transform.position.x,Mathf.Clamp(transform.position.y,0,10),transform.position.z);
       

        if (isDoorOpen&&transform.position.y<10)
        {
           
            transform.position = Vector3.Lerp(startPos, endPos, lerpTime);
           
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")&&gameManager.collectedCoins==10)
        {
           isDoorOpen=true;
            gameManager.GameWon();
        }
    }
}
