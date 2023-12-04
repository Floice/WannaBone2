using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CommandButton : MonoBehaviour
{
    private void Start()
    {
        // 获取按钮组件
        Button button = GetComponent<Button>();

        // 添加点击事件监听器
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {

        // 获取当前行数
        Transform ppppp = transform.parent.parent.parent.parent.parent;
        TextMeshProUGUI LineNumberText = ppppp.GetComponentInChildren<TextMeshProUGUI>();
        string text = LineNumberText.text;
        int thisLineNumber = int.Parse(text);

        // 获取 OrderController 脚本
        OrderController orderController = FindObjectOfType<OrderController>();

        // 获取按钮上的文本信息
        string instruction = gameObject.name;
        //print(instruction);
        // 将指令添加到 OrderController 的全局静态列表中
        orderController.AddInstruction(instruction, thisLineNumber);
    }
}

