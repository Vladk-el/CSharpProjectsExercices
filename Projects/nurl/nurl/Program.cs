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
			
			string url = "http://fake";
			
			ShowTheContentOfAWebPage(url);
			
		}
		
		public void ShowTheContentOfAWebPage(string url){ // -url "http://fake"
			//Console.WriteLine("ShowTheContentOfAPage of page : " + url);
			WebClient client = new WebClient();
			
			string downloadString = "<h1>hello</h1>";
			
			try{
				downloadString = client.DownloadString(url);
			}catch(WebException e){
				//Console.WriteLine("Erreur, return standard response");
			}
			
			Console.WriteLine(downloadString);
		}
		
		public void SaveTheContentOfAWebPage(string url){ // -url "http://fake" -save
			Console.WriteLine("SaveTheContentOfAPage of page : " + url);
		}
		
		public void ShowDowloadTimeOfAWebPage(string url){
			 // En cours
			WebClient client = new WebClient();
			
			DateTime before = DateTime.Now;
			string downloadString = client.DownloadString("http://www.gooogle.com");
			
			DateTime after = DateTime.Now;
			TimeSpan time = after - before;
			
			Console.WriteLine("Download duration : " + time.TotalMilliseconds + " (ms)");
		}
	}
}