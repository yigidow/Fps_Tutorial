using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    public string nextLevel;

    public float waitTime;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameManager.instance.levelEnding = true;

            StartCoroutine(EndLevel());

            AudioManager.instance.stopAllSfx();
            AudioManager.instance.playLevelVictory();
        }
    }

    private IEnumerator EndLevel()
    {
        PlayerPrefs.SetString(nextLevel + "_cp", "");

        yield return new WaitForSeconds(waitTime);

        SceneManager.LoadScene(nextLevel);
    }
}
