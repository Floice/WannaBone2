using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmSelection : MonoBehaviour
{
    public EnemyWhere currentButton;
    public GameObject leftup;
    public GameObject leftdown;
    public GameObject rightup;
    public GameObject rightdown;
    public GameObject left;
    public GameObject right;
    private SelectLair[] selections;
    // Start is called before the first frame update
    void Start()
    {
        selections = FindObjectsOfType<SelectLair>();
        // 获取按钮组件
        Button button = GetComponent<Button>();
        // 添加点击事件监听器
        button.onClick.AddListener(OnClick);
    }
    private void OnClick()
    {
        foreach (SelectLair selectlair in selections)
        {
            if (selectlair.isSelected == true)
            {
                if (selectlair.gameObject.name == "leftup")
                {
                    currentButton.CreatePrefabInParents(leftup);
                    currentButton.CommandButton("leftup");
                    currentButton.Retract();
                }
                else if(selectlair.gameObject.name == "leftdown")
                {
                    currentButton.CreatePrefabInParents(leftdown);
                    currentButton.CommandButton("leftdown");
                    currentButton.Retract();
                }
                else if (selectlair.gameObject.name == "rightup")
                {
                    currentButton.CreatePrefabInParents(rightup);
                    currentButton.CommandButton("rightup");
                    currentButton.Retract();
                }
                else if (selectlair.gameObject.name == "rightdown")
                {
                    currentButton.CreatePrefabInParents(rightdown);
                    currentButton.CommandButton("rightdown");
                    currentButton.Retract();
                }
                else if (selectlair.gameObject.name == "right")
                {
                    currentButton.CreatePrefabInParents(right);
                    currentButton.CommandButton("right");
                    currentButton.Retract();
                }
                else if (selectlair.gameObject.name == "left")
                {
                    currentButton.CreatePrefabInParents(left);
                    currentButton.CommandButton("left");
                    currentButton.Retract();
                }
                transform.parent.gameObject.SetActive(false);
                break;
            }
        }
    }
}
