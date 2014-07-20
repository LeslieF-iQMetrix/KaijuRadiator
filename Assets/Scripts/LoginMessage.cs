using UnityEngine;
using System.Collections;

public class LoginMessage : MonoBehaviour
{
		void OnGUI ()
		{
		GUI.depth = 10;
				GUIStyle successStyle = new GUIStyle (GUI.skin.label);
				successStyle.normal.textColor = Color.green;
				successStyle.fontSize = 50;
				successStyle.fontStyle = FontStyle.Bold;
				successStyle.normal.background = MakeTex (200, 200, Color.black);
				successStyle.alignment = TextAnchor.MiddleCenter;
				GUI.Label (new Rect ((Screen.width / 2) - 200, (Screen.height / 2) - 100, 480, 240), "YOU LOGGED IN", successStyle);
		}

		private Texture2D MakeTex (int width, int height, Color col)
		{
				Color[] pix = new Color[width * height];
		
				for (int i = 0; i < pix.Length; i++)
						pix [i] = col;
		
				Texture2D result = new Texture2D (width, height);
				result.SetPixels (pix);
				result.Apply ();
		
				return result;
		}
}
