using UnityEngine;
using UnityEngine.UI;

public class CleanControlPanel_l : MonoBehaviour
{
    private void Start()
    {
        // 获取按钮组件
        Button button = GetComponent<Button>();

        // 注册按钮的onClick事件
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        // 查找 ControlCanvas 对象
        Transform parentTransform = transform.parent;
        GameObject controlCanvas_l = parentTransform.gameObject;
        print(controlCanvas_l);
        if (controlCanvas_l != null)
        {   
            print("controlCanvas_l != null");
            // 遍历 ControlCanvas 下的所有子物体
            foreach (Transform child in controlCanvas_l.transform)
            {
                // 检查子物体是否存在 AddOrderButton
                Transform addOrderButton = child.Find("AddOrderButton");

                if (addOrderButton != null)
                {
                    // 查找 AddOrderButton 子物体的 AddOrderPanel 对象
                    Transform addOrderPanel = addOrderButton.Find("AddOrderPanel");

                    if (addOrderPanel != null)
                    {
                        // 将 AddOrderPanel 设置为不可见
                        addOrderPanel.gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}

