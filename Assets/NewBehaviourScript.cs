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
        Size = text.fontSize;
        rectTransform = GetComponent<RectTransform>();
        text.resizeTextForBestFit = true;
        StartCoroutine("Fix");
    }
    public IEnumerator Fix()
    {
        while (text.cachedTextGenerator.fontSizeUsedForBestFit > Size)
        {
            rectTransform.sizeDelta = rectTransform.sizeDelta - new Vector2(0, 10);
            yield return new WaitForSeconds(.01f);
        }
        while (text.cachedTextGenerator.fontSizeUsedForBestFit < Size)
        {
            rectTransform.sizeDelta = rectTransform.sizeDelta + new Vector2(0, 10);
            yield return new WaitForSeconds(.01f);
        }
        yield return new WaitForSeconds(2);
        Debug.Log("Done");
        StartCoroutine("Fix");
    }
}