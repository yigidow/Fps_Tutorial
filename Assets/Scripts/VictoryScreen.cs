using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryScreen : MonoBehaviour
{
    public string mainMenu;

    public GameObject textBox;
    public GameObject returnButton;

    public Image blackScreen;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        StartCoroutine(ShowTexts());
    }

    // Update is called once per frame
    void Update()
    {
        blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 0f, 3f * Time.deltaTime));
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }
    public IEnumerator ShowTexts()
    {
        yield return new WaitForSeconds(1f);

        textBox.SetActive(true);

        yield return new WaitForSeconds(1f);

        returnButton.SetActive(true);
    }
}
