using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class delect_to_recoverRetract : MonoBehaviour
{   
    private Button button;
    private GameObject addlinebtn;
    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        addlinebtn = transform.parent.parent.gameObject;
        if (addlinebtn != null)
        {
            // 获取目标物体的当前位置
            Vector3 currentPosition = addlinebtn.transform.localPosition;

            // 将X轴位置向正方向移动105
            float newX = currentPosition.x + 69.3f;
            float newY = currentPosition.y;
            float newZ = currentPosition.z;

            // 设置新的位置
            Vector3 newPosition = new Vector3(newX, newY, newZ);
            addlinebtn.transform.localPosition = newPosition;
        }
        else
        {
            Debug.LogError("AddLineButton not found in the parent object's directory!");
        }
    }
}


