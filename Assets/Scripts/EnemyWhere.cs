using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnemyWhere : MonoBehaviour
{
    public string targetObjectName; // 目标物体的名称
    public GameObject addlinebtn;
    // Start is called before the first frame update
    void Start()
    {
        // 获取按钮组件
        Button button = GetComponent<Button>();
        // 添加点击事件监听器
        button.onClick.AddListener(OnClick);
    }
    private void OnClick()
    {
        FindObjectOfType<ConfirmSelection>().currentButton = this;
    }
    public void CreatePrefabInParents(GameObject prefab)
    {
        Transform parent = transform.parent;

        while (parent != null)
        {
            Transform target = parent.Find(targetObjectName);
            if (target != null)
            {
                Vector3 targetPosition = target.position;
                target.gameObject.SetActive(false);
                // 创建预制体实例并设置父物体
                GameObject instantiatedPrefab = Instantiate(prefab, targetPosition, Quaternion.identity);
                instantiatedPrefab.transform.SetParent(target.parent);
                instantiatedPrefab.transform.localScale = Vector3.one;
                break;
            }

            parent = parent.parent;
        }
    }
    public void CommandButton(string instruction)
    {
        // 获取当前行数
        Transform ppppp = transform.parent.parent.parent.parent.parent;
        TextMeshProUGUI LineNumberText = ppppp.GetComponentInChildren<TextMeshProUGUI>();
        string text = LineNumberText.text;
        int thisLineNumber = int.Parse(text);

        // 获取 OrderController 脚本
        OrderController orderController = FindObjectOfType<OrderController>();

        //print(instruction);
        // 将指令添加到 OrderController 的全局静态列表中
        orderController.AddInstruction(instruction, thisLineNumber);
    }
    public void Retract()
    {
        // 获取目标物体的当前位置
        Vector3 currentPosition = addlinebtn.transform.localPosition;

        // 将X轴位置向正方向移动105
        float newX = currentPosition.x + 105f;
        float newY = currentPosition.y;
        float newZ = currentPosition.z;

        // 设置新的位置
        Vector3 newPosition = new Vector3(newX, newY, newZ);
        addlinebtn.transform.localPosition = newPosition;
    }
}
