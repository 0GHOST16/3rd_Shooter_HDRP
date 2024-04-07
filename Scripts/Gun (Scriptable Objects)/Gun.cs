using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName = "Gun")]
public class Gun : ScriptableObject
{
    public GameObject gunModel;
    public AudioClip SFX;

    public string gunName;
    public float damage;
    public float damageFrequency;
    public int Ammo;
    public int AmmoClip;
}
