using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsCollect : MonoBehaviour
{
    public GameManager gameManager;
    private void Update()
    {
        
        transform.Rotate(Vector3.forward * 50 * Time.deltaTime, Space.Self);
        transform.position=new Vector3(transform.position.x,Mathf.Clamp( Mathf.PingPong(Time.time,4),1,4),transform.position.z);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.CollectedCoin();
            Destroy(gameObject);
        }
    }
}
