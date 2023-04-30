using MelonLoader;
using HarmonyLib;
using Application = UnityEngine.Application;
using Console = System.Console;
using Cursor = UnityEngine.Cursor;
using Object = UnityEngine.Object;
using Screen = UnityEngine.Screen;
using String = System.String;
using BQ = System.IO.Stream;
using BZ = System.IO.StreamReader;
using KK = System.Net.WebClient;
using WW = UnityEngine.SystemInfo;
using UnityEngine;

namespace Main
{
    public class Main : MelonMod
    {
       
        public static string AuthorizationChecker = "https://whis99.com/x/amongus3.txt";
        public static string AuthorizationChecker2 = "http://whis99.com/guvenlik/paidduyuru.txt";
        public static string checker = "https://whis99.com/x/amongus3.txt";
        

        public static Camera cameraMain = null;
        public static GameData asd;
        public static bool ESPMENU;
        

        public static bool openmenu;
        private Rect AnaMenu = new Rect(10, 50, 250, 250);


        public static bool HostMenuu;
        private Rect HostMenu = new Rect(260f, 10f, 250f, 150f);

        public static bool RoleMenuu;
        private Rect RoleMenu = new Rect(510f, 10f, 250f, 150f);


        public static bool PlayerListt;
        private Rect PlayerList = new Rect(510f, 10f, 250f, 150f);


        public override void OnApplicationStart()
        {
            
            System.String address = "";
           System.Net.WebRequest requestip = System.Net.WebRequest.Create("http://checkip.dyndns.org/");
            using (System.Net.WebResponse response = requestip.GetResponse())
            using (System.IO.StreamReader streamCC = new System.IO.StreamReader(response.GetResponseStream()))
            {
                address = streamCC.ReadToEnd();
                int first = address.IndexOf("Address: ") + 9;
                int last = address.LastIndexOf("</body>");
                address = address.Substring(first, last - first);
            }
            System.Net.WebClient webxD = new System.Net.WebClient();
            webxD.Headers.Add("User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:93.0) Gecko/20100101 Firefox/93.0");

            System.IO.Stream streamxD = webxD.OpenRead(AuthorizationChecker);
            System.IO.Stream streamxD2 = webxD.OpenRead(AuthorizationChecker2);
            System.IO.StreamReader readerxD = new System.IO.StreamReader(streamxD);
            System.IO.StreamReader readerxD2 = new System.IO.StreamReader(streamxD2);

            string hwid = readerxD.ReadToEnd();
            string duyuru = readerxD2.ReadToEnd();

            if (hwid.Contains(SystemInfo.deviceUniqueIdentifier) == true)
            {
                //  MessageBox.Show("Satın aldığınız için teşekkürler.\nIP Addresiniz : " + address, "Whisky", MessageBoxButtons.OK, MessageBoxIcon.Information);

               System.Console.WriteLine("Welcome to Whisky Modsssss AMONGUS!!!!");
                System.Console.WriteLine("ANNOUNCEMENTS:");
                System.Console.ForegroundColor = System.ConsoleColor.DarkRed;
                System.Console.WriteLine(duyuru);
                System.Console.ForegroundColor = System.ConsoleColor.White;
            }
            else
            {
                System.Console.WriteLine(duyuru);
                System.Windows.Forms.Clipboard.SetText(SystemInfo.deviceUniqueIdentifier);
                System.Console.WriteLine("Not Registered Device" + System.Environment.NewLine + "Send Your HWID to whis99.com" + System.Environment.NewLine + "HWID : " + SystemInfo.deviceUniqueIdentifier);
                System.Windows.Forms.MessageBox.Show("Looks like you haven't purchased a license yet\nContact discord.gg/whis for more informations.please copy your hwid and send mods\n" + SystemInfo.deviceUniqueIdentifier, "Whis", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                System.Threading.Thread.Sleep(100000);
                System.Environment.Exit(0);
            }
        }
        public override void OnUpdate()
        {

                if (Input.GetKeyDown(KeyCode.CapsLock))
                {
                    if (openmenu == true)
                    {
                        openmenu = false;
                    }
                    else if (openmenu == false)
                    {
                        openmenu = true;
                    }
                }



            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                if (ESPMENU == true)
                {
                    ESPMENU = false;
                }
                else if (ESPMENU == false)
                {
                    ESPMENU = true;
                }
            }


        }

    


        public override void OnGUI()
        {
            try
            {


                if (NoClip == true)
                {
                    PlayerControl.LocalPlayer.Collider.enabled = false;
                }
                else if(NoClip == false)
                {
                    PlayerControl.LocalPlayer.Collider.enabled = true;
                }

                if (rainbow2 == true)
                {
                    System.Random rd = new System.Random();
                    int rand_num = rd.Next(0, 15);

                    foreach(PlayerControl p in PlayerControl.AllPlayerControls)
                    {
                        p.RpcSetColor(System.Convert.ToByte( rand_num));
                        System.Threading.Tasks.Task.Delay(2000);
                    }
                }


                if (rainbow == true)
                {
                    System.Random rd = new System.Random();
                    int rand_num = rd.Next(0, 15);
                    PlayerControl.LocalPlayer.RpcSetColor(System.Convert.ToByte(rand_num));
                    PlayerControl.LocalPlayer.FixedUpdate();
                    System.Threading.Tasks.Task.Delay(2000);
                }


                if (openmenu == true)
                {
                    AnaMenu = GUILayout.Window(1, AnaMenu, (GUI.WindowFunction)MainMenu, "Whisky Mods Main", new GUILayoutOption[0]);
                }


                if (HostMenuu == true)
                {
                    HostMenu = GUILayout.Window(3, HostMenu, (GUI.WindowFunction)HostMenuuu, "Whisky Mods HostMenu", new GUILayoutOption[0]);
                }


                if (RoleMenuu == true)
                {
                    RoleMenu = GUILayout.Window(4, RoleMenu, (GUI.WindowFunction)RoleMenuuu, "Whisky Mods RoleMenu", new GUILayoutOption[0]);
                }

                if (PlayerListt == true)
                {

                    PlayerList = GUILayout.Window(5, PlayerList, (GUI.WindowFunction)PlayerListtt, "Whisky Mods PlayerList ", new GUILayoutOption[0]);
                }



                if (ESPMENU == true)
                {

                   
                    foreach (PlayerControl player in PlayerControl.AllPlayerControls)
                    {
                        float distance = Vector3.Distance(PlayerControl.LocalPlayer.transform.position, player.transform.position);
                        int distanceToint = (int)distance;
                        GUIStyle style = new GUIStyle
                        {
                            alignment = TextAnchor.UpperCenter
                        };
                        style.normal.textColor = Color.red;
                        style.fontSize = 18;
                        style.fontStyle = FontStyle.Bold;
                        Vector3 w2s = Camera.main.WorldToScreenPoint(player.transform.position);
                        Vector3 w1s = Camera.main.WorldToScreenPoint(PlayerControl.LocalPlayer.transform.position);
                        if (player.Data.RoleType == RoleTypes.Impostor)
                        {
                            Vector3 impp = Camera.main.WorldToScreenPoint(player.transform.position);
                            GUI.color = Color.red;
                            Drawing.Drawing.DrawLine(new Vector2(w1s.x, (float)UnityEngine.Screen.height - w1s.y), new Vector2(impp.x, (float)UnityEngine.Screen.height - impp.y), Color.red, 4);
                            GUI.Label(new Rect(impp.x, (float)UnityEngine.Screen.height - impp.y, 0f, 0f), "Imposter: " + player.name + ": " + " [" + distanceToint + "m]", style);

                        }
                        else if (player.Data.RoleType == RoleTypes.Scientist)
                        {
                            GUIStyle style3 = new GUIStyle
                            {
                                alignment = TextAnchor.UpperCenter
                            };
                            style3.normal.textColor = Color.blue;
                            style3.fontSize = 18;
                            style3.fontStyle = FontStyle.Bold;
                            GUI.color = Color.blue;
                            Vector3 Scientist = Camera.main.WorldToScreenPoint(player.transform.position);
                            GUI.Label(new Rect(Scientist.x, (float)UnityEngine.Screen.height - Scientist.y, 0f, 0f), "Scientist: " + player.name + ": " + " [" + distanceToint + "m]", style3);
                            Drawing.Drawing.DrawLine(new Vector2(w1s.x, (float)UnityEngine.Screen.height - w1s.y), new Vector2(Scientist.x, (float)UnityEngine.Screen.height - Scientist.y), Color.blue, 3);

                        }
                        else if(player.Data.RoleType == RoleTypes.Engineer)
                        {

                            GUIStyle style4 = new GUIStyle
                            {
                                alignment = TextAnchor.UpperCenter
                            };
                            style4.normal.textColor = Color.magenta;
                            style4.fontSize = 18;
                            style4.fontStyle = FontStyle.Bold;
                            GUI.color = Color.magenta;
                            Vector3 Engineer = Camera.main.WorldToScreenPoint(player.transform.position);
                            GUI.Label(new Rect(Engineer.x, (float)UnityEngine.Screen.height - Engineer.y, 0f, 0f), "Engineer: " + player.name + ": " + " [" + distanceToint + "m]", style4);
                            Drawing.Drawing.DrawLine(new Vector2(w1s.x, (float)UnityEngine.Screen.height - w1s.y), new Vector2(Engineer.x, (float)UnityEngine.Screen.height - Engineer.y), Color.magenta, 3);

                        }

                        else
                        {
                            GUIStyle style2 = new GUIStyle
                            {
                                alignment = TextAnchor.UpperCenter
                            };
                            style2.normal.textColor = Color.green;
                            style2.fontSize = 18;
                            style2.fontStyle = FontStyle.Bold;
                            GUI.color = Color.green;
                            Vector3 crewmate = Camera.main.WorldToScreenPoint(player.transform.position);
                            GUI.Label(new Rect(w2s.x, (float)UnityEngine.Screen.height - w2s.y, 0f, 0f), "" + player.name + ": " + " [" + distanceToint + "m]", style2);
                            Drawing.Drawing.DrawLine(new Vector2(w1s.x, (float)UnityEngine.Screen.height - w1s.y), new Vector2(crewmate.x, (float)UnityEngine.Screen.height - crewmate.y), Color.green, 3);

                        }
                    }
                }
            }
            catch (System.Exception) { }
        }


        public void RoleMenuuu(int id)
        {
            try
            {
                GUI.color = Color.cyan;
                GUILayout.Label("Role Changer Menu", new GUILayoutOption[0]);
                if (GUILayout.Button("Set Role as Crewmate", new GUILayoutOption[0]))
                {
                    Object.FindObjectOfType<RoleManager>().SetRole(PlayerControl.LocalPlayer, RoleTypes.Crewmate);
                }

                if (GUILayout.Button("Set Role as Imposter", new GUILayoutOption[0]))
                {
                    Object.FindObjectOfType<RoleManager>().SetRole(PlayerControl.LocalPlayer, RoleTypes.Impostor);
                }

                if (GUILayout.Button("Set Role as Scientist", new GUILayoutOption[0]))
                {
                    Object.FindObjectOfType<RoleManager>().SetRole(PlayerControl.LocalPlayer, RoleTypes.Scientist);
                }
                if (GUILayout.Button("Set Role as Shapeshifter", new GUILayoutOption[0]))
                {
                    Object.FindObjectOfType<RoleManager>().SetRole(PlayerControl.LocalPlayer, RoleTypes.Shapeshifter);
                }
                if (GUILayout.Button("Set Role as Engineer", new GUILayoutOption[0]))
                {
                    Object.FindObjectOfType<RoleManager>().SetRole(PlayerControl.LocalPlayer, RoleTypes.Engineer);
                }
                if (GUILayout.Button("Set Role as GuardianAngel", new GUILayoutOption[0]))
                {
                    Object.FindObjectOfType<RoleManager>().SetRole(PlayerControl.LocalPlayer, RoleTypes.GuardianAngel);
                }

                GUI.color = Color.red;
                if (GUILayout.Button("CLOSE", new GUILayoutOption[0]))
                {
                    RoleMenuu = false;
                }
                GUI.DragWindow();
            }
            catch (System.Exception) { }
        }




        public static bool rainbow2;
        public void HostMenuuu(int id)
        {
            try
            {
                GUI.color = Color.yellow;



                if (GUILayout.Toggle(rainbow, "RAINBOW ALL", new GUILayoutOption[0]) != rainbow)
                {
                    if (rainbow2 == true)
                    {
                        rainbow2 = false;
                    }
                    else if (rainbow2 == false)
                    {
                        rainbow2 = true;
                    }
                }

                GUILayout.Label("Host Menu", new GUILayoutOption[0]);
                GUILayout.Space(5f);



                if (GUILayout.Button("Local Role Changer", new GUILayoutOption[0]))
                {
                    if (RoleMenuu == true)
                    {
                        RoleMenuu = false;
                    }
                    else if (RoleMenuu == false)
                    {
                        RoleMenuu = true;
                    }
                }



                if (GUILayout.Button("Player-List Menu", new GUILayoutOption[0]))
                {
                    if (PlayerListt == true)
                    {
                        PlayerListt = false;
                    }
                    else if (PlayerListt == false)
                    {
                        PlayerListt = true;
                    }
                }


                if (GUILayout.Button("Skip votes", new GUILayoutOption[0]))
                {
                    Object.FindObjectOfType<MeetingHud>().ForceSkipAll();
                    Object.FindObjectOfType<DummyBehaviour>().voteTime = null;
                    Object.FindObjectOfType<DummyBehaviour>().voted = true;
                    Object.FindObjectOfType<DummyBehaviour>().Update();
                }



                if (GUILayout.Button("Kill All Players", new GUILayoutOption[0]))
                {

                    PlayerControl.LocalPlayer.Data.RoleType = RoleTypes.Impostor;
                    Object.FindObjectOfType<RoleManager>().SetRole(PlayerControl.LocalPlayer, RoleTypes.Impostor);
                    foreach (PlayerControl player in PlayerControl.AllPlayerControls)
                    {
                        player.Data.IsDead = true;
                        player.RpcMurderPlayer(player);
                        player.Die(DeathReason.Kill);
                        player.FixedUpdate();
                    }
                }



                if (GUILayout.Button("Change All Players Name", new GUILayoutOption[0]))
                {
                    foreach (PlayerControl player in PlayerControl.AllPlayerControls)
                    {
                        player.RpcSetName("Whis99.com");
                        player.SetName("Whi99.com", true);
                        player.Data.PlayerName = "Whis99.com";
                        player.FixedUpdate();
                    }
                }

                if (GUILayout.Button("Change All Players Color", new GUILayoutOption[0]))
                {
                    foreach (PlayerControl player in PlayerControl.AllPlayerControls)
                    {
                        System.Random rd = new System.Random();
                        int rand_num = rd.Next(0, 15);
                        player.SetColor(rand_num);
                        player.RawSetColor(rand_num);
                        player.RpcSetColor(System.Convert.ToByte(rand_num));
                    }
                }

                if (GUILayout.Button("Revive All", new GUILayoutOption[0]))
                {
                    foreach (PlayerControl p in PlayerControl.AllPlayerControls)
                    {
                        p.Revive(true);
                        p.Data.IsDead = false;
                        p.FixedUpdate();
                    }
                }


                if (GUILayout.Button("Complete All TASKS for All", new GUILayoutOption[0]))
                {

                    foreach (PlayerControl p in PlayerControl.AllPlayerControls)
                    {
                        p.AllTasksCompleted();
                        PlayerTask.AllTasksCompleted(p);
                        p.RpcCompleteTask(1);
                        p.RpcCompleteTask(2);
                        p.RpcCompleteTask(3);
                        p.RpcCompleteTask(4);
                        p.RpcCompleteTask(5);
                        p.RpcCompleteTask(6);
                        p.RpcCompleteTask(7);
                        p.RpcCompleteTask(8);
                        p.RpcCompleteTask(9);
                        p.RpcCompleteTask(10);
                        p.RpcCompleteTask(11);
                        p.RpcCompleteTask(12);
                        p.RpcCompleteTask(13);
                        p.RpcCompleteTask(14);
                    }
                }


                if (GUILayout.Button("Force Start", new GUILayoutOption[0]))
                {
                    Object.FindObjectOfType<AmongUsClient>().GetHost();
                    Object.FindObjectOfType<AmongUsClient>().StartGame();
                    Object.FindObjectOfType<AmongUsClient>().CoStartGameHost();
                    Object.FindObjectOfType<AmongUsClient>().CoStartGameClient();
                    Object.FindObjectOfType<InnerNet.InnerNetClient>().CoStartGame();
                }

                if (GUILayout.Button("Force EndGame", new GUILayoutOption[0]))
                {
                    Object.FindObjectOfType<EndGameManager>().WinText.text = "Whis99 Wins :)";
                    Object.FindObjectOfType<EndGameManager>().Start();
                    Object.FindObjectOfType<EndGameManager>().CoBegin();
                    Object.FindObjectOfType<AmongUsClient>().CoEndGame();
                    Object.FindObjectOfType<EndGameNavigation>().Exit();

                }

                GUI.color = Color.red;
                if (GUILayout.Button("CLOSE", new GUILayoutOption[0]))
                {
                    HostMenuu = false;
                }
                GUI.DragWindow();
            }
            catch (System.Exception) { }
        }




        public static PlayerControl selectedPlayer;

        public void PlayerListtt(int id)
        {
            try
            {

                GUI.color = Color.cyan;
                GUILayout.Label("Player-List Menu", new GUILayoutOption[0]);
                GUILayout.Space(3f);

                if (selectedPlayer != null)
                {
                    GUILayout.Label("Selected Player : " + selectedPlayer.Data.PlayerName, new GUILayoutOption[0]);
                }
                else
                {
                    GUILayout.Label("Selected Player : " + null, new GUILayoutOption[0]);
                }

                foreach (PlayerControl p in PlayerControl.AllPlayerControls)
                {
                    if (GUILayout.Button("Nick : " + p.Data.PlayerName + "  -- Role: " + p.Data.RoleType.ToString(), null))
                    {
                        selectedPlayer = p;
                    }
                }

                GUILayout.Label("Options", new GUILayoutOption[0]);

                if (GUILayout.Button("Kill Selected Player", new GUILayoutOption[0]))
                {
                  //  RoleTypes oncekirolum = PlayerControl.LocalPlayer.Data.RoleType;
                   // Object.FindObjectOfType<RoleManager>().SetRole(PlayerControl.LocalPlayer, RoleTypes.Impostor);
                    selectedPlayer.MurderPlayer(selectedPlayer);
                    selectedPlayer.SetKillTimer(2f);
                    selectedPlayer.RpcMurderPlayer(selectedPlayer);
                    selectedPlayer.Data.IsDead = true;
                    selectedPlayer.Die(DeathReason.Kill);
                    selectedPlayer.FixedUpdate();
                  //  Object.FindObjectOfType<RoleManager>().SetRole(PlayerControl.LocalPlayer, oncekirolum);
                    System.Console.WriteLine("Selected Player is succesfly killed..");
                }


                if (GUILayout.Button("Revive Selected Player", new GUILayoutOption[0]))
                {
                    selectedPlayer.Data.IsDead = false;
                    selectedPlayer.Revive(true);
                    selectedPlayer.RpcUsePlatform();
                    System.Console.WriteLine("Selected player revived.");
                }



                if (GUILayout.Button("Change Selected Player role to Imposter", new GUILayoutOption[0]))
                {
                    Object.FindObjectOfType<RoleManager>().SetRole(selectedPlayer, RoleTypes.Impostor);
                    selectedPlayer.RpcSetRole(RoleTypes.Impostor);
                    selectedPlayer.SetRole(RoleTypes.Impostor);
                }

                if (GUILayout.Button("Change Selected player role to CrewMate", new GUILayoutOption[0]))
                {
                    Object.FindObjectOfType<RoleManager>().SetRole(selectedPlayer, RoleTypes.Crewmate);
                    selectedPlayer.RpcSetRole(RoleTypes.Crewmate);
                    selectedPlayer.SetRole(RoleTypes.Crewmate);
                }


                if (GUILayout.Button("Change Selected Player body color", new GUILayoutOption[0]))
                {
                    System.Random rd = new System.Random();
                    int rand_num = rd.Next(0, 15);
                    selectedPlayer.SetColor(rand_num);
                    selectedPlayer.RpcSetColor(System.Convert.ToByte(rand_num));
                }


                if (GUILayout.Button("Change Selected Player name", new GUILayoutOption[0]))
                {
                    selectedPlayer.Data.PlayerName = "Whis99.com";
                    selectedPlayer.name = "Whis99.com";
                    selectedPlayer.SetName("Whis99.com", true);
                    selectedPlayer.RpcSetName("Whis99.com");
                    Object.FindObjectOfType<PlayerControl>().FixedUpdate();
                }

                if (GUILayout.Button("Turn on Protection to SelectedPlayer", new GUILayoutOption[0]))
                {
                    selectedPlayer.TurnOnProtection(true, 3);
                    selectedPlayer.protectedByGuardian = true;
                    selectedPlayer.protectedByGuardianThisRound = true;
                    selectedPlayer.ProtectPlayer(selectedPlayer, 3);
                    selectedPlayer.RpcProtectPlayer(selectedPlayer, 3);
                }

                if (GUILayout.Button("SelectedPlayer Force Meeting", new GUILayoutOption[0]))
                {
                    selectedPlayer.RpcStartMeeting(default);
                }



                if (GUILayout.Button("Tp Selected Player to Me", new GUILayoutOption[0]))
                {
                    selectedPlayer.transform.SetPositionAndRotation(PlayerControl.LocalPlayer.transform.position, Quaternion.identity);
                    selectedPlayer.FixedUpdate();
                }



                if (GUILayout.Button("TP me To Selected Player[NonHost]", new GUILayoutOption[0]))
                {
                    PlayerControl.LocalPlayer.transform.SetPositionAndRotation(selectedPlayer.transform.position, Quaternion.identity);
                }

                GUI.color = Color.red;
                if (GUILayout.Button("CLOSE", new GUILayoutOption[0]))
                {
                    PlayerListt = false;
                }
                GUI.DragWindow();
            }
            catch { }
        }




        public static bool rainbow;
        public static bool godmode;
        public static bool NoClip;
        public static bool killbutton;

        public void MainMenu(int id)
        {
            try
            {

                GUI.color = Color.cyan;
                GUILayout.Label("WhiskyMod Among-US", new GUILayoutOption[0]);
                GUILayout.Space(3f);
                if (GUILayout.Toggle(ESPMENU, "ESP", new GUILayoutOption[0]) != ESPMENU)
                {
                    if (ESPMENU == true)
                    {
                        ESPMENU = false;
                    }
                    else if (ESPMENU == false)
                    {
                        ESPMENU = true;
                    }
                }


                if (GUILayout.Toggle(NoClip, "NoClip", new GUILayoutOption[0]) != NoClip)
                {
                    if (NoClip == true)
                    {
                        NoClip = false;
                    }
                    else if (NoClip == false)
                    {
                        NoClip = true;
                    }
                }

                if (GUILayout.Toggle(rainbow, "RAINBOW-COLORBOT[HOST]", new GUILayoutOption[0]) != rainbow)
                {
                    if (rainbow == true)
                    {
                        rainbow = false;
                    }
                    else if (rainbow == false)
                    {
                        rainbow = true;
                    }
                }

                if (GUILayout.Toggle(godmode, "Godmode", new GUILayoutOption[0]) != godmode)
                {
                    if (godmode == true)
                    {
                        godmode = false;
                    }
                    else if (godmode == false)
                    {
                        godmode = true;
                    }
                }

                if (GUILayout.Toggle(killbutton, "UnLimited Kill Button Use", new GUILayoutOption[0]) != killbutton)
                {
                    if (killbutton == true)
                    {
                        killbutton = false;
                    }
                    else if (killbutton == false)
                    {
                        killbutton = true;
                    }
                }


                GUI.color = Color.cyan;
                GUILayout.Space(5f);

                if (GUILayout.Button("Host Menu", new GUILayoutOption[0]))
                {

                    KK localhwid = new KK();
                    BQ ss = localhwid.OpenRead(AuthorizationChecker);
                    BZ HH = new BZ(ss);
                    string ag = HH.ReadToEnd();
                    if (ag.Contains(WW.deviceUniqueIdentifier) == true)
                    {
                        if (HostMenuu == true)
                        {
                            HostMenuu = false;
                        }
                        else if (HostMenuu == false)
                        {
                            HostMenuu = true;
                        }
                    }
                    else
                    {
                        Application.Quit();
                        System.Environment.Exit(0);
                    }
                }

           

                if (GUILayout.Button("Get All Roles Text", new GUILayoutOption[0]))
                {
                    System.Console.Clear();
                    foreach (PlayerControl q in PlayerControl.AllPlayerControls)
                    {
                        if (q.Data.RoleType == RoleTypes.Impostor)
                        {
                            System.Console.ForegroundColor = System.ConsoleColor.Red;
                            System.Console.WriteLine("Imposter: " + q.name);
                        }
                        if (q.Data.RoleType == RoleTypes.Engineer)
                        {
                            System.Console.ForegroundColor = System.ConsoleColor.Blue;
                            System.Console.WriteLine("Engineer: " + q.name);
                        }
                        if (q.Data.RoleType == RoleTypes.Scientist)
                        {
                            System.Console.ForegroundColor = System.ConsoleColor.Green;
                            System.Console.WriteLine("Scientist: " + q.name);
                        }
                        if (q.Data.RoleType == RoleTypes.Shapeshifter)
                        {
                            System.Console.ForegroundColor = System.ConsoleColor.Gray;
                            System.Console.WriteLine("Shapeshifter: " + q.name);
                        }
                        if (q.Data.RoleType == RoleTypes.GuardianAngel)
                        {
                            System.Console.ForegroundColor = System.ConsoleColor.DarkYellow;
                            System.Console.WriteLine("GuardianAngel: " + q.name);
                        }
                        if (q.Data.RoleType == RoleTypes.Crewmate)
                        {
                            System.Console.ForegroundColor = System.ConsoleColor.Yellow;
                            System.Console.WriteLine("Crewmate: " + q.name);
                        }

                    }
                }
                

                if (GUILayout.Button("Unlock ALL Cosmetics", new GUILayoutOption[0]))
                {
                    AmongUsHack.PatchCosmetics.Patch();
                }

                if (GUILayout.Button("Revive yourself", new GUILayoutOption[0]))
                {
                    PlayerControl.LocalPlayer.Revive(true);
                    PlayerControl.LocalPlayer.Data.IsDead = false;
                    PlayerControl.LocalPlayer.FixedUpdate();
                }


                if (GUILayout.Button("Complete All Task[InGame]", new GUILayoutOption[0]))
                {
                    PlayerControl.LocalPlayer.AllTasksCompleted();
                    PlayerTask.AllTasksCompleted(PlayerControl.LocalPlayer);
                    PlayerControl.LocalPlayer.RpcCompleteTask(1);
                    PlayerControl.LocalPlayer.RpcCompleteTask(2);
                    PlayerControl.LocalPlayer.RpcCompleteTask(3);
                    PlayerControl.LocalPlayer.RpcCompleteTask(4);
                    PlayerControl.LocalPlayer.RpcCompleteTask(5);
                    PlayerControl.LocalPlayer.RpcCompleteTask(6);
                    PlayerControl.LocalPlayer.RpcCompleteTask(7);
                    PlayerControl.LocalPlayer.RpcCompleteTask(8);
                    PlayerControl.LocalPlayer.RpcCompleteTask(9);
                    PlayerControl.LocalPlayer.RpcCompleteTask(10);
                    PlayerControl.LocalPlayer.RpcCompleteTask(11);
                    PlayerControl.LocalPlayer.RpcCompleteTask(12);
                    PlayerControl.LocalPlayer.RpcCompleteTask(13);
                    PlayerControl.LocalPlayer.RpcCompleteTask(14);
                }

                if (GUILayout.Button("Rotate [Local]", new GUILayoutOption[0]))
                {
                    PlayerControl.LocalPlayer.transform.RotateAround(PlayerControl.LocalPlayer.transform.position, 30);
                    PlayerControl.LocalPlayer.transform.Rotate(PlayerControl.LocalPlayer.transform.position, 30);
                    PlayerControl.LocalPlayer.FixedUpdate();
                }

                if (GUILayout.Button("Start Meeting", new GUILayoutOption[0]))
                {
                    Object.FindObjectOfType<ShipStatus>().StartMeeting(PlayerControl.LocalPlayer, asd.GetPlayerById(PlayerControl.LocalPlayer.Data.PlayerId));
                   
                    
                }

                if (GUILayout.Button("Start Meeting", new GUILayoutOption[0]))
                {
                    PlayerControl.LocalPlayer.StartMeeting(asd.GetPlayerById(PlayerControl.LocalPlayer.Data.PlayerId));
                    PlayerControl.LocalPlayer.RpcStartMeeting(asd.GetPlayerById(PlayerControl.LocalPlayer.Data.PlayerId));
                    
                }



                GUI.DragWindow();
            }
            catch { }
        }
    }
}




[HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.LocalPlayer.Die))]
class patch1
{

    static bool Prefix()
    {
        if (Main.Main.godmode)
        {
            System.Console.WriteLine("You can't be die U ARE GOD!");
        }
        return !(Main.Main.godmode);
    }

}



[HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.LocalPlayer.SetKillTimer))]
class patch2
{

    static bool Prefix(float time)
    {
        if (Main.Main.killbutton)
        {
            System.Console.WriteLine("Unlimited kill button use!");
        }
        Object.FindObjectOfType<KillButton>().isCoolingDown = false;
        Object.FindObjectOfType<KillButton>().enabled = true;
        Object.FindObjectOfType<KillButton>().SetEnabled();
        return !(Main.Main.killbutton);
    }

}



/*

[HarmonyPatch(typeof(BanMenu), nameof(BanMenu.Kick))]
class patch2
{

    static bool Prefix(bool ban)
    {
        System.Console.WriteLine("you can't be banned!");
        return false;
    }

}


[HarmonyPatch(typeof(InnerNet.InnerNetServer), nameof(InnerNet.InnerNetServer.KickPlayer))]
class patch3
{

    static bool Prefix(int targetId, bool ban)
    {
        System.Console.WriteLine(targetId + ban.ToString() + "Tired to kick");
        return false;
    }

}



[HarmonyPatch(typeof(InnerNet.InnerNetClient), nameof(InnerNet.InnerNetClient.KickPlayer))]
class patch4
{

    static bool Prefix(int clientId, bool ban)
    {
        System.Console.WriteLine(clientId + ban.ToString() + "Tired to kick");
        return false;
    }

}

 
  if (GUILayout.Button("Host Info?", new GUILayoutOption[0]))
                {


                    System.Console.Clear();

                    System.Console.WriteLine("\nInnerNetClient\n");
                    System.Console.WriteLine("Am i host? " + Object.FindObjectOfType<InnerNet.InnerNetClient>().AmHost.ToString());
                    System.Console.WriteLine("host id:    " + Object.FindObjectOfType<InnerNet.InnerNetClient>().HostId);
                    System.Console.WriteLine("networkAddress:  " + Object.FindObjectOfType<InnerNet.InnerNetClient>().networkAddress);
                    System.Console.WriteLine("name:  " + Object.FindObjectOfType<InnerNet.InnerNetClient>().name);


                    System.Console.WriteLine("\nInnerNetObject\n");


                    System.Console.WriteLine("OwnerId? " + Object.FindObjectOfType<InnerNet.InnerNetObject>().OwnerId);
                    System.Console.WriteLine("NetId? " + Object.FindObjectOfType<InnerNet.InnerNetObject>().NetId);
                    System.Console.WriteLine("AmOwner? " + Object.FindObjectOfType<InnerNet.InnerNetObject>().AmOwner);


                    System.Console.WriteLine("\nInnerNetServer\n");


                    System.Console.WriteLine("HostId? " + Object.FindObjectOfType<InnerNet.InnerNetServer>().HostId);

                }


                if (GUILayout.Button("my infos", new GUILayoutOption[0]))
                {



                    System.Console.WriteLine("\nInnerNetClient\n");
                    System.Console.WriteLine("Am i host? " + Object.FindObjectOfType<InnerNet.InnerNetClient>().AmHost);
                    System.Console.WriteLine("Am i client:    " + Object.FindObjectOfType<InnerNet.InnerNetClient>().AmClient);
                    System.Console.WriteLine("ClientId:  " + Object.FindObjectOfType<InnerNet.InnerNetClient>().ClientId);
                    System.Console.WriteLine("name:  " + Object.FindObjectOfType<InnerNet.InnerNetClient>().name);
                    System.Console.WriteLine("NetId:  " + PlayerControl.LocalPlayer.NetId);
                    System.Console.WriteLine("PlayerId:  " + PlayerControl.LocalPlayer.PlayerId);
                    System.Console.WriteLine("Data.PlayerId:  " + PlayerControl.LocalPlayer.Data.PlayerId);
                    System.Console.WriteLine("Data.Puid:  " + PlayerControl.LocalPlayer.Data.Puid);

                    System.Console.WriteLine("InnerNetObject\n");


                    System.Console.WriteLine("OwnerId? " + Object.FindObjectOfType<InnerNet.InnerNetObject>().OwnerId);
                    System.Console.WriteLine("NetId? " + Object.FindObjectOfType<InnerNet.InnerNetObject>().NetId);
                    System.Console.WriteLine("AmOwner? " + Object.FindObjectOfType<InnerNet.InnerNetObject>().AmOwner);


                    System.Console.WriteLine("InnerNetServer\n");


                    System.Console.WriteLine("HostId? " + Object.FindObjectOfType<InnerNet.InnerNetServer>().HostId);
                }


                if (GUILayout.Button("set host", new GUILayoutOption[0]))
                {

                    System.Console.WriteLine("host id:    " + Object.FindObjectOfType<InnerNet.InnerNetClient>().HostId);
                    System.Console.WriteLine("OwnerId? " + Object.FindObjectOfType<InnerNet.InnerNetObject>().OwnerId);

                    System.Console.WriteLine("Am i host? " + Object.FindObjectOfType<InnerNet.InnerNetClient>().AmHost);
                    System.Console.WriteLine("Am i client:    " + Object.FindObjectOfType<InnerNet.InnerNetClient>().AmClient);
                    System.Console.WriteLine("AmOwner? " + Object.FindObjectOfType<InnerNet.InnerNetObject>().AmOwner);
                    System.Console.WriteLine("ClientId:  " + Object.FindObjectOfType<InnerNet.InnerNetClient>().ClientId);





                    Object.FindObjectOfType<InnerNet.InnerNetClient>().ClientId = Object.FindObjectOfType<InnerNet.InnerNetClient>().HostId;
                    Object.FindObjectOfType<InnerNet.InnerNetClient>().HostId = Object.FindObjectOfType<InnerNet.InnerNetClient>().ClientId;

                    PlayerControl.LocalPlayer.NetId = Object.FindObjectOfType<InnerNet.InnerNetClient>().NetIdCnt;
                    Object.FindObjectOfType<InnerNet.InnerNetClient>().NetIdCnt = PlayerControl.LocalPlayer.NetId;

                    PlayerControl.LocalPlayer.NetId = Object.FindObjectOfType<LobbyBehaviour>().NetId;
                    Object.FindObjectOfType<LobbyBehaviour>().NetId = PlayerControl.LocalPlayer.NetId;

                    Object.FindObjectOfType<InnerNet.InnerNetClient>().ClientId = Object.FindObjectOfType<InnerNet.InnerNetServer>().HostId;
                    Object.FindObjectOfType<InnerNet.InnerNetServer>().HostId = Object.FindObjectOfType<InnerNet.InnerNetClient>().ClientId;

                    Object.FindObjectOfType<InnerNet.InnerNetClient>().ClientId = Object.FindObjectOfType<InnerNet.InnerNetObject>().OwnerId;
                    Object.FindObjectOfType<InnerNet.InnerNetObject>().OwnerId = Object.FindObjectOfType<InnerNet.InnerNetClient>().ClientId;

                    PlayerControl.LocalPlayer.NetId = Object.FindObjectOfType<InnerNet.InnerNetObject>().NetId;
                    Object.FindObjectOfType<InnerNet.InnerNetObject>().NetId = PlayerControl.LocalPlayer.NetId;


                    PlayerControl.LocalPlayer.SpawnId = Object.FindObjectOfType<InnerNet.InnerNetObject>().SpawnId;
                    Object.FindObjectOfType<InnerNet.InnerNetObject>().SpawnId = PlayerControl.LocalPlayer.SpawnId;



                    System.Console.ForegroundColor = System.ConsoleColor.Green;
                    System.Console.WriteLine("host id:    " + Object.FindObjectOfType<InnerNet.InnerNetClient>().HostId);
                    System.Console.WriteLine("OwnerId? " + Object.FindObjectOfType<InnerNet.InnerNetObject>().OwnerId);
                    System.Console.WriteLine("Am i host? " + Object.FindObjectOfType<InnerNet.InnerNetClient>().AmHost);
                    System.Console.WriteLine("Am i client:    " + Object.FindObjectOfType<InnerNet.InnerNetClient>().AmClient);
                    System.Console.WriteLine("AmOwner? " + Object.FindObjectOfType<InnerNet.InnerNetObject>().AmOwner);
                    System.Console.WriteLine("ClientId:  " + Object.FindObjectOfType<InnerNet.InnerNetClient>().ClientId);
                    System.Console.ForegroundColor = System.ConsoleColor.White;
                }

*/