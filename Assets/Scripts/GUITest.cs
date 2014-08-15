using UnityEngine;
using System.Collections;
using System;
using System.Text;
using System.Collections.Generic;

public class GUITest : MonoBehaviour
{

		private string username = "Username";
		private string password = "Password";

		void OnGUI ()
		{
		Configuration.Initialize ();
				GUI.depth = 20;
				GUIStyle bigFontStyleTextField = new GUIStyle (GUI.skin.textField);
				GUIStyle bigFontStyleBox = new GUIStyle (GUI.skin.box);
				bigFontStyleTextField.fontSize = 24;
				bigFontStyleBox.fontSize = 30;
				// Make a background box
				GUI.Box (new Rect ((Screen.width / 2) - 240, (Screen.height / 2) - 120, 480, 240), "TeamCity Login", bigFontStyleBox);

				GUI.SetNextControlName ("Username");
				username = GUI.TextField (new Rect ((Screen.width / 2) - 220, (Screen.height / 2) - 60, 400, 40), username, bigFontStyleTextField);
				GUI.SetNextControlName ("Password");
				password = GUI.PasswordField (new Rect ((Screen.width / 2) - 220, (Screen.height / 2), 400, 40), password, '*', bigFontStyleTextField);
				if (GUI.Button (new Rect ((Screen.width / 2) + 100, (Screen.height / 2) + 60, 120, 40), "LOGIN")) {
						//StartCoroutine (Configuration.Login());
				}

                username = Configuration.Settings [Configuration.USERNAME_FIELD];
                password = Configuration.Settings [Configuration.PASSWORD_FIELD];

				// The textfields getting focus makes textfields blank if still at default value
				if (Event.current.type == EventType.Repaint) {
						if (GUI.GetNameOfFocusedControl () == "Username") {
								if (username.Equals ("Username"))
										username = "";
						} else {
								if (username.Equals (""))
										username = "Username";
						}

						if (GUI.GetNameOfFocusedControl () == "Password") {
								if (password.Equals ("Password"))
										password = "";
						} else {
								if (password.Equals (""))
										password = "Password";
						}
				}
		}
}