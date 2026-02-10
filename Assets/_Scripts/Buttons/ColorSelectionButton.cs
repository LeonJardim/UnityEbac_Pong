using UnityEngine;
using UnityEngine.UI;
public class ColorSelectionButton : MonoBehaviour
{
    public Button uiButton;
    public Image buttonColor;
    public Image paddleReference;

    public bool isPlayerColor = false;

    public void OnButtonClick()
    {
        paddleReference.color = buttonColor.color;

        if (isPlayerColor)
        {
            SaveController.Instance.playerColor = paddleReference.color;
        }
        else
        {
            SaveController.Instance.enemyColor = paddleReference.color;

        }
    }
}
