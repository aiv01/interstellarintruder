using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class LoadLogic : MonoBehaviour
{
    public Button btn;
    private void OnEnable()
    {
        string path = Application.dataPath + "/map.sav";
        if (File.Exists(path))
        {
            btn.interactable = true;
        }
    }
}
