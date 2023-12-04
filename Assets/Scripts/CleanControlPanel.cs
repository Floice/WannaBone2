using UnityEngine;
using UnityEngine.UI;

public class CleanControlPanel : MonoBehaviour
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
        // 查找 ButtonContent 对象
        GameObject content = null;
        if (GameObject.Find("ButtonContent") != null)
        {
            content = GameObject.Find("ButtonContent");
        }
        else if(GameObject.Find("ButtonContent_lit") != null)
        {
            content = GameObject.Find("ButtonContent_lit");
        }

        if (content != null)
        {
            // 遍历 ControlCanvas 下的所有子物体
            foreach (Transform child in content.transform)
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

