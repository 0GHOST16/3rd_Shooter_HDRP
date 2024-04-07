using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [Header("Aplicarea setarilor armei")]
    public Gun gun;

    [Header("SFX")]
    public AudioSource source;
    public AudioClip clip;

    [Header("Gun Settings")]
    private float damageAmount;
    private float damageFrequency;
    private float nextDamageTime = 0f;
    public int ammoInClip;
    public int totalAmmo;
    public int ammoClipSize;
    private bool isReloading = false;

    [Header("Aim")]
    public LayerMask enemyLayer;
    public Transform raycastSource;
    public Transform raycastTarget;

    [Header("Raycast")]
    public Color rayColor = Color.red;

    [Header("Input")]
    private bool isWalking;
    private bool isRunning;
    private bool isJumping;
    private bool isAiming;


    public int killCount = 0;

    private void Start()
    {
        // obtinem datele din obiectele scriptabile
        damageAmount = gun.damage;
        damageFrequency = gun.damageFrequency;
        clip = gun.SFX;
        ammoInClip = gun.AmmoClip;
        totalAmmo = gun.Ammo;
        ammoClipSize = gun.AmmoClip;
    }

    void Update()
    {
        bool isWalkingForward = Input.GetKey(KeyCode.W) || Input.GetAxis("Vertical") > 0;
        bool isWalkingBackward = Input.GetKey(KeyCode.S) || Input.GetAxis("Vertical") < 0;
        bool isWalkingLeftward = Input.GetKey(KeyCode.A) || Input.GetAxis("Horizontal") < 0;
        bool isWalkingRightward = Input.GetKey(KeyCode.D) || Input.GetAxis("Horizontal") > 0;

        isWalking = isWalkingForward || isWalkingBackward || isWalkingLeftward || isWalkingRightward;
        isRunning = Input.GetKey(KeyCode.LeftShift) && isWalking;
        isJumping = Input.GetKey(KeyCode.Space);

        isAiming = Input.GetMouseButton(0) && !isRunning && !isJumping;

        if (!isReloading && isAiming && Time.time >= nextDamageTime)
        {
            if (ammoInClip > 0)
            {
                // frecventa de damage
                nextDamageTime = Time.time + damageFrequency;

                // interpretarea sunetului
                PlaySound();

                // determinarea centrului ecranului
                Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);

                // setarea pozitiei raycastului in centrul ecranului
                Ray ray = Camera.main.ScreenPointToRay(screenCenter);

                // crearea raycastului
                if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
                {
                    // verificarea daca obiectul lovit are layer-ul specificat
                    if (IsEnemy(hit.collider.gameObject))
                    {
                        // aplicarea damage
                        EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
                        if (enemyHealth != null)
                        {
                            enemyHealth.TakeDamage(damageAmount);

                            // marim nr de killuri
                            if (enemyHealth.currentHealth <= 0)
                            {
                                killCount++;
                            }
                        }
                    }
                }

                // scadem munitia din clipa
                ammoInClip--;

                // actualizare dimensiunii
                ammoClipSize = gun.AmmoClip;
            }
            else
            {
                Reload();
            }
        }

        // apelarea metodei pentru reincarcarea clipei
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    // metoda pentru reincarcare
    void Reload()
    {
        if (totalAmmo > 0 && ammoInClip < ammoClipSize)
        {
            // incarcarea clipei
            isReloading = true;
            int ammoNeeded = ammoClipSize - ammoInClip;
            int ammoToReload = Mathf.Min(ammoNeeded, totalAmmo);

            // actualizarea munitiei din clipa
            ammoInClip += ammoToReload;

            // actualizarea munitiei totale
            totalAmmo -= ammoToReload;
            isReloading = false;
        }
    }

    // verificarea daca obiectul are layer-ul de enemy
    bool IsEnemy(GameObject obj)
    {
        return enemyLayer == (enemyLayer | (1 << obj.layer));
    }

    // interpretarea sunetului
    public void PlaySound()
    {
        source.PlayOneShot(clip);
    }

    // obtinerea nr de killuri
    public int GetKillCount()
    {
        return killCount;
    }
}
