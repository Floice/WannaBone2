using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideBigDogController : MonoBehaviour
{

    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(HideObjects);
    }

    private void HideObjects()
    {
        GameObject obj = GameObject.Find("ControlCanvas");
        Transform objTransform = obj.GetComponent<Transform>();
        for (int i = 0; i < objTransform.childCount; i++)
        {
            if (i == 0 || i >= 5)
            {
                objTransform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
