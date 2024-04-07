using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AmmoUi : MonoBehaviour
{
    public TMP_Text ammo;
    public TMP_Text ammo_Clip;
    public TMP_Text player_health;

    public PlayerDamage playerDamage;
    public PlayerHealth playerHealth;

    public Canvas AK47_Canvas;
    public Canvas PPBizon_Canvas;
    public Canvas AR15_Canvas;

    void Update()
    {
        // actualizarea textului UI pentru ammo
        ammo.text = playerDamage.totalAmmo.ToString();
        ammo_Clip.text = playerDamage.ammoInClip.ToString();
        player_health.text = playerHealth.currentHealth.ToString();

        // verificarea daca playerul a tastat tasta corespunzatoare
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // Dezactivam toate canvas-urile
            AK47_Canvas.gameObject.SetActive(false);
            PPBizon_Canvas.gameObject.SetActive(false);
            AR15_Canvas.gameObject.SetActive(false);

            // Activam canvas-ul corespunzator
            AK47_Canvas.gameObject.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            AK47_Canvas.gameObject.SetActive(false);
            PPBizon_Canvas.gameObject.SetActive(false);
            AR15_Canvas.gameObject.SetActive(false);

            PPBizon_Canvas.gameObject.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            AK47_Canvas.gameObject.SetActive(false);
            PPBizon_Canvas.gameObject.SetActive(false);
            AR15_Canvas.gameObject.SetActive(false);

            AR15_Canvas.gameObject.SetActive(true);
        }
    }
}
