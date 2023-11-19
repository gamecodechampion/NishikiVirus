using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using NAudio.Wave;

namespace NishikiVirus
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            
            string nishikiCallsYouAPussy =
                "D:\\Jetbrains Rider\\Projects\\NishikiVirus\\NishikiVirus\\y2mate.com - Ten years in the joint made you a fuckin pussy.wav";
            
            SoundPlayer nishikisMusic =
                 new SoundPlayer("D:\\Jetbrains Rider\\Projects\\NishikiVirus\\NishikiVirus\\ten years in the joint but it's an actual song (instrumental).wav");

            const string imagePath = @"D:\Downloads\image_2023-03-05_154448952.png";
            
            const string path = "D:\\asdf\\";
            const string baseFileName = "10yearsinthejointmadeyouafuckingpussy";
            int fileCount = 1500;
            string content = File.ReadAllText("D:\\Jetbrains Rider\\Projects\\NishikiVirus\\NishikiVirus\\banner.txt");
            

            
            const string message = "This program is a joke virus, and will not cause any harm to your device, do you wish to run it.";
            const string caption = "DISCLAIMER!";
            var res = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);


            if (res == DialogResult.Yes)
            {

                var gug = MessageBox.Show(@"This program will run now, have fun with it!!!!", @"Running", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                
                SetWallPaper(imagePath);
                
                PlayAudio(nishikiCallsYouAPussy);
                
                
                
               for (int i = 1; i <= fileCount; i++)
               {
                    string finalName = $"{baseFileName}_{i}.txt";
                    string finalPath = Path.Combine(path, finalName);

                    using (FileStream fs = File.Create(finalPath))
                    {
                        byte[] conBytes = System.Text.Encoding.UTF8.GetBytes(content);
                        fs.Write(conBytes, 0, conBytes.Length);
                    }
               }
               
               nishikisMusic.PlaySync();

            }
            else
            {
                MessageBox.Show(@"This program will now stop.", "",MessageBoxButtons.OK);
            }
        }
        
        static void SetWallPaper(string image)
        {
            try
            {
                RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);
                
                rk.SetValue("WallPaperStyle", "2");
                
                rk.SetValue("StretchWallpaper", 2);

                SystemParametersInfo(0x0014, 0, image, 0x01 | 0x02);
                
                rk.Close();

            }
            
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e}");
            }
        }
        
        
        static void PlayAudio(string audioPath)
        {
            WaveOutEvent waveEvent = new WaveOutEvent();
            WaveFileReader fileReader = new WaveFileReader(audioPath);
            WaveChannel32 channel = new WaveChannel32(fileReader);
            
            waveEvent.Init(channel);
            waveEvent.Play();
        }

        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        public static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
    }
}