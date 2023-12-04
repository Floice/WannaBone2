using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DelectOrderInList : MonoBehaviour
{
    private void Start()
    {
        // 获取按钮组件
        Button button = GetComponent<Button>();

        // 添加按钮点击事件监听
        button.onClick.AddListener(ResetInstruction);
    }

    private void ResetInstruction()
    {
        // 获取父物体的父物体的子目录中的 TextMeshPro 组件
        TextMeshProUGUI textComponent = transform.parent.parent.GetComponentInChildren<TextMeshProUGUI>();

        // 获取文本中的索引值
        if (int.TryParse(textComponent.text, out int index))
        {
            // 将指定索引位置的字符串值改为 "None"
            if (index >= 0 && index < OrderController.instructionList.Count)
            {
                OrderController.instructionList[index-1] = "None";
            }
        }
    }
}
