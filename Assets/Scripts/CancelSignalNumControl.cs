using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class CancelSignalNumControl : MonoBehaviour
{
    public int currentCirTimes = 0; // 当前数字
    public TMP_Text numberText;
    private int thisLinenum;

    private void Start()
    {
        Transform panel = transform.Find("Cancel_NumPanel");

        //通过rawbutton_获取当前行数
        string parentObjectName = transform.parent.name;
        string lastTwoChars = parentObjectName.Substring(parentObjectName.Length - 2);
        if (int.TryParse(lastTwoChars, out int result))
        {
            thisLinenum = result;
        }
        else
        {
            char lastChar = parentObjectName[parentObjectName.Length - 1];
            thisLinenum = int.Parse(lastChar.ToString());
        }
        print("第" + thisLinenum + "行");
        // 获取面板中的所有按钮，并为每个按钮绑定点击事件
        Button[] buttons = panel.GetComponentsInChildren<Button>();
        for (int i = 0; i < buttons.Length; i++)
        {
            int buttonNumber = i + 1; // 按钮的数字（从1开始）
            buttons[i].onClick.AddListener(() => OnButtonClick(buttonNumber));
        }
    }

    // 处理按钮点击事件
    public void OnButtonClick(int buttonNumber)
    {
        // 更新当前数字
        currentCirTimes = buttonNumber;
        numberText.text = buttonNumber.ToString();
        OrderController orderController = FindObjectOfType<OrderController>();
        if(OrderController.instructionList.Count >= thisLinenum){
            OrderController.instructionList[thisLinenum - 1] = "c" + buttonNumber.ToString();
            print("c" + buttonNumber.ToString());
        }else{
            OrderController.instructionList.Add("c" + buttonNumber.ToString());
            print("c" + buttonNumber.ToString());
        }
    }
}

