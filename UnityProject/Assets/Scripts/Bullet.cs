using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region 練習區域

    #region 屬性
    [Header("子彈移動速度"), Range(1, 2000)]
    public float BulletSpeed;
    [Header("子彈剛體")]
    public Rigidbody2D BulletR2d;
    [Header("子彈攻擊目標")]
    public string BulletTarget;
    #endregion

    #region 事件
    private void Awake()
    {
        BulletR2d = GetComponent<Rigidbody2D>();
        BulletMove();

    }
    private void Update()
    {

    }
    #endregion

    #region 方法
    void BulletMove()
    {
        BulletR2d.AddForce(BulletR2d.transform.right * BulletSpeed * Time.deltaTime, ForceMode2D.Impulse);
    }
    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.tag == BulletTarget)
        {
            Destroy(gameObject, 0.01f);
        }

    }
    #endregion
    #endregion
    /*#region KID 區域 - 不要偷看 @3@
    [Header("讓子彈飛的速度"), Range(0f, 2000f)]
    public float speed = 1.5f;
    [Header("剛體")]
    public Rigidbody2D rig;

    private void Start()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject, 0.03f);
    }

    /// <summary>
    /// 讓子彈飛
    /// </summary>
    private void Move()
    {
        rig.AddForce(transform.right * speed);
    }
    #endregion*/
}
