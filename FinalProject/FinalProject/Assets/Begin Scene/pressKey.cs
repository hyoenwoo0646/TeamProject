using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class pressKey : MonoBehaviour
{
    public TextMeshProUGUI txt;
    private bool isBlink;

    void Start()
    {
        StartCoroutine(BlinkText());
        isBlink = false;
    }

    public IEnumerator BlinkText()
    {
        while(true)
        {
            if(isBlink)
            {
                txt.enabled = false;
                isBlink = false;
            }
            else
            {
                txt.enabled = true;
                isBlink = true;
            }
            yield return new WaitForSeconds(0.5f);
        }
        //yield break;
    }
}
