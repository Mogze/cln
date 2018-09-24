using UnityEngine;
using zehreken.i_cheat;
using zehreken.i_cheat.Extensions;

namespace cln.Sources.Services
{
	public class DataService : IService
	{
		public DataService()
		{
			Dbg.Log("DataService is Started".Color(Color.green));
		}
		
		public void Initialize()
		{
		}
		
		
	}
}