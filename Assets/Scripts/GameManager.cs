using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float waitAfterDied = 2f;

    public bool levelEnding;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        AudioManager.instance.stopAllSfx();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnPause();
        }
    }
    public void PlayerDied()
    {
        StartCoroutine(PlayerDeathCorutine());
    }

    public IEnumerator PlayerDeathCorutine()
    {
        yield return new WaitForSeconds(waitAfterDied);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PauseUnPause()
    {
        if (UIController.instance.pauseScreen.activeInHierarchy)
        {
            UIController.instance.pauseScreen.SetActive(false);

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1f;

            PlayerControlller.instance.footStepFast.Play();
            PlayerControlller.instance.footStepSlow.Play();
            AudioManager.instance.PlayBgm();
        }
        else
        {
            UIController.instance.pauseScreen.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;

            AudioManager.instance.stopBgm();
            PlayerControlller.instance.footStepFast.Stop();
            PlayerControlller.instance.footStepSlow.Stop();
        }
    }
}
