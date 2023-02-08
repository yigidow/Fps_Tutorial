using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int currentHealth = 3;

    public EnemyController ec;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamageEnemy(int damageAmount)
    {
        currentHealth -= damageAmount;

        if(ec != null)
        {
            ec.GetShot();
        }

        if(currentHealth <= 0) 
        {
            Destroy(gameObject);

            AudioManager.instance.PlaySfx(2);
        }
    }
}
