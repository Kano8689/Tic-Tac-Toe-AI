using System.Collections;
using System.Collections.Generic;
using UnityEditor.TerrainTools;
using UnityEngine;
using UnityEngine.UI;

public class Play : MonoBehaviour
{
    public GameObject Prefab, Parent;
    internal char[,] allValue;
    GameObject[,] allBtns;
    int n;
    int w;
    int cnt = 0;
    int temp = 0;
    // Start is called before the first frame update
    void Start()
    {
        n = PlayerPrefs.GetInt("N", 3);
        w = PlayerPrefs.GetInt("W", 3);
        allBtns = new GameObject[n, n];
        allValue = new char[n, n];

        boardGenerator();
    }

    // Update is called once per frame
    //void Update()
    //{

    //}

    void boardGenerator()
    {
        Parent.GetComponent<GridLayoutGroup>().constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        Parent.GetComponent<GridLayoutGroup>().constraintCount = n;

        for (int i = 0; i < n; i++)
        {
            int m = i;
            for (int j = 0; j < n; j++)
            {
                int k = j;
                GameObject g = Instantiate(Prefab, Parent.transform);
                g.GetComponentInChildren<Text>().text = "";
                g.GetComponent<Button>().onClick.AddListener(() => onCLickBtn(m, k));
                allValue[i, j] = ' ';
                allBtns[i, j] = g;
            }
        }
    }

    void onCLickBtn(int m, int k)
    {
        {
            allBtns[m, k].GetComponentInChildren<Text>().text = "X";
            allBtns[m, k].GetComponent<Button>().interactable = false;
            allValue[m, k] = 'X';
            cnt++;
            checkMatchFor('X');
        }

        if (cnt < (((n * n) + 1) / 2))
        {
            m = Random.Range(0, n);
            k = Random.Range(0, n);
            while (allValue[m, k] != ' ')
            {
                m = Random.Range(0, n);
                k = Random.Range(0, n);
            }

            allBtns[m, k].GetComponentInChildren<Text>().text = "0";
            allBtns[m, k].GetComponent<Button>().interactable = false;
            allValue[m, k] = '0';
            checkMatchFor('0');
        }
    }

    void checkMatchFor(char ch)
    {
        for (int i = 0; i < n; i++)
        {
            temp = 0;
            for (int j = 0; j < n; j++)
            {
                if (allValue[i, j] == ch)
                {
                    temp++;
                    if (temp == n)
                    {
                        Debug.Log(ch+"Win1");
                        break;
                    }
                }
            }

            temp = 0;
            for (int j = 0; j < n; j++)
            {
                if (allValue[j, i] == ch)
                {
                    temp++;
                    if (temp == n)
                    {
                        Debug.Log(ch+"Win2");
                        break;
                    }
                }
            }
        }

        temp = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = i; j <= i; j++)
            {
                if (allValue[i, j] == ch)
                {
                    Debug.Log(i + "-" + j + " = " + temp);
                    temp++;
                    if (temp == n)
                    {
                        Debug.Log(ch+"Win3");
                        break;
                    }
                }
            }

            temp = 0;
            int k = n - 1;
            for (int j = (n - 1) - i; k >= j;)
            {
                k--;
                if (allValue[i, j] == ch)
                {
                    Debug.Log(i + "-" + j + " = " + temp);
                    temp++;
                    if (temp == n)
                    {
                        Debug.Log(ch+"Win4");
                        break;
                    }
                }
            }
        }

    }
}
