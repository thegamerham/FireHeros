using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class dialog : MonoBehaviour
{
    //변경할 변수
    public float delay;
    public float Skip_delay;
    public int cnt;
    
    GameObject chatText;
    GameObject nameText;

    //타이핑효과 변수
    public string[] fulltext;
    public string[] nametext;
    public string[] effecttext;
    public string[] BGMtext;
    public string[] SoundEffecttext;
    public int dialog_cnt;
    public int name_cnt;
    string currentText;
    string currentName;
    string currentEffect;
    string currentBGM; //
    string currentSoundEffect; //
    public string lastName;

    //타이핑확인 변수
    public bool text_exit;
    public bool text_full;
    public bool text_cut;
    public bool name_exit;

    public string[] scg;
    public GameObject scgImg1;
    public GameObject scgImg2;
    public GameObject scgImg3;
    public GameObject scgImg4;
    public GameObject scgImg5;
    public GameObject scgImg6;
    public GameObject scgImg7;
    public GameObject scgImg8;
    public GameObject scgImg9;
    public GameObject scgImg10;
    public GameObject scgImg11;
    public GameObject scgImg12;
    public GameObject scgImg1_1;
    public GameObject scgImg2_1;
    public GameObject scgImg3_1;
    public GameObject scgImg4_1;
    public GameObject scgImg5_1;
    public GameObject scgImg6_1;
    public GameObject scgImg7_1;
    public GameObject scgImg8_1;
    public GameObject scgImg9_1;
    public GameObject scgImg10_1;
    public GameObject scgImg11_1;
    public GameObject scgImg12_1;
    public GameObject chatpanel;
    public GameObject dialogmanager;
    public GameObject shake;
    private int BGMCount = 0; //
    private int SoundEffectCount = 0; //

    // 사운드
    public AudioSource SoundEffect;
    [SerializeField] public AudioClip[] clip;
    public AudioSource BGM;
    [SerializeField] public AudioClip[] bgm;

    //시작과 동시에 타이핑시작
    void Start()
    {
        this.chatText = GameObject.Find("textbox");
        this.nameText = GameObject.Find("name");
        this.dialogmanager = GameObject.Find("Dialog Manager");
        this.shake = GameObject.Find("Main Camera");
        Get_Typing(dialog_cnt, fulltext);

        SoundEffect = GetComponent<AudioSource>(); // 시작하자마자 오디오 찾기.
        BGM = GetComponent<AudioSource>(); // 시작하자마자 오디오 찾기.
    }


    //모든 텍스트 호출완료시 탈출
    void Update()
    {
        if (text_exit == true)
        {
            chatText.SetActive(false);
            chatpanel.SetActive(false);
            scgDown();
            effectDown();
            BGMDown(); //
            SoundEffectDown(); //
        }
        if(name_exit == true)
        {
            nameText.SetActive(false);
        }
            
    }

    //다음버튼함수
    public void End_Typing()
    {
        //다음 텍스트 호출
        if (text_full == true)
        {
            lastName = currentName;
            cnt++;
            text_full = false;
            text_cut = false;
            StartCoroutine(ShowText(fulltext, nametext, effecttext, BGMtext, SoundEffecttext));
//            StartCoroutine(ShownameText(nametext));
        }
        //텍스트 타이핑 생략
        else
        {
            text_cut = true;
        }
    }

    //텍스트 시작호출
    public void Get_Typing(int _dialog_cnt, string[] _fullText)
    {
        //재사용을 위한 변수초기화
        text_exit = false;
        text_full = false;
        text_cut = false;
        name_exit = false;

        cnt = 0;

        //변수 불러오기
        dialog_cnt = _dialog_cnt;
        fulltext = new string[dialog_cnt];
        fulltext = _fullText;

        //타이핑 코루틴시작
        StartCoroutine(ShowText(fulltext, nametext, effecttext, BGMtext, SoundEffecttext));
       // StartCoroutine(ShownameText(nametext));
    }

    IEnumerator ShowText(string[] _fullText, string[] _nameText, string[] _effectText, string[] _BGMText, string[] _SoundEffectText)
    {
        //모든텍스트 종료
        if (cnt >= dialog_cnt)
        {
            text_exit = true;
            name_exit = true;
            StopCoroutine("showText");
            //StopCoroutine("shownameText");
        }
        else
        {
            //기존문구clear
            currentText = "";
            currentName = "";
            //타이핑 시작
            //lastName = _nameText[cnt];

            for (int i = 0; i < _fullText[cnt].Length; i++)
            {
                //타이핑중도탈출
                Debug.Log(nameText);
                nameText.GetComponent<Text>().text = _nameText[cnt];
                
                currentName = _nameText[cnt];
                currentEffect = _effectText[cnt];
                currentBGM = _BGMText[cnt]; //
                currentSoundEffect = _SoundEffectText[cnt]; //
                Debug.Log(lastName);
                Debug.Log(currentName);
                Debug.Log(currentEffect);
                Debug.Log(currentBGM); //
                Debug.Log(currentSoundEffect); //
                currentName.ToString();
                Debug.Log(_fullText[cnt]);
                if (text_cut == true)
                {
                    break;
                }
                //단어하나씩출력
                currentText = _fullText[cnt].Substring(0, i + 1);
                chatText.GetComponent<Text>().text = currentText;

                scgUp();
                effectUp();
                BGMUp(); //
                SoundEffectUp(); //
                if (currentName != lastName)
                scgUp2();
                yield return new WaitForSeconds(delay);
            }
            //탈출시 모든 문자출력
            Debug.Log("Typing 종료");
            chatText.GetComponent<Text>().text = _fullText[cnt];
            
            yield return new WaitForSeconds(Skip_delay);

            //스킵_지연후 종료
            Debug.Log("Enter 대기");
            text_full = true;
            
        }
    }

    public void scgUp()
    {

        
        if (currentName.Equals("광수"))
        {

            Debug.Log("1");
            scgImg1.SetActive(true);
            scgImg2.SetActive(false);
            scgImg3.SetActive(false);
            scgImg4.SetActive(false);
            scgImg5.SetActive(false);
            scgImg6.SetActive(false);
            scgImg7.SetActive(false);
            scgImg8.SetActive(false);
            scgImg9.SetActive(false);
            scgImg10.SetActive(false);
            scgImg11.SetActive(false);
            scgImg12.SetActive(false);

        }
        else if (currentName.Equals("석신"))
        {
            Debug.Log("2");
            scgImg1.SetActive(false);
            scgImg2.SetActive(true);
            scgImg3.SetActive(false);
            scgImg4.SetActive(false);
            scgImg5.SetActive(false);
            scgImg6.SetActive(false);
            scgImg7.SetActive(false);
            scgImg8.SetActive(false);
            scgImg9.SetActive(false);
            scgImg10.SetActive(false);
            scgImg11.SetActive(false);
            scgImg12.SetActive(false);


        }
        else if (currentName.Equals("준수"))
        {
            Debug.Log("3");
            scgImg1.SetActive(false);
            scgImg2.SetActive(false);
            scgImg3.SetActive(true);
            scgImg4.SetActive(false);
            scgImg5.SetActive(false);
            scgImg6.SetActive(false);
            scgImg7.SetActive(false);
            scgImg8.SetActive(false);
            scgImg9.SetActive(false);
            scgImg10.SetActive(false);
            scgImg11.SetActive(false);
            scgImg12.SetActive(false);

        }
        else if (currentName.Equals("태경"))
        {
            Debug.Log("4");
            scgImg1.SetActive(false);
            scgImg2.SetActive(false);
            scgImg3.SetActive(false);
            scgImg4.SetActive(true);
            scgImg5.SetActive(false);
            scgImg6.SetActive(false);
            scgImg7.SetActive(false);
            scgImg8.SetActive(false);
            scgImg9.SetActive(false);
            scgImg10.SetActive(false);
            scgImg11.SetActive(false);
            scgImg12.SetActive(false);

        }
        else if (currentName.Equals("진욱"))
        {
            Debug.Log("5");
            scgImg1.SetActive(false);
            scgImg2.SetActive(false);
            scgImg3.SetActive(false);
            scgImg4.SetActive(false);
            scgImg5.SetActive(true);
            scgImg6.SetActive(false);
            scgImg7.SetActive(false);
            scgImg8.SetActive(false);
            scgImg9.SetActive(false);
            scgImg10.SetActive(false);
            scgImg11.SetActive(false);
            scgImg12.SetActive(false);

        }

        else if (currentName.Equals("광수 "))
        {

            Debug.Log("6");
            scgImg1.SetActive(false);
            scgImg2.SetActive(false);
            scgImg3.SetActive(false);
            scgImg4.SetActive(false);
            scgImg5.SetActive(false);
            scgImg6.SetActive(true);
            scgImg7.SetActive(false);
            scgImg8.SetActive(false);
            scgImg9.SetActive(false);
            scgImg10.SetActive(false);
            scgImg11.SetActive(false);
            scgImg12.SetActive(false);

        }
        else if (currentName.Equals("석신 "))
        {
            Debug.Log("7");
            scgImg1.SetActive(false);
            scgImg2.SetActive(false);
            scgImg3.SetActive(false);
            scgImg4.SetActive(false);
            scgImg5.SetActive(false);
            scgImg6.SetActive(false);
            scgImg7.SetActive(true);
            scgImg8.SetActive(false);
            scgImg9.SetActive(false);
            scgImg10.SetActive(false);
            scgImg11.SetActive(false);
            scgImg12.SetActive(false);

        }
        else if (currentName.Equals("준수 "))
        {
            Debug.Log("8");
            scgImg1.SetActive(false);
            scgImg2.SetActive(false);
            scgImg3.SetActive(false);
            scgImg4.SetActive(false);
            scgImg5.SetActive(false);
            scgImg6.SetActive(false);
            scgImg7.SetActive(false);
            scgImg8.SetActive(true);
            scgImg9.SetActive(false);
            scgImg10.SetActive(false);
            scgImg11.SetActive(false);
            scgImg12.SetActive(false);

        }
        else if (currentName.Equals("태경 "))
        {
            Debug.Log("9");
            scgImg1.SetActive(false);
            scgImg2.SetActive(false);
            scgImg3.SetActive(false);
            scgImg4.SetActive(false);
            scgImg5.SetActive(false);
            scgImg6.SetActive(false);
            scgImg7.SetActive(false);
            scgImg8.SetActive(false);
            scgImg9.SetActive(true);
            scgImg10.SetActive(false);
            scgImg11.SetActive(false);
            scgImg12.SetActive(false);

        }
        else if (currentName.Equals("진욱 "))
        {
            Debug.Log("10");
            scgImg1.SetActive(false);
            scgImg2.SetActive(false);
            scgImg3.SetActive(false);
            scgImg4.SetActive(false);
            scgImg5.SetActive(false);
            scgImg6.SetActive(false);
            scgImg7.SetActive(false);
            scgImg8.SetActive(false);
            scgImg9.SetActive(false);
            scgImg10.SetActive(true);
            scgImg11.SetActive(false);
            scgImg12.SetActive(false);

        }
        else if (currentName.Equals("방화범"))
        {
            Debug.Log("9");
            scgImg1.SetActive(false);
            scgImg2.SetActive(false);
            scgImg3.SetActive(false);
            scgImg4.SetActive(false);
            scgImg5.SetActive(false);
            scgImg6.SetActive(false);
            scgImg7.SetActive(false);
            scgImg8.SetActive(false);
            scgImg9.SetActive(false);
            scgImg10.SetActive(false);
            scgImg11.SetActive(true);
            scgImg12.SetActive(false);

        }
        else if (currentName.Equals("방화범 "))
        {
            Debug.Log("9");
            scgImg1.SetActive(false);
            scgImg2.SetActive(false);
            scgImg3.SetActive(false);
            scgImg4.SetActive(false);
            scgImg5.SetActive(false);
            scgImg6.SetActive(false);
            scgImg7.SetActive(false);
            scgImg8.SetActive(false);
            scgImg9.SetActive(false);
            scgImg10.SetActive(false);
            scgImg11.SetActive(false);
            scgImg12.SetActive(true);

        }
        else if (currentName.Equals("???"))
        {
            Debug.Log("9");
            scgImg1.SetActive(false);
            scgImg2.SetActive(false);
            scgImg3.SetActive(false);
            scgImg4.SetActive(false);
            scgImg5.SetActive(false);
            scgImg6.SetActive(false);
            scgImg7.SetActive(false);
            scgImg8.SetActive(false);
            scgImg9.SetActive(false);
            scgImg10.SetActive(false);
            scgImg11.SetActive(true);
            scgImg12.SetActive(false);

        }
        else if (currentName.Equals("??? "))
        {
            Debug.Log("9");
            scgImg1.SetActive(false);
            scgImg2.SetActive(false);
            scgImg3.SetActive(false);
            scgImg4.SetActive(false);
            scgImg5.SetActive(false);
            scgImg6.SetActive(false);
            scgImg7.SetActive(false);
            scgImg8.SetActive(false);
            scgImg9.SetActive(false);
            scgImg10.SetActive(false);
            scgImg11.SetActive(false);
            scgImg12.SetActive(true);

        }
        else if (currentName.Equals(" "))
        {
            Debug.Log("9");
            scgImg1.SetActive(false);
            scgImg2.SetActive(false);
            scgImg3.SetActive(false);
            scgImg4.SetActive(false);
            scgImg5.SetActive(false);
            scgImg6.SetActive(false);
            scgImg7.SetActive(false);
            scgImg8.SetActive(false);
            scgImg9.SetActive(false);
            scgImg10.SetActive(false);
            scgImg11.SetActive(false);
            scgImg12.SetActive(false);

        }
        else if (currentName.Equals("정석 "))
        {
            Debug.Log("9");
            scgImg1.SetActive(false);
            scgImg2.SetActive(false);
            scgImg3.SetActive(false);
            scgImg4.SetActive(false);
            scgImg5.SetActive(false);
            scgImg6.SetActive(false);
            scgImg7.SetActive(false);
            scgImg8.SetActive(false);
            scgImg9.SetActive(false);
            scgImg10.SetActive(false);
            scgImg11.SetActive(false);
            scgImg12.SetActive(false);

        }
        else if (currentName.Equals("??"))
        {
            Debug.Log("9");
            scgImg1.SetActive(false);
            scgImg2.SetActive(false);
            scgImg3.SetActive(false);
            scgImg4.SetActive(false);
            scgImg5.SetActive(false);
            scgImg6.SetActive(false);
            scgImg7.SetActive(false);
            scgImg8.SetActive(false);
            scgImg9.SetActive(false);
            scgImg10.SetActive(false);
            scgImg11.SetActive(false);
            scgImg12.SetActive(false);

        }
        /*
        scgImg1.SetActive(currentName.Equals("광수") ? true : false);
        scgImg2.SetActive(currentName.Equals("석신") ? true : false);
        scgImg3.SetActive(currentName.Equals("준수") ? true : false);
        scgImg4.SetActive(currentName.Equals("태경") ? true : false);
        scgImg5.SetActive(currentName.Equals("진욱") ? true : false);
        scgImg6.SetActive(currentName.Equals("광수 ") ? true : false);
        scgImg7.SetActive(currentName.Equals("석신 ") ? true : false);
        scgImg8.SetActive(currentName.Equals("준수 ") ? true : false);
        scgImg9.SetActive(currentName.Equals("태경 ") ? true : false);
        scgImg10.SetActive(currentName.Equals("진욱 ") ? true : false);
        */
    }
    
       public void scgUp2()
        {
            if (lastName.Equals("광수"))
            {

                Debug.Log("1");
                scgImg1_1.SetActive(true);
                scgImg2_1.SetActive(false);
                scgImg3_1.SetActive(false);
                scgImg4_1.SetActive(false);
                scgImg5_1.SetActive(false);
                scgImg6_1.SetActive(false);
                scgImg7_1.SetActive(false);
                scgImg8_1.SetActive(false);
                scgImg9_1.SetActive(false);
                scgImg10_1.SetActive(false);
                scgImg11_1.SetActive(false);
                scgImg12_1.SetActive(false);

        }
            else if (lastName.Equals("석신"))
            {
                Debug.Log("2");
                scgImg1_1.SetActive(false);
                scgImg2_1.SetActive(true);
                scgImg3_1.SetActive(false);
                scgImg4_1.SetActive(false);
                scgImg5_1.SetActive(false);
                scgImg6_1.SetActive(false);
                scgImg7_1.SetActive(false);
                scgImg8_1.SetActive(false);
                scgImg9_1.SetActive(false);
                scgImg10_1.SetActive(false);
                scgImg11_1.SetActive(false);
                scgImg12_1.SetActive(false);


        }
            else if (lastName.Equals("준수"))
            {
                Debug.Log("3");
                scgImg1_1.SetActive(false);
                scgImg2_1.SetActive(false);
                scgImg3_1.SetActive(true);
                scgImg4_1.SetActive(false);
                scgImg5_1.SetActive(false);
                scgImg6_1.SetActive(false);
                scgImg7_1.SetActive(false);
                scgImg8_1.SetActive(false);
                scgImg9_1.SetActive(false);
                scgImg10_1.SetActive(false);
                scgImg11_1.SetActive(false);
                scgImg12_1.SetActive(false);

        }
            else if (lastName.Equals("태경"))
            {
                Debug.Log("4");
                scgImg1_1.SetActive(false);
                scgImg2_1.SetActive(false);
                scgImg3_1.SetActive(false);
                scgImg4_1.SetActive(true);
                scgImg5_1.SetActive(false);
                scgImg6_1.SetActive(false);
                scgImg7_1.SetActive(false);
                scgImg8_1.SetActive(false);
                scgImg9_1.SetActive(false);
                scgImg10_1.SetActive(false);
                scgImg11_1.SetActive(false);
                scgImg12_1.SetActive(false);

        }
            else if (lastName.Equals("진욱"))
            {
                Debug.Log("5");
                scgImg1_1.SetActive(false);
                scgImg2_1.SetActive(false);
                scgImg3_1.SetActive(false);
                scgImg4_1.SetActive(false);
                scgImg5_1.SetActive(true);
                scgImg6_1.SetActive(false);
                scgImg7_1.SetActive(false);
                scgImg8_1.SetActive(false);
                scgImg9_1.SetActive(false);
                scgImg10_1.SetActive(false);
                scgImg11_1.SetActive(false);
                scgImg12_1.SetActive(false);

        }

            else if (lastName.Equals("광수 "))
            {

                Debug.Log("6");
                scgImg1_1.SetActive(false);
                scgImg2_1.SetActive(false);
                scgImg3_1.SetActive(false);
                scgImg4_1.SetActive(false);
                scgImg5_1.SetActive(false);
                scgImg6_1.SetActive(true);
                scgImg7_1.SetActive(false);
                scgImg8_1.SetActive(false);
                scgImg9_1.SetActive(false);
                scgImg10_1.SetActive(false);
                scgImg11_1.SetActive(false);
                scgImg12_1.SetActive(false);

        }
            else if (lastName.Equals("석신 "))
            {
                Debug.Log("7");
                scgImg1_1.SetActive(false);
                scgImg2_1.SetActive(false);
                scgImg3_1.SetActive(false);
                scgImg4_1.SetActive(false);
                scgImg5_1.SetActive(false);
                scgImg6_1.SetActive(false);
                scgImg7_1.SetActive(true);
                scgImg8_1.SetActive(false);
                scgImg9_1.SetActive(false);
                scgImg10_1.SetActive(false);
                scgImg11_1.SetActive(false);
                scgImg12_1.SetActive(false);

        }
            else if (lastName.Equals("준수 "))
            {
                Debug.Log("8");
                scgImg1_1.SetActive(false);
                scgImg2_1.SetActive(false);
                scgImg3_1.SetActive(false);
                scgImg4_1.SetActive(false);
                scgImg5_1.SetActive(false);
                scgImg6_1.SetActive(false);
                scgImg7_1.SetActive(false);
                scgImg8_1.SetActive(true);
                scgImg9_1.SetActive(false);
                scgImg10_1.SetActive(false);
                scgImg11_1.SetActive(false);
                scgImg12_1.SetActive(false);

            }
            else if (lastName.Equals("태경 "))
            {
                Debug.Log("9");
                scgImg1_1.SetActive(false);
                scgImg2_1.SetActive(false);
                scgImg3_1.SetActive(false);
                scgImg4_1.SetActive(false);
                scgImg5_1.SetActive(false);
                scgImg6_1.SetActive(false);
                scgImg7_1.SetActive(false);
                scgImg8_1.SetActive(false);
                scgImg9_1.SetActive(true);
                scgImg10_1.SetActive(false);
                scgImg11_1.SetActive(false);
                scgImg12_1.SetActive(false);

        }
            else if (lastName.Equals("진욱 "))
            {
                Debug.Log("10");
                scgImg1_1.SetActive(false);
                scgImg2_1.SetActive(false);
                scgImg3_1.SetActive(false);
                scgImg4_1.SetActive(false);
                scgImg5_1.SetActive(false);
                scgImg6_1.SetActive(false);
                scgImg7_1.SetActive(false);
                scgImg8_1.SetActive(false);
                scgImg9_1.SetActive(false);
                scgImg10_1.SetActive(true);
                scgImg11_1.SetActive(false);
                scgImg12_1.SetActive(false);

            }
            else if (lastName.Equals("???"))
            {
                Debug.Log("라넴???");
                scgImg1_1.SetActive(false);
                scgImg2_1.SetActive(false);
                scgImg3_1.SetActive(false);
                scgImg4_1.SetActive(false);
                scgImg5_1.SetActive(false);
                scgImg6_1.SetActive(false);
                scgImg7_1.SetActive(false);
                scgImg8_1.SetActive(false);
                scgImg9_1.SetActive(false);
                scgImg10_1.SetActive(false);
                scgImg11_1.SetActive(true);
                scgImg12_1.SetActive(false);

            }
            else if (lastName.Equals("??? "))
            {
                Debug.Log("라넴???");
                scgImg1_1.SetActive(false);
                scgImg2_1.SetActive(false);
                scgImg3_1.SetActive(false);
                scgImg4_1.SetActive(false);
                scgImg5_1.SetActive(false);
                scgImg6_1.SetActive(false);
                scgImg7_1.SetActive(false);
                scgImg8_1.SetActive(false);
                scgImg9_1.SetActive(false);
                scgImg10_1.SetActive(false);
                scgImg11_1.SetActive(false);
                scgImg12_1.SetActive(true);

             }
        else if (lastName.Equals("??"))
        {
            Debug.Log("라넴???");
            scgImg1_1.SetActive(false);
            scgImg2_1.SetActive(false);
            scgImg3_1.SetActive(false);
            scgImg4_1.SetActive(false);
            scgImg5_1.SetActive(false);
            scgImg6_1.SetActive(false);
            scgImg7_1.SetActive(false);
            scgImg8_1.SetActive(false);
            scgImg9_1.SetActive(false);
            scgImg10_1.SetActive(false);
            scgImg11_1.SetActive(false);
            scgImg12_1.SetActive(false);

        }
        else if (lastName.Equals("방화범"))
            {
                Debug.Log("10");
                scgImg1_1.SetActive(false);
                scgImg2_1.SetActive(false);
                scgImg3_1.SetActive(false);
                scgImg4_1.SetActive(false);
                scgImg5_1.SetActive(false);
                scgImg6_1.SetActive(false);
                scgImg7_1.SetActive(false);
                scgImg8_1.SetActive(false);
                scgImg9_1.SetActive(false);
                scgImg10_1.SetActive(false);
                scgImg11_1.SetActive(true);
                scgImg12_1.SetActive(false);

            }
            else if (lastName.Equals("방화범 "))
            {
                Debug.Log("10");
                scgImg1_1.SetActive(false);
                scgImg2_1.SetActive(false);
                scgImg3_1.SetActive(false);
                scgImg4_1.SetActive(false);
                scgImg5_1.SetActive(false);
                scgImg6_1.SetActive(false);
                scgImg7_1.SetActive(false);
                scgImg8_1.SetActive(false);
                scgImg9_1.SetActive(false);
                scgImg10_1.SetActive(false);
                scgImg11_1.SetActive(false);
                scgImg12_1.SetActive(true);

            }
            else if (lastName.Equals(" "))
            {
                Debug.Log("10");
                scgImg1_1.SetActive(false);
                scgImg2_1.SetActive(false);
                scgImg3_1.SetActive(false);
                scgImg4_1.SetActive(false);
                scgImg5_1.SetActive(false);
                scgImg6_1.SetActive(false);
                scgImg7_1.SetActive(false);
                scgImg8_1.SetActive(false);
                scgImg9_1.SetActive(false);
                scgImg10_1.SetActive(false);
                scgImg11_1.SetActive(false);
                scgImg12_1.SetActive(false);

            }
        else if (lastName.Equals("정석 "))
        {
            
            scgImg1_1.SetActive(false);
            scgImg2_1.SetActive(false);
            scgImg3_1.SetActive(false);
            scgImg4_1.SetActive(false);
            scgImg5_1.SetActive(false);
            scgImg6_1.SetActive(false);
            scgImg7_1.SetActive(false);
            scgImg8_1.SetActive(false);
            scgImg9_1.SetActive(false);
            scgImg10_1.SetActive(false);
            scgImg11_1.SetActive(false);
            scgImg12_1.SetActive(false);

        }


        /*
    scgImg1.SetActive(lastName.Equals("광수") ? true : false);
    scgImg2.SetActive(lastName.Equals("석신") ? true : false);
    scgImg3.SetActive(lastName.Equals("준수") ? true : false);
    scgImg4.SetActive(lastName.Equals("태경") ? true : false);
    scgImg5.SetActive(lastName.Equals("진욱") ? true : false);
    scgImg6.SetActive(lastName.Equals("광수 ") ? true : false);
    scgImg7.SetActive(lastName.Equals("석신 ") ? true : false);
    scgImg8.SetActive(lastName.Equals("준수 ") ? true : false);
    scgImg9.SetActive(lastName.Equals("태경 ") ? true : false);
    scgImg10.SetActive(lastName.Equals("진욱 ") ? true : false);
    */
    }
    
    public void scgDown()
    {
        scgImg1.SetActive(false);
        scgImg2.SetActive(false);
        scgImg3.SetActive(false);
        scgImg4.SetActive(false);
        scgImg5.SetActive(false);
        scgImg6.SetActive(false);
        scgImg7.SetActive(false);
        scgImg8.SetActive(false);
        scgImg9.SetActive(false);
        scgImg10.SetActive(false);
        scgImg11.SetActive(false);
        scgImg12.SetActive(false);
        scgImg1_1.SetActive(false);
        scgImg2_1.SetActive(false);
        scgImg3_1.SetActive(false);
        scgImg4_1.SetActive(false);
        scgImg5_1.SetActive(false);
        scgImg6_1.SetActive(false);
        scgImg7_1.SetActive(false);
        scgImg8_1.SetActive(false);
        scgImg9_1.SetActive(false);
        scgImg10_1.SetActive(false);
        scgImg11_1.SetActive(false);
        scgImg12_1.SetActive(false);
    }

    public void effectUp()
    {
        if (currentEffect.Equals("지진"))
        {

            Debug.Log("1");
            this.shake.GetComponent<Shake>().CameraShaking = true;
            Debug.Log(this.shake.GetComponent<Shake>().CameraShaking);
        }
        else if (currentEffect.Equals("페이드아웃"))
        {

            Debug.Log("페이드아웃");
            this.shake.GetComponent<FadeScript>().Fade();

        }
        else if (currentEffect.Equals("페이드인"))
        {

            Debug.Log("페이드인");
            this.shake.GetComponent<FadeScript>().Fade2();

        }
        else if (currentEffect.Equals("지진페이드아웃")) { 
            this.shake.GetComponent<FadeScript>().Fade();
            this.shake.GetComponent<Shake>().CameraShaking = true;

        }
        if (currentEffect.Equals("쓰러짐"))
        {

            Debug.Log("1");
            this.shake.GetComponent<Shake>().CameraShaking = true;
            
        }
    }



    public void effectDown()
    {

    }

    // BGM 재생
    public void BGMUp()
    {
        if (currentBGM.Equals("적당한 템포의 긴장감"))
        {
            if (BGMCount == 0)
            {
                BGM.clip = bgm[0];
                BGM.Play();
                BGMCount = 1;
            }
        }

        if (currentBGM.Equals("평온"))
        {
            if (BGMCount == 0)
            {
                BGM.clip = bgm[1];
                BGM.Play();
                BGMCount = 1;
            }
        }

        if (currentBGM.Equals("실수"))
        {
            if (BGMCount == 0)
            {
                BGM.clip = bgm[2];
                BGM.Play();
                BGMCount = 1;
            }
        }

        if (currentBGM.Equals("불안"))
        {
            if (BGMCount == 0)
            {
                BGM.clip = bgm[3];
                BGM.Play();
                BGMCount = 1;
            }
        }

        if (currentBGM.Equals("의혹, 의문"))
        {
            if (BGMCount == 0)
            {
                BGM.clip = bgm[4];
                BGM.Play();
                BGMCount = 1;
            }
        }

        if (currentBGM.Equals("당황, 놀람, 화남"))
        {
            if (BGMCount == 0)
            {
                BGM.clip = bgm[5];
                BGM.Play();
                BGMCount = 1;
            }
        }

        if (currentBGM.Equals("불신, 슬픔, 아픔"))
        {
            if (BGMCount == 0)
            {
                BGM.clip = bgm[6];
                BGM.Play();
                BGMCount = 1;
            }
        }

        if (currentBGM.Equals("환청, 혼란"))
        {
            if (BGMCount == 0)
            {
                BGM.clip = bgm[7];
                BGM.Play();
                BGMCount = 1;
            }
        }

        if (currentBGM.Equals("휴식, 걱정, 잔잔함"))
        {
            if (BGMCount == 0)
            {
                BGM.clip = bgm[8];
                BGM.Play();
                BGMCount = 1;
            }
        }

        if (currentBGM.Equals("약간의 감정 해소, 일보 전진"))
        {
            if (BGMCount == 0)
            {
                BGM.clip = bgm[9];
                BGM.Play();
                BGMCount = 1;
            }
        }

        if (currentBGM.Equals("긴박"))
        {
            if (BGMCount == 0)
            {
                BGM.clip = bgm[10];
                BGM.Play();
                BGMCount = 1;
            }
        }

        if (currentBGM.Equals("의심"))
        {
            if (BGMCount == 0)
            {
                BGM.clip = bgm[11];
                BGM.Play();
                BGMCount = 1;
            }
        }

        if (currentBGM.Equals("의혹, 밝혀지는 놈의 노림수"))
        {
            if (BGMCount == 0)
            {
                BGM.clip = bgm[12];
                BGM.Play();
                BGMCount = 1;
            }
        }

        if (currentBGM.Equals("대치"))
        {
            if (BGMCount == 0)
            {
                BGM.clip = bgm[13];
                BGM.Play();
                BGMCount = 1;
            }
        }

        if (currentBGM.Equals("엔딩 크레딧"))
        {
            if (BGMCount == 0)
            {
                BGM.clip = bgm[14];
                BGM.Play();
                BGMCount = 1;
            }
        }

        if (currentBGM.Equals("마무리"))
        {
            if (BGMCount == 0)
            {
                BGM.clip = bgm[15];
                BGM.Play();
                BGMCount = 1;
            }
        }

        if (currentBGM.Equals("중지"))
        {
            if (BGMCount == 1)
            {
                BGM.Stop();
                BGMCount = 0;
            }
        }

    }
    public void BGMDown()
    {

    }
    // 효과음 재생
    public void SoundEffectUp()
    {
        if (currentSoundEffect.Equals("스마트폰 벨소리"))
        {
            if (SoundEffectCount == 0)
            {
                SoundEffect.PlayOneShot(clip[0]);
                SoundEffect.Play();
                SoundEffectCount = 1;
            }
        }

        if (currentSoundEffect.Equals("폭발음"))
        {
            if (SoundEffectCount == 0 || SoundEffectCount == 1)
            {
                SoundEffect.PlayOneShot(clip[1]);
                SoundEffect.Play();
                SoundEffectCount = 1;
            }
        }

        if (currentSoundEffect.Equals("아이 울음소리"))
        {
            if (SoundEffectCount == 0)
            {
                SoundEffect.PlayOneShot(clip[2]);
                SoundEffect.Play();
                SoundEffectCount = 1;
            }
        }

        if (currentSoundEffect.Equals("달리는 소리"))
        {
            if (SoundEffectCount == 0)
            {
                SoundEffect.PlayOneShot(clip[3]);
                SoundEffect.Play();
                SoundEffectCount = 1;
            }
        }
    }
    public void SoundEffectDown()
    {

    }


}
