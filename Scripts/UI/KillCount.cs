using UnityEngine;
using UnityEngine.SceneManagement;

public class KillCount : MonoBehaviour
{
    public PlayerDamage AK47;
    public PlayerDamage PPBizon;
    public PlayerDamage AR15;

    public int killCount;

    private void Update()
    {
        killCount = AK47.killCount + PPBizon.killCount + AR15.killCount;

        if(killCount == 25)
        {
            SceneManager.LoadScene(2);
        }
    }
}
