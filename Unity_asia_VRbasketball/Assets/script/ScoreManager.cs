
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    [Header("分數介面")]
    public Text textScore;
    [Header("分數")]
    public int score;
    [Header("投進的分數")]
    public int scoreIn = 2;
    [Header("進球音效")]
    public AudioClip soundIn;

    private AudioSource aud;

    private void Awake()
    {
        //音效來源 = 取得元件<音效來源>()
        aud = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
         //如果 碰撞物件的標籤 為 籃球  且  物件高度高於5.3就加分
        if (other.tag == "basketball"  && other.transform.position.y >5.3)
        {
            AddScore();
        }
        // 如果 碰撞的跟物件名稱為  Player


        if (other.transform.root.name == "Player")
        {
            //玩家進入三分區域，將投進分數改為三分
            scoreIn = 3;
        }
    }
    // 當碰撞物件離開碰撞範圍時執行一次
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.root.name =="Player")
        {
            //將投進的分數改為兩分
            scoreIn = 2;
        }
    }

    ///加分數
    private void AddScore()
    {
        score += scoreIn;                                                                             //分數遞增
        textScore.text = "Score : 0" + score;                                           //更新介面
        aud.PlayOneShot(soundIn, Random.Range(1f, 5f));               //音效來源.撥放一次(音效片段，音量)
    }
}

