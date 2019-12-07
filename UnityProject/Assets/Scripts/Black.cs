using UnityEngine;
using UnityEngine.UI;

public class Black : MonoBehaviour
{
    #region 練習區域 - 在此區域內練習
    #region 屬性
    [Header("怪物血量"), Range(0, 300)]
    public int MonsterLife;
    static int _MonsterLife;
    [Header("怪物血量文字")]
    public Text MonsterLifeText;
    [Header("怪物剛體")]
    public Rigidbody2D MonsterR2d;
    //[Header("怪物受傷音效")]
    //public AudioClip hurtClip;
    [Header("喇叭")]
    public AudioSource MonsterAud;
    #endregion

    #region 事件
    private void Awake()
    {
        MonsterR2d = GetComponent<Rigidbody2D>();
        MonsterLifeText = GetComponentInChildren<Text>();
        MonsterLifeText.text = MonsterLife.ToString();
        _MonsterLife = MonsterLife;
    }
    private void OnTriggerEnter2D(Collider2D Hit)
    {
        if (Hit.tag == "子彈")
        {
            MonsterAud.Play();
            GameObject.FindGameObjectWithTag("BGM").GetComponent<AudioSource>().volume = 0.5f;
            MonsterLife--;
            MonsterLifeText.text = MonsterLife.ToString();
            if (MonsterLife <= 0)
            {
                MonsterLifeText.text = "0";
                Dead();
            }
        }
    }
    #endregion

    #region 方法
    void Dead()
    {


        print("怪物死亡");

    }
    #endregion
    #endregion
}
