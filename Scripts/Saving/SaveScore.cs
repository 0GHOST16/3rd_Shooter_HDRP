using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveScore : MonoBehaviour
{
    public KillCount kills;

    public int killCount;

    public TMP_Text textScore;

    private void Start()
    {
        // atribuim scorul la incarcarea scenei
        Debug.Log(PlayerPrefs.GetInt("KillCount", killCount));
        textScore.text = PlayerPrefs.GetInt("KillCount", killCount).ToString();
    }

    private void Update()
    {
        // salvam scorul
        killCount = kills.killCount;
        PlayerPrefs.SetInt("KillCount", killCount);
    }
}
