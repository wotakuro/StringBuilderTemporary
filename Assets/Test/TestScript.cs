using UnityEngine;
using System.Collections;
using StringBufferTemporary;

public class TestScript : MonoBehaviour {

	bool sbtFlag = false;
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
		this.txt.text = Sbt.i + "sbtFlag " + sbtFlag + "\n" + "detltaTime:" + Time.deltaTime;
	}
	
	// Update is called once per frame
	void UpdateSbtOn()
	{
		// Sbt str = Sbt.i + "test";
		var str = Sbt.i + "test";
		for (int i = 0; i < 20000; ++i)
		{
			str += "a";
		}
	}
	void UpdateSbtOff()
	{
		// string str = "test";
		var str = "test";
		for (int i = 0; i < 20000; ++i)
		{
			str += "a";
		}
	}
}
