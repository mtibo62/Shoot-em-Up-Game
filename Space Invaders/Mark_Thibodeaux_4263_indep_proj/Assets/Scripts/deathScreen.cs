using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetButtonDown("Jump"))
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu Scene");
        }
    }

    public void setActive()
    {
        gameObject.SetActive(true);
        StartCoroutine(showScreen());
    }

    IEnumerator showScreen()
    {
        yield return new WaitForSeconds(1);
        gameObject.SetActive(true);
    }
}
