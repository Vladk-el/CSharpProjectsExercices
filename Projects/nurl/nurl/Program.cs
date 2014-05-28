/*
 * Created by SharpDevelop.
 * User: Vladk
 * Date: 14/05/2014
 * Time: 11:32
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Net;

namespace nurl
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			
			
			MainClass main = new MainClass();
			main.test();
			
			
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		
		public void test(){
			Console.WriteLine("Test function");
			WebClient client = new WebClient();
			// DownloadFile(String, String)
			
			DateTime before = DateTime.Now;
			string downloadString = client.DownloadString("http://www.gooogle.com");
			
			DateTime after = DateTime.Now;
			TimeSpan time = after - before;
			
			Console.WriteLine("Download duration : " + time.TotalMilliseconds + " (ms)");
			
			//client.DownloadStringCompleted += new DownloadStringCompletedEventHandler (DowloadTime);
			
			//Console.WriteLine(downloadString);
		}
		
		public void ShowTheContentOfAPage(string url){
			Console.WriteLine("ShowTheContentOfAPage of page : " + url);
			WebClient client = new WebClient();
			
			string downloadString = client.DownloadString(url);
			Console.WriteLine(downloadString);
		}
		
		public double DowloadTime(DateTime before){
			DateTime after = DateTime.Now;
			
			TimeSpan time = after - before;
			return time.TotalMilliseconds;
		}
	}
}