using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class Typing : MonoBehaviour
{

    [SerializeField] Text qtext;
    [SerializeField] Text atext;
    [SerializeField] Image CountryImage = null;
    [SerializeField] Text GDP;


    /*private string[] _question = { "アメリカ", "中国", "日本" };
    private string[] _answer = { "amerika", "tyugoku", "nihonn" };*/

    //[SerializeField] TextAsset _question;
    //[SerializeField] TextAsset _answer;

    [SerializeField] TextAsset csv;

    //private List<string> _qList = new List<string>();
    //private List<string> _aList = new List<string>();

    List<string[]> values = new List<string[]>();

    int i=0;

    //static float timer = 0;


    private string _qstring;
    private string _astring;
    private string _istring;
    private string _gstring;

    int _qnum;

    int _anum;

    public static int count;

    public float time;
    public Text timeText;
    int typeCount;
    public static float efficiency;
    int timelong;

    void Start()
    {
        SetList();
        Output();
        count = 0;
        typeCount = 0;
        timelong = (int)time;
    }

    // Update is called once per frame //空白
    void Update()
    {
        time -= Time.deltaTime;
        timeText.text = time.ToString("f1");

        if (time <= 0f)
        {
            efficiency = (float)typeCount / timelong;
            SceneManager.LoadScene("Ranking");
        }   

        if (Input.GetKeyDown(_astring[_anum].ToString()))
        {
            Correct();

            
            if(_anum >= _astring.Length)
            {
                count++;
                Output();
            }
        }
        else if (Input.anyKeyDown)
        {
            Miss();
        }
       // timer += Time.deltaTime;

    }

    void SetList()
    {

        StringReader reader = new StringReader(csv.text);
        reader.ReadLine();
        while (reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            values.Add(line.Split(','));  //values = line.Split(',');
            i++;
        }

        /*string[] _qArray = _question.text.Split('\n');
        _qList.AddRange(_qArray);

        string[] _aArray = _answer.text.Split(new char[] { '\n', '\r' }, System.StringSplitOptions.RemoveEmptyEntries);
        _aList.AddRange(_aArray);*/
    }
    void Output()
    {
        //string[][] values1 = values.ToArray();
        _anum = 0;
        _qnum = Random.Range(0, i); //values1.GetLength(1) //_qList.Count  /_question.length
        Debug.Log(i);

        _qstring = values[_qnum][0];
        _astring = values[_qnum][1];
        _istring = values[_qnum][2];
        _gstring = values[_qnum][3];


        qtext.text = _qstring;
        atext.text = _astring;
        CountryImage.sprite = Resources.Load<Sprite>(_istring);
        GDP.text = "GDP"+_gstring;
    }

    void Correct()
    {
        _anum++;
        atext.text = "<color=#6A6A6A>" + _astring.Substring(0, _anum) +"</color>"+_astring.Substring(_anum);
        Debug.Log("正解");
        typeCount++;
    }

    void Miss()
    {
        atext.text = "<color=#6A6A6A>" + _astring.Substring(0, _anum) + "</color>"
            + "<color=#FF0000>" + _astring.Substring(_anum, 1) + "</color>" + _astring.Substring(_anum + 1);
        Debug.Log("不正解");
    }
}

