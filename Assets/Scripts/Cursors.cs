using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cursors : MonoBehaviour
{
    [SerializeField] GameObject cursorObject;
    [SerializeField] Sprite cursorBasic;
    [SerializeField] Sprite cursorHand;
    [SerializeField] Image image;

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        moveCursor();
        ChangeCursor();
    }

    private void moveCursor()
    {
        cursorObject.transform.position = Input.mousePosition;   
    }

    private void ChangeCursor()
    {
        if(Input.GetMouseButton(1))
        {
            image.sprite = cursorHand;
        }
        if(Input.GetMouseButtonUp(1))
        {
            image.sprite = cursorBasic;
        }
    }
}
