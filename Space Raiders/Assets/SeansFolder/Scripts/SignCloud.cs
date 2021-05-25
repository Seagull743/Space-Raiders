using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignCloud : InteractiveObject
{
    [SerializeField]
    private GameObject FreezeWord;
    
    public override void PlayerInteraction()
    {
        StartCoroutine(FreezeText());
    }

    IEnumerator FreezeText()
    {
        FreezeWord.SetActive(true);
        yield return new WaitForSeconds(3);
        FreezeWord.SetActive(false);
    }

}
