using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhereBeginWhile_l : MonoBehaviour
{   
    private int thisLinenum;
    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        string parentObjectName = transform.parent.name;
        char lastChar = parentObjectName[parentObjectName.Length - 1];
        thisLinenum = int.Parse(lastChar.ToString());
        OrderController_lit orderController_lit = FindObjectOfType<OrderController_lit>();
        foreach (string instruction in OrderController_lit.instructionList_l)
        {
            if (instruction=="While")
            {
            count++;
            }
        }
        print("第" + count + "个while在第" + thisLinenum + "行");
        if (OrderController_lit.WhileinstructionList_l.Count > count)
        {
            OrderController_lit.WhileinstructionList_l[count] = thisLinenum;
        }
        else
        {
            OrderController_lit.WhileinstructionList_l.Add(thisLinenum);
        }
    }
}
