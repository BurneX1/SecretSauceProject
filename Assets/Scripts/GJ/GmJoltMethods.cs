using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameJolt.API;
using GameJolt.API.Core;
using GameJolt.API.Internal;
using GameJolt.API.Objects;
using GameJolt.External;
using GameJolt.UI;
using UnityEngine.Networking;
using UnityEngine.UI;
using System;
using System.Linq;

public class GmJoltMethods : MonoBehaviour
{
	// Console
	public RectTransform ConsoleTransform;
	public GameObject LinePrefab;

	// Users
	public InputField UserNameField;
	public InputField UserTokenField;
	public InputField UserIdsField;

	// Scores
	public InputField ScoreValueField;
	public InputField ScoreTextField;
	public Toggle GuestScoreToggle;
	public InputField GuestNameField;
	public InputField TableField;
	public InputField LimitField;
	public Dropdown UserScoreMode;
	public InputField CompareValue;
	public Dropdown ScoreOptions;
	public Dropdown UserScoreMode2;

	// Trophies
	public InputField TrophyIdField;
	public InputField TrophyIdsField;
	public Toggle UnlockedTrophiesOnlyToggle;

	// DataStore
	public InputField KeyField;
	public InputField ValueField;
	public Dropdown ModeField;
	public InputField PatternField;
	public Toggle GlobalToggle;


	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void SignInButtonClicked()
	{
		GameJoltUI.Instance.ShowSignIn(success => {
			GameJoltUI.Instance.QueueNotification(success ? "Bienvenido" : "Cerraste la ventana");
		});
	}

	public void SignOutButtonClicked()
	{
		if (!GameJoltAPI.Instance.HasUser)
		{
			GameJoltUI.Instance.QueueNotification("No has iniciado sesion");
		}
		else
		{
			GameJoltAPI.Instance.CurrentUser.SignOut();
			GameJoltUI.Instance.QueueNotification("Has cerrado sesion");
		}
	}

	public void IsSignedInButtonClicked()
	{
		if (GameJoltAPI.Instance.HasUser)
		{
			GameJoltUI.Instance.QueueNotification(
				"Has iniciado sesion como " + GameJoltAPI.Instance.CurrentUser.Name);
		}
		else
		{
			GameJoltUI.Instance.QueueNotification("No has iniciado sesion");
		}
	}

	public void LoadSceneButtonClicked(string sceneName)
	{
		Debug.Log("Loading Scene " + sceneName);
		UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
	}


	//Data
	public void GetDataStoreKey(string keyName, bool global)
	{
		Debug.Log("Get DataStore Key. Click to see source.");

		DataStore.Get(keyName, global, value => {
			if (value != null)
			{
				AddConsoleLine("> {0}", value);
			}
		});
	}

	public void GetDataStoreKeys()
	{
		Debug.Log("Get DataStore Keys. Click to see source.");

		DataStore.GetKeys(GlobalToggle.isOn, PatternField.text, keys => {
			if (keys != null)
			{
				foreach (var key in keys)
				{
					AddConsoleLine("> {0}", key);
				}
				AddConsoleLine("Found {0} keys.", keys.Length);
			}
			else
			{
				AddConsoleLine("No keys found.");
			}
		});
	}

	public void RemoveDataStoreKey(string keyName, bool global)
	{
		Debug.Log("Remove DataStore Key. Click to see source.");

		DataStore.Delete(keyName, global, success => {
			AddConsoleLine("Remove DataStore Key {0}.", success ? "Successful" : "Failed");
		});
	}

	public void SetDataStoreKey(string keyName, float value, bool global)
	{
		Debug.Log("Set DataStore Key. Click to see source.");
		var data = ValueField.text;

		// for testing: limit the upload size
		// if the data is larger than 50 bytes, it will be split into 5 packages
		int uploadSize = 50;
		if (data.Length > uploadSize) uploadSize = data.Length / 5 + 1;
		DataStore.SetSegmented(KeyField.text, data, GlobalToggle.isOn, success => {
			AddConsoleLine("Set DataStore Key {0}.", success ? "Successful" : "Failed");
		}, progress => AddConsoleLine("uploaded {0}% ({1}/{2} bytes)",
			progress * 100 / data.Length, progress, data.Length), uploadSize);
	}

	public void UpdateDataStoreKey()
	{
		DataStoreOperation mode;
		try
		{
			mode = (DataStoreOperation)Enum.Parse(typeof(DataStoreOperation), ModeField.captionText.text);
		}
		catch
		{
			Debug.LogWarning("Wrong Mode. Should be Add, Subtract, Multiply, Divide, Append or Prepend.");
			return;
		}

		Debug.Log("Update DataStore Key. Click to see source.");

		DataStore.Update(KeyField.text, ValueField.text, mode, GlobalToggle.isOn, value => {
			if (value != null)
			{
				AddConsoleLine("> {0}", value);
			}
		});
	}

	//Trofeos
	public void UnlockTrophy(string trophyID)
	{
		Debug.Log("Unlock Trophy. Click to see source.");

		var trophyId = trophyID != string.Empty ? int.Parse(trophyID) : 0;
		Trophies.Unlock(trophyId, success => {
			AddConsoleLine("Unlock Trophy {0}.", success ? "Successful" : "Failed");
		});
	}

	public void TryUnlockTrophy(string trophyID)
	{
		Debug.Log("Try Unlock Trophy. Click to see source.");

		var trophyId = trophyID != string.Empty ? int.Parse(trophyID) : 0;
		Trophies.TryUnlock(trophyId, success => {
			AddConsoleLine("Unlock Trophy {0}.", success);
		});
	}


	private void AddConsoleLine(string format, params object[] args)
	{
		var tr = Instantiate(LinePrefab).transform;
		tr.GetComponent<Text>().text = string.Format(format, args);
		tr.SetParent(ConsoleTransform);
		tr.SetAsFirstSibling();
	}
}
