using UnityEngine;
using UnityEngine.SceneManagement;
public class ResetData : MonoBehaviour
{
    public void ClearSave()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
