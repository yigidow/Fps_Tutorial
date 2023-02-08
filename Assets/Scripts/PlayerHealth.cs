using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;

    public int maxHealth, currentHealth;

    public float invisTime;
    private float invisCount;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentHealth = maxHealth;
        UIController.instance.healthBar.maxValue = maxHealth;
        UIController.instance.health.text = "HEALTH:" + currentHealth + "/" + maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(invisCount > 0)
        {
            invisCount -= Time.deltaTime;
        }
    }

    public void DamagePayer(int damage)
    {
        if(invisCount <= 0 && !GameManager.instance.levelEnding)
        {
            AudioManager.instance.PlaySfx(7);

            currentHealth -= damage;

            UIController.instance.showDamage();

            if (currentHealth <= 0)
            {
                gameObject.SetActive(false);

                currentHealth = 0;

                GameManager.instance.PlayerDied();
                AudioManager.instance.stopBgm();
                AudioManager.instance.StopSfx(7);
                AudioManager.instance.PlaySfx(6);
            }

            invisCount = invisTime;

            UIController.instance.healthBar.value = currentHealth;
            UIController.instance.health.text = "HEALTH:" + currentHealth + "/" + maxHealth;
        }
    }

    public void HealPLayer(int healAmount)
    {
        currentHealth += healAmount;

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        UIController.instance.healthBar.value = currentHealth;
        UIController.instance.health.text = "HEALTH:" + currentHealth + "/" + maxHealth;
    }
}
