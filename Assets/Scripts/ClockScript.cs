using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class ClockScript : MonoBehaviour
{

	public class Clock
	{
		private Stopwatch stopwatch;
		private int second;
		private int minute;
		private int hour;
		private int day;
		private int year;
		private float minutesPerDay; //Realtime minutes per game-day (1440 would be realtime)

		public Clock(float minPerDay)
		{
			second = 0;
			minute = 0;
			hour = 0;
			day = 0;
			year = 0;
			minutesPerDay = minPerDay;
			stopwatch = new Stopwatch();
			stopwatch.Start();
			UnityEngine.Debug.Log("Started");
		}

		public int[] GetTime()
		{
			float timeScale = 1440 / minutesPerDay;
			System.TimeSpan ts = stopwatch.Elapsed;
			second = (int)Mathf.Floor(ts.Seconds * timeScale);
			if (second > 60) {
				minute += second / 60;
				second = 0;
				stopwatch.Stop ();
				stopwatch.Reset ();
				stopwatch.Start ();
			}
			if (minute > 60) {
				hour+= minute/60;
				minute = 0;
			}
			if (hour > 24) {
				day+= hour/24;
				hour = 0;
			}
			if (day > 365) {
				year+= day/365;
				day = 0;
			}
			return new int[]{second,minute,hour,day,year};
		}
	}


}