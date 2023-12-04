using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhereBeginWhile : MonoBehaviour
{   
    private int thisLinenum;
    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        string parentObjectName = transform.parent.name;
        char lastChar = parentObjectName[parentObjectName.Length - 1];
        thisLinenum = int.Parse(lastChar.ToString());
        OrderController orderController = FindObjectOfType<OrderController>();
        foreach (string instruction in OrderController.instructionList)
        {
            if (instruction=="While")
            {
                count++;
            }
        }
        print("第" + count + "个while在第" + thisLinenum + "行");
        if (OrderController.WhileinstructionList.Count > count)
        {
            OrderController.WhileinstructionList[count] = thisLinenum;
        }
        else
        {
            OrderController.WhileinstructionList.Add(thisLinenum);
        }
    }
}
