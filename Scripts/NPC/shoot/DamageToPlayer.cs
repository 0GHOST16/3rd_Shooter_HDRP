using UnityEngine;
using UnityEngine.AI;

public class DamageToPlayer : MonoBehaviour
{
    [Header("Target")]
    public Transform originPoint;
    public Transform target;

    [Header("Raycast and Damage")]
    public float raycastDistance = 10f;
    public float damagePerShot = 10f;
    public float timeBetweenShots = 1f;

    [Header("Find Player")]
    public LayerMask playerLayer;
    public PlayerHealth playerHealth;
    public float shootDistance = 50f;
    private float timer;

    [Header("SFX")]
    public AudioSource source;
    public AudioClip clip;

    [Header("NPC")]
    public NavMeshAgent agent;

    void Start()
    {
        timer = 0f;

        // setarea destinatiei
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        // modificarea pozitiei catre player
        agent.SetDestination(target.position);

        timer += Time.deltaTime;

        // verificarea timpului de la ultima tragere
        if (timer >= timeBetweenShots)
        {
            // crearea raycastului
            if (Physics.Raycast(originPoint.position, originPoint.forward, out RaycastHit hit, raycastDistance))
            {
                // verificam daca obiectul lovit contine tagul player
                if (hit.collider.CompareTag("Player"))
                {
                    // interpretarea sunetului
                    playSFX();

                    // aplicam damageul
                    playerHealth.TakeDamage(damagePerShot);

                    // afisarea obiectului lovit
                    Debug.Log("Obiect lovit: " + hit.collider.name);
                }

                // reset timer
                timer = 0f;
            }
        }

        Debug.DrawRay(originPoint.position, originPoint.forward * raycastDistance, Color.green);
    }

    public void playSFX()
    {
        source.PlayOneShot(clip);
    }
}
