using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ButtonType { Left, Right, Up, Down, Shot}

public class ButtonManager_ : MonoBehaviour
{
    public List<Controllable> targets;
    public static ButtonManager_ Instance { get; private set; }

    private void Start()
    {
        if (Instance == null)
            Instance = this;
    }

    public void PushButton(ButtonType type)
    {
        foreach (var item in targets)
        {
            if (item.isActiveAndEnabled)
            {
                item.OnCtrl(type);
            }
        }
    }
}
