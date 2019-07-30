﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player2Controller : MonoBehaviour
{
    public CharatorDetector CD;
    public FireDetector FD;

    public GameObject P_LeftCollis;
    public GameObject P_RightCollis;
    public GameObject P_UpCollis;
    public GameObject P_DownCollis;

    [SerializeField]
    Button btn_Up;
    [SerializeField]
    Button btn_Down;
    [SerializeField]
    Button btn_Left;
    [SerializeField]
    Button btn_Right;

    public Text hp;
    public Text res;

    GameManager GM;
    SaveUserInfo SUI;
    WaterController WC;

    GameObject player2; //player 오브젝트
    GameObject Controller2;

    Vector3 moving = new Vector3(0, 0, 0);

    int player2HP;
    int rescueMax = 2;

    // 사운드
    public AudioSource SoundEffect;
    [SerializeField] public AudioClip[] se;
    public AudioSource BGM;
    [SerializeField] public AudioClip[] bgm;

    void Start()
    {
        player2 = this.gameObject;
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        SUI = GameObject.Find("SaveUserInfo").GetComponent<SaveUserInfo>();
        WC = GameObject.Find("WaterGenerator").GetComponent<WaterController>();
        player2HP = SUI.player2_HP;
        Controller2 = GameObject.Find("P2_btn");

        SoundEffect = GetComponent<AudioSource>(); // 시작하자마자 오디오 찾기.
        BGM = GetComponent<AudioSource>(); // 시작하자마자 오디오 찾기.
    }

    void Update()
    {
        //HP표시
        hp.text = string.Format("{0:f0}", "  X" + player2HP);
        AP_Checker();
        //구조자 표시
        if (rescueMax == 0)
        {
            res.text = string.Format("{0:f0}", "  X" + 2);
        }
        else if (rescueMax == 1)
        {
            res.text = string.Format("{0:f0}", "  X" + 1);
        }
        else if (rescueMax == 2)
        {
            res.text = string.Format("{0:f0}", "  X" + 0);
        }

        if (player2HP == 0)
        {
            Destroy(gameObject);
            hp.text = "사망";
            GM.playerDieCount++;
        }
    }

    //불에 닿으면 HP - 1 and 캐릭터와 겹쳐진 불은 삭제
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "fire")
        {
            player2HP = player2HP - 1;
            SoundEffect.clip = se[2];
            SoundEffect.Play();

            Destroy(collision.gameObject);
            if (rescueMax == 0)
            {
                rescueMax = 2;
                GM.rescueDieCount += 2;
            }
            else if (rescueMax == 1)
            {
                rescueMax = 2;
                GM.rescueDieCount++;
            }
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

    public void MainLayer()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 5;
    }
    public void SecondLayer()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 4;
    }

    // +Y 이동
    public void moveUp()
    {
        CD = P_UpCollis.GetComponent<CharatorDetector>();

        //좌표값 오류로 초기화 시켜줘야함
        moving = player2.transform.position;

        // 이동 조건 : 계단에서만 이동 가능하고, 불이 있다면 이동하지 않음
        // AP(행동력)이 있을 때만 행동(불끄기, 이동)이 가능함

        // AP 체크
        if (GM.playAP == 0)
        {
            print("AP없음");
        }
        else
        {
            //CharaterDetecter에 불이 닿았는지 판별
            //닿아 있다면 이동하지 않고 불을 끄는 행동을 한다. AP -1
            if (CD.hitFire == true && (moving.x >= -0.1 && moving.x <= 0.1))
            {
                player2.transform.position = moving; //이동하지 않음
                moving = new Vector3(CD.cdr.gameObject.transform.position.x, CD.cdr.gameObject.transform.position.y, CD.cdr.gameObject.transform.position.z);
                WC.waterAction(moving);
                Destroy(CD.cdr.gameObject); // 닿아 있는 불 제거
                GM.playAP--;
                SoundEffect.clip = se[1];
                SoundEffect.Play();
            }
            //닿아 있지 않다면 이동. AP -1
            else if (moving.y <= 3.4f && (moving.x >= -0.1 && moving.x <= 0.1))
            {
                player2.transform.Translate(0, 0.7f, 0);
                GM.playAP--;
                SoundEffect.clip = se[0];
                SoundEffect.Play();
            }
        }
    }

    // -Y 이동
    public void moveDown()
    {
        CD = P_DownCollis.GetComponent<CharatorDetector>();

        //좌표값 오류로 초기화 시켜줘야함
        moving = player2.transform.position;

        // 이동 조건 : 계단에서만 이동 가능하고, 불이 있다면 이동하지 않음
        // AP(행동력)이 있을 때만 행동(불끄기, 이동)이 가능함

        // AP 체크
        if (GM.playAP == 0)
        {
            print("AP없음");
        }
        else
        {
            //CharaterDetecter에 불이 닿았는지 판별
            //닿아 있다면 이동하지 않고 불을 끄는 행동을 한다. AP -1
            if (CD.hitFire == true && (moving.x >= -0.1 && moving.x <= 0.1))
            {
                player2.transform.position = moving;
                moving = new Vector3(CD.cdr.gameObject.transform.position.x, CD.cdr.gameObject.transform.position.y, CD.cdr.gameObject.transform.position.z);
                WC.waterAction(moving);
                Destroy(CD.cdr.gameObject);
                GM.playAP--;
                SoundEffect.clip = se[1];
                SoundEffect.Play();
            }
            //최대 움직일 수 있는 범위 설정, x좌표 값 오류로 범위 체크해야 함
            else if ((moving.x >= -0.1 && moving.x <= 0.1) && moving.y > -1.6f)
            {
                player2.transform.Translate(0, -0.7f, 0);
                GM.playAP--;
                SoundEffect.clip = se[0];
                SoundEffect.Play();

                //구조자를 업은 상태이고 출구로 나오면 구조 성공
                if (player2.transform.position.y == -2.2f && rescueMax == 1)
                {
                    rescueMax = 2;
                    GM.rescueCount++;
                }
                else if (player2.transform.position.y == -2.2f && rescueMax == 0)
                {
                    rescueMax = 2;
                    GM.rescueCount += 2;
                }
            }
        }
    }

    // -X 이동
    public void moveLeft()
    {
        moving = player2.transform.position;
        CD = P_LeftCollis.GetComponent<CharatorDetector>();

        // 이동 조건 : 계단에서만 이동 가능하고, 불이 있다면 이동하지 않음
        // AP(행동력)이 있을 때만 행동(불끄기, 이동)이 가능함

        // AP 체크
        if (GM.playAP == 0)
        {
            print("AP없음");
        }
        else
        {
            //CharaterDetecter에 불이 닿았는지 판별
            //닿아 있다면 이동하지 않고 불을 끄는 행동을 한다. AP -1
            // 최대 움직일 수 있는 범위 설정
            if (moving.x < -2.3f || CD.hitFire == true)
            {
                player2.transform.position = moving;
                //캐릭터와 닿아 있는 불 삭제
                moving = new Vector3(CD.cdr.gameObject.transform.position.x, CD.cdr.gameObject.transform.position.y, CD.cdr.gameObject.transform.position.z);
                WC.waterAction(moving);
                Destroy(CD.cdr.gameObject);
                
                GM.playAP--;
                SoundEffect.clip = se[1];
                SoundEffect.Play();
            }
            else if (moving.x < -2.3f || CD.hitFlame == true)
            {
                player2.transform.position = moving;
                moving = new Vector3(CD.cdr.gameObject.transform.position.x, CD.cdr.gameObject.transform.position.y, CD.cdr.gameObject.transform.position.z);
                WC.waterAction(moving);
                Destroy(CD.inf.gameObject);
                GM.playAP--;
                SoundEffect.clip = se[1];
                SoundEffect.Play();
            }

            //구조자를 업는다
            else if (CD.hitRescue == true && rescueMax != 0)
            {
                player2.transform.position = moving;
                Destroy(CD.res.gameObject);
                GM.playAP--;
                rescueMax--;
                SoundEffect.clip = se[3];
                SoundEffect.Play();
            }
            //구조할 수 있는 한계치가 있다
            else if (CD.hitRescue == true && rescueMax == 0)
            {
                player2.transform.position = moving;
                //최대 두 명만 구조할 수 있습니다
            }

            //불에 닿아 있지 않다면 이동
            else if (moving.y > -2.0f && moving.y < 4.8f && moving.x > -2.1f)
            {
                player2.transform.Translate(-0.7f, 0, 0);
                GM.playAP--;
                SoundEffect.clip = se[0];
                SoundEffect.Play();
            }
        }

    }

    // +X 이동
    public void moveRight()
    {

        moving = player2.transform.position;

        CD = P_RightCollis.GetComponent<CharatorDetector>();

        // 이동 조건 : 계단에서만 이동 가능하고, 불이 있다면 이동하지 않음
        // AP(행동력)이 있을 때만 행동(불끄기, 이동)이 가능함

        // AP 체크
        if (GM.playAP == 0)
        {
            print("AP없음");
        }
        else
        {
            //CharaterDetecter에 불이 닿았는지 판별
            //닿아 있다면 이동하지 않고 불을 끄는 행동을 한다. AP -1
            // 최대 움직일 수 있는 범위 설정
            if (moving.x > 2.0f || CD.hitFire == true)
            {
                player2.transform.position = moving;
                // 닿아 있는 불 삭제
                Destroy(CD.cdr.gameObject);

                GM.playAP--;
                

            }
            else if (moving.x > 2.0f || CD.hitFlame == true)
            {
                player2.transform.position = moving;
                moving = new Vector3(CD.cdr.gameObject.transform.position.x, CD.cdr.gameObject.transform.position.y, CD.cdr.gameObject.transform.position.z);
                WC.waterAction(moving);
                Destroy(CD.inf.gameObject);
                GM.playAP--;
                SoundEffect.clip = se[1];
                SoundEffect.Play();
            }
            //구조자를 업는다
            else if (CD.hitRescue == true && rescueMax != 0)
            {
                player2.transform.position = moving;
                moving = new Vector3(CD.cdr.gameObject.transform.position.x, CD.cdr.gameObject.transform.position.y, CD.cdr.gameObject.transform.position.z);
                WC.waterAction(moving);
                Destroy(CD.res.gameObject);
                GM.playAP--;
                rescueMax--;
                SoundEffect.clip = se[3];
                SoundEffect.Play();
            }
            //구조할 수 있는 한계치가 있다
            else if (CD.hitRescue == true && rescueMax == 0)
            {
                player2.transform.position = moving;
                //최대 두 명만 구조할 수 있습니다
                print("eekap");
            }

            // 닿아 있는 불이 없다면 이동
            else if (moving.y > -2.0f && moving.y < 4.8f && moving.x <= 2.1f)
            {
                player2.transform.Translate(0.7f, 0, 0);
                GM.playAP--;
                SoundEffect.clip = se[0];
                SoundEffect.Play();
            }
        }
    }
}