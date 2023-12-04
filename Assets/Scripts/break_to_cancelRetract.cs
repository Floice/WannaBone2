using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class break_to_cancelRetract : MonoBehaviour
{   
    public GameObject addlinebtn;
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {   
        // 获取目标物体的当前位置
        Vector3 currentPosition = addlinebtn.transform.localPosition;

        // 将X轴位置向正方向移动105
        float newX = currentPosition.x - 68.5f;
        float newY = currentPosition.y;
        float newZ = currentPosition.z;

        // 设置新的位置
        Vector3 newPosition = new Vector3(newX, newY, newZ);
        addlinebtn.transform.localPosition = newPosition;               
    }
}

