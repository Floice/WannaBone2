using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class OrderController_lit : MonoBehaviour
{   
    public static List<string> instructionList_l = new List<string>(); // 指令列表
    public static List<List<int>> ForinstructionList_l = new List<List<int>>(); //二维列表，元素为<for所在的行数，循环次数>
    public static List<int> ForBreakList_l = new List<int>(); //记录何时停止for循环
    public static List<int> WhileinstructionList_l = new List<int>(); //记录何时开始While循环
    public static List<int> WhileBreakList_l = new List<int>(); //记录何时停止While循环
    public static List<int> IfinstructionList_l = new List<int>(); //记录何时开始If条件
    public static List<int> IfBreakList_l = new List<int>(); //记录何时停止If条件
    public Transform[] bone;
    private int codeOverLine;
    public GameObject player; // 玩家对象
    public float moveDistance; // 每一步移动距离
    private int currentCounter; // 当前最大指令索引
    public static int alreadyRunCounter_l = 0; // 上次执行到的指令索引
    private int layerMask;
    private WinCondition winCondition; //获取是否吃到骨头
    public bool whileBoneAppear = false;
    private string sceneName;
    private BoolVariableScript boolvariable;
    private void Awake()
    {
        layerMask = 1 << LayerMask.NameToLayer("Brick");
    }
    private void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        if (FindObjectOfType<BoolVariableScript>() != null)
        {
            boolvariable = FindObjectOfType<BoolVariableScript>();
        }
    }

    public void AddInstruction(string instruction, int lineNumber)
    {
        if (lineNumber > instructionList_l.Count)
        {
            instructionList_l.Add(instruction);
        }
        else
        {
            instructionList_l[lineNumber - 1] = instruction;
        }
    }

    public void RunCommands_l()
    {   
        currentCounter = CreateNewLine_l.counter_l;
        print(currentCounter);
        //判断当前命令行中是不是有没选的，既空的
        if((currentCounter == instructionList_l.Count) || (!CheckIfContainsNone(instructionList_l)))
        {
            print("currentCounter=" + currentCounter);
            print("alreadyRunCounter=" + alreadyRunCounter_l);
            if (instructionList_l.Count == 0)
            {
                return;
            }
            else if (alreadyRunCounter_l < currentCounter)
            {
                alreadyRunCounter_l ++;
            }
            else
            {
                return;
            }

            // 将已有的指令取消按钮和删除行按钮设为不可见
            Transform pparentTransform = GameObject.Find("CleanlPanel").transform;
            Transform parentTransform = pparentTransform.transform.Find("little dog").Find("Viewport").Find("ButtonContent_lit");
            // ***********************************************************************************************************************************
            //此处用到了所有RawButton在目录中的索引，如上方需要添加新物体要记得修改i
            //i为RawButton1在目录中的索引位置
            for (int i = 1; i < parentTransform.childCount; i++)
            {
                Transform childTransform = parentTransform.GetChild(i);
                if (childTransform.childCount >= 5)
                {
                    Transform prefabsTransform = childTransform.GetChild(4);
                    Transform deleteOrderBtnTransform = prefabsTransform.GetChild(0);
                    deleteOrderBtnTransform.gameObject.SetActive(false);
                }
                if (i == parentTransform.childCount - 1)
                {
                    Transform deleteLineBtnTransform = childTransform.GetChild(3);
                    deleteLineBtnTransform.gameObject.SetActive(false);
                }
            }
            // *************************************************************************************************************************************
            codeOverLine = instructionList_l.Count + 1;
            StartCoroutine(RunLines(alreadyRunCounter_l, codeOverLine));
        }
    }
    private IEnumerator RunLines(int beginLine, int overLine)
    {
        for (int line = beginLine; line < overLine; line++)
        {
            string instruction = instructionList_l[line - 1];
            print("当前行数为" + line + " 指令为" + instruction);
            alreadyRunCounter_l = line;
            // 根据指令执行相应的任务逻辑
            switch (instruction)
            {
                case "UP":
                    {
                        yield return MovePlayerCoroutine(Vector3.up);
                        break;
                    }
                case "Down":
                    {
                        yield return MovePlayerCoroutine(Vector3.down);
                        break;
                    }
                case "Left":
                    {
                        yield return MovePlayerCoroutine(Vector3.left);
                        break;
                    }
                case "Right":
                    {
                        yield return MovePlayerCoroutine(Vector3.right);
                        break;
                    }
                case "For":
                    {
                        for (int forindex = 0; forindex < ForinstructionList_l.Count; forindex++)
                        {
                            if (ForinstructionList_l[forindex][0] == line)
                            {
                                for (int i = 0; i < ForinstructionList_l[forindex][1]; i++)
                                {
                                    yield return RunLines(ForinstructionList_l[forindex][0] + 1, SearchMarchLine(ForinstructionList_l[forindex][0]));
                                }
                                break;
                            }
                        }
                        yield return RunLines(SearchMarchLine(line) + 1, codeOverLine);
                        yield break;
                    }
                case "While":
                    {
                        while (player.GetComponent<IfLittleDogGetnipple>().getNipple == false)
                        {
                            yield return RunLines(line + 1, SearchMarchLine(line));
                        }
                        yield return RunLines(SearchMarchLine(line) + 1, codeOverLine);
                        yield break;
                    }
                case "left":
                    {
                        if (GameObject.Find("leftlair").GetComponent<LairBlue>().staying == true)
                        {
                            yield return RunLines(line + 1, SearchMarchLine(line));
                        }
                        yield return RunLines(SearchMarchLine(line) + 1, codeOverLine);
                        yield break;
                    }
                case "right":
                    {
                        if (GameObject.Find("rightlair").GetComponent<LairBlue>().staying == true)
                        {
                            yield return RunLines(line + 1, SearchMarchLine(line));
                        }
                        yield return RunLines(SearchMarchLine(line) + 1, codeOverLine);
                        yield break;
                    }
                case "leftup":
                    {
                        if (GameObject.Find("leftuplair").GetComponent<LairBlue>().staying == true)
                        {
                            yield return RunLines(line + 1, SearchMarchLine(line));
                        }
                        yield return RunLines(SearchMarchLine(line) + 1, codeOverLine);
                        yield break;
                    }
                case "leftdown":
                    {
                        if (GameObject.Find("leftdownlair").GetComponent<LairBlue>().staying == true)
                        {
                            yield return RunLines(line + 1, SearchMarchLine(line));
                        }
                        yield return RunLines(SearchMarchLine(line) + 1, codeOverLine);
                        yield break;
                    }
                case "rightup":
                    {
                        if (GameObject.Find("rightuplair").GetComponent<LairBlue>().staying == true)
                        {
                            yield return RunLines(line + 1, SearchMarchLine(line));
                        }
                        yield return RunLines(SearchMarchLine(line) + 1, codeOverLine);
                        yield break;
                    }
                case "rightdown":
                    {
                        if (GameObject.Find("rightdownlair").GetComponent<LairBlue>().staying == true)
                        {
                            yield return RunLines(line + 1, SearchMarchLine(line));
                        }
                        yield return RunLines(SearchMarchLine(line) + 1, codeOverLine);
                        yield break;
                    }
                case "Signal1Open":
                    {
                        if (boolvariable.boolVariable1)
                        {
                            yield return RunLines(line + 1, SearchMarchLine(line));
                            yield return Wait(0.5f);
                        }
                        yield return RunLines(SearchMarchLine(line) + 1, codeOverLine);
                        yield break;
                    }
                case "Signal2Open":
                    {
                        if (boolvariable.boolVariable2)
                        {
                            yield return RunLines(line + 1, SearchMarchLine(line));
                            yield return Wait(0.5f);
                        }
                        yield return RunLines(SearchMarchLine(line) + 1, codeOverLine);
                        yield break;
                    }
                case "Signal3Open":
                    {
                        if (boolvariable.boolVariable3)
                        {
                            yield return RunLines(line + 1, SearchMarchLine(line));
                            yield return Wait(0.5f);
                        }
                        yield return RunLines(SearchMarchLine(line) + 1, codeOverLine);
                        yield break;
                    }
                case "Signal4Open":
                    {
                        if (boolvariable.boolVariable4)
                        {
                            yield return RunLines(line + 1, SearchMarchLine(line));
                            yield return Wait(0.5f);
                        }
                        yield return RunLines(SearchMarchLine(line) + 1, codeOverLine);
                        yield break;
                    }
                case "1":
                    boolvariable.SetBoolVariableTrue(1);
                    break;
                case "2":
                    boolvariable.SetBoolVariableTrue(2);
                    break;
                case "3":
                    boolvariable.SetBoolVariableTrue(3);
                    break;
                case "4":
                    boolvariable.SetBoolVariableTrue(4);
                    break;
                case "c1":
                    boolvariable.SetBoolVariableFalse(1);
                    break;
                case "c2":
                    boolvariable.SetBoolVariableFalse(2);
                    break;
                case "c3":
                    boolvariable.SetBoolVariableFalse(3);
                    break;
                case "c4":
                    boolvariable.SetBoolVariableFalse(4);
                    break;
                default:
                    break;
            }
        }
    }
    private IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
    }
    private IEnumerator MovePlayerCoroutine(Vector3 direction)
    {
        print("start move littledog to" + direction);
        bool hasBrickAhead = CheckIfTargetHasBrick(player.transform.position, direction, moveDistance);
        if(hasBrickAhead)
        {
            Vector3 targetPosition = player.transform.position + direction * moveDistance;
            while (player.transform.position != targetPosition && player.GetComponent<Dog>().state != 1)// && player.GetComponent<IfLittleDogGetnipple>().getNipple == false
            {
                float step = moveDistance * Time.deltaTime;
                player.transform.position = Vector3.MoveTowards(player.transform.position, targetPosition, step);
                yield return null;
            }
        }
    }

    public bool CheckIfContainsNone(List<string> list)
    {
        foreach (string item in list)
        {
            if (item == "None")
            {
                return true;
            }
        }
        return false;
    }

    //检测前方是否有方砖函数
    private bool CheckIfTargetHasBrick(Vector3 currentPosition, Vector3 direction, float stepSize)
    {
        Vector3 targetPosition = currentPosition + direction * stepSize;
        RaycastHit2D hit = Physics2D.Raycast(targetPosition, direction, stepSize, layerMask);
        if (hit.collider != null)
        {      
             if (hit.collider.CompareTag("Brick"))
            {
                return true; // 目标位置有砖块
            }
            // 检测到碰撞物体，判断是否是方形砖块
        }
        return false; // 目标位置没有砖块
    }

    //检测四周是否有敌人函数

    public GameObject GetMonsterObject(Vector3 playerPosition, float detectionRadius)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(playerPosition, detectionRadius);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("monster"))
            {
                return collider.gameObject; // 返回标签为"monster"的游戏对象
            }
        }

        return null; // 没有找到标签为"monster"的游戏对象
    }

    public bool CheckPlayerReachedTarget(Vector3 playerPosition, Transform[] targets)
    {
        foreach (Transform target in targets)
        {
            Vector3 targetCenter = target.position ;
            //print(targetCenter);
            //print(playerPosition);
            //print(Vector3.Distance(playerPosition, targetCenter));
            // 检测玩家位置与目标中心点是否重合
            if (Vector3.Distance(playerPosition, targetCenter) < 0.15f)
            {   
                target.gameObject.SetActive(false);
                return true;
            }
        }

        return false;
    }
    private int SearchMarchLine(int currentLine)//输入输出都是行数
    {
        Stack<string> stack = new Stack<string>();
        for (int line = 1; line < instructionList_l.Count + 1; line++)
        {
            string current = instructionList_l[line - 1];
            switch (current)
            {
                case "For":
                case "While":
                case "left":
                case "right":
                case "leftup":
                case "leftdown":
                case "rightup":
                case "rightdown":
                case "EnemyUp":
                case "EnemyDown":
                case "Signal1Open":
                case "Signal2Open":
                case "Signal3Open":
                case "Signal4Open":
                case "Monsterbefore":
                    stack.Push(current);
                    break;
                case "For Break":
                case "If Break":
                case "While Break":
                    if (stack.Count <= 0)
                    {
                        print("括号不匹配");
                        return 0;
                    }
                    else
                    {
                        string top = stack.Peek();
                        if (IsCouple(top, current)) //top左括号，current右括号
                        {
                            if ((instructionList_l[currentLine - 1] == top) && (line > currentLine))//不加第二个条件，会匹配到之前同名左括号的右括号
                            {
                                print(currentLine + "匹配的行数为" + line);
                                return line;
                            }
                            stack.Pop();
                        }
                        else
                        {
                            print("第" + top + "行和第" + current + "行" + "括号不匹配");
                            return 0;
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        print("括号不匹配");
        return 0;
    }
    static bool IsCouple(string left, string right)
    {
        if (left == "For" && right == "For Break")
        {
            return true;
        }
        if (left == "While" && right == "While Break")
        {
            return true;
        }
        if ((left == "left" || left == "right" || left == "leftup" || left == "leftdown" || left == "rightup" || left == "rightdown"
            || left == "EnemyUp" || left == "EnemyDown" || left == "Signal1Open" || left == "Signal2Open" || left == "Signal3Open"
            || left == "Signal4Open" || left == "Monsterbefore") && right == "If Break")
        {
            return true;
        }
        print("左括号是" + left + " 有括号是" + right + " not couple");
        return false;
    }
}



