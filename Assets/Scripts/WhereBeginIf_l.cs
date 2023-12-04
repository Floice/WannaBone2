using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhereBeginIf_l : MonoBehaviour
{   
    private int thisLinenum;
    private int count = 0;
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
        OrderController_lit orderController_lit = FindObjectOfType<OrderController_lit>();
        foreach (string instruction in OrderController_lit.instructionList_l)
        {
            if (instruction=="Signal1Open" || instruction=="Signal2Open" || instruction=="Signal3Open" || instruction=="Signal4Open")
            {
                count++;
            }
        }
        print("第" + count + "个if在第" + thisLinenum + "行");
        if (OrderController_lit.IfinstructionList_l.Count > count)
        {
            OrderController_lit.IfinstructionList_l[count] = thisLinenum ;
        }
        else
        {
            OrderController_lit.IfinstructionList_l.Add(thisLinenum );
        }
    }
}
