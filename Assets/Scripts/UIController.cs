using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace YY_Games_Scripts
{
    public class UIController : MonoBehaviour
    {
        public static UIController instance;

        public Slider healthBar;
        public TextMeshProUGUI health;

        public TextMeshProUGUI ammo;

        public Image damageEffect;
        public float damageAlpha = 0.25f, damageFadeSpeed = 2f;

        public GameObject pauseScreen;

        public Image fadeImg;
        public float fadeSpeed = 1f;

        private void Awake()
        {
            instance = this;
        }
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (damageEffect.color.a != 0)
            {
                damageEffect.color = new Color(damageEffect.color.r, damageEffect.color.g, damageEffect.color.b, Mathf.MoveTowards(damageEffect.color.a, 0f, damageFadeSpeed * Time.deltaTime));
            }

            if (!GameManager.instance.levelEnding)
            {
                fadeImg.color = new Color(fadeImg.color.r, fadeImg.color.g, fadeImg.color.b, Mathf.MoveTowards(fadeImg.color.a, 0f, fadeSpeed * Time.deltaTime));
            }
            else
            {
                fadeImg.color = new Color(fadeImg.color.r, fadeImg.color.g, fadeImg.color.b, Mathf.MoveTowards(fadeImg.color.a, 1f, fadeSpeed * Time.deltaTime));
            }
        }

        public void showDamage()
        {
            damageEffect.color = new Color(damageEffect.color.r, damageEffect.color.g, damageEffect.color.b, damageAlpha);
        }
    }
}