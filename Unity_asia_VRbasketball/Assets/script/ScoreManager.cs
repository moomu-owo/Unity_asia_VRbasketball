
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    [Header("分數介面")]
    public Text textScore;
    [Header("分數")]
    public int score;

    private void OnTriggerExit(Collider other)
    {
        print(other.name);
    }
}

