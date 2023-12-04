using UnityEngine;
using UnityEngine.UI;

public class CreatePrefabs : MonoBehaviour
{
    public GameObject prefab; // 预制体的引用
    public string targetObjectName; // 目标物体的名称
    private Button button; // 按钮的引用

    private void Start()
    {
        // 获取按钮组件
        button = GetComponent<Button>();

        // 绑定按钮的点击事件
        button.onClick.AddListener(CreatePrefabInParents);
    }

    public void CreatePrefabInParents()
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
}
