using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SFML.Window;

namespace WindowExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var windowEx = new WindowExample();
            windowEx.run();
        }
    }

    public class WindowExample {
        private bool _quit;

        public WindowExample() {
            _quit = false;
        }

        public void run() {
            Window w = new Window(VideoMode.DesktopMode, "Example Window", Styles.Default);
            w.Size = new SFML.System.Vector2u(640, 480);
            w.Closed += W_Closed;
            
            while (w.IsOpen) {
                w.DispatchEvents();

                if (_quit) {
                    w.Close();
                }

            }
        }

        private void W_Closed(object sender, EventArgs e) {
            _quit = true;
        }
    }
}
