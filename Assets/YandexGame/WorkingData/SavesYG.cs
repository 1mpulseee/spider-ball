
namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        public bool isFirstSession = true;
        public string language = "ru";
        public bool feedbackDone;
        public bool promptDone;

        // Ваши сохранения
        public int money = 1;
        public string newPlayerName = "Hello!";
        public bool[] openLevels = new bool[3];

        public int lvl = 1;
        public bool[] IsOpen = new bool[8];
        public int Color = 0;
        public float Volume = .5f;
        public int Wallpaper = 0;
    }
}
