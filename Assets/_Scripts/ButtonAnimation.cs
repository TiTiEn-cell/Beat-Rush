using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimation : MonoBehaviour
{
    [SerializeField] private Vector3 scaleTarget = new Vector3(1.2f,1.2f,1.2f);
    Button btn;

    private void Awake()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(Anim);
    }

    void Anim()
    {
        LeanTween.scale(gameObject, scaleTarget, 0.1f);
        LeanTween.scale(gameObject, Vector3.one, 0.1f).setDelay(0.1f);

    }

}
