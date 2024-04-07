using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        // take damage
        currentHealth -= damage;

        // kill
        if (currentHealth <= 0)
        {
            kill();
        }
    }

    public void kill()
    {
        Destroy(gameObject);
    }
}
