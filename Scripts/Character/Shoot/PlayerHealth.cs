using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        // verificam hp-urile playerului
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(3);
        }
        else
        {
            Debug.Log("Player HP: " + currentHealth);
        }
    }
}
