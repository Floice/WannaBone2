using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreateNewLine : MonoBehaviour
{
    public GameObject rawButtonPrefab;
    public static int counter = 1;
    private int thisLevelmaxCounter;
    private void Start()
    {
        // 获取按钮组件
        Button button = GetComponent<Button>();

        // 注册按钮的onClick事件
        button.onClick.AddListener(OnClick);

        thisLevelmaxCounter = GameManager.Instance.GetMaxCounter();
    }

    private void OnClick()
    {   
        // 获取按钮的父物体
        Transform parent = transform.parent;
        Transform parentparent = parent.parent;
        if(counter<thisLevelmaxCounter)
        {
            counter++;
            print("当前counter为"+counter);
            // 生成预制体，并指定名称
            GameObject spawnedRawButton = Instantiate(rawButtonPrefab, transform.position, Quaternion.identity, parentparent);
            spawnedRawButton.name = "RawButton" + counter.ToString();

            // 查找子目录下的TextMeshPro游戏对象
            TextMeshProUGUI spawnedCounterText = spawnedRawButton.GetComponentInChildren<TextMeshProUGUI>();

            // 将Text内容加1
            spawnedCounterText.text = counter.ToString();

            // 获取 AddOrderButton 和 deletLineButton 和AddLineButton 对象，既新生成的预设体中对应的对象
            Transform addOrderButton = spawnedRawButton.transform.Find("AddOrderButton");
            Transform addLineButton = spawnedRawButton.transform.Find("AddLineButton");
            Transform deletLineButton = spawnedRawButton.transform.Find("DeletLineButton");

            Transform parentTransform = transform.parent;

            // 将物体相对于父物体的位置设置为(0, -108, 0)
            addLineButton.localPosition = new Vector3(0, -108, 0);
            // 添加了以运行指令锁定之后，删除行按钮会奇怪的消失，在此设为可见
            deletLineButton.gameObject.SetActive(true);

            // 将 AddOrderButton 下的 AddOrderPanel 设置为不可见
            if (addOrderButton != null)
            {
                Transform addOrderPanel = addOrderButton.Find("AddOrderPanel");
                if (addOrderPanel != null)
                {   
                    addOrderButton.gameObject.SetActive(true);
                    addOrderPanel.gameObject.SetActive(false);
                }
            }

            // 删除除 TextMeshPro、AddOrderButton 和 AddLineButton 之外的其他子物体
            foreach (Transform child in spawnedRawButton.transform)
            {
                if (child != spawnedCounterText.transform && child != addOrderButton && child != addLineButton && child != deletLineButton)
                {
                    Destroy(child.gameObject);
                }
            }

            // 将按钮设置为不可见
            gameObject.SetActive(false);
            Transform thisdeletLineButton = transform.parent.Find("DeletLineButton");
            thisdeletLineButton.gameObject.SetActive(false);

            //达到最大行数限制之后，不再显示添加行数按钮
            if(counter == thisLevelmaxCounter)
            {
                addLineButton.gameObject.SetActive(false);
            }

            //如果此行之前已经执行完毕，则无法删除此行
            int alreadyCounter = OrderController.alreadyRunCounter;
            if(counter == alreadyCounter+1)
            {
                deletLineButton.gameObject.SetActive(false);
            }
        }else{
            print("以达到最大行数限制");
            //以下是提示玩家的信息





        }
    }
}



