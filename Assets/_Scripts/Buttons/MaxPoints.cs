using TMPro;
using UnityEngine;

public class MaxPoints : MonoBehaviour
{
    public TMP_Text label;

    void Start()
    {
        label.text = "Recorde: " + PlayerPrefs.GetInt("maxPoints", 0);
    }
}
