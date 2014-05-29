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
	class Nurl
	{
		
		public Nurl(){
			
		}
		
		public Nurl(string url){
			Console.WriteLine(ShowTheContentOfAWebPage(url));
		}
		
		public Nurl(string url, string fileName){
			SaveTheContentOfAWebPage(url, fileName);
		}
		
		public Nurl(string url, int numberOfTimeToExecute, bool avg){
			if(avg){
				Console.WriteLine(ShowAverageDowloadTimeOfAWebPage(url, numberOfTimeToExecute));
			}
			else{
				Console.WriteLine(ShowDowloadTimeOfAWebPage(url, numberOfTimeToExecute));
			}
		}
		
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			
			
			Nurl main = new Nurl();
			
			//string url = "http://fake";
			
			string url = "http://dametenebra.com/";
			
			string fileName = "fake.txt";
			
			new Nurl(url);
			
			//new Nurl(url, fileName);
			
			//new Nurl(url, 5, false);
			
			//new Nurl(url, 5, true);
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}

		
		public string ShowTheContentOfAWebPage(string url){ // -url "urlOfAWebPage"
			//Console.WriteLine("ShowTheContentOfAPage of page : " + url);
			WebClient client = new WebClient();
			
			string downloadString = "<h1>hello</h1>";
			
			try{
				downloadString = client.DownloadString(url);
			}catch(WebException e){
				//Console.WriteLine("Erreur, return standard response");
			}
			
			//Console.WriteLine(downloadString);
			return downloadString;
		}
		
		public bool SaveTheContentOfAWebPage(string url, string fileName){ // -url "urlOfAWebPage" -save "fileName"
			//Console.WriteLine("SaveTheContentOfAPage of page : " + url + " in file : " + fileName);
			
			WebClient client = new WebClient();
			
			string downloadString = "<h1>hello</h1>";
			
			try{
				downloadString = client.DownloadString(url);
			}catch(WebException e){
				//Console.WriteLine("Erreur, return standard response");
			}
			try{
				TextWriter tw = new StreamWriter(fileName);
	            tw.WriteLine(downloadString);
	            tw.Close();
			}catch(Exception e){
				return false;
			} 
			
			return true;
		}
		
		
		public string ShowDowloadTimeOfAWebPage(string url, int numberOfTimeToExecute){  // -url "urlOfAWebPage" -time numberOfTimeToExecute
			
			//Console.WriteLine("ShowDowloadTimeOfAWebPage of page : " + url + " * : " + numberOfTimeToExecute);
			
			string toReturn = "";
			
			for(int i = 0; i < numberOfTimeToExecute; i++){
				toReturn += ShowDowloadTimeOfAWebPage(url) + " ";
				//Console.Write(ShowDowloadTimeOfAWebPage(url) + " ");
			}
			//Console.WriteLine();
			return toReturn;
		}
		
		public double ShowAverageDowloadTimeOfAWebPage(string url, int numberOfTimeToExecute){  // -url "urlOfAWebPage" -time numberOfTimeToExecute -avg
			
			//Console.WriteLine("ShowAverageDowloadTimeOfAWebPage of page : " + url + " * : " + numberOfTimeToExecute);
			
			string toReturn = "";
			double averageDownloadedTime = 0;
			
			for(int i = 0; i < numberOfTimeToExecute; i++){
				averageDownloadedTime += ShowDowloadTimeOfAWebPage(url);
			}
			
			//Console.WriteLine(averageDownloadedTime / numberOfTimeToExecute);
			return averageDownloadedTime / numberOfTimeToExecute;
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