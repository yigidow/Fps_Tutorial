using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{
    private bool collected;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !collected)
        {
            PlayerControlller.instance.myGun.GetAmmo();
            collected = true;
            Destroy(gameObject);

            AudioManager.instance.PlaySfx(3);
        }
    } 
}
