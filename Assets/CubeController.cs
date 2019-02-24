using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour
{

    // キューブの移動速度
    private float speed = -0.2f;

    // 消滅位置
    private float deadLine = -10;

    private AudioSource SoundEffect;

    // Use this for initialization
    void Start()
    {
        SoundEffect = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // キューブを移動させる
        transform.Translate(this.speed, 0, 0);

        // 画面外に出たら破棄する
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //衝突判定
        if (collision.gameObject.tag == "Cube" || collision.gameObject.tag == "Ground")
        {
            SoundEffect.PlayOneShot(SoundEffect.clip);
        }
    }
}