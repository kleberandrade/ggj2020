using UnityEngine;
using UnityEngine.UI;

public class SpawnUI : MonoBehaviour
{
    // Start is called before the first frame update
    public void DisableUI()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void EnableUI()
    {
        gameObject.SetActive(true);
    }
}
