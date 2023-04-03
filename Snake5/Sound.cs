//using NAudio.Wave;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Snake5
//{
//    class Sound
//    {
//        // представляет устройство вывода звука
//        private WaveOutEvent outputDevice;
//        private AudioFileReader audioFile;

//        // метод конструктора, который принимает строковый параметр fileName, представляющий путь к аудиофайлу
//        public Sound(string fileName)
//        {
//            //инициализируется в конструкторе и используется для чтения аудиоданных из файла.
//            audioFile = new AudioFileReader(fileName);
//            outputDevice = new WaveOutEvent();
//            outputDevice.Init(audioFile);
//        }
//        //  этот метод воспроизводит аудиофайл
//        public void Play()
//        {
//            outputDevice.Play();
//        }
//        //этот метод останавливает аудиофайл

//        public void Stop()
//        {
//            outputDevice.Stop();
//            audioFile.Position = 0;
//        }
//        // указывает, воспроизводится ли звук в данный момент.если свойство PlaybackState
//        // объекта outputDevice равно PlayBackState.Playing, то метод IsPlaying () возвращает значение true
//        public bool IsPlaying()
//        {
//            return outputDevice.PlaybackState == PlaybackState.Playing;
//        }
//    }
//}
