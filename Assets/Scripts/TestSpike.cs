using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpike : MonoBehaviour
{
        public int damageAmount = 10;
private void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Player"))
    {
        collision.gameObject.GetComponent<HealthController>().TakeDamage(damageAmount);
        Destroy(gameObject);
    }
}
}
