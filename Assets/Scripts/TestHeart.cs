using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHeart : MonoBehaviour
{
        public int healingAmount = 10;
private void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Player"))
    {
        collision.gameObject.GetComponent<HealthController>().TakeHealth(healingAmount);
        Destroy(gameObject);
    }
}
}
