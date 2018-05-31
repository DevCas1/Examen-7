using Sjouke.CodeArchitecture.Variables;
using TMPro;
using UnityEngine;

public class IntToText : MonoBehaviour
{
    public IntReference Int;
    public TextMeshPro Text;
    public string TextBeforeInt;
    public string TextAfterInt;

    private void Update()
    {
        if (Text == null || Int.Variable == null) return;
        Text.text = TextBeforeInt + Int.Value + TextAfterInt;
    }
}