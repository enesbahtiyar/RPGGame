using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChoosePlayer : MonoBehaviour
{
    [SerializeField] GameObject[] playerPrefabs;
    private int p = 0;
    public Text playerName;

    private void Start()
    {
        for (int i = 1; i < playerPrefabs.Length; i++)
        {
            playerPrefabs[i].SetActive(false);
        }
    }

    private void Update()
    {
    }

    public void Next()
    {
        if (p < playerPrefabs.Length - 1)
        {
            playerPrefabs[p].SetActive(false);
            p++;
            playerPrefabs[p].SetActive(true);
        }
    }

    public void Back()
    {
        if (p > 0)
        {
            playerPrefabs[p].SetActive(false);
            p--;
            playerPrefabs[p].SetActive(true);
        }
    }

    public void Accept()
    {
        SaveScript.pChar = p;
        SaveScript.pName = playerName.text;
        SceneManager.LoadScene(1);
    }
}
