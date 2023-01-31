using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPick : MonoBehaviour
{
    public string gunName;
    private bool collected;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !collected)
        {
            PlayerControlller.instance.UnlockGun(gunName);
            collected = true;
            Destroy(gameObject);
        }
    }
}
