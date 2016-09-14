using UnityEngine;
using System.Collections;
using System.Threading;

using StrOpe = StringOperationUtil.OptimizedStringOperation;

public class TestScript : MonoBehaviour {

	bool strOpeFlag = true;
	TextMesh txt;
	// Use this for initialization
	void Start () {
		txt = this.GetComponent<TextMesh>();
	}

	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			strOpeFlag = !strOpeFlag;
		}
		if (strOpeFlag)
		{
			UpdateSbtOn();
		}
		else
		{
			UpdateSbtOff();
		}
		int gcUsed = (int)Profiler.GetMonoUsedSize();
		this.txt.text = (StrOpe.i + "StrOpeFlag " + strOpeFlag + "\n" + "detltaTime:" + Time.deltaTime).ToUpper();
	}
	
	// Update is called once per frame
	void UpdateSbtOn()
	{
		var str = StrOpe.i + "TestD";
		for (int i = 0; i < 20000; ++i)
		{
			str += "a";
		}
         str.ToUpper().Trim();
	}
	void UpdateSbtOff()
	{
        var str = "TestD";
		for (int i = 0; i < 20000; ++i)
		{
			str += "a";
		}
        str.ToUpper();
    }
}
