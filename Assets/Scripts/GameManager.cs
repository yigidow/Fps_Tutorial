using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float waitAfterDied = 2f;


    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        //Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
