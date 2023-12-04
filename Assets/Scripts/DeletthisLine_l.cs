using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeletthisLine_l : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         // 获取按钮组件
        Button button = GetComponent<Button>();

        // 注册按钮的onClick事件
        button.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    private void OnClick()
    {   
        OrderController_lit orderController_lit = FindObjectOfType<OrderController_lit>();
        int currentCounter = CreateNewLine_l.counter_l; // 获取counter的值
        if(currentCounter - 1 <= OrderController_lit.instructionList_l.Count)
        {
            OrderController_lit.instructionList_l.RemoveAt(currentCounter-1);
        }
        currentCounter--; // 修改counter的值
        CreateNewLine_l.counter_l = currentCounter; // 将修改后的值赋回给counter
        int currentIndex = transform.parent.GetSiblingIndex();
        // 获取上一个物体的索引
        int previousIndex = currentIndex - 1;
        Transform siblingTransform = transform.parent.parent.GetChild(previousIndex);
        GameObject siblingAddLineBtn = siblingTransform.GetChild(2).gameObject;
        GameObject siblingDeletLineBtn = siblingTransform.GetChild(3).gameObject;
        print("当前counter_l为"+currentCounter);
        siblingAddLineBtn.SetActive(true);
        Destroy( transform.parent.gameObject);
        if (currentCounter>1)
        {   
            siblingDeletLineBtn.SetActive(true);
        }

    }
}
