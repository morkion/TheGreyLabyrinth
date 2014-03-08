using UnityEngine;
using System.Collections;

public class Gamelog : MonoBehaviour 
{
	string[] latestLogs;

	void Start()
	{
		latestLogs  = new string[4];
	}

	void OnGUI()
	{
		GUI.BeginGroup(new Rect(10, 10, 210, 10 + latestLogs.Length * 25));

		GUI.Box(new Rect(0, 0, 210, 10 + latestLogs.Length * 25), "Log");
		for(int i = 0; i < latestLogs.Length; i++){
			GUI.Label(new Rect(0, 10 + i * 25, 200, 25), latestLogs[i]);
		}

		GUI.EndGroup();
	}

	public void AddLog(string newLog)
	{
		latestLogs[0] = latestLogs[1];
		latestLogs[1] = latestLogs[2];
		latestLogs[2] = latestLogs[3];
		latestLogs[3] = newLog;
	}
}
