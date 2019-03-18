using UnityEngine;

public class Button_ : MonoBehaviour
{
    public ButtonType type;

    private void OnTriggerStay(Collider other)
    {
        ButtonManager_.Instance.PushButton(type);
    }
}