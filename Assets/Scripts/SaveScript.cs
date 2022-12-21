using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScript : MonoBehaviour
{
    public static int pChar = 0;
    public static string pName = "";

    private void Start()
    {
        DontDestroyOnLoad(this);
    }
}
