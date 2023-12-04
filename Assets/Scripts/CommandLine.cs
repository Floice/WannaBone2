using UnityEngine;
using TMPro;

public class CommandLine : MonoBehaviour
{
    public int ThisCommandLineNum { get; private set; }

    private TextMeshProUGUI textMeshPro;

    private void OnEnable()
    {
        ThisCommandLineNum = CreateNewLine.counter;
        print("this LineNumber is" + ThisCommandLineNum);
    }

}

