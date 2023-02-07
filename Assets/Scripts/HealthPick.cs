using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPick : MonoBehaviour
{
    private bool collected;
    public int healAmount;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !collected)
        {
            PlayerHealth.instance.HealPLayer(healAmount);
            collected = true;
            Destroy(gameObject);

            AudioManager.instance.PlaySfx(5);
        }
    }
}
