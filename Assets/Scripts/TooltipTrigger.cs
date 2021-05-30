using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public CanvasGroup canvas;
    private static LTDescr delay;
    public string header;

    [Multiline()]
    public string content;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        delay = LeanTween.delayedCall(0.2f, () =>
        {
            LeanTween.alphaCanvas(canvas, 0.8f, 0.5f);
            TooltipSystem.Show(content, header);
        });

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        LeanTween.cancel(delay.uniqueId);
        LeanTween.alphaCanvas(canvas, 0f, 0.5f);
        TooltipSystem.Hide();
    }
}
