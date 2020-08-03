using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellController : MonoBehaviour
{
    public Text mainText;
    public int value = 2;

    public void changeValue(int newValue)
    {
        Color newColor;
        value = newValue;
        mainText.text = value.ToString();

        switch (value)
        {
            case 2:
                ColorUtility.TryParseHtmlString("#FFFDE7", out newColor);
                break;
            case 4:
                ColorUtility.TryParseHtmlString("#FFF9C4", out newColor);
                break;
            case 8:
                ColorUtility.TryParseHtmlString("#FFF59D", out newColor);
                break;
            case 16:
                ColorUtility.TryParseHtmlString("#FFF176", out newColor);
                break;
            case 32:
                ColorUtility.TryParseHtmlString("#FFEE58", out newColor);
                break;
            case 64:
                ColorUtility.TryParseHtmlString("#FFEB3B", out newColor);
                break;
            case 128:
                ColorUtility.TryParseHtmlString("#FDD835", out newColor);
                break;
            case 256:
                ColorUtility.TryParseHtmlString("#FBC02D", out newColor);
                break;
            case 512:
                ColorUtility.TryParseHtmlString("#F9A825", out newColor);
                break;
            case 1024:
                ColorUtility.TryParseHtmlString("#F57F17", out newColor);
                break;
            case 2048:
                ColorUtility.TryParseHtmlString("#81C784", out newColor);
                break;
            case 5096:
                ColorUtility.TryParseHtmlString("#66BB6A", out newColor);
                break;
            case 10192:
                ColorUtility.TryParseHtmlString("#4CAF50", out newColor);
                break;
            case 20384:
                ColorUtility.TryParseHtmlString("#43A047", out newColor);
                break;
            case 40768:
                ColorUtility.TryParseHtmlString("#388E3C", out newColor);
                break;
            case 81536:
                ColorUtility.TryParseHtmlString("#2E7D32", out newColor);
                break;
            case 163072:
                ColorUtility.TryParseHtmlString("#1B5E20", out newColor);
                break;
            default:
                ColorUtility.TryParseHtmlString("#1B5E20", out newColor);
                break;

        }

        GetComponent<Image>().color = newColor;

    }
}
