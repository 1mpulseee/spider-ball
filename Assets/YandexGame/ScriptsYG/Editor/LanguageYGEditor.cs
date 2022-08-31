using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEditor.SceneManagement;

namespace YG
{
    [CustomEditor(typeof(LanguageYG))]
    public class LanguageYGEditor : Editor
    {
        LanguageYG scr;

        GUIStyle red;
        GUIStyle green;

        int processTranslateLabel;

        private void OnEnable()
        {
            scr = (LanguageYG)target;
            scr.Serialize();
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            scr = (LanguageYG)target;
            Undo.RecordObject(scr, "Undo LanguageYG");

            red = new GUIStyle(EditorStyles.label);
            red.normal.textColor = Color.red;
            green = new GUIStyle(EditorStyles.label);
            green.normal.textColor = Color.green;

            if (scr.textUIComponent == null && scr.textMeshComponent == null)
            {
                if (GUILayout.Button("Identify Text/TextMesh"))
                {
                    scr.textUIComponent = scr.GetComponent<Text>();
                    scr.textMeshComponent = scr.GetComponent<TextMesh>();
                }
                if (GUILayout.Button("Create Text компонент"))
                    scr.textUIComponent = scr.gameObject.AddComponent<Text>();
                if (GUILayout.Button("Create TextMesh компонент"))
                    scr.textMeshComponent = scr.gameObject.AddComponent<TextMesh>();

                GUILayout.Space(10);
            }

            if (scr.infoYG == null)
            {
                if (GUILayout.Button("Identify infoYG", GUILayout.Height(35)))
                {
                    scr.infoYG = GameObject.Find("YandexGame").GetComponent<YandexGame>().infoYG;
                    if (scr.infoYG == null)
                        Debug.LogError("InfoYG not found!  (ru) InfoYG не найден!");
                }
            }

            if (scr.infoYG)
            {
                if (scr.infoYG.translateMethod == InfoYG.TranslateMethod.CSVFile)
                {

                    if (GUILayout.Button(">", GUILayout.Width(20)))
                    {
                        TranslationTableEditorWindow.ShowWindow();
                    }

                    bool availableStr = true;

                    
                    if (availableStr)
                    {
                        GUILayout.Label("ID Translate");
                    }
                    else
                    {
                        GUILayout.Label("ID Translate (necessarily)", red);
                    }

                    GUILayout.EndHorizontal();

                    GUILayout.BeginHorizontal();

                    if (GUILayout.Button("Import"))
                    {
                        string[] translfers = CSVManager.ImportTransfersByKey(scr);
                        if (translfers != null)
                            scr.languages = CSVManager.ImportTransfersByKey(scr);
                    }
                    if (GUILayout.Button("Export"))
                    {
                        CSVManager.SetIDLineFile(scr.infoYG, scr);
                    }

                    GUILayout.EndHorizontal();
                    GUILayout.EndVertical();

                    UpdateLanguages(true);
                }
                else
                {

                    if (scr.infoYG.translateMethod == InfoYG.TranslateMethod.AutoLocalization)
                    {

                        if (GUILayout.Button("CLEAR"))
                        {
                            scr.ru = "";
                            scr.en = "";
                            scr.tr = "";
                            scr.az = "";
                            scr.be = "";
                            scr.he = "";
                            scr.hy = "";
                            scr.ka = "";
                            scr.et = "";
                            scr.fr = "";
                            scr.kk = "";
                            scr.ky = "";
                            scr.lt = "";
                            scr.lv = "";
                            scr.ro = "";
                            scr.tg = "";
                            scr.tk = "";
                            scr.uk = "";
                            scr.uz = "";

                        }

                        GUILayout.EndHorizontal();
                        GUILayout.EndVertical();
                    }

                    GUILayout.BeginVertical("box");
                    GUILayout.BeginHorizontal();

                    bool labelProcess = false;


                    if (labelProcess == false)
                        GUILayout.Label(processTranslateLabel + " Languages", GUILayout.Height(20));

                  

                    GUILayout.EndHorizontal();

                    UpdateLanguages(false);
                    GUILayout.EndVertical();
                }
            }

            if (scr.textUIComponent || scr.textMeshComponent)
            {
                GUILayout.Space(10);
                GUILayout.BeginVertical("box");

                scr.fontNumber = EditorGUILayout.IntField("Font Number", scr.fontNumber);
                scr.uniqueFont = (Font)EditorGUILayout.ObjectField("Unique Font", scr.uniqueFont, typeof(Font), false);

                if (GUILayout.Button("Replace the font with the standard one"))
                {
                    if (scr.infoYG.fonts.defaultFont.Length >= scr.fontNumber + 1 && scr.infoYG.fonts.defaultFont[scr.fontNumber])
                    {
                        if (scr.textUIComponent)
                            scr.textUIComponent.font = scr.infoYG.fonts.defaultFont[scr.fontNumber];
                        else if (scr.textMeshComponent)
                            scr.textMeshComponent.font = scr.infoYG.fonts.defaultFont[scr.fontNumber];
                    }
                    else
                    {
                        Debug.LogError("The standard font is not specified! Specify it in the InfoYG plugin settings.  (ru) Не указан стандартный шрифт! Укажите его в настройках плагина InfoYG", scr.gameObject);
                    }
                }

                GUILayout.EndVertical();
            }

            if (GUI.changed) SetObjectDirty(scr.gameObject);
        }


        void UpdateLanguages(bool CSVFile)
        {
            processTranslateLabel = 0;
            bool[] langArr = scr.infoYG.LangArr();

            for (int i = 0; i < langArr.Length; i++)
            {
                if (langArr[i])
                {
                    processTranslateLabel++;
                    GUILayout.BeginHorizontal();
                    GUILayout.Label(new GUIContent(scr.infoYG.LangName(i), CSVManager.FullNameLanguages()[i]), GUILayout.Width(20), GUILayout.Height(20));


                    //if (CSVFile)
                    //{
                    //    if (GUILayout.Button("Imp", GUILayout.Width(35)))
                    //    {

                    //    }
                    //    if (GUILayout.Button("Exp", GUILayout.Width(35)))
                    //    {
                    //        CSVManager.SetKeyFile(scr);
                    //    }
                    //}

                    GUILayout.EndHorizontal();
                }
            }
        }

        public static void SetObjectDirty(GameObject obj)
        {
            EditorUtility.SetDirty(obj);
            EditorSceneManager.MarkSceneDirty(obj.scene);
        }
    }
}
