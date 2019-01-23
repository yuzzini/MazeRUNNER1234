using UnityEngine;
using System.Collections;

public class ProceduralNumberGenerator {
    // create the same maze every time
    //public static int currentPosition = 0;
    public static int currentPosition;
	public const string key = "123424123342421432233144441212334432121223344";

	public static int GetNextNumber() {
		string currentNum = key.Substring(currentPosition++ % key.Length, 1);
        // create the same maze every time
        //return int.Parse (currentNum); 
        return Random.Range(1, 5);
	}
}
