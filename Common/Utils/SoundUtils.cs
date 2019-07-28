using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Media;
using System.Net;
using Common.enums;
using SpeechLib;

namespace Common.Utils
{
    public class SoundUtils
    {

        /// <summary>
        /// 新消息来临
        /// </summary>
        /// <returns></returns>
        public static void NewestInfoCome()
        {
            string filePath = ToolUtils.substringFromLast(Application.StartupPath, @"\", 3, @"\FrmClient\Audio\msg.wav");
            SoundPlayer player = new SoundPlayer(filePath);
            player.Play();//这个方法只播放一遍
            //player.PlayLooping();//这个方法循环播放
            player.Dispose();
            player = null;
        }

        /// <summary>
        /// 系统声音
        /// </summary>
        /// <returns></returns>
        public static void SystemSound()
        {
            string filePath = ToolUtils.substringFromLast(Application.StartupPath, @"\", 3, @"\FrmClient\Audio\system.wav");
            SoundPlayer player = new SoundPlayer(filePath);
            player.Play();//这个方法只播放一遍
            //player.PlayLooping();//这个方法循环播放
            player.Dispose();
            player = null;
        }

        /// <summary>
        /// 播放制定语音
        /// </summary>
        /// <param name="msg"></param>
        public static void playSound(string msg, EndPointEnum playSource = EndPointEnum.无)
        {
            SpeechVoiceSpeakFlags flag = SpeechVoiceSpeakFlags.SVSFDefault;
            SpVoice voice  = new SpVoice();
            voice.Voice = voice.GetVoices().Item(0);
            if (playSource != EndPointEnum.无)
            {
                voice.Speak(playSource + "提示您", flag);
            }
            voice.Speak(msg, flag);
        }
    }
}