using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    PlayerHealth playerHealth;
    public int minDamage;
    public int maxDamage;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {

                InvokeRepeating(nameof(DamagePlayer), 0f, 1f); // Mỗi 1 giây gây damage
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            CancelInvoke(nameof(DamagePlayer));
            playerHealth = null;
        }
    }

    private void DamagePlayer()
    {
        if (playerHealth != null)
        {
            int damage = Random.Range(minDamage, maxDamage + 1);
            Debug.Log($"Gây sát thương cho Player: {damage}");
            playerHealth.TakeDamage(damage);
        }
    }

}
