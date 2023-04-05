using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthController : MonoBehaviour
{
    public int health = 100;
    public Text healthText;
void Start()
{
    healthText.text = "Health: " + health.ToString();
}
public void TakeDamage(int damageAmount)
{
    health -= damageAmount;
    if (health <= 0)
    {
        Destroy(gameObject);
    }
    healthText.text = "Health: " + health.ToString();
}

public void TakeHealth(int healingAmount)
{
    health += healingAmount;
    healthText.text = "Health: " + health.ToString();
}
}
