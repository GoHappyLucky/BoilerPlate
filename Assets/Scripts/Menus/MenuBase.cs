using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBase<T> : MonoBehaviour
{
    public static event Action OnUILoaded;
    public static event Action OnUIUnloaded;
    [SerializeField] protected Canvas menuCanvas;

    private void OnEnable()
    {
        if (OnUILoaded is not null)
            OnUILoaded();
    }

    private void OnDisable()
    {
        if (OnUIUnloaded is not null)
            OnUIUnloaded();
    }
}
