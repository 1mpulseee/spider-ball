using UnityEngine;
using UnityEngine.UI;

namespace YG
{
    public class LanguageYG : MonoBehaviour
    {
        public Text textUIComponent;
        public TextMesh textMeshComponent;
        public InfoYG infoYG;
        [Space(10)]
        public string text;
        [Tooltip("RUSSIAN")]
        public string ru, en, tr, az, be, he, hy, ka, et, fr, kk, ky, lt, lv, ro, tg, tk, uk, uz, es, pt, ar, id, ja, it, de, hi;
        public int fontNumber;
        public Font uniqueFont;

        // ���������������� ������ ������, ���� �� ��������� �����-���� ������ ��������� � infoYG. � ����� �� �������, ��� ����� ������.
        // Uncomment the bottom lines if you get any errors related to infoYG. In some cases, it may help.
        //private void Start()
        //{
        //    Serialize();
        //}

        public void Serialize()
        {
            textUIComponent = GetComponent<Text>();
            textMeshComponent = GetComponent<TextMesh>();
            infoYG = GameObject.Find("YandexGame").GetComponent<YandexGame>().infoYG;
        }

        private void OnEnable()
        {
            YandexGame.SwitchLangEvent += SwitchLanguage;
            SwitchLanguage(YandexGame.savesData.language);
        }
        private void OnDisable() => YandexGame.SwitchLangEvent -= SwitchLanguage;

        public void SwitchLanguage(string lang)
        {
            for (int i = 0; i < languages.Length; i++)
            {
                if (lang == infoYG.LangName(i))
                {
                    AssignTranslate(languages[i], infoYG.LangName(i));
                    ChangeFont(infoYG.GetFont(i));
                }
            }
        }

        void AssignTranslate(string translation, string lang)
        {
            if (textUIComponent)
                textUIComponent.text = translation;
            else if (textMeshComponent)
                textMeshComponent.text = translation;
        }

        public void ChangeFont(Font[] fontArray)
        {
            Font font;

            if (fontArray.Length >= fontNumber + 1 && fontArray[fontNumber])
            {
                font = fontArray[fontNumber];
            }
            else font = null;

            if (uniqueFont)
            {
                font = uniqueFont;
            }
            else if (font == null)
            {
                if (infoYG.fonts.defaultFont.Length >= fontNumber + 1 && infoYG.fonts.defaultFont[fontNumber])
                {
                    font = infoYG.fonts.defaultFont[fontNumber];
                }
                else if (infoYG.fonts.defaultFont.Length >= 1 && infoYG.fonts.defaultFont[0])
                {
                    font = infoYG.fonts.defaultFont[0];
                }
            }

            if (font != null)
            {
                if (textUIComponent)
                    textUIComponent.font = font;
                else if (textMeshComponent)
                    textMeshComponent.font = font;
            }
        }

        public string[] languages
        {
            get
            {
                string[] s = new string[27];

                s[0] = ru;
                s[1] = en;
                s[2] = tr;
                s[3] = az;
                s[4] = be;
                s[5] = he;
                s[6] = hy;
                s[7] = ka;
                s[8] = et;
                s[9] = fr;
                s[10] = kk;
                s[11] = ky;
                s[12] = lt;
                s[13] = lv;
                s[14] = ro;
                s[15] = tg;
                s[16] = tk;
                s[17] = uk;
                s[18] = uz;
                s[19] = es;
                s[20] = pt;
                s[21] = ar;
                s[22] = id;
                s[23] = ja;
                s[24] = it;
                s[25] = de;
                s[26] = hi;

                return s;
            }
            set
            {
                ru = value[0];
                en = value[1];
                tr = value[2];
                az = value[3];
                be = value[4];
                he = value[5];
                hy = value[6];
                ka = value[7];
                et = value[8];
                fr = value[9];
                kk = value[10];
                ky = value[11];
                lt = value[12];
                lv = value[13];
                ro = value[14];
                tg = value[15];
                tk = value[16];
                uk = value[17];
                uz = value[18];
                es = value[19];
                pt = value[20];
                ar = value[21];
                id = value[22];
                ja = value[23];
                it = value[24];
                de = value[25];
                hi = value[26];
            }
        }
    }
}