using UnityEngine;


public class White : MonoBehaviour
{
    #region 練習區域 - 在此區域內練習
    #region  屬性

    [Header("玩家移動速度"), Range(1, 100),]
    public float PlayerSpeed;
    /// <summary>
    /// 玩家剛體
    /// </summary>
    Rigidbody2D PlayerR2d;
    [Header("玩家子彈元件")]
    public GameObject PlayerBullet;
    /// <summary>
    /// 玩家子彈生成位置
    /// </summary>
    public Transform PlayerBulletTrm;
    [Header("子彈生成時間")]
    public float CreateBulletTime;
    [Header("怪物腳本")]
    public Black _Black;
    [Header("子彈發射音效")]
    public AudioClip ShootClip;
    [Header("喇叭")]
    public AudioSource PlayerAud;
    #endregion

    #region  事件
    private void Awake()
    {
        PlayerR2d = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        CreateBulletTime += Time.deltaTime;
        PlayerMove();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateBulletTime++;
            if (CreateBulletTime > 2.5f && _Black.MonsterLife > 0)
            {
                PlayerAud.PlayOneShot(ShootClip);
                CreateBullet();
                CreateBulletTime = 0;
            }
        }
    }
    #endregion

    #region  方法
    void PlayerMove()
    {
        PlayerR2d.AddForce(PlayerR2d.transform.right * Input.GetAxisRaw("Horizontal") * PlayerSpeed);
    }
    void CreateBullet()
    {
        Instantiate(PlayerBullet, PlayerBulletTrm.position, PlayerBulletTrm.rotation);
    }
    #endregion

    #endregion

    /*#region KID 區域 - 不要偷看 @3@
    [Header("移動速度"), Range(0f, 100f)]
    public float speed = 1.5f;

    private Rigidbody2D rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        rig.AddForce(transform.right * Input.GetAxisRaw("Horizontal") * speed);
    }
    #endregion*/
}
