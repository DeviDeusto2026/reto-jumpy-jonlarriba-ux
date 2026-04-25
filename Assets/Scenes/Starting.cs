using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Starting : MonoBehaviour
{
    public PlatformSpawning pf;
    public GameObject text;
    private static string txt;
    // Update is called once per frame

    void Start()
    {
        txt = "";
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            txt += Input.inputString;
            string txt2 = Input.inputString;
            text.GetComponent<TextMeshPro>().text += txt2;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Int32.TryParse(txt, out int result))
            {
                result -= 1;
                StaticData.numberOfPlatforms = result;
                SceneManager.LoadScene("Main");
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            
        }

    }

    public int GetText()
    {
        return Int32.Parse(txt);
    }
}
