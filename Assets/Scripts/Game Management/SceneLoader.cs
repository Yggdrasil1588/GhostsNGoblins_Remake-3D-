using UnityEngine;
using System.Collections;

public class SceneLoader : MonoBehaviour {

	public string sceneToLoad;

	public void SceneLoad (){

		Application.LoadLevel(sceneToLoad);
	}
}
