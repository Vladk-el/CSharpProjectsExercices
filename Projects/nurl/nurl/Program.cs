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
using System.IO;

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
			
			//string url = "http://www.google.fr/";
			
			string fileName = "fake.txt";
			
			ShowAverageDowloadTimeOfAWebPage(url, 5);
			
		}
		
		public void ShowTheContentOfAWebPage(string url){ // -url "urlOfAWebPage"
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
		
		public void SaveTheContentOfAWebPage(string url, string fileName){ // -url "urlOfAWebPage" -save "fileName"
			//Console.WriteLine("SaveTheContentOfAPage of page : " + url + " in file : " + fileName);
			
			WebClient client = new WebClient();
			
			string downloadString = "<h1>hello</h1>";
			
			try{
				downloadString = client.DownloadString(url);
			}catch(WebException e){
				//Console.WriteLine("Erreur, return standard response");
			}
            TextWriter tw = new StreamWriter(fileName);
            tw.WriteLine(downloadString);
            tw.Close();
		}
		
		
		public void ShowDowloadTimeOfAWebPage(string url, int numberOfTimeToExecute){  // -url "urlOfAWebPage" -time numberOfTimeToExecute
			
			Console.WriteLine("ShowDowloadTimeOfAWebPage of page : " + url + " * : " + numberOfTimeToExecute);
			
			for(int i = 0; i < numberOfTimeToExecute; i++){
				Console.Write(ShowDowloadTimeOfAWebPage(url) + " ");
			}
			Console.WriteLine();
		}
		
		public void ShowAverageDowloadTimeOfAWebPage(string url, int numberOfTimeToExecute){  // -url "urlOfAWebPage" -time numberOfTimeToExecute -avg
			
			Console.WriteLine("ShowAverageDowloadTimeOfAWebPage of page : " + url + " * : " + numberOfTimeToExecute);
			
			double averageDownloadedTime = 0;
			
			for(int i = 0; i < numberOfTimeToExecute; i++){
				averageDownloadedTime += ShowDowloadTimeOfAWebPage(url);
			}
			
			Console.WriteLine(averageDownloadedTime / numberOfTimeToExecute);
		}
		
		public double ShowDowloadTimeOfAWebPage(string url){  // -url "urlOfAWebPage"
			WebClient client = new WebClient();
			
			try{
				DateTime before = DateTime.Now;
				client.DownloadString(url);
				DateTime after = DateTime.Now;
				TimeSpan time = after - before;
				return time.TotalMilliseconds;
			}catch(WebException e){
				return 0;
			}
		}
		
		
		
	}
}