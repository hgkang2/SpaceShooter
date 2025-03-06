using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public void OnButtonClick()
    {
        Debug.Log("Click Button");
    }
    public void OnButtonClick2(string msg)
    {
        Debug.Log($"Click Button : {msg}");
    }
    public void OnButtonClick3(RectTransform rt)
    {
        Debug.Log($"Click Button : {rt.localScale.x}");
    }
}
