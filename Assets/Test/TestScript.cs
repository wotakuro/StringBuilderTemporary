using UnityEngine;
using System.Collections;
using StringBufferTemporary;

public class TestScript : MonoBehaviour {

	bool sbtFlag = true;
	TextMesh txt;
	// Use this for initialization
	void Start () {
		txt = this.GetComponent<TextMesh>();
	}

	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			sbtFlag = !sbtFlag;
		}
		if (sbtFlag)
		{
			UpdateSbtOn();
		}
		else
		{
			UpdateSbtOff();
		}
		int gcUsed = (int)Profiler.GetMonoUsedSize();
		this.txt.text = (Sbt.i + "sbtFlag " + sbtFlag + "\n" + "detltaTime:" + Time.deltaTime).ToUpper();
	}
	
	// Update is called once per frame
	void UpdateSbtOn()
	{
		// Sbt str = Sbt.i + "test";
		var str = Sbt.i + "TestD";
		for (int i = 0; i < 20000; ++i)
		{
			str += "a";
		}
         str.ToUpper().Trim();
	}
	void UpdateSbtOff()
	{
		// string str = "test";
        var str = "TestD";
		for (int i = 0; i < 20000; ++i)
		{
			str += "a";
		}
        str.ToLower() ;
    }
}
