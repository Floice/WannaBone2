using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class CirculationTimes : MonoBehaviour
{
    public int currentCirTimes = 0; // 当前数字
    public TMP_Text numberText;
    private int thisLinenum;
    private int count = 0;

    private void Start()
    {
        Transform panel = transform.Find("Cir_NumPanel");

        //通过rawbutton_获取当前行数
        string parentObjectName = transform.parent.name;
        char lastChar = parentObjectName[parentObjectName.Length - 1];
        char last2Char = parentObjectName[parentObjectName.Length - 2];
        if (char.IsDigit(last2Char))
        {
            string lastTwoChars = parentObjectName.Substring(parentObjectName.Length - 2, 2);
            thisLinenum = int.Parse(lastTwoChars.ToString());
        }
        else
        {
            thisLinenum = int.Parse(lastChar.ToString());
        }

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
        foreach (string instruction in OrderController.instructionList)
        {
            if (instruction=="For")
            {
                count++;
            }
        }
        Debug.Log("出现 'for' 的个数: " + count);
        List<int> sublist = new List<int>(); // 创建一个包含 thisLinenum 和 buttonNumber 的一维列表
        sublist.Add(thisLinenum);
        sublist.Add(buttonNumber);
        
        if (OrderController.ForinstructionList.Count > count)
        {
            OrderController.ForinstructionList[count] = sublist;
            print(sublist[0]);
            print(sublist[1]);
        }
        else
        {
            print(sublist[0]);
            print(sublist[1]);
            OrderController.ForinstructionList.Add(sublist);

        }
    }
}

