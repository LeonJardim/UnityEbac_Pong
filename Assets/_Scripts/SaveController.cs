using TMPro;
using UnityEngine;

public class SaveController : MonoBehaviour
{
    public Color playerColor = Color.white;
    public Color enemyColor = Color.white;
    public string playerName = "";

    public TMP_InputField inputField;
    private static SaveController _instance;

    public static SaveController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<SaveController>();

                if (_instance == null )
                {
                    GameObject singletonObject = new(typeof(SaveController).Name);
                    _instance = singletonObject.AddComponent<SaveController>();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        
        if (transform.parent != null)
        {
            transform.parent = null;
        }

        DontDestroyOnLoad(gameObject);
    }

    public void SetPlayerName()
    {
        playerName = inputField.text;
        PlayerPrefs.SetString("playerName", playerName);
    }

}
