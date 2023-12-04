using UnityEngine;
using TMPro;

public class CommandLine_l : MonoBehaviour
{
    public int ThisCommandLineNum { get; private set; }

    private TextMeshProUGUI textMeshPro;

    private void OnEnable()
    {
        ThisCommandLineNum = CreateNewLine_l.counter_l;
        print("this LineNumber is" + ThisCommandLineNum);
    }

}

