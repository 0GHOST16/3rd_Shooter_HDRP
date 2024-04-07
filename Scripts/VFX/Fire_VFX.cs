using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_VFX : MonoBehaviour
{
    public GameObject gunVFX;

    public PlayerDamage gun;


    void Update()
    {
        // aplicam efectul dor atunci cand playerul sa tintit
        if (Input.GetMouseButton(0) && Input.GetMouseButton(1) && gun.ammoInClip>0 )
        {
            // activam efecul vfx
            gunVFX.SetActive(true);
        }
        else
        {
            // dezactivam efecul vfx
            gunVFX.SetActive(false);;
        }
    }
}
