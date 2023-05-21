using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextShow : MonoBehaviour
{
    public TMP_Text textBox;
    private void OnEnable()
    {
        EventHandler.TriggerShowRecipeTextEvent += onShowText;
    }
    private void OnDisable()
    {
        EventHandler.TriggerShowRecipeTextEvent -= onShowText;
    }

    private void onShowText(string obj)
    {
        textBox.text = obj;
    }
}
