using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    public float bounceForce;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerControlller.instance.Bounce(bounceForce);
            AudioManager.instance.PlaySfx(0);
        }
    }
}
