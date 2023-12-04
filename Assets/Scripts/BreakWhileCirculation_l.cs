using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakWhileCirculation_l : MonoBehaviour
{   
    private int thisLinenum;
    private int Wbcount = 0;
    // Start is called before the first frame update
    void Start()
    {
        string parentObjectName = transform.parent.name;
        char lastChar = parentObjectName[parentObjectName.Length - 1];
        thisLinenum = int.Parse(lastChar.ToString());
        char last2Char = parentObjectName[parentObjectName.Length - 2];
        if(char.IsDigit(last2Char)){
            string lastTwoChars = parentObjectName.Substring(parentObjectName.Length - 2, 2);
            thisLinenum = int.Parse(lastTwoChars.ToString());
        }else{
            thisLinenum = int.Parse(lastChar.ToString());
        }
        //print("ssssssssssssssssssssssssssssssssssssss");
        //print(Wbcount);
        OrderController_lit orderController_l = FindObjectOfType<OrderController_lit>();
        foreach (string instruction in OrderController_lit.instructionList_l)
        {
            if (instruction=="While Break")
            {
                Wbcount++;
            }
        }
        print("第" + Wbcount + "个while break在第" + thisLinenum + "行");

        if (OrderController_lit.WhileBreakList_l.Count > Wbcount)
        {
            OrderController_lit.WhileBreakList_l[Wbcount] = thisLinenum;
        }
        else
        {
            OrderController_lit.WhileBreakList_l.Add(thisLinenum);
        }
    }


}
