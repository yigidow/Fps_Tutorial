using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YY_Games_Scripts
{
    public class AudioManager : MonoBehaviour
    {
        #region Variables and References
        public static AudioManager instance;

        public AudioSource bgm, victory;
        public AudioSource[] sfx;
        #endregion
        #region Functions to play musics and sfxs
        //Function to play background music
        public void PlayBgm()
        {
            bgm.Play();
        }
        //Function to stop background music
        public void StopBgm()
        {
            bgm.Stop();
        }
        public void PlayLevelVictory()
        {
            StopBgm();
            victory.Play();
        }
        public void PlaySfx(int sfxNo)
        {
            sfx[sfxNo].Stop();
            sfx[sfxNo].Play();
        }

        public void StopSfx(int sfxNo)
        {
            sfx[sfxNo].Stop();
        }
        #endregion
        public void StopAllSfx()
        {
            foreach (AudioSource allSfx in sfx)
            {
                allSfx.Stop();
            }
        }

        #region Unity Functions
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

        }
        #endregion
    }

}

