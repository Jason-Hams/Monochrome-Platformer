using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickups : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lives"))
        {
            Destroy(collision.gameObject);
            GameManager.singelton.GainLife();

        }
    }
}
