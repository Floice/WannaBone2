using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakIfCondition_l : MonoBehaviour
{   
    private int thisLinenum;
    private int Ifcount = 0;
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
        //print(Wbcount);
        OrderController_lit orderController_l = FindObjectOfType<OrderController_lit>();
        foreach (string instruction in OrderController_lit.instructionList_l)
        {
            if (instruction=="If Break")
            {
                Ifcount++;
            }
        }
        print("第" + Ifcount + "个If Break在第" + thisLinenum + "行");
        if (OrderController_lit.IfBreakList_l.Count > Ifcount)
        {
            OrderController_lit.IfBreakList_l[Ifcount] = thisLinenum ;
        }
        else
        {
            OrderController_lit.IfBreakList_l.Add(thisLinenum );
        }
    }


}
