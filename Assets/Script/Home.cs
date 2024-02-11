using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Home : MonoBehaviour
{
    SceneManager sceneManager;
    public InputField gridLayout, winLayout;
    internal int n=0;
    internal int w=0;
    // Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    //void Update()
    //{

    //}

    public void onClickBtn()
    {
        string s1 = gridLayout.text;
        n = int.Parse(s1);
        PlayerPrefs.SetInt("N", n);

        string s2;// = winLayout.text;
        s2 = "3";
        w = int.Parse(s2);
        PlayerPrefs.SetInt("W", w);

        SceneManager.LoadScene("Play");
    }
}
