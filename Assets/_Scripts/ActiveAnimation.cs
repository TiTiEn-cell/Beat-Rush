using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveAnimation : MonoBehaviour
{
    [SerializeField] Vector3 tweenScale = new Vector3 (1.2f, 1.2f, 1.2f);
    private void OnEnable()
    {
        LeanTween.scale(gameObject, tweenScale, 0.1f);
        LeanTween.scale(gameObject, Vector3.one, 0.1f).setDelay(0.1f);
    }
}
