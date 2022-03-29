using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashController : MonoBehaviour
{
    public AnimationClip clip;

    private void OnEnable()
    {
        Invoke("Disable", clip.length);
    }
    private void OnDisable()
    {
        CancelInvoke();
    }
    private void Disable()
    {
        gameObject.SetActive(false);
    }
}
