using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Snake.Models
{
    class DateStorage
    {
        private string _pathsToStorage;
        private string _leaderBoardFileName = "LeaderBoard.txt";

        public DateStorage(string pathsToStorage)
        {
            _pathsToStorage = pathsToStorage;
            if (!Directory.Exists(pathsToStorage))
            {
                Directory.CreateDirectory(pathsToStorage);
                if (!File.Exists(Path.Combine(pathsToStorage, _leaderBoardFileName)))
                {
                    File.Create(Path.Combine(pathsToStorage, _leaderBoardFileName));
                }
            }
        }
        public void Save(LeaderBoard leaderBoard)
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(_pathsToStorage, _leaderBoardFileName)))
            {
                sw.WriteLine(JsonConvert.SerializeObject(leaderBoard));
            }
        }
        public LeaderBoard Load()
        {
            LeaderBoard leaderBoard;
            using (StreamReader sr = new StreamReader(Path.Combine(_pathsToStorage, _leaderBoardFileName)))
            {
                leaderBoard = JsonConvert.DeserializeObject<LeaderBoard>(sr.ReadToEnd());
                if (leaderBoard == null)
                {
                    leaderBoard = new LeaderBoard();
                }
            }
            return leaderBoard;
        }

    }
}
