using UnityEngine;
using UnityEngine.UI;

public class ButtonSelect : MonoBehaviour
{
    public Button button;

    private void OnEnable()
    {
        button.Select();
    }
}
