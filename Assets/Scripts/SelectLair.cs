using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLair : MonoBehaviour
{
    public Sprite transparent;
    public Sprite selectedSprite;
    public bool isSelected=false;
    private SelectLair[] selections;
    // Start is called before the first frame update
    void Start()
    {
        selections = FindObjectsOfType<SelectLair>();
        GetComponent<Image>().sprite = transparent;
        // 获取按钮组件
        Button button = GetComponent<Button>();
        // 添加点击事件监听器
        button.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnClick()
    {
        print("down");
        if (isSelected)
        {
            GetComponent<Image>().sprite = transparent;
            isSelected = false;
        }
        else
        {
            foreach (SelectLair selectlair in selections)
            {
                selectlair.changeToNull();
            }
            GetComponent<Image>().sprite = selectedSprite;
            isSelected = true;
        }
    }

    public void changeToNull()
    {
        GetComponent<Image>().sprite = transparent;
        isSelected = false;
    }
}
