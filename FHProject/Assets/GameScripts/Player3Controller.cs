using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player3Controller : MonoBehaviour
{
    public Text ap;

    GameObject player; //player 오브젝트
    GameObject touchFire;
    GameObject coll;
    GameManager GM;

    [SerializeField]
    Button btn_Up;
    [SerializeField]
    Button btn_Down;
    [SerializeField]
    Button btn_Left;
    [SerializeField]
    Button btn_Right;

    Touch t;
    Animator anim;
    WaterController WC;

    Vector3 moving = new Vector3(0, 0, 0);

    // 사운드
    public AudioSource SoundEffect;
    [SerializeField] public AudioClip[] se;
    public AudioSource BGM;
    [SerializeField] public AudioClip[] bgm;

    void Start()
    {
        player = this.gameObject;
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        WC = GameObject.Find("WaterGenerator").GetComponent<WaterController>();

        SoundEffect = GetComponent<AudioSource>(); // 시작하자마자 오디오 찾기.
        BGM = GetComponent<AudioSource>(); // 시작하자마자 오디오 찾기.
    }

    float timer = 15.0f;

    //AP회복, 타이머
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0.0f)
        {
            timer = 15.0f;
        }
        AP_Checker();
        touchRay();

        if (touchFire && (touchFire.transform.position == coll.transform.position))
        {
            if (coll.gameObject.transform.position.y < 0 && GM.playAP >= 3)
            {
                WC.waterAction(coll.gameObject.transform.position);
                Destroy(coll.gameObject);
                GM.playAP -= 3;
            }
            else if (coll.gameObject.transform.position.y < 2.1 && GM.playAP >= 4)
            {
                WC.waterAction(coll.gameObject.transform.position);
                Destroy(coll.gameObject);
                GM.playAP -= 4;
            }
            else if (coll.gameObject.transform.position.y < 4.2 && GM.playAP >= 5)
            {
                WC.waterAction(coll.gameObject.transform.position);
                Destroy(coll.gameObject);
                GM.playAP -= 5;
            }
            else
                print("AP가 부족하여 끌 수 없음");
            gameObject.transform.position = new Vector3(0, -2.2f, 0);
        }
    }


    //터치 된 불 끄기 : 타겟을 움직인 후 터치
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "fire")
        {
            coll = collision.gameObject;
            
        }
    }

    //AP를 다 소모하면 버튼 비활성화
    public void AP_Checker()
    {
        if (GM.playAP == 0)
        {
            btn_Up.GetComponent<Button>().interactable = false;
            btn_Down.GetComponent<Button>().interactable = false;
            btn_Left.GetComponent<Button>().interactable = false;
            btn_Right.GetComponent<Button>().interactable = false;
        }
        else if (GM.playAP != 0)
        {
            btn_Up.GetComponent<Button>().interactable = true;
            btn_Down.GetComponent<Button>().interactable = true;
            btn_Left.GetComponent<Button>().interactable = true;
            btn_Right.GetComponent<Button>().interactable = true;
        }
    }

    //화면 터치 판정
    public GameObject touchRay()
    {
        touchFire = null;
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
            if (hit.transform)
            {
                touchFire = hit.transform.gameObject;
                SoundEffect.clip = se[1];
                SoundEffect.Play();
            }
        }

        return touchFire;
    }

    // +Y 이동
    public void moveUp()
    {
        //좌표값 오류로 초기화 시켜줘야함
        moving = player.transform.position;

        if (moving.y <= 3.4f)
        {
            player.transform.Translate(0, 0.7f, 0);
            SoundEffect.clip = se[0];
            SoundEffect.Play();
        }
    }

    // -Y 이동
    public void moveDown()
    {
        //좌표값 오류로 초기화 시켜줘야함
        moving = player.transform.position;
        if (moving.y > -1.4f)
            {
                player.transform.Translate(0, -0.7f, 0);
                SoundEffect.clip = se[0];
                SoundEffect.Play();
        }
    }

    // -X 이동
    public void moveLeft()
    {
        moving = player.transform.position;

        if (moving.x >= -2.0f)
        {
            player.transform.Translate(-0.7f, 0, 0);
            SoundEffect.clip = se[0];
            SoundEffect.Play();
        }
    }


    // +X 이동
    public void moveRight()
    {
        moving = player.transform.position;

        if (moving.x <= 2.0f)
        {
            player.transform.Translate(0.7f, 0, 0);
            SoundEffect.clip = se[0];
            SoundEffect.Play();
        }
    }
}