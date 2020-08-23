using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class NPC_Chat : MonoBehaviour
{

	public string textPath;

	static void ReadString(string path)
	{
		string words = path;

		StreamReader reader = new StreamReader(words);
		Debug.Log(reader.ReadToEnd());
		reader.Close();
	}

    // Start is called before the first frame update
    void Start()
    {
		ReadString(textPath);
    }
}
