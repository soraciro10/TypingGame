using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVLoader : MonoBehaviour
{
    [SerializeField] TextAsset csv;
    List<string[]> values = new List<string[]>();   //string[][] values;
    public int row,colum;   //int i = 0;
    void Start()
    {
        StringReader reader = new StringReader(csv.text);
        reader.ReadLine();
        while (reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            values.Add(line.Split(','));   //values[i++] = line.Split(',');
        }

        Debug.Log(values[row][colum]);
        //Debug.Log(values[colum]);
    }

    void Update()
    {
        
    }
}
