using UnityEngine;
using zehreken.i_cheat;
using zehreken.i_cheat.Extensions;

namespace cln.Sources.Services
{
    public class GPGService : IService
    {
        public GPGService()
        {
        }

        public void Initialize()
        {
            Dbg.Log("GPGService is Started".Color(Color.green));
        }
    }
}