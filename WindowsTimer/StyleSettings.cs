using System.Windows.Media;

namespace WindowsTimer
{
    public class StyleSettings
    {
        
        public Color Background
        {
            get => background;
            set
            {
                if (this.background != value)
                {
                    this.background = value;
                    if (StyleChanging != null)
                        StyleChanging();
                }
            }
        }

        public Color Foreground
        {
            get => foreground;
            set
            {
                if (this.foreground != value)
                {
                    this.foreground = value;
                    if (StyleChanging != null)
                        StyleChanging();
                }
            }
        }

        public int Size
        {
            get => size;
            set
            {
                if (this.size != value)
                {
                    this.size = value;
                    if(StyleChanging!=null)
                        StyleChanging();
                }
            }
        }

        public WindowStyleView Style
        {
            get => _style;
            set
            {
                if (this._style != value)
                {
                    this._style = value;
                    if (StyleChanging != null)
                        StyleChanging();
                }
            }
        }

        public Mode Behaviour
        {
            get => behaviour;
            set
            {
                if (this.behaviour != value)
                {
                    this.behaviour = value;
                    if (ActionChanging != null)
                        ActionChanging();
                }
            }
        }

        public static StyleSettings Instance
        {
            get
            {
                if (instance == null)
                    instance = new StyleSettings();
                return instance;
            }
        }

        
        //private
        private Color background;
        private Color foreground;
        private int size;
        private WindowStyleView _style;
        private Mode behaviour;
        private static StyleSettings instance;
        

        public StyleSettings(Color back= new Color(), Color fore = new Color(), int size = 60, int style = 0, int behaviour= 1)
        {
            instance = this;
            Background = back;
            Foreground = fore;
            Size = size;
            Behaviour =(Mode)behaviour;
            Style = (WindowStyleView)style;
            if (Background == new Color())
                Background = Colors.Black;
            if (Foreground == new Color())
                Foreground = Colors.White;
        }

        public delegate void CurrentChanging();

        public event CurrentChanging StyleChanging;
        public event CurrentChanging ActionChanging;

       
    }
    public enum WindowStyleView
        {
            Circle,
            Quad
        }
        public enum Mode
        {
            Sleep,
            Shutdown,
            Hibernate,
            Reboot
        }
}
