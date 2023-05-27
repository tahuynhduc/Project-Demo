using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public EnemyHealth health;
    public int damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var playerHealth = collision.GetComponent<Health>();
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth.TakeDamage(damage);
            health.TakeDamage(damage);
        }
    }

}
