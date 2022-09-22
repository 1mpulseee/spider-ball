using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class NewBehaviourScript : MonoBehaviour
{
    private Text text;
    private int Size;
    private RectTransform rectTransform;
    void Start()
    {
        text = GetComponent<Text>();
        rectTransform = GetComponent<RectTransform>();
        StartCoroutine("Fix");
    }
    public IEnumerator Fix()
    {
        yield return new WaitForSeconds(.25f);
        Size = text.fontSize;
        text.resizeTextForBestFit = true;
        while (text.cachedTextGenerator.fontSizeUsedForBestFit > Size)
        {
            rectTransform.sizeDelta = rectTransform.sizeDelta - new Vector2(0, 10);
            yield return new WaitForEndOfFrame();
        }
        while (text.cachedTextGenerator.fontSizeUsedForBestFit < Size)
        {
            rectTransform.sizeDelta = rectTransform.sizeDelta + new Vector2(0, 10);
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(.1f);
        while (text.cachedTextGenerator.fontSizeUsedForBestFit > Size)
        {
            rectTransform.sizeDelta = rectTransform.sizeDelta - new Vector2(0, 10);
            yield return new WaitForEndOfFrame();
        }
        while (text.cachedTextGenerator.fontSizeUsedForBestFit < Size)
        {
            rectTransform.sizeDelta = rectTransform.sizeDelta + new Vector2(0, 10);
            yield return new WaitForEndOfFrame();
        }
    }
}