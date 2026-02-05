using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Handy.Lib
{
    /// <summary>
    /// Provides methods for playing various beeps
    /// </summary>
    public class Audio
    {
        private static Controller AudioController = null;
        private static TerminalInfo terminalInfo;

        private static void Initialize()
        {
            AudioController = new Controller();
            terminalInfo = new TerminalInfo();
        }

        public static void PlayErrorBeep()
        {
            Initialize();
            if (AudioController == null)
                return;  // There is no audio controller

            byte Duration = 200/10; //millisec nilo modified from 400
            byte Frequency = 2670/100; //hz

            AudioController.PlayAudio(Duration, Frequency);//play Default beep
            Thread.Sleep(300);
            AudioController.PlayAudio(Duration, Frequency);//play Default beep
            AudioController.Dispose();
        }

        public static void PlayOKBeep()
        {
            Initialize();
            if (AudioController == null)
                return;  // There is no audio controller

            byte Duration = 400/10;//millisec nilo modified from 800
            byte Frequency = 2670/100;//hz

            AudioController.PlayAudio(Duration, Frequency);//play Default beep
            AudioController.Dispose();
        }           

    }

    /// <summary>
    /// Controller class for Keyence
    /// </summary>
    public class Controller
    {
        public void PlayAudio(byte duration, byte frequency)
        {
            Bt.LibDef.BT_BUZZER_PARAM param = new Bt.LibDef.BT_BUZZER_PARAM();
            param.bTone = frequency;
            param.bVolume = 1;
            param.dwCount = duration;
            param.dwOff = 0;
            param.dwOn = 1;
            
            Bt.SysLib.Device.btBuzzer(duration, param); 
        }

        public void Dispose()
        {
        }
    }

    public class TerminalInfo
    {
    }
}
