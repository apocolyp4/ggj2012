using UnityEngine;
using System.Collections;

public class GuiScript : MonoBehaviour {

    //public Texture _GuiTexture;
    public Texture GaugeTexture;
    public Texture ArrowTexture;

    public Texture ContinueButton;
    public Texture ContinueButtonGlow;

    public Texture QuitButton;
    public Texture QuitButtonGlow;

    public Texture BlackTexture;

    float alphaFadeValue = 0;

   // private Texture _ArrowPlaceholderMod;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        //_ArrowPlaceholderMod = (Texture)Texture.Instantiate(Resources.Load("arrowPlaceholder"), new Vector3(), new Quaternion());
	}

    void OnGUI() {

        if (Globals.PlayerLife > 110)
        {

            alphaFadeValue += Mathf.Clamp01(Time.deltaTime / 5);
            GUI.color = new Color(alphaFadeValue, alphaFadeValue, alphaFadeValue, alphaFadeValue);
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), BlackTexture);

            var myStyle = new GUIStyle();
            myStyle.fontSize = 50;
            myStyle.normal.textColor = Color.white;
            myStyle.alignment = TextAnchor.MiddleCenter;



            GUI.Label(new Rect(10, Screen.height / 2 - 30, Screen.width - 20, 60), "You broke the cycle", myStyle);

            myStyle.fontSize = 20;

            GUI.Label(new Rect(10, Screen.height / 2 + 30, Screen.width - 20, 60), "(And lost the game...)", myStyle);

        }

        if (Globals.GamePaused)
        {


            //draw menu stuff

            //continue button
            //if (GUI.Button(new Rect(Screen.width / 2 - 40, 150, 80, 20), "Continue"))
            //{
            //    Globals.ContinueCurrentGame();
            //}


            ////quit button
            //if (GUI.Button(new Rect(Screen.width / 2 - 40, 180, 80, 20), "Quit"))
            //{
            //    Globals.QuitCurrentGame();
            //}

           


            GUIStyle style = new GUIStyle(); //a blank style to remove default button borders

            GUI.backgroundColor = Color.black;

            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
            // GUI.backgroundColor = bgcolor;


            //cogs
            //GUI.DrawTexture(new Rect(Screen.width / 2 - 230, Screen.height / 2 - 215, 255, 382), Cogs);


            //continue button
            Rect ContinueButtonRect = new Rect(Screen.width / 2 - 106, Screen.height / 2 - 95, 212, 50);


            Texture startTexture;
            if (ContinueButtonRect.Contains(Event.current.mousePosition))
            {
                // Debug.Log("I see you");
                startTexture = ContinueButtonGlow;
            }
            else
            {
                startTexture = ContinueButton;
            }

            if (GUI.Button(ContinueButtonRect, startTexture, style))
            {
                Globals.ContinueCurrentGame();
            }


            //quit game button


            Rect QuitButtonRect = new Rect(Screen.width / 2 - 106, Screen.height / 2 + 25, 212, 50);


            Texture quitTexture;
            if (QuitButtonRect.Contains(Event.current.mousePosition))
            {
                // Debug.Log("I see you");
                quitTexture = QuitButtonGlow;
            }
            else
            {
                quitTexture = QuitButton;
            }

            if (GUI.Button(QuitButtonRect, quitTexture, style))
            {
                Globals.QuitCurrentGame();
            }





        }
        else
        {

            //draw game stuff


            GUI.Label(new Rect(10, 10, 300, 200), Globals.PlayerLife.ToString());

            GUI.DrawTexture(new Rect((Screen.width / 2) - 77, Screen.height - 105, 154, 85), GaugeTexture);

            Matrix4x4 matrixBackup = GUI.matrix;

            int iAngle = -90;

            if (Globals.PlayerLife < 40)
            {
                iAngle += Globals.PlayerLife;
            }

            GUIUtility.RotateAroundPivot(iAngle, new Vector2((Screen.width / 2) - 67 + 35, Screen.height - 140 + 73));

            GUI.DrawTexture(new Rect((Screen.width / 2) - 67, Screen.height - 140 + 71, 70, 5), ArrowTexture);

            GUI.matrix = matrixBackup;
            //' GUI.DrawTexture(new Rect(Screen.width - 120, Screen.height - 120, 100, 100), );
        }
    }
}
