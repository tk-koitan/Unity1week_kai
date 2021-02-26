using UnityEngine;
using System.Collections;
using KoitanLib;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    Vector3 prev;

    [SerializeField]
    float power = 80f;

    Rigidbody2D rb;
    Collider2D col;
    bool isThrowed = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        //操作説明
        KoitanDebug.Display("Rでリセット\n");
        KoitanDebug.Display("左クリックで掴む\n");

        if (isThrowed)
        {
            Vector3 pos = Camera.main.transform.position;
            Vector3 vec = transform.position - pos;
            vec.y = 0;
            vec.z = 0;
            vec *= 0.9f;
            Camera.main.transform.position += vec;
            Camera.main.orthographicSize = Mathf.Max(12, transform.position.y + 12);
            KoitanDebug.Display("飛んだ距離：" + transform.position.x.ToString() + "m\n");
        }
        else
        {
            Vector3 p = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
            p.z = 0;

            if (Input.GetMouseButton(0))
            {
                rb.velocity = (p - this.prev) * power;
            }
            this.prev = p;

            if (Input.GetMouseButtonUp(0))
            {
                rb.isKinematic = false;
                col.enabled = true;
                isThrowed = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}