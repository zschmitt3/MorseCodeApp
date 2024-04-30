using System.Reflection;
// using Android.Locations;

namespace MauiApp1.Views
{
    public partial class MainPage : ContentPage
    {
        private string _letter = "";
        private string _sentence = "";
        private bool _lastWasSpace = false;
        private Dictionary<string, string> MorseCode = new Dictionary<string, string>
        {
            {".-", "A"},
            {"-...", "B"},
            {"-.-.", "C"},
            {"-..", "D"},
            {".", "E"},
            {"..-.", "F"},
            {"--.", "G"},
            {"....", "H"},
            {"..", "I"},
            {".---", "J"},
            {"-.-", "K"},
            {".-..", "L"},
            {"--", "M"},
            {"-.", "N"},
            {"---", "O"},
            {".--.", "P"},
            {"--.-", "Q"},
            {".-.", "R"},
            {"...", "S"},
            {"-", "T"},
            {"..-", "U"},
            {"...-", "V"},
            {".--", "W"},
            {"-..-", "X"},
            {"-.--", "Y"},
            {"--..", "Z"}
            
        };

        public MainPage()
        {
            InitializeComponent();
            var version = typeof(MauiApp).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                ?.InformationalVersion;
            VersionLabel.Text = $".NET MAUI ver. {version?[..version.IndexOf('+')]}";
        }

        private void OnCounterClicked()
        {
            LetterLabel.Text = _letter;
            _lastWasSpace = false;

            SemanticScreenReader.Announce(LetterLabel.Text);
        }
        private void UpdateSentence()
        {
            SentenceLabel.Text = _sentence;

            SemanticScreenReader.Announce(SentenceLabel.Text);
        }
        private void AddDot(object sender, EventArgs e)
        {
            _letter = _letter + ".";
            OnCounterClicked();
        }
        private void AddDash(object sender, EventArgs e)
        {
            _letter = _letter + "-";
            OnCounterClicked();
        }

        private void AddSpace(object sender, EventArgs e)
        {
            if (_lastWasSpace)
            {
                _sentence = _sentence + " ";
                UpdateSentence();
                _lastWasSpace = false;
            }
            else
            {
                
                _sentence = _sentence + MorseDictionary();
                UpdateSentence();
                _letter = "";
                OnCounterClicked();
                _lastWasSpace = true;
            }
        }

        private string MorseDictionary()
        {
            if (MorseCode.ContainsKey(_letter))
            {
                MorseCode.TryGetValue(_letter, out string trueLetter);
                return trueLetter;
            }
            else
            {
                return _letter;
            }
        }
    }
}