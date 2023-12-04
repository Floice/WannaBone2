using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestoreAddBtn : MonoBehaviour
{   
    public string targetObjectName;
    private Button button;
    // Start is called before the first frame update
    void Start()
    {

    }
    void OnEnable() 
    {
        button = GetComponentInChildren<Button>();

        // 绑定按钮的点击事件
        button.onClick.AddListener(RestoreAddOrderBtn);
    }
    
    public void RestoreAddOrderBtn()
    {   
        Transform parent = transform.parent;
        Transform target = parent.Find(targetObjectName);
        target.gameObject.SetActive(true);
        Destroy(gameObject);
    }

}
