using GooglePlayGames;
using UnityEngine;
using zehreken.i_cheat;
using zehreken.i_cheat.Extensions;

namespace cln.Sources.Services
{
    public class GpgService : IService
    {
        private const string LeaderboardId = "CgkI5cP4kesEEAIQAQ";

        public GpgService()
        {
            Dbg.Log("GPGService is Started".Color(Color.green));
            PlayGamesPlatform.Activate();
        }

        public void Initialize()
        {
            Dbg.Log("GPGService is initialized");
            Social.localUser.Authenticate(OnAuthenticate);
        }

        private void OnAuthenticate(bool success)
        {
            Dbg.Log("Successfully connected to Google Play Games: " + success);
        }

        private bool IsAuthenticated()
        {
            return Social.localUser.authenticated;
        }

        public void ShowLeaderboard()
        {
            Dbg.Log("IsAuthenticated: " + IsAuthenticated());
            if (IsAuthenticated())
            {
                Social.ShowLeaderboardUI();
            }
            else
            {
                Social.localUser.Authenticate(OnAuthenticate);
            }
        }

        public void PublishHighScore(int value)
        {
            if (IsAuthenticated())
            {
                Social.ReportScore(value, LeaderboardId, (b) => Dbg.Log("Success: " + b));
            }
        }
    }
}