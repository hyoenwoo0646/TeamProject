using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "BorderBullet")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Enemy")
        { 
            Destroy(gameObject);
        }

    }

    
}


