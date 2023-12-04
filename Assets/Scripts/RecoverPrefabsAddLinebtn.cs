using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecoverPrefabsAddLinebtn : MonoBehaviour
{
    private Button button;
    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }
        private void OnClick()
    {
        // 获取父物体的Transform组件
        Transform parentTransform = transform.parent;

        // 将物体相对于父物体的位置设置为(0, -108, 0)
        transform.localPosition = new Vector3(0, -108, 0);

    }

}
